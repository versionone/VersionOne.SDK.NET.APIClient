namespace VersionOne.SDK.APIClient
{
    public interface ICanSetApi
    {
        /// <summary>
        /// For connecting to meta.v1 endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseMetaApi();

        /// <summary>
        /// For connecting to rest-1.v1/Data endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseDataApi();

        /// <summary>
        /// For connecting to rest-1.v1/Hist endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseHistoryApi();

        /// <summary>
        /// For connecting to rest-1.v1/New endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseNewApi();

        /// <summary>
        /// For connecting to query.v1 endpoint
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseQueryApi();

        /// <summary>
        /// For connecting to a user specified endpoint.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        ICanAddHeaderOrGetConnector UseEndpoint(string endpoint);
    }
}