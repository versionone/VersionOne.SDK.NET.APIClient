namespace VersionOne.SDK.APIClient
{
    public interface IOperation
    {
        string Token { get; }
        string Name { get; }
        IAssetType AssetType { get; }
        IAttributeDefinition ValidatorAttribute { get; }
    }
}