using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using Attribute = VersionOne.SDK.APIClient;

namespace VersionOne.SDK.APIClient
{
    internal class XmlApiWriter
    {
        private readonly bool changesOnly;
        private readonly XmlTextWriter writer;

        public XmlApiWriter(TextWriter response) : this(response, false) { }

        public XmlApiWriter(TextWriter response, bool changesOnly)
        {
            writer = new XmlTextWriter(response);
            this.changesOnly = changesOnly;
#if DEBUG
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
#endif
        }

        public void WriteAssetList(AssetList assets, int total, int pagesize, int pagestart)
        {
            writer.WriteStartElement("Assets");

            if (total > -1)
            {
                writer.WriteAttributeString("total", total.ToString());
            }

            if (pagesize > -1)
            {
                writer.WriteAttributeString("pageSize", pagesize.ToString());
            }

            if (pagestart > -1)
            {
                writer.WriteAttributeString("pageStart", pagestart.ToString());
            }

            foreach (var asset in assets)
            {
                WriteAsset(asset);
            }

            writer.WriteEndElement();
        }

        public void WriteAsset(Asset asset)
        {
            writer.WriteStartElement("Asset");

            if (!asset.Oid.IsNull)
            {
                writer.WriteAttributeString("id", asset.Oid.Token);
            }

            foreach (var attribute in asset.Attributes.Values)
            {
                WriteAttributeReference(attribute);
            }

            writer.WriteEndElement();
        }

        public void WriteAttribute(Attribute attrib)
        {
            AttributeToXml(attrib);
        }

        public void WriteOid(Oid oid)
        {
            writer.WriteStartElement("Asset");

            if (!oid.IsNull)
            {
                writer.WriteAttributeString("id", oid.Token);
            }

            writer.WriteEndElement();
        }

        public void WriteHistoricalAssetList(AssetList assets, int total, int pagesize, int pagestart)
        {
            writer.WriteStartElement("History");

            if (total > -1)
            {
                writer.WriteAttributeString("total", total.ToString());
            }

            if (pagesize > -1)
            {
                writer.WriteAttributeString("pageSize", pagesize.ToString());
            }

            if (pagestart > -1)
            {
                writer.WriteAttributeString("pageStart", pagestart.ToString());
            }

            foreach (var asset in assets)
            {
                WriteAsset(asset);
            }

            writer.WriteEndElement();
        }

        public void WriteHistoricalAsset(AssetList assets, int total, int pagesize, int pagestart)
        {
            WriteHistoricalAssetList(assets, total, pagesize, pagestart);
        }

        public void WriteHistoricalAttribute(AssetList assets, IAttributeDefinition attribdef, int total, int pagesize, int pagestart)
        {
            writer.WriteStartElement("History");

            if (total > -1)
            {
                writer.WriteAttributeString("total", total.ToString());
            }

            if (pagesize > -1)
            {
                writer.WriteAttributeString("pageSize", pagesize.ToString());
            }

            if (pagestart > -1)
            {
                writer.WriteAttributeString("pageStart", pagestart.ToString());
            }

            foreach (var asset in assets)
            {
                WriteAttribute(asset.GetAttribute(attribdef));
            }

            writer.WriteEndElement();
        }

        private void WriteAttributeReference(Attribute attrib)
        {
            AttributeToXml(attrib);
        }

        #region Attribute Value Output

        private void AttributeToXml(Attribute attribute)
        {
            if (changesOnly && !attribute.HasChanged)
            {
                return;
            }

            if (attribute.Definition.AttributeType == AttributeType.Relation)
            {
                writer.WriteStartElement("Relation");
                writer.WriteAttributeString("name", attribute.Definition.Name);
                RelationAttributeToXml(attribute);
                writer.WriteEndElement();
            }
            else if (attribute.Definition.IsMultiValue)
            {
                writer.WriteStartElement("Attribute");
                writer.WriteAttributeString("name", attribute.Definition.Name);
                ValuesToXml(attribute.Definition, attribute.Values, "Value");
                writer.WriteEndElement();
            }
            else
            {
                var content = ValueToXmlString(attribute.Definition, attribute.Value);
                writer.WriteStartElement("Attribute");
                writer.WriteAttributeString("name", attribute.Definition.Name);

                if (attribute.HasChanged)
                {
                    writer.WriteAttributeString("act", "set");
                }

                writer.WriteString(content);
                writer.WriteEndElement();
            }
        }

        private void RelationAttributeToXml(Attribute attribute)
        {
            if (attribute.HasChanged && attribute.Definition.IsMultiValue)
            {
                WriteAttributeValues(attribute.AddedValues, "add");
                WriteAttributeValues(attribute.RemovedValues, "remove");
            }
            else
            {
                if (attribute.HasChanged)
                {
                    writer.WriteAttributeString("act", "set");
                }

                WriteAttributeValues(attribute.Values, null);
            }
        }

        private void WriteAttributeValues(IEnumerable list, string action)
        {
            if (list == null)
            {
                return;
            }

            foreach (var oid in list.Cast<Oid>().Where(oid => !oid.IsNull))
            {
                writer.WriteStartElement("Asset");
                writer.WriteAttributeString("idref", oid.Token);

                if (action != null)
                {
                    writer.WriteAttributeString("act", action);
                }

                writer.WriteEndElement();
            }
        }

        private void ValuesToXml(IAttributeDefinition attribdef, IEnumerable values, string tag)
        {
            if (values != null)
            {
                foreach (var val in values)
                {
                    ValueToXml(attribdef, val, tag);
                }
            }
        }

        private void ValueToXml(IAttributeDefinition attribdef, object val, string tag)
        {
            var content = ValueToXmlString(attribdef, val);

            if (content != null)
            {
                writer.WriteStartElement(tag);
                writer.WriteString(content);
                writer.WriteEndElement();
            }
        }

        private static string ValueToXmlString(IAttributeDefinition attribdef, object value)
        {
            var type = attribdef.AttributeType;

            if (value == null)
            {
                return null;
            }

            switch (type)
            {
                case AttributeType.Boolean:
                    return XmlConvert.ToString((bool)value);
                case AttributeType.Date:
                    var datetimevalue = (DateTime)value;
                    return XmlConvert.ToString(datetimevalue, datetimevalue.TimeOfDay == TimeSpan.Zero ? "yyyy-MM-dd" : "yyyy-MM-ddTHH:mm:ss.fff");
                case AttributeType.Numeric:
                    return Convert.ToSingle(value).ToString();
                case AttributeType.Relation:
                    return ((Oid)value).IsNull ? string.Empty : ((Oid)value).Token;

                case AttributeType.LongText:
                case AttributeType.Text:
                case AttributeType.LocalizerTag:
                    return (string)value;

                case AttributeType.Duration:
                    return value.ToString();
                case AttributeType.Rank:
                    return value.ToString();

                case AttributeType.AssetType:
                    return ((IAssetType)value).Token;
                case AttributeType.Opaque:
                    return value.ToString();

                case AttributeType.State:
                    return XmlConvert.ToString((byte)value);

                case AttributeType.Password:
                    return (string)value;
                case AttributeType.Blob:
                    return string.Empty;
                case AttributeType.LongInt:
                    return XmlConvert.ToString((long)value);

                default:
                    throw new MetaException("Unsupported AttributeType ", type.ToString());
            }
        }

        #endregion
    }
}