namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetAuthMethod
    {
        ICanSetProxyOrApi WithUsernameAndPassword(string username, string password);

        ICanSetProxyOrApi WithAccessToken(string accessToken);
    }
}