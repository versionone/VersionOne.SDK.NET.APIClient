using System.Dynamic;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class AssetClassBase : DynamicObject
    {
        private readonly Asset _wrapped;

        public AssetClassBase()
        {
        }

        public AssetClassBase(Asset wrapped, string basePrefix)
        {
            _wrapped = wrapped;
            AssetBasePrefix = basePrefix;
        }

        protected AssetClassBase(Asset wrapped)
        {
            _wrapped = wrapped;
        }

        protected string AssetBasePrefix { get; set; }

        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            var attribute = MetaModelProvider.Meta.GetAttributeDefinition(AssetBasePrefix + "." + binder.Name);
            result = _wrapped.GetAttribute(attribute).Value;
            return result != null;
        }

        public IAttributeDefinition GetAttribute(object fieldName)
        {
            return MetaModelProvider.Meta.GetAttributeDefinition(
                AssetBasePrefix + "." + fieldName);
        }
    }
}