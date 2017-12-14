using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using Attribute = VersionOne.SDK.APIClient;
using static VersionOne.SDK.APIClient.XmlApiWriterConstants;

namespace VersionOne.SDK.APIClient
{
	internal class XmlApiWriter
	{
		private readonly XmlTextWriter _writer;

		public XmlApiWriter(TextWriter response)
		{
			_writer = new XmlTextWriter(response);
#if DEBUG
			_writer.Formatting = Formatting.Indented;
			_writer.IndentChar = '\t';
			_writer.Indentation = 1;
#endif
		}

		public void WriteAsset(Asset asset)
		{
			_writer.WriteStartElement(AssetElement);
			if (!asset.Oid.IsNull) _writer.WriteAttributeString(IdAttribute, asset.Oid.Token);
			foreach (var attribute in asset.Attributes.Values) WriteAttributeReference(attribute);
			_writer.WriteEndElement();
		}

		private void WriteAttributeReference(Attribute attrib) => AttributeToXml(attrib);

		#region Attribute Value Output

		private void AttributeToXml(Attribute attribute)
		{
			if (!attribute.HasChanged) return;

			if (attribute.Definition.AttributeType == AttributeType.Relation)
			{
				_writer.WriteStartElement(RelationElement);
				_writer.WriteAttributeString(NameAttribute, attribute.Definition.Name);
				RelationAttributeToXml(attribute);
				_writer.WriteEndElement();
			}
			else if (attribute.Definition.IsMultiValue)
			{
				_writer.WriteStartElement(AttributeElement);
				_writer.WriteAttributeString(NameAttribute, attribute.Definition.Name);
				MultiValueAttributeToXml(attribute);
				_writer.WriteEndElement();
			}
			else
			{
				var content = ValueToXmlString(attribute.Definition, attribute.Value);
				_writer.WriteStartElement(AttributeElement);
				_writer.WriteAttributeString(NameAttribute, attribute.Definition.Name);
				if (attribute.HasChanged) _writer.WriteAttributeString(Act, ActSet);
				_writer.WriteString(content);
				_writer.WriteEndElement();
			}
		}

		private void RelationAttributeToXml(Attribute attribute)
		{
			if (attribute.HasChanged && attribute.Definition.IsMultiValue)
			{
				WriteAttributeValues(attribute.AddedValues, ActAdd);
				WriteAttributeValues(attribute.RemovedValues, ActRemove);
			}
			else
			{
				if (attribute.HasChanged) _writer.WriteAttributeString(Act, ActSet);
				WriteAttributeValues(attribute.Values, null);
			}
		}

		private void WriteAttributeValues(IEnumerable list, string action)
		{
			if (list == null) return;

			foreach (var oid in list.Cast<Oid>().Where(oid => !oid.IsNull))
			{
				_writer.WriteStartElement(AssetElement);
				_writer.WriteAttributeString(IdRefAttribute, oid.Token);
				if (action != null) _writer.WriteAttributeString(Act, action);
				_writer.WriteEndElement();
			}
		}

		private void MultiValueAttributeToXml(Attribute attribute)
		{
			if (!attribute.HasChanged || !attribute.Definition.IsMultiValue) return;

			WriteMultiValueAttributeValues(attribute.AddedValues, ActAdd);
			WriteMultiValueAttributeValues(attribute.RemovedValues, ActRemove);
		}

		private void WriteMultiValueAttributeValues(IEnumerable list, string action)
		{
			if (list == null) return;

			foreach (var oid in list.Cast<string>().Where(s => !string.IsNullOrWhiteSpace(s)))
			{
				_writer.WriteStartElement(ValueElement);
				_writer.WriteAttributeString(Act, action);
				_writer.WriteValue(oid);
				_writer.WriteEndElement();
			}
		}

		private static string ValueToXmlString(IAttributeDefinition attribdef, object value)
		{
			var type = attribdef.AttributeType;

			if (value == null) return null;

			switch (type)
			{
				case AttributeType.Boolean:
					return XmlConvert.ToString((bool) value);
				case AttributeType.Date:
					var datetimevalue = (DateTime) value;
					return XmlConvert.ToString(datetimevalue,
						datetimevalue.TimeOfDay == TimeSpan.Zero ? DateTimeShortFormat : DateTimeLongFormat);
				case AttributeType.Numeric:
					return Convert.ToSingle(value).ToString();
				case AttributeType.Relation:
					return ((Oid) value).IsNull ? string.Empty : ((Oid) value).Token;

				case AttributeType.LongText:
				case AttributeType.Text:
				case AttributeType.LocalizerTag:
					return (string) value;

				case AttributeType.Duration:
					return value.ToString();
				case AttributeType.Rank:
					return value.ToString();

				case AttributeType.AssetType:
					return ((IAssetType) value).Token;
				case AttributeType.Opaque:
					return value.ToString();

				case AttributeType.State:
					return XmlConvert.ToString((byte) value);

				case AttributeType.Password:
					return (string) value;
				case AttributeType.Blob:
					return string.Empty;
				case AttributeType.LongInt:
					return XmlConvert.ToString((long) value);

				default:
					throw new MetaException("Unsupported AttributeType ", type.ToString());
			}
		}

		#endregion
	}
}