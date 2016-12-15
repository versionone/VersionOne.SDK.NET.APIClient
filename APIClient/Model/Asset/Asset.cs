using System;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient
{
    public class Asset
    {
        private Oid oid = Oid.Null;
        private readonly IDictionary<string, IAttribute> attributes = new Dictionary<string, IAttribute>();
        private readonly IAssetType assetType;
        private readonly AssetList children = new AssetList();

        public IAssetType AssetType
        {
            get { return assetType; }
        }

        public Oid Oid
        {
            get { return oid; }
            set
            {
                if (value.AssetType != assetType)
                {
                    throw new OidException("Cannot change this asset's AssetType", value.Token);
                }

                oid = value;
            }
        }

        public IDictionary<string, IAttribute> Attributes => attributes;

        public AssetList Children => children;

        public Asset(Oid oid)
        {
            if (oid.IsNull)
            {
                throw new ArgumentOutOfRangeException("oid", oid, "Cannot initialize Asset with NULL Oid");
            }

            this.oid = oid;
            assetType = oid.AssetType;
        }

        public Asset(IAssetType assetType)
        {
            this.assetType = assetType;
        }

        public void SetAttributeValue(IAttributeDefinition attribdef, object value)
        {
            EnsureAttribute(attribdef).SetValue(value);
        }

        public void ForceAttributeValue(IAttributeDefinition attribdef, object value)
        {
            EnsureAttribute(attribdef).ForceValue(value);
        }

        public void AddAttributeValue(IAttributeDefinition attribdef, object value)
        {
            EnsureAttribute(attribdef).AddValue(value);
        }

        public void RemoveAttributeValue(IAttributeDefinition attribdef, object value)
        {
            EnsureAttribute(attribdef).RemoveValue(value);
        }

        /// <summary>
        /// Clear an attribute from cache based on definition.
        /// </summary>
        /// <param name="attribdef">definition of attribute to clear; 
        /// if null, all attributes will be cleared from cache.</param>
        public void ClearAttributeCache(IAttributeDefinition attribdef)
        {
            if (attribdef == null)
            {
                attributes.Clear();
            }
            else
            {
                attributes.Remove(ResolveAttributeDefinition(attribdef).Token);
            }
        }

        public Attribute GetAttribute(IAttributeDefinition attribdef)
        {
            IAttribute attrib;
            attributes.TryGetValue(ResolveAttributeDefinition(attribdef).Token, out attrib);
            return (Attribute)attrib;
        }

        private IAttributeDefinition ResolveAttributeDefinition(IAttributeDefinition attribdef)
        {
            try
            {
                if (AssetType.Is(attribdef.AssetType))
                {
                    return AssetType.GetAttributeDefinition(attribdef.Name);
                }
            }
            catch (MetaException) { }

            return attribdef;
        }

        public void AcceptChanges()
        {
            foreach (var attrib in attributes.Values)
            {
                attrib.AcceptChanges();
            }
        }

        public void RejectChanges()
        {
            foreach (var attrib in attributes.Values)
            {
                attrib.RejectChanges();
            }
        }

        public bool HasChanged
        {
            get { return attributes.Values.Any(attrib => attrib.HasChanged); }
        }

        public void LoadAttributeValue(IAttributeDefinition attribdef, object value)
        {
            EnsureAttribute(attribdef).LoadValue(value);
        }

        public Attribute EnsureAttribute(IAttributeDefinition attribdef)
        {
            attribdef = ResolveAttributeDefinition(attribdef);
            IAttribute attrib;

            if (!attributes.TryGetValue(attribdef.Token, out attrib))
            {
                attrib = attribdef.IsMultiValue ? (Attribute)new MultiValueAttribute(attribdef, this) : new SingleValueAttribute(attribdef, this);
                attributes[attribdef.Token] = attrib;
            }

            return (Attribute)attrib;
        }
    }
}