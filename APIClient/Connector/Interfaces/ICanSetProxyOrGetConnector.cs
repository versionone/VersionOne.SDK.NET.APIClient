namespace VersionOne.SDK.APIClient
{
    public interface ICanSetProxyOrGetConnector : ICanGetConnector
    {
         ICanGetConnector WithProxy(ProxyProvider proxyProvider);
    }
}