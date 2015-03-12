namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanSetAuthMethodOrApi : ICanSetApi
    {
        /// <summary>
        /// For setting the username and password for authentication.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrApi WithUsernameAndPassword(string username, string password);

        /// <summary>
        /// For setting the access token for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrApi WithAccessToken(string accessToken);

        /// <summary>
        /// For setting the Windows Integrated Authentication credentials. 
        /// The currently logged in users credentials are used.
        /// </summary>
        /// <returns></returns>
        ICanSetProxyOrApi WithWindowsIntegrated();

        /// <summary>
        /// For setting the Windows Integrated Authentication credentials. 
        /// The fully qualified domain name will be in form "DOMAIN\username".
        /// </summary>
        /// <param name="fullyQualifiedDomainUsername"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrApi WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password);
    }
}