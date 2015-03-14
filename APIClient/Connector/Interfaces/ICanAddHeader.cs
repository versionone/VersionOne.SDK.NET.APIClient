namespace VersionOne.SDK.APIClient
{
    public interface ICanAddHeaderOrSetProxyOrGetConnector : ICanSetProxyOrGetConnector
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
        ICanSetProxyOrGetConnector SetUserAgentHeader(string name, string version);
    }
}