namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetProxyOrGetConnector : ICanGetConnector
    {
         ICanGetConnector WithProxy(ProxyProvider proxyProvider);
    }
}