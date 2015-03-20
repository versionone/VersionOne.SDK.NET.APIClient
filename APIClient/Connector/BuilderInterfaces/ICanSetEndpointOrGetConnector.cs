namespace VersionOne.SDK.APIClient
{
    public interface ICanSetEndpointOrGetConnector : ICanGetConnector
    {
        ICanGetConnector UseEndpoint(string endpoint);
    }
}