namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetApi
    {
        ICanAddHeaderOrMakeRequest UseMetaApi();

        ICanAddHeaderOrMakeRequest UseDataApi();

        ICanAddHeaderOrMakeRequest UseHistoryApi();

        ICanAddHeaderOrMakeRequest UseNewApi();

        ICanAddHeaderOrMakeRequest UseQueryApi();

        ICanAddHeaderOrMakeRequest UseEndpoint(string endpoint);
    }
}