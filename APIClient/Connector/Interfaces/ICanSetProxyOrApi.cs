namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetProxyOrApi : ICanSetApi
    {
        /// <summary>
        /// For setting the proxy credentials.
        /// </summary>
        /// <param name="proxyProvider"></param>
        /// <returns></returns>
        ICanSetApi WithProxy(ProxyProvider proxyProvider);
    }
}