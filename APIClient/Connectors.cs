using System;

namespace VersionOne.SDK.APIClient
{

    public interface IConnectors
    {
        V1APIConnector MetaConnector { get; }
        V1APIConnector DataConnector { get; }
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
            DataConnector = new V1APIConnector(_urls.DataUrl, _credentials.V1UserName, _credentials.V1Password);
            MetaConnector = new V1APIConnector(_urls.MetaUrl);
        }

        public V1APIConnector MetaConnector { get; private set; }
        public V1APIConnector DataConnector { get; private set; }

    }
}
