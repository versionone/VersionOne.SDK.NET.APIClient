namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetProxyOrApi : ICanSetApi
    {
        /// <summary>
        /// Sets a proxy.
        /// </summary>
        /// <param name="proxyProvider"></param>
        /// <returns></returns>
        ICanSetApi WithProxy(ProxyProvider proxyProvider);
    }
}