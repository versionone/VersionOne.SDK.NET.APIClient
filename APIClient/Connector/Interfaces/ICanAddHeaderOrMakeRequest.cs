namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanAddHeaderOrMakeRequest : ICanMakeRequest
    {
        void SetUpstreamUserAgent(string userAgent);

        ICanMakeRequest WithUserAgentHeader(string name, string version);
    }
}