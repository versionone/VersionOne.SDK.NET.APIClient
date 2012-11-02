using System.Dynamic;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public abstract class TypedAssetClass : AssetClassBase
    {
        public TypedAssetClass()
        {
            
        }

        public TypedAssetClass(Asset wrapped) : base(wrapped)
        {
        }

        public abstract AssetClassBase Create(Asset wrapped);
    }

    public abstract class AssetClassBase : DynamicObject
    {
        private readonly Asset _wrapped;

        public AssetClassBase()
        {
        }

        protected AssetClassBase(Asset wrapped)
        {
            _wrapped = wrapped;
        }

        protected string AssetBasePrefix { get; set; }

        protected virtual string GetAssetBasePrefix()
        {
            return AssetBasePrefix;
        }

        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            var attribute = MetaModelProvider.Meta.GetAttributeDefinition(GetAssetBasePrefix() + "." + binder.Name);
            result = _wrapped.GetAttribute(attribute).Value;
            return result != null;
        }

        public IAttributeDefinition GetAttribute(object fieldName)
        {
            return MetaModelProvider.Meta.GetAttributeDefinition(
                GetAssetBasePrefix() + "." + fieldName);
        }
    }
}