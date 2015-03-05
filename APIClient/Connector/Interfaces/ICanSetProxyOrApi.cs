using System.Net;

namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetProxyOrApi : ICanSetApi
    {
        ICanSetApi WithProxy(WebProxy webProxy);
    }
}