using System.Collections.Generic;
using System.IO;
using VersionOne.Assets;

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
        string Localization(string key);
        string Localization(IAttributeDefinition attribute);
        Dictionary<string, string> Localization(params IAttributeDefinition[] attributes);
        IFluentQueryBuilder Query(string from);
        
        /// <summary>
        /// Executes a query using the Query API (query.v1 endpoint).
        /// </summary>
        /// <param name="query">string The query to execute in JSON or YAML format.</param>
        /// <returns>String containing the query results in a JSON format.</returns>
        string ExecutePassThroughQuery(string query);

        /// <summary>
        /// Saves an attachment to the specified asset.
        /// </summary>
        /// <param name="filePath">Path and name of the attachment file.</param>
        /// <param name="asset">Asset to save the attachment to.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <returns>Oid</returns>
        Oid SaveAttachment(string filePath, Asset asset, string attachmentName);

        /// <summary>
        /// Saves an embedded image to the specified asset.
        /// </summary>
        /// <param name="filePath">Path and name of the embedded image file.</param>
        /// <param name="asset">Asset to save the embedded image to.</param>
        /// <returns>Oid</returns>
        Oid SaveEmbeddedImage(string filePath, Asset asset);

        /// <summary>
        /// Returns the attachment data for the specified attachment Oid.
        /// </summary>
        /// <param name="attachmentOid">The Oid of the attachment to return.</param>
        /// <returns>Stream</returns>
        Stream GetAttachment(Oid attachmentOid);

        /// <summary>
        /// Returns the embedded image data for the specified attachment Oid.
        /// </summary>
        /// <param name="embeddedImageOid">The Oid of the embedded image to return.</param>
        /// <returns>Stream</returns>
        Stream GetEmbeddedImage(Oid embeddedImageOid);
    }
}