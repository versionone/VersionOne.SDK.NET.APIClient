namespace VersionOne.SDK.APIClient
{
    public interface ICanSetUserAgentHeader
    {
        /// <summary>
        /// Required method for setting a custom user agent header for all HTTP requests made to the VersionOne API.
        /// </summary>
        /// <param name="name">The name of the application.</param>
        /// <param name="version">The version number of the application.</param>
        /// <returns></returns>
        ICanSetAuthMethod WithUserAgentHeader(string name, string version);
    }
}