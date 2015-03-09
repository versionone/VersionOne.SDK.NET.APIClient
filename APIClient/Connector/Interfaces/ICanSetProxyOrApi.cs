namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetProxyOrApi : ICanSetApi
    {
        ICanSetApi WithProxy(ProxyProvider proxyProvider);
    }
}