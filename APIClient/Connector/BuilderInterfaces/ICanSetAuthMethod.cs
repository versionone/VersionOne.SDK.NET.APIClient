namespace VersionOne.SDK.APIClient
{
    public interface ICanSetAuthMethod
    {
        /// <summary>
        /// Optional method for setting the username and password for authentication.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrEndpointOrGetConnector WithUsernameAndPassword(string username, string password);

        /// <summary>
        /// Optional method for setting the Windows Integrated Authentication credentials.
        /// The currently logged in users credentials are used.
        /// </summary>
        /// <returns></returns>
        ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated();

        /// <summary>
        /// Optional method for setting the Windows Integrated Authentication credentials.
        /// The fully qualified domain name will be in form "DOMAIN\username".
        /// </summary>
        /// <param name="fullyQualifiedDomainUsername"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password);

        /// <summary>
        /// Optional method for setting the access token for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrEndpointOrGetConnector WithAccessToken(string accessToken);

        /// <summary>
        /// Optional method for setting the OAuth2 access token for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrEndpointOrGetConnector WithOAuth2Token(string accessToken);
    }
}