using System;

namespace VersionOne.SDK.APIClient
{
    /// <summary>
    /// Provides connectors for a VersionOne instance.
    /// </summary>
    public interface IConnectors
    {
        V1APIConnector MetaConnector { get; }
        V1APIConnector MetaConnectorWithProxy { get; }
        V1APIConnector DataConnector { get; }
        V1APIConnector DataConnectorWithProxy { get; }
        V1APIConnector ConfigurationConnector { get; }
        V1APIConnector ConfigurationConnectorWithProxy { get; }
    }

    public sealed class Connectors : IConnectors
    {

        private readonly IUrls _urls;
        private readonly ICredentials _credentials;

        public Connectors()
        {
            _urls = new Urls();
            _credentials = new Credentials();
            SetConnectors();
        }

        public Connectors(IUrls urls, ICredentials credentials)
        {
            if (urls == null) throw new ArgumentNullException("urls");
            if (credentials == null) throw new ArgumentNullException("credentials");
            _urls = urls;
            _credentials = credentials;
            SetConnectors();
        }

        private void SetConnectors()
        {
            var useWindowsIntegratedAuth = V1ConfigurationManager.GetValue(Settings.UseWindowsIntegratedAuth, false);
            DataConnector = new V1APIConnector(_urls.DataUrl, _credentials.V1UserName, _credentials.V1Password, useWindowsIntegratedAuth);
            DataConnectorWithProxy = new V1APIConnector(_urls.DataUrl, _credentials.V1UserName, _credentials.V1Password, useWindowsIntegratedAuth, GetProxyProvider());
            MetaConnector = new V1APIConnector(_urls.MetaUrl);
            MetaConnectorWithProxy = new V1APIConnector(_urls.MetaUrl, _credentials.V1UserName, _credentials.V1Password, useWindowsIntegratedAuth, GetProxyProvider());
            ConfigurationConnector = new V1APIConnector(_urls.ConfigUrl, _credentials.V1UserName, _credentials.V1Password);
            ConfigurationConnectorWithProxy = new V1APIConnector(_urls.ConfigUrl, _credentials.V1UserName, _credentials.V1Password, useWindowsIntegratedAuth, GetProxyProvider());

        }

        private ProxyProvider GetProxyProvider()
        {
            var proxyUri = new Uri(_urls.ProxyUrl);
            return new ProxyProvider(proxyUri, _credentials.ProxyUserName, _credentials.ProxyPassword);
        }

        public V1APIConnector MetaConnector { get; private set; }
        public V1APIConnector MetaConnectorWithProxy { get; private set; }
        public V1APIConnector DataConnector { get; private set; }
        public V1APIConnector DataConnectorWithProxy { get; private set; }
        public V1APIConnector ConfigurationConnector { get; private set; }
        public V1APIConnector ConfigurationConnectorWithProxy { get; private set; }

    }
}
