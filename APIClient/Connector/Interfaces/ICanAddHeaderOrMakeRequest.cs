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
        /// Sets the values to use for the custom user-agent header.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        ICanMakeRequest WithUserAgentHeader(string name, string version);
    }
}