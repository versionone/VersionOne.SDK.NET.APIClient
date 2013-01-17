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
        private bool _useWindowsIntegratedAuth;

        public Connectors()
        {
            _urls = new Urls();
            _credentials = new Credentials();
            InitializeInternal();
        }

        public Connectors(IUrls urls, ICredentials credentials)
        {
            if (urls == null) throw new ArgumentNullException("urls");
            if (credentials == null) throw new ArgumentNullException("credentials");
            _urls = urls;
            _credentials = credentials;
            InitializeInternal();
        }

        private void InitializeInternal()
        {
            _useWindowsIntegratedAuth = V1ConfigurationManager.GetValue(Settings.UseWindowsIntegratedAuth, false);
        }

        private ProxyProvider GetProxyProvider()
        {
            var proxyUri = new Uri(_urls.ProxyUrl);
            return new ProxyProvider(proxyUri, _credentials.ProxyUserName, _credentials.ProxyPassword);
        }

        private V1APIConnector _metaConnector;
        public V1APIConnector MetaConnector
        {
            get
            {
                if (_metaConnector != null) return _metaConnector;
                _metaConnector = new V1APIConnector(_urls.MetaUrl);
                return _metaConnector;
            }
        }

        private V1APIConnector _metaConnectorWithProxy;
        public V1APIConnector MetaConnectorWithProxy
        {
            get
            {
                if (_metaConnectorWithProxy != null) return _metaConnectorWithProxy;
                _metaConnectorWithProxy = new V1APIConnector(_urls.MetaUrl, _credentials.V1UserName, _credentials.V1Password, _useWindowsIntegratedAuth, GetProxyProvider());
                return _metaConnectorWithProxy;
            }
        }

        private V1APIConnector _dataConnector;
        public V1APIConnector DataConnector
        {
            get
            {
                if (_dataConnector != null) return _dataConnector;
                _dataConnector = new V1APIConnector(_urls.DataUrl, _credentials.V1UserName, _credentials.V1Password, _useWindowsIntegratedAuth);
                return _dataConnector;
            }
        }

        private V1APIConnector _dataConnectorWithProxy;
        public V1APIConnector DataConnectorWithProxy
        {
            get
            {
                if (_dataConnectorWithProxy != null) return _dataConnectorWithProxy;
                _dataConnectorWithProxy = new V1APIConnector(_urls.DataUrl, _credentials.V1UserName, _credentials.V1Password, _useWindowsIntegratedAuth, GetProxyProvider());
                return _dataConnectorWithProxy;
            }
        }

        private V1APIConnector _configurationConnector;
        public V1APIConnector ConfigurationConnector
        {
            get
            {
                if (_configurationConnector != null) return _configurationConnector;
                _configurationConnector = new V1APIConnector(_urls.ConfigUrl, _credentials.V1UserName, _credentials.V1Password);
                return _configurationConnector;
            }
        }

        private V1APIConnector _configurationConnectorWithProxy;
        public V1APIConnector ConfigurationConnectorWithProxy
        {
            get
            {
                if (_configurationConnectorWithProxy != null) return _configurationConnectorWithProxy;
                _configurationConnectorWithProxy = new V1APIConnector(_urls.ConfigUrl, _credentials.V1UserName, _credentials.V1Password, _useWindowsIntegratedAuth, GetProxyProvider());
                return _configurationConnectorWithProxy;
            }
        }

    }
}
