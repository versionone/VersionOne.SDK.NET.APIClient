using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;
using log4net;
using VersionOne.SDK.APIClient.Connector.Interfaces;
using VersionOne.SDK.APIClient.Model;

namespace VersionOne.SDK.APIClient.Connector
{
    public class V1Connector : ICanSetAuthMethodOrApi, ICanSetProxyOrApi, ICanAddHeaderOrMakeRequest
    {
        private const string MetaApiEndpoint = "meta.v1/";
        private const string DataApiEndpoint = "rest-1.v1/Data/";
        private const string HistoryApiEndpoint = "rest-1.v1/Hist/";
        private const string NewApiEndpoint = "rest-1.v1/New";
        private const string QueryApiEndpoint = "query.v1/";

        private readonly HttpClient _client;
        private readonly HttpClientHandler _handler;
        private readonly ILog _log = LogManager.GetLogger(typeof(V1Connector));
        private string _endpoint;
        private string _upstreamUserAgent;
        
        private bool _isRequestConfigured = false;

        private V1Connector(string instanceUrl)
        {
            if (string.IsNullOrWhiteSpace(instanceUrl))
                throw new ArgumentNullException("instanceUrl");
            if (!instanceUrl.EndsWith("/"))
                instanceUrl += "/";

            Uri baseAddress;
            if (Uri.TryCreate(instanceUrl, UriKind.RelativeOrAbsolute, out baseAddress))
            {
                _handler = new HttpClientHandler();
                _client = new HttpClient(_handler) {BaseAddress = baseAddress};
                _upstreamUserAgent = FormatAssemblyUserAgent(Assembly.GetEntryAssembly());
            }
            else
            {
                throw new V1Exception("Instance url is not valid.");
            }
        }

        /// <summary>
        /// Primary constructor for the class, takes the URL of the V1 instance.
        /// </summary>
        /// <param name="versionOneInstanceUrl"></param>
        /// <returns></returns>
        public static ICanSetAuthMethodOrApi CreateConnector(string versionOneInstanceUrl)
        {
            return new V1Connector(versionOneInstanceUrl);
        }

        public ICanSetProxyOrApi WithUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("username");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            _handler.Credentials = new NetworkCredential(username, password);

            return this;
        }

        public ICanSetProxyOrApi WithAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException("accessToken");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            return this;
        }

        public ICanSetProxyOrApi WithWindowsIntegrated()
        {
            var credentialCache = new CredentialCache
            {
                {_client.BaseAddress, "NTLM", CredentialCache.DefaultNetworkCredentials},
                {_client.BaseAddress, "Negotiate", CredentialCache.DefaultNetworkCredentials}
            };
            _handler.Credentials = credentialCache;

            return this;
        }

        public ICanSetProxyOrApi WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password)
        {
            if (string.IsNullOrWhiteSpace(fullyQualifiedDomainUsername))
                throw new ArgumentNullException("fullyQualifiedDomainUsername");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            _handler.Credentials = new NetworkCredential(fullyQualifiedDomainUsername, password);

            return this;
        }

        public ICanSetApi WithProxy(ProxyProvider proxyProvider)
        {
            if (proxyProvider == null)
                throw new ArgumentNullException("proxyProvider");

            _handler.Proxy = proxyProvider.CreateWebProxy();

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseMetaApi()
        {
            _endpoint = MetaApiEndpoint;

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseDataApi()
        {
            _endpoint = DataApiEndpoint;

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseHistoryApi()
        {
            _endpoint = HistoryApiEndpoint;

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseNewApi()
        {
            _endpoint = NewApiEndpoint;

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseQueryApi()
        {
            _endpoint = QueryApiEndpoint;

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseEndpoint(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentNullException("endpoint");

            _endpoint = endpoint;

            return this;
        }

        public ICanMakeRequest SetUserAgentHeader(string name, string version)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException("version");

            _client.DefaultRequestHeaders.Add(name, version);

            return this;
        }

        public Stream GetData(string resource = null)
        {
            ConfigureRequestIfNeeded();
            var resourceUrl = GetResourceUrl(resource);
            var response = _client.GetAsync(resourceUrl).Result;
            ThrowWebExceptionIfNeeded(response);
            var result = response.Content.ReadAsStreamAsync().Result;
            LogResponse(response, result.ToString());

            return result;
        }

        public Stream SendData(object data, string resource = null, RequestFormat requestFormat = RequestFormat.Xml)
        {
            ConfigureRequestIfNeeded();
            switch (requestFormat)
            {
                case RequestFormat.Json:
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                    break;
                default:
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml")); 
                    break;
            }
            var content = new StringContent(data.ToString(), Encoding.UTF8);
            var resourceUrl = GetResourceUrl(resource);
            var response = _client.PostAsync(resourceUrl, content).Result;
            ThrowWebExceptionIfNeeded(response);
            var result = response.Content.ReadAsStreamAsync().Result;
            LogResponse(response, result.ToString(), data.ToString());

            return result;
        }

        public void SetUpstreamUserAgent(string userAgent)
        {
            _upstreamUserAgent = userAgent;
        }

        private string GetResourceUrl(string resource)
        {
            return _endpoint + ValidateResource(resource);
        }

        private void ThrowWebExceptionIfNeeded(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var statusCode = Convert.ToInt32(response.StatusCode);
                var message = string.Format("The remote server returned an error: ({0}) {1}.", statusCode,
                    HttpWorkerRequest.GetStatusDescription(statusCode));
                throw new WebException(message);
            }
        }

        private string ValidateResource(string resource)
        {
            var result = string.Empty;
            if (resource != null && !resource.StartsWith("/"))
            {
                result = "/" + resource;
            }

            return result;
        }

        private void ConfigureRequestIfNeeded()
        {
            if (!_isRequestConfigured)
            {
                _handler.PreAuthenticate = true;
                _handler.AllowAutoRedirect = true;
                _client.DefaultRequestHeaders.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
                _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                _isRequestConfigured = true;
            }
        }

        private string UserAgent
        {
            get
            {
                var assembly = Assembly.GetAssembly(typeof(V1Connector));

                return FormatAssemblyUserAgent(assembly, _upstreamUserAgent);
            }
        }

        private string FormatAssemblyUserAgent(Assembly a, string upstream = null)
        {
            if (a == null) return null;
            var n = a.GetName();
            var s = String.Format("{0}/{1} ({2})", n.Name, n.Version, n.FullName);
            if (!String.IsNullOrEmpty(upstream))
                s = s + " " + upstream;
            return s;
        }
        
        private void LogRequest(HttpRequestMessage rm, string requestBody)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("REQUEST");
            stringBuilder.AppendLine("\tMethod: " + rm.Method);
            stringBuilder.AppendLine("\tRequest URL: " + rm.RequestUri);
            stringBuilder.AppendLine("\tHeaders: ");
            foreach (var header in rm.Headers)
            {
                stringBuilder.AppendLine("\t\t" + header.Key + "=" + header.Value);
            }
            stringBuilder.AppendLine("\tBody: ");
            stringBuilder.AppendLine("\t\t" + requestBody);

            _log.Info(stringBuilder.ToString());
        }

        private void LogResponse(HttpResponseMessage resp, string responseBody, string requestBody = "")
        {
            LogRequest(resp.RequestMessage, requestBody);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("RESPONSE");
            stringBuilder.AppendLine("\tStatus code: " + resp.StatusCode);
            stringBuilder.AppendLine("\tHeaders: ");
            foreach (var header in resp.Headers)
            {
                stringBuilder.AppendLine("\t\t" + header.Key + "=" + header.Value);
            }
            stringBuilder.AppendLine("\tBody: ");
            stringBuilder.AppendLine("\t\t" + responseBody);

            _log.Info(stringBuilder.ToString());
        }
    }

    public enum RequestFormat
    {
        Xml = 0, Json = 1
    }
}
