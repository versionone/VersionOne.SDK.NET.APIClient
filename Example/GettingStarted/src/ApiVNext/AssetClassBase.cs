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

	    public object this[string name] => GetValueByName(name);

	    protected string AssetBasePrefix { get; set; }

        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            var attribute = GetAttribute(binder.Name);
            result = _wrapped.GetAttribute(attribute).Value;
            return result != null;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var attribute = GetAttribute(binder.Name);
            if (attribute != null)
            {
                _wrapped.SetAttributeValue(attribute, value);
                return true;
            }
            return false;
        }

        public object GetValueByName(string fieldName)
        {
            var attribute = GetAttribute(fieldName);
            return _wrapped.GetAttribute(attribute).Value;
        }

        public IAttributeDefinition GetAttribute(object fieldName)
        {
            return MetaModelProvider.Meta.GetAttributeDefinition(AssetBasePrefix + "." + fieldName);
        }

        public void SaveChanges()
        {
            ServicesProvider.Services.Save(_wrapped);
        }

        public void SaveChanges(string comment)
        {
            ServicesProvider.Services.Save(_wrapped, comment);
        }
    }
}