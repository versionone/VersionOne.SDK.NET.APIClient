using System;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient {
    public class V1ConnectionValidator {
        private readonly string connectionUrl;
        private readonly string username;
        private readonly string password;
        private readonly bool integratedAuth;
        private readonly IDictionary<string, string> customHttpHeaders = new Dictionary<string, string>();

        private readonly ProxyProvider proxyProvider = null;

        public V1ConnectionValidator(string connectionUrl, string username, string password, bool integratedAuth) {
            this.connectionUrl = connectionUrl;

            if(this.connectionUrl == null) {
                this.connectionUrl = string.Empty;
            } else if(!this.connectionUrl.EndsWith("/")) {
                this.connectionUrl += "/";
            }

            this.username = username;
            this.password = password;
            this.integratedAuth = integratedAuth;
        }

        public V1ConnectionValidator(string connectionUrl, string username, string password, bool integratedAuth, ProxyProvider proxyProvider)
            : this(connectionUrl, username, password, integratedAuth) {
            this.proxyProvider = proxyProvider;
        }

        /// <summary>
        /// Headers from this Dictionary will be added to all HTTP requests to VersionOne server.
        /// </summary>
        public IDictionary<string, string> CustomHttpHeaders {
            get { return customHttpHeaders; }
        }

        public void Test() {
            Test(null);
        }

        public void Test(string version) {
            try {
                CheckConnection();
                CheckVersion(version);
                CheckAuthentication();
            } catch(ConnectionException) {
                throw;
            } catch(System.Net.WebException ex) {
                throw new ConnectionException("Connection Check: " + ex.Message, ex);
            }
        }

        public void CheckConnection() {
            IAPIConnector connector = PrepareConnector(connectionUrl + "loc.v1/?Member");
            
            try {
                connector.GetData().Close();
            } catch(System.Net.WebException ex) {
                throw new ConnectionException("Application not found at the URL: " + connectionUrl, ex);
            }
        }

        public void CheckVersion(string version) {
            var meta = CreateMetaModel();
            meta.GetAssetType("Member");

            if(!string.IsNullOrEmpty(version) && (meta.Version == null || meta.Version < new Version(version))) {
                throw new ConnectionException(string.Format(
                    "VersionOne Release {0} or above is required (found {1}).", version, meta.Version));
            }
        }

        private MetaModel CreateMetaModel() {
            return new MetaModel(PrepareConnector(connectionUrl + "meta.v1/"), false);
        }

        public void CheckAuthentication() {
            IServices services = new Services(CreateMetaModel(), PrepareConnector(connectionUrl + "rest-1.v1/"));
            Oid loggedin;

            try {
                loggedin = services.LoggedIn;
            } catch(System.Net.WebException ex) {
                throw new ConnectionException("Unable to log in. Incorrect username or password.", ex);
            }

            if(loggedin.IsNull) {
                throw new ConnectionException("Unable to retrieve logged in member.");
            }
        }

        private V1APIConnector PopulateHeaders(V1APIConnector connector) {
            IDictionary<string, string> dict = connector.CustomHttpHeaders;
            foreach(KeyValuePair<string, string> pair in customHttpHeaders) {
                dict.Add(pair.Key, pair.Value);
            }
            return connector;
        }

        private V1APIConnector PrepareConnector(string url) {
            var connector = new V1APIConnector(url, username, password, integratedAuth, proxyProvider);
            return PopulateHeaders(connector);
        }
    }
}