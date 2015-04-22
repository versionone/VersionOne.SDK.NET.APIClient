using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
    public interface IServices
    {
        QueryResult Retrieve(Query query);
        void Save(Asset asset);
        void Save(Asset asset, string comment);
        void Save(AssetList assetList);
        Oid LoggedIn { get; }
        IMetaModel MetaModel { get; }
        Asset New(IAssetType assetType, Oid context = null);
        Oid GetOid(string token);
        Oid ExecuteOperation(IOperation op, Oid oid);
        void SetUpstreamUserAgent(string userAgent);
        Dictionary<string, string> Loc(IAttributeDefinition[] attributes);
        string Loc(IAttributeDefinition attribute);
    }
}