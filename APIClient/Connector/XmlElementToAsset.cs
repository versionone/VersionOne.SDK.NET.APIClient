using System.Xml;
using VersionOne.SDK.APIClient.Model;
using VersionOne.SDK.APIClient.Model.Asset;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Connector
{
    public class XmlElementToAsset
    {
        public static Asset ParseNewAssetNode(XmlNode element, IAssetType assetType)
        {
            var asset = new Asset(assetType);

            foreach (XmlElement child in element.ChildNodes)
            {
                ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
            }

            return asset;
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
