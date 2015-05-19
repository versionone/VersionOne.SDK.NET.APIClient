using System;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated.")]
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
    [Obsolete("This class has been deprecated.")]
    public sealed class Credentials : ICredentials
    {

        private string _v1UserName;
        public string V1UserName
        {
            get
            {
                if (string.IsNullOrEmpty(_v1UserName) == false) return _v1UserName;
                _v1UserName = V1ConfigurationManager.GetValue(Settings.V1UserName, "admin");
                return _v1UserName;
            }
        }

        private string _v1Password;
        public string V1Password
        {
            get
            {
                if (string.IsNullOrEmpty(_v1Password) == false) return _v1Password;
                _v1Password = V1ConfigurationManager.GetValue(Settings.V1Password, "admin");
                return _v1Password;
            }
        }

        private string _proxyUserName;
        public string ProxyUserName
        {
            get
            {
                if (string.IsNullOrEmpty(_proxyUserName) == false) return _proxyUserName;
                _proxyUserName = V1ConfigurationManager.GetValue(Settings.ProxyUserName, "Administrator");
                return _proxyUserName;
            }
        }

        private string _proxyPassword;
        public string ProxyPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_proxyPassword) == false) return _proxyPassword;
                _proxyPassword = V1ConfigurationManager.GetValue(Settings.ProxyPassword, "12345678");
                return _proxyPassword;
            }
        }

    }
}
