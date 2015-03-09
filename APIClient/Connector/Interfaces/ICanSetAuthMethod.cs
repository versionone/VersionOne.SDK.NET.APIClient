namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetAuthMethodOrApi : ICanSetApi
    {
        ICanSetProxyOrApi WithUsernameAndPassword(string username, string password);

        ICanSetProxyOrApi WithAccessToken(string accessToken);
    }
}