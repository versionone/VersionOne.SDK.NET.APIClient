using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
	public class MetaModel : IMetaModel
	{
		private readonly IAPIConnector _connector;
        private readonly V1Connector _v1Connector;
		private readonly IDictionary _map = new Hashtable();
		private Version _version;
		private string _versionString = null;

		public MetaModel(IAPIConnector connector, bool hookup = false)
		{
			_connector = connector;

		    if (hookup)
		        Hookup();
		}

        public MetaModel(V1Connector v1Connector, bool hookup = false)
        {
            _v1Connector = v1Connector;

            if (hookup)
                Hookup();
        }

		public Version Version
		{
			get
			{
				if ( _version == null )
				{
					if ( _versionString == null )
						GetAssetType("BaseAsset");

					if ( _versionString != null )
						_version = new Version(_versionString);
				}

				return _version;
			}
		}

		#region IMetaModel Members

		public IAssetType GetAssetType(string token)
		{
			try { return LookupAssetType(token); }
			catch (Exception ex)
			{
				throw new MetaException("Unknown AssetType", token, ex);
			}
		}

		public IAttributeDefinition GetAttributeDefinition(string token)
		{
			try { return LookupAttributeDefinition(token); }
			catch (Exception ex)
			{
				throw new MetaException("Unknown AttributeDefinition", token, ex);
			}
		}

		public IOperation GetOperation(string token)
		{
			try { return LookupOperation(token); }
			catch (Exception ex)
			{
				throw new MetaException("Unknown Operation", token, ex);
			}
		}

		public bool TryGetAssetType(string token, out IAssetType type)
		{
			type = null;
			try { type = LookupAssetType(token); } catch (Exception) { }
			return type != null;
		}

		public bool TryGetAttributeDefinition(string token, out IAttributeDefinition def)
		{
			def = null;
			try { def = LookupAttributeDefinition(token); } catch (Exception) { }
			return def != null;
		}

		public bool TryGetOperation(string token, out IOperation op)
		{
			op = null;
			try { op = LookupOperation(token); } catch (Exception) { }
			return op != null;
		}

		#endregion

		private IAssetType LookupAssetType(string token)
		{
			IAssetType mapped = _map[token] as IAssetType;
			if ( mapped != null ) return mapped;

			return HookupAssetType(token);
		}

		private void SaveAssetType(IAssetType assettype)
		{
			_map[assettype.Token] = assettype;
		}

		private IAttributeDefinition LookupAttributeDefinition(string token)
		{
			string prefix;
			string suffix;
			TextBuilder.SplitPrefix(token, '.', out prefix, out suffix);

			LookupAssetType(prefix);

			IAttributeDefinition mapped = _map[token] as IAttributeDefinition;
			if ( mapped != null ) return mapped;

			return HookupAttributeDefinition(prefix, suffix);
		}

		private void SaveAttributeDefinition(IAttributeDefinition attribdef)
		{
			_map[attribdef.Token] = attribdef;
		}

		private IOperation LookupOperation(string token)
		{
			string prefix;
			string suffix;
			TextBuilder.SplitPrefix(token, '.', out prefix, out suffix);

			LookupAssetType(prefix);

			IOperation mapped = _map[token] as IOperation;
			if ( mapped != null ) return mapped;

			return HookupOperation(prefix, suffix);
		}

		private void SaveOperation(IOperation op)
		{
			_map[op.Token] = op;
		}

		private IAssetType HookupAssetType(string token)
		{
			XmlDocument doc = new XmlDocument();
		    Stream stream = GetStreamFromAppropiateConnector(token);
            doc.Load(stream);
            stream.Dispose();

			_versionString = doc.DocumentElement.Attributes["version"].Value;

			AssetType assetType = new AssetType(this, doc.DocumentElement, _map);
			SaveAssetType(assetType);

			XmlNodeList attribnodes = doc.DocumentElement.SelectNodes("AttributeDefinition");
			foreach (XmlElement attribelement in attribnodes)
				SaveAttributeDefinition(new AttributeDefinition(this, attribelement));

			XmlNodeList opnodes = doc.DocumentElement.SelectNodes("Operation");
			foreach (XmlElement opelement in opnodes)
				SaveOperation(new Operation(this, assetType.Token, opelement));

			return assetType;
		}

		private IAttributeDefinition HookupAttributeDefinition(string assettypetoken, string name)
		{
			XmlDocument doc = new XmlDocument();
		    Stream stream = GetStreamFromAppropiateConnector(assettypetoken + "/" + name);
    		doc.Load(stream);
            stream.Dispose();

			_versionString = doc.DocumentElement.Attributes["version"].Value;

			AttributeDefinition attribdef = new AttributeDefinition(this, doc.DocumentElement);
			SaveAttributeDefinition(attribdef);

			return attribdef;
		}

		private IOperation HookupOperation(string assettypetoken, string name)
		{
			XmlDocument doc = new XmlDocument();
		    Stream stream = GetStreamFromAppropiateConnector(assettypetoken + "/" + name);
			doc.Load(stream);
            stream.Dispose();

			_versionString = doc.DocumentElement.Attributes["version"].Value;

			Operation op = new Operation(this, assettypetoken, doc.DocumentElement);
			SaveOperation(op);

			return op;
		}

		private void Hookup()
		{
			XmlDocument doc = new XmlDocument();
		    Stream stream = GetStreamFromAppropiateConnector();
			doc.Load(stream);
            stream.Dispose();

			_versionString = doc.DocumentElement.Attributes["version"].Value;

			XmlNodeList assetnodes = doc.SelectNodes("//AssetType");

			foreach (XmlElement element in assetnodes)
				SaveAssetType(new AssetType(this, element, _map));

			foreach (XmlElement assetelement in assetnodes)
			{
				XmlNodeList attribnodes = assetelement.SelectNodes("AttributeDefinition");
				foreach (XmlElement attribelement in attribnodes)
					SaveAttributeDefinition(new AttributeDefinition(this, attribelement));
			}

			foreach (XmlElement assetelement in assetnodes)
			{
				XmlNodeList opnodes = assetelement.SelectNodes("Operation");
				foreach (XmlElement opelement in opnodes)
					SaveOperation(new Operation(this, assetelement.GetAttribute("token"), opelement));
			}
		}

        private Stream GetStreamFromAppropiateConnector(string path = "")
        {
            Stream result = null;
            if (_connector != null)
            {
                result = _connector.GetData(path);
            }
            if (_v1Connector != null)
            {
                _v1Connector.UseMetaApi();
                result = _v1Connector.GetData(path);
            }

            return result;
        }
	}
}