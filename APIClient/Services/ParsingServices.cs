using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
    internal static class ParsingServices
    {
        internal static QueryResult ParseQueryResult(XmlElement element, Query query, IMetaModel metaModel)
        {
            switch (element.LocalName)
            {
                case "History":
                    return ParseHistoryQueryResult(element, query, metaModel);
                case "Assets":
                    return ParseAssetListQueryResult(element, query, metaModel);
                case "Asset":
                    return ParseAssetQueryResult(element, query, metaModel);
                case "Attribute":
                    return ParseAttributeQueryResult(element, query, metaModel);
                case "Relation":
                    return ParseAttributeQueryResult(element, query, metaModel);
                default:
                    return GetEmptyQueryResult(query);
            }
        }

        internal static QueryResult GetEmptyQueryResult(Query query)
        {
            return new QueryResult(new AssetList(), 0, query);
        }

        internal static QueryResult ParseHistoryQueryResult(XmlElement element, Query query, IMetaModel metaModel)
        {
            if (!element.HasChildNodes)
            {
                return new QueryResult(new AssetList(), 0, query);
            }

            if (element.FirstChild.Name == "Asset")
            {
                return ParseAssetListQueryResult(element, query, metaModel);
            }

            throw new NotImplementedException();
        }

        internal static QueryResult ParseAssetListQueryResult(XmlElement element, Query query, IMetaModel metaModel)
        {
            var list = new AssetList();
            var total = int.Parse(element.GetAttribute("total"));

            var assetnodes = element.SelectNodes("Asset");

            list.AddRange(from XmlElement assetnode in assetnodes select ParseAssetNode(assetnode, metaModel));

            if (query.ParentRelation != null)
            {
                list = TreeAssetListByAttribute(list, query.ParentRelation);
            }

            return new QueryResult(list, total, query);
        }

        internal static AssetList TreeAssetListByAttribute(IEnumerable<Asset> input, IAttributeDefinition def)
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

        internal static QueryResult ParseAssetQueryResult(XmlElement element, Query query, IMetaModel metaModel)
        {
            var list = new AssetList();
            list.Add(ParseAssetNode(element, metaModel));
            return new QueryResult(list, 1, query);
        }

        internal static QueryResult ParseAttributeQueryResult(XmlElement element, Query query, IMetaModel metaModel)
        {
            var list = new AssetList();

            var asset = new Asset(query.Oid);
            list.Add(asset);

            var attribdef = metaModel.GetAttributeDefinition(query.AssetType.Token + "." + element.GetAttribute("name"));

            ParseAttributeNode(asset, attribdef, element);

            return new QueryResult(list, 1, query);
        }

        internal static Asset ParseAssetNode(XmlElement element, IMetaModel metaModel)
        {
            var asset = new Asset(Oid.FromToken(element.GetAttribute("id"), metaModel));

            foreach (XmlElement child in element.ChildNodes)
            {
                ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
            }

            return asset;
        }

        internal static Asset ParseNewAssetNode(XmlNode element, IAssetType assetType)
        {
            var asset = new Asset(assetType);

            foreach (XmlElement child in element.ChildNodes)
            {
                ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
            }

            return asset;
        }

        internal static void ParseSaveAssetNode(XmlElement element, Asset asset, IMetaModel metaModel)
        {
            asset.Oid = Oid.FromToken(element.GetAttribute("id"), metaModel);
            asset.AcceptChanges();
        }

        internal static void ParseAttributeNode(Asset asset, IAttributeDefinition attribdef, XmlElement element)
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