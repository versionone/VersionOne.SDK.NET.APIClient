namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetApi
    {
        /// <summary>
        /// Sets the Meta endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseMetaApi();

        /// <summary>
        /// Sets the Data endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseDataApi();

        /// <summary>
        /// Sets the History endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseHistoryApi();

        /// <summary>
        /// Sets the New endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseNewApi();

        /// <summary>
        /// Sets the Query endpoint.
        /// </summary>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseQueryApi();

        /// <summary>
        /// Sets a custom endpoint.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        ICanAddHeaderOrMakeRequest UseEndpoint(string endpoint);
    }
}