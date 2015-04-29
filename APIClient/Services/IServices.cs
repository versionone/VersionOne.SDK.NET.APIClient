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
        IMetaModel Meta { get; }
        Asset New(IAssetType assetType, Oid context = null);
        Oid GetOid(string token);
        Oid ExecuteOperation(IOperation op, Oid oid);
        void SetUpstreamUserAgent(string userAgent);
        string Loc(string key);
        string Loc(IAttributeDefinition attribute);
        Dictionary<string, string> Loc(params IAttributeDefinition[] attributes);
        
        /// <summary>
        /// Executes a query using the Query API (query.v1 endpoint).
        /// </summary>
        /// <param name="query">string The query to execute in JSON or YAML format.</param>
        /// <returns>String containing the query results in a JSON format.</returns>
        string ExecutePassThroughQuery(string query);
    }
}