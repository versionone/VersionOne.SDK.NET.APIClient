namespace VersionOne.SDK.APIClient
{

    public interface ICredentials
    {
        string V1UserName { get; }
        string V1Password { get; }
        string ProxyUserName { get; }
        string ProxyPassword { get; }
    }

    /// <summary>
    /// Retrieves credential information from the executing assemblies .config file.
    /// </summary>
    public sealed class Credentials : ICredentials
    {

        public Credentials()
        {
            V1UserName = ConfigurationManager.GetValue(Settings.V1UserName, "admin");
            V1Password = ConfigurationManager.GetValue(Settings.V1Password, "admin");
            ProxyUserName = ConfigurationManager.GetValue(Settings.ProxyUserName, "Administrator");
            ProxyPassword = ConfigurationManager.GetValue(Settings.ProxyPassword, "12345678");
        }

        public string V1UserName { get; private set; }
        public string V1Password { get; private set; }
        public string ProxyUserName { get; private set; }
        public string ProxyPassword { get; private set; }

    }
}
