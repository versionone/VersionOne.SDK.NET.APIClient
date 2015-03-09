using VersionOne.SDK.APIClient.Model;
using VersionOne.SDK.APIClient.Model.Asset;
using VersionOne.SDK.APIClient.Model.Interfaces;
using VersionOne.SDK.APIClient.Queries;

namespace VersionOne.SDK.APIClient.Services
{
    public interface IServices
    {
        QueryResult Retrieve(Query query);
        void Save(Asset asset);
        void Save(Asset asset, string comment);
        void Save(AssetList assetList);
        Oid LoggedIn { get; }
        Asset New(IAssetType assetType, Oid context = null);
        Oid GetOid(string token);
        Oid ExecuteOperation(IOperation op, Oid oid);
        void SetUpstreamUserAgent(string userAgent);
    }
}