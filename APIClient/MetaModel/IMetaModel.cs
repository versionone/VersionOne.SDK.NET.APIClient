namespace VersionOne.SDK.APIClient
{
    public interface IMetaModel
    {
        IAssetType GetAssetType(string token);
        IAttributeDefinition GetAttributeDefinition(string token);
        IOperation GetOperation(string token);

        bool TryGetAssetType(string token, out IAssetType type);
        bool TryGetAttributeDefinition(string token, out IAttributeDefinition def);
        bool TryGetOperation(string token, out IOperation op);
    }
}