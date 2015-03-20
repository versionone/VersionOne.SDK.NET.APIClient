namespace VersionOne.SDK.APIClient
{
    public interface ICanSetEndpoint
    {
        ICanSetProxyOrGetConnector UseEndpoint(string endpoint);
    }
}