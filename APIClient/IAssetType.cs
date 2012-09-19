namespace VersionOne.SDK.APIClient {
    public interface IAssetType {
        string Token { get; }
        IAssetType Base { get; }
        string DisplayName { get; }
        IAttributeDefinition DefaultOrderBy { get; }
        IAttributeDefinition ShortNameAttribute { get; }
        IAttributeDefinition NameAttribute { get; }
        IAttributeDefinition DescriptionAttribute { get; }
        bool Is(IAssetType targettype);
        IAttributeDefinition GetAttributeDefinition(string name);
        bool TryGetAttributeDefinition(string name, out IAttributeDefinition def);
        IOperation GetOperation(string name);
        bool TryGetOperation(string name, out IOperation op);
    }
}