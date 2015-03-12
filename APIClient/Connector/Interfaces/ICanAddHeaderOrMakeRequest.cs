namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanAddHeaderOrMakeRequest : ICanMakeRequest
    {
        /// <summary>
        /// Sets the stream user agent.
        /// </summary>
        /// <param name="userAgent"></param>
        void SetUpstreamUserAgent(string userAgent);

        /// <summary>
        /// For setting a custom user agent header.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        ICanMakeRequest SetUserAgentHeader(string name, string version);
    }
}