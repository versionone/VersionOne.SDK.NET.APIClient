namespace VersionOne.SDK.APIClient
{
    public interface ICanSetProxyOrGetConnector : ICanGetConnector
    {
        /// <summary>
        /// Optional method for setting the proxy credentials.
        /// </summary>
        /// <param name="proxyProvider"></param>
        /// <returns></returns>
        ICanGetConnector WithProxy(ProxyProvider proxyProvider);
    }
}