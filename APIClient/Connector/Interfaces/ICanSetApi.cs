namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetApi
    {
        /// <summary>
        /// For connecting to meta.v1 endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseMetaApi();

        /// <summary>
        /// For connecting to rest-1.v1/Data endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseDataApi();

        /// <summary>
        /// For connecting to rest-1.v1/Hist endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseHistoryApi();

        /// <summary>
        /// For connecting to rest-1.v1/New endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseNewApi();

        /// <summary>
        /// For connecting to query.v1 endpoint
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseQueryApi();

        /// <summary>
        /// For connecting to a user specified endpoint.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseEndpoint(string endpoint);
    }
}