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
                    return ParsingServices.GetEmptyQueryResult(query);
                }

                throw;
            }

            return ParsingServices.ParseQueryResult(doc.DocumentElement, query, metaModel);
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

                var asset = ParsingServices.ParseAssetNode(doc.DocumentElement, metaModel);

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

                    ParsingServices.ParseSaveAssetNode(doc.DocumentElement, asset, metaModel);
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

                return ParsingServices.ParseNewAssetNode(doc.DocumentElement, assetType);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to get new asset!", assetType.Token, ex);
            }
        }
    }
}