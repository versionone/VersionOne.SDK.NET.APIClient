using System;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public class V1ConnectionValidator
    {
        private readonly string _connectionUrl;
        private readonly string _username;
        private readonly string _password;
        private readonly bool _integratedAuth;
        private readonly IDictionary<string, string> _customHttpHeaders = new Dictionary<string, string>();

        private readonly ProxyProvider _proxyProvider;

        public V1ConnectionValidator(string connectionUrl, string username, string password, bool integratedAuth)
        {
            _connectionUrl = connectionUrl;

            if (_connectionUrl == null)
            {
                _connectionUrl = string.Empty;
            }
            else if (!_connectionUrl.EndsWith("/"))
            {
                _connectionUrl += "/";
            }

            _username = username;
            _password = password;
            _integratedAuth = integratedAuth;
        }

        public V1ConnectionValidator(string connectionUrl, string username, string password, bool integratedAuth, ProxyProvider proxyProvider)
            : this(connectionUrl, username, password, integratedAuth)
        {
            _proxyProvider = proxyProvider;
        }

        /// <summary>
        /// Headers from this Dictionary will be added to all HTTP requests to VersionOne server.
        /// </summary>
        public IDictionary<string, string> CustomHttpHeaders
        {
            get { return _customHttpHeaders; }
        }

        public void Test()
        {
            Test(null);
        }

        public void Test(string version)
        {
            try
            {
                CheckConnection();
                CheckVersion(version);
                CheckAuthentication();
            }
            catch (System.Net.WebException ex)
            {
                throw new ConnectionException("Connection Check: " + ex.Message, ex);
            }
        }

        public void CheckConnection()
        {
            IAPIConnector connector = PrepareConnector(_connectionUrl + "loc.v1/?Member");

            try
            {
                connector.GetData().Close();
            }
            catch (System.Net.WebException ex)
            {
                throw new ConnectionException("Application not found at the URL: " + _connectionUrl, ex);
            }
        }

        public void CheckVersion(string version)
        {
            var meta = CreateMetaModel();
            meta.GetAssetType("Member");

            if (!string.IsNullOrEmpty(version) && (meta.Version == null || meta.Version < new Version(version)))
            {
                throw new ConnectionException(string.Format(
                    "VersionOne Release {0} or above is required (found {1}).", version, meta.Version));
            }
        }

        private MetaModel CreateMetaModel()
        {
            return new MetaModel(PrepareConnector(_connectionUrl + "meta.v1/"), false);
        }

        public void CheckAuthentication()
        {
            IServices services = new Services(CreateMetaModel(), PrepareConnector(_connectionUrl + "rest-1.v1/"));
            Oid loggedin;

            try
            {
                loggedin = services.LoggedIn;
            }
            catch (System.Net.WebException ex)
            {
                throw new ConnectionException("Unable to log in. Incorrect username or password.", ex);
            }

            if (loggedin.IsNull)
            {
                throw new ConnectionException("Unable to retrieve logged in member.");
            }
        }

        private IAPIConnector PopulateHeaders(IAPIConnector connector)
        {
            IDictionary<string, string> dict = connector.CustomHttpHeaders;
            foreach (KeyValuePair<string, string> pair in _customHttpHeaders)
            {
                dict.Add(pair.Key, pair.Value);
            }
            return connector;
        }

        private IAPIConnector PrepareConnector(string url)
        {
            var connector = new VersionOneAPIConnector(url, proxyProvider: _proxyProvider)
                .WithVersionOneUsernameAndPassword(_username, _password);

            if (_integratedAuth)
                connector.WithWindowsIntegratedAuthentication();

            return PopulateHeaders(connector);
        }
    }
}