using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
    public class Services : IServices
    {
        private readonly IMetaModel metaModel;
        private readonly IAPIConnector connector;
        private Oid loggedIn;

        public Oid LoggedIn
        {
            get
            {
                if (loggedIn == null)
                {
                    var q = new Query(metaModel.GetAssetType("Member"));
                    var term = new FilterTerm(metaModel.GetAttributeDefinition("Member.IsSelf"));
                    term.Equal(true);
                    q.Filter = term;
                    var list = Retrieve(q).Assets;

                    if (list.Count != 1)
                    {
                        loggedIn = Oid.Null;
                    }
                    else
                    {
                        loggedIn = list[0].Oid;
                    }
                }

                return loggedIn;
            }
        }

        public Services(IMetaModel metaModel, IAPIConnector connector)
        {
            this.metaModel = metaModel;
            this.connector = connector;
        }

        public void SetUpstreamUserAgent(string userAgent)
        {
            connector.SetUpstreamUserAgent(userAgent);
        }

        public QueryResult Retrieve(Query query)
        {
            var doc = new XmlDocument();

            try
            {
                using (var stream = connector.GetData(new QueryURLBuilder(query).ToString()))
                {
                    doc.Load(stream);
                }
            }
            catch (WebException ex)
            {
                //if we get a 404, return an empty query result otherwise throw the exception
                if (ex.Response is HttpWebResponse && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return GetEmptyQueryResult(query);
                }

                throw;
            }

            return ParseQueryResult(doc.DocumentElement, query);
        }

        public Oid GetOid(string token)
        {
            return Oid.FromToken(token, metaModel);
        }

        public Oid ExecuteOperation(IOperation op, Oid oid)
        {
            var doc = new XmlDocument();

            try
            {
                var path = "Data/" + oid.AssetType.Token + "/" + oid.Key + "?op=" + op.Name;

                using (var stream = connector.SendData(path, string.Empty))
                {
                    doc.Load(stream);
                }

                var asset = ParseAssetNode(doc.DocumentElement);

                return asset.Oid;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                {
                    doc.Load(stream);
                }

                var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
                throw new APIException(message, oid.Token, ex);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to execute", oid.Token, ex);
            }
        }

        public void Save(Asset asset)
        {
            Save(asset, string.Empty);
        }

        public void Save(Asset asset, string comment)
        {
            if (asset.HasChanged || asset.Oid.IsNull)
            {
                var doc = new XmlDocument();

                var s = new StringWriter();
                var writer = new XmlApiWriter(s, true);
                writer.WriteAsset(asset);
                var data = s.ToString();

                var path = "Data/" + asset.AssetType.Token;

                if (!asset.Oid.IsNull)
                {
                    path += "/" + asset.Oid.Key;
                }

                if (comment != null & comment != string.Empty)
                {
                    path += string.Format("?Comment='{0}'", System.Web.HttpUtility.UrlEncode(comment));
                }

                try
                {
                    using (var stream = connector.SendData(path, data))
                    {
                        doc.Load(stream);
                    }

                    ParseSaveAssetNode(doc.DocumentElement, asset);
                }
                catch (WebException ex)
                {
                    if (ex.Response == null)
                    {
                        throw new ConnectionException("Error writing to output stream", ex);
                    }

                    using (var stream = ex.Response.GetResponseStream())
                    {
                        doc.Load(stream);
                    }

                    var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
                    throw new APIException(message, asset.Oid.Token, ex);
                }
                catch (Exception ex)
                {
                    throw new APIException("Failed to save", asset.Oid.Token, ex);
                }
            }
        }

        public void Save(AssetList assetList)
        {
            foreach (var asset in assetList)
            {
                Save(asset);
            }
        }

        public Asset New(IAssetType assetType, Oid context)
        {
            var doc = new XmlDocument();

            var path = "New/" + assetType.Token;

            if (context != null && !context.IsNull)
            {
                path += "?ctx=" + context.Token;
            }

            try
            {
                using (var stream = connector.GetData(path))
                {
                    doc.Load(stream);
                }

                return ParseNewAssetNode(doc.DocumentElement, assetType);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to get new asset!", assetType.Token, ex);
            }
        }

        private QueryResult ParseQueryResult(XmlElement element, Query query)
        {
            switch (element.LocalName)
            {
                case "History":
                    return ParseHistoryQueryResult(element, query);
                case "Assets":
                    return ParseAssetListQueryResult(element, query);
                case "Asset":
                    return ParseAssetQueryResult(element, query);
                case "Attribute":
                    return ParseAttributeQueryResult(element, query);
                case "Relation":
                    return ParseAttributeQueryResult(element, query);
                default:
                    return GetEmptyQueryResult(query);
            }
        }

        private static QueryResult GetEmptyQueryResult(Query query)
        {
            return new QueryResult(new AssetList(), 0, query);
        }

        private QueryResult ParseHistoryQueryResult(XmlElement element, Query query)
        {
            if (!element.HasChildNodes)
            {
                return new QueryResult(new AssetList(), 0, query);
            }

            if (element.FirstChild.Name == "Asset")
            {
                return ParseAssetListQueryResult(element, query);
            }

            throw new NotImplementedException();
        }

        private QueryResult ParseAssetListQueryResult(XmlElement element, Query query)
        {
            var list = new AssetList();
            var total = int.Parse(element.GetAttribute("total"));

            var assetnodes = element.SelectNodes("Asset");

            list.AddRange(from XmlElement assetnode in assetnodes select ParseAssetNode(assetnode));

            if (query.ParentRelation != null)
            {
                list = TreeAssetListByAttribute(list, query.ParentRelation);
            }

            return new QueryResult(list, total, query);
        }

        private static AssetList TreeAssetListByAttribute(IEnumerable<Asset> input, IAttributeDefinition def)
        {
            var h = new Hashtable();

            foreach (var asset in input)
            {
                h.Add(asset.Oid.Token, asset);
            }

            var r = new AssetList();

            foreach (var asset in input)
            {
                var parent = (Asset)h[((Oid)asset.GetAttribute(def).Value).Token];
                var t = parent != null ? parent.Children : r;
                t.Add(asset);
            }

            return r;
        }

        private QueryResult ParseAssetQueryResult(XmlElement element, Query query)
        {
            var list = new AssetList();
            list.Add(ParseAssetNode(element));
            return new QueryResult(list, 1, query);
        }

        private QueryResult ParseAttributeQueryResult(XmlElement element, Query query)
        {
            var list = new AssetList();

            var asset = new Asset(query.Oid);
            list.Add(asset);

            var attribdef = metaModel.GetAttributeDefinition(query.AssetType.Token + "." + element.GetAttribute("name"));

            ParseAttributeNode(asset, attribdef, element);

            return new QueryResult(list, 1, query);
        }

        private Asset ParseAssetNode(XmlElement element)
        {
            var asset = new Asset(GetOid(element.GetAttribute("id")));

            foreach (XmlElement child in element.ChildNodes)
            {
                ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
            }

            return asset;
        }

        private static Asset ParseNewAssetNode(XmlNode element, IAssetType assetType)
        {
            var asset = new Asset(assetType);

            foreach (XmlElement child in element.ChildNodes)
            {
                ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
            }

            return asset;
        }

        private void ParseSaveAssetNode(XmlElement element, Asset asset)
        {
            asset.Oid = GetOid(element.GetAttribute("id"));
            asset.AcceptChanges();
        }

        private static void ParseAttributeNode(Asset asset, IAttributeDefinition attribdef, XmlElement element)
        {
            var type = element.LocalName;

            asset.EnsureAttribute(attribdef);

            if (type == "Relation")
            {
                if (attribdef.IsMultiValue)
                {
                    foreach (XmlElement child in element.ChildNodes)
                    {
                        var add = child.HasAttribute("act") && child.GetAttribute("act") == "add";

                        var token = child.GetAttribute("idref");

                        if (add)
                        {
                            asset.AddAttributeValue(attribdef, token);
                        }
                        else
                        {
                            asset.LoadAttributeValue(attribdef, token);
                        }
                    }
                }
                else
                {
                    var token = Oid.Null.Token;

                    if (element.HasChildNodes)
                    {
                        token = ((XmlElement)element.ChildNodes.Item(0)).GetAttribute("idref");
                    }

                    var force = element.HasAttribute("act") && element.GetAttribute("act") == "set";

                    if (force)
                    {
                        asset.ForceAttributeValue(attribdef, token);
                    }
                    else
                    {
                        asset.LoadAttributeValue(attribdef, token);
                    }
                }
            }
            else
            {
                if (attribdef.IsMultiValue)
                {
                    foreach (XmlElement child in element.ChildNodes)
                    {
                        var add = child.HasAttribute("act") && child.GetAttribute("act") == "add";

                        if (add)
                        {
                            asset.AddAttributeValue(attribdef, child.InnerText);
                        }
                        else
                        {
                            asset.LoadAttributeValue(attribdef, child.InnerText);
                        }
                    }
                }
                else
                {
                    object v = null;

                    if (!string.IsNullOrEmpty(element.InnerText))
                    {
                        v = element.InnerText;
                    }

                    var force = element.HasAttribute("act") && element.GetAttribute("act") == "set";

                    if (force)
                    {
                        asset.ForceAttributeValue(attribdef, v);
                    }
                    else
                    {
                        asset.LoadAttributeValue(attribdef, v);
                    }
                }
            }
        }
    }
}
