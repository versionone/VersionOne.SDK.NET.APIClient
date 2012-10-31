using System.Dynamic;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public abstract class AssetClassBase : DynamicObject
    {
        protected abstract string GetAssetBasePrefix();

        private readonly Asset _wrapped;

        public AssetClassBase()
        {
            
        }

        protected AssetClassBase(Asset wrapped)
        {
            _wrapped = wrapped;
        }

        public abstract AssetClassBase Create(Asset wrapped);

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