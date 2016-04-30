using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace VersionOne.SDK.APIClient
{
    public class Asset : DynamicObject
    {
        private Oid oid = Oid.Null;
        private readonly IDictionary<string, Attribute> attributes = new Dictionary<string, Attribute>();
        private readonly IAssetType assetType;
        private readonly AssetList children = new AssetList();
        protected string AssetBasePrefix { get; set; }
        private IMetaModel metaModel;
        private IServices services;

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

        public IDictionary<string, Attribute> Attributes
        {
            get { return attributes; }
        }

        public AssetList Children
        {
            get { return children; }
        }

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

        public Asset(string basePrefix, IMetaModel metaModel, IServices services)
        {
            Configure(basePrefix, metaModel, services);
        }

        public void Configure(string basePrefix, IMetaModel metaModel, IServices services)
        {
            this.AssetBasePrefix = basePrefix;
            this.metaModel = metaModel;
            this.services = services;
        }

        public object this[string name] => GetValueByName(name);

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
            Attribute attrib;
            attributes.TryGetValue(ResolveAttributeDefinition(attribdef).Token, out attrib);
            return attrib;
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
            Attribute attrib;

            if (!attributes.TryGetValue(attribdef.Token, out attrib))
            {
                attrib = attribdef.IsMultiValue ? (Attribute)new MultiValueAttribute(attribdef, this) : new SingleValueAttribute(attribdef, this);
                attributes[attribdef.Token] = attrib;
            }

            return attrib;
        }

        #region DynamicObject members

        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            var attribute = GetAttributeByName(binder.Name);
            result = GetAttribute(attribute).Value;
            return result != null;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var attribute = GetAttributeByName(binder.Name);
            if (attribute != null)
            {
                SetAttributeValue(attribute, value);
                return true;
            }
            return false;
        }

        #endregion

        public IAttributeDefinition GetAttributeByName(object fieldName)
        {
            return metaModel.GetAttributeDefinition(AssetBasePrefix + "." + fieldName);
        }

        public object GetValueByName(string fieldName)
        {
            var attribute = GetAttributeByName(fieldName);
            return GetAttribute(attribute).Value;
        }

        public void SaveChanges()
        {
            services.Save(this);
        }

        public void SaveChanges(string comment)
        {
            services.Save(this, comment);
        }
    }
}