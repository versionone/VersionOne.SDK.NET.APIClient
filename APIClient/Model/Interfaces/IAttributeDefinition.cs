using VersionOne.SDK.APIClient.Model.Asset.Attribute;
using VersionOne.SDK.APIClient.Queries;

namespace VersionOne.SDK.APIClient.Model.Interfaces {
    public interface IAttributeDefinition {
        IAssetType AssetType { get; }
        string Name { get; }
        string Token { get; }
        AttributeType AttributeType { get; }
        IAttributeDefinition Base { get; }
        bool IsReadOnly { get; }
        bool IsRequired { get; }
        bool IsMultiValue { get; }
        IAssetType RelatedAsset { get; }
        string DisplayName { get; }

        object Coerce(object value);

        IAttributeDefinition Downcast(IAssetType assetType);
        IAttributeDefinition Filter(IFilterTerm filter);
        IAttributeDefinition Join(IAttributeDefinition joined);
        IAttributeDefinition Aggregate(Aggregate aggregate);
    }
}