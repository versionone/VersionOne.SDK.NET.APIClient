namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetAuthMethodOrApi : ICanSetApi
    {
        /// <summary>
        /// Authenticates using username and password. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrApi WithUsernameAndPassword(string username, string password);

        /// <summary>
        /// Authenticates using access token.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrApi WithAccessToken(string accessToken);
    }
}