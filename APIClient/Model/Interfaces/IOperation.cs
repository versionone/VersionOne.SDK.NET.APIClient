namespace VersionOne.SDK.APIClient.Model.Interfaces {
    public interface IOperation {
        string Token { get; }
        string Name { get; }
        IAssetType AssetType { get; }
        IAttributeDefinition ValidatorAttribute { get; }
    }
}