namespace VersionOne.SDK.APIClient
{
    public interface ICanSetProxyOrEndpointOrGetConnector : ICanSetEndpoint, ICanGetConnector
    {
        /// <summary>
        /// Optional method for setting the proxy credentials.
        /// </summary>
        /// <param name="proxyProvider"></param>
        /// <returns></returns>
        ICanSetEndpointOrGetConnector WithProxy(ProxyProvider proxyProvider);
    }
}