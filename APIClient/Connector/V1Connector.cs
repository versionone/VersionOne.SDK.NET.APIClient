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

namespace VersionOne.SDK.APIClient
{
    public class V1Connector
    {
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
            if (Uri.TryCreate(instanceUrl, UriKind.Absolute, out baseAddress))
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
        /// Required method for setting the URL of the V1 instance.
        /// </summary>
        /// <param name="versionOneInstanceUrl"></param>
        /// <returns></returns>
        public static ICanSetUserAgentHeader WithInstanceUrl(string versionOneInstanceUrl)
        {
            return new Builder(versionOneInstanceUrl);
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

        public Stream SendData(string resource = null, object data = null, RequestFormat requestFormat = RequestFormat.Xml)
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
            var stringData = data != null ? data.ToString() : string.Empty;
            var content = new StringContent(stringData, Encoding.UTF8);
            var resourceUrl = GetResourceUrl(resource);
            var response = _client.PostAsync(resourceUrl, content).Result;
            ThrowWebExceptionIfNeeded(response);
            var result = response.Content.ReadAsStreamAsync().Result;
            LogResponse(response, result.ToString(), stringData);

            return result;
        }

        public void SetUpstreamUserAgent(string userAgent)
        {
            _upstreamUserAgent = userAgent;
        }

        private string GetResourceUrl(string resource)
        {
            if (string.IsNullOrWhiteSpace(_endpoint))
                throw new V1Exception("V1Connector is not properly configured. There is no API or endpoint selected.");

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

        #region Fluent Builder

        private class Builder : ICanSetUserAgentHeader, ICanSetApi, ICanSetAuthMethod, ICanSetProxyOrGetConnector
        {
            private const string MetaApiEndpoint = "meta.v1/";
            private const string DataApiEndpoint = "rest-1.v1/Data/";
            private const string HistoryApiEndpoint = "rest-1.v1/Hist/";
            private const string NewApiEndpoint = "rest-1.v1/New";
            private const string QueryApiEndpoint = "query.v1/";
            private readonly V1Connector _instance;

            public Builder(string versionOneInstanceUrl)
            {
                _instance = new V1Connector(versionOneInstanceUrl);
            }

            public ICanSetApi WithUserAgentHeader(string name, string version)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException("name");
                if (string.IsNullOrWhiteSpace(version))
                    throw new ArgumentNullException("version");

                _instance._client.DefaultRequestHeaders.Add(name, version);

                return this;
            }

            public ICanSetProxyOrGetConnector UseMetaApi()
            {
                _instance._endpoint = MetaApiEndpoint;

                return this;
            }

            public ICanSetAuthMethod UseDataApi()
            {
                _instance._endpoint = DataApiEndpoint;

                return this;
            }

            public ICanSetAuthMethod UseHistoryApi()
            {
                _instance._endpoint = HistoryApiEndpoint;

                return this;
            }

            public ICanSetAuthMethod UseNewApi()
            {
                _instance._endpoint = NewApiEndpoint;

                return this;
            }

            public ICanSetAuthMethod UseQueryApi()
            {
                _instance._endpoint = QueryApiEndpoint;

                return this;
            }

            public ICanSetAuthMethod UseEndpoint(string endpoint)
            {
                if (string.IsNullOrWhiteSpace(endpoint))
                    throw new ArgumentNullException("endpoint");

                _instance._endpoint = endpoint;

                return this;
            }

            public ICanSetProxyOrGetConnector WithUsernameAndPassword(string username, string password)
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentNullException("username");
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("password");

                _instance._handler.Credentials = new NetworkCredential(username, password);

                return this;
            }

            public ICanSetProxyOrGetConnector WithWindowsIntegrated()
            {
                var credentialCache = new CredentialCache
                {
                    {_instance._client.BaseAddress, "NTLM", CredentialCache.DefaultNetworkCredentials},
                    {_instance._client.BaseAddress, "Negotiate", CredentialCache.DefaultNetworkCredentials}
                };
                _instance._handler.Credentials = credentialCache;

                return this;
            }

            public ICanSetProxyOrGetConnector WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password)
            {
                if (string.IsNullOrWhiteSpace(fullyQualifiedDomainUsername))
                    throw new ArgumentNullException("fullyQualifiedDomainUsername");
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("password");

                _instance._handler.Credentials = new NetworkCredential(fullyQualifiedDomainUsername, password);

                return this;
            }

            public ICanSetProxyOrGetConnector WithAccessToken(string accessToken)
            {
                if (string.IsNullOrWhiteSpace(accessToken))
                    throw new ArgumentNullException("accessToken");

                _instance._client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                return this;
            }

            public ICanSetProxyOrGetConnector WithOAuth2Token(string accessToken)
            {
                if (string.IsNullOrWhiteSpace(accessToken))
                    throw new ArgumentNullException("accessToken");

                //TODO: add logic to authenticate with OAuth2

                return this;
            }

            public ICanGetConnector WithProxy(ProxyProvider proxyProvider)
            {
                if (proxyProvider == null)
                    throw new ArgumentNullException("proxyProvider");

                _instance._handler.Proxy = proxyProvider.CreateWebProxy();

                return this;
            }

            public V1Connector Build()
            {
                return _instance;
            }
        }

        #endregion
    }

    public enum RequestFormat
    {
        Xml = 0, Json = 1
    }

    #region Interfaces

    public interface ICanSetUserAgentHeader
    {
        /// <summary>
        /// Required method for setting a custom user agent header.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        ICanSetApi WithUserAgentHeader(string name, string version);
    }

    public interface ICanSetApi
    {
        /// <summary>
        /// For connecting to meta.v1 endpoint.
        /// </summary>
        /// <returns></returns>
        ICanSetProxyOrGetConnector UseMetaApi();

        /// <summary>
        /// For connecting to rest-1.v1/Data endpoint.
        /// </summary>
        /// <returns></returns>
        ICanSetAuthMethod UseDataApi();

        /// <summary>
        /// For connecting to rest-1.v1/Hist endpoint.
        /// </summary>
        /// <returns></returns>
        ICanSetAuthMethod UseHistoryApi();

        /// <summary>
        /// For connecting to rest-1.v1/New endpoint.
        /// </summary>
        /// <returns></returns>
        ICanSetAuthMethod UseNewApi();

        /// <summary>
        /// For connecting to query.v1 endpoint
        /// </summary>
        /// <returns></returns>
        ICanSetAuthMethod UseQueryApi();

        /// <summary>
        /// For connecting to a user specified endpoint.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        ICanSetAuthMethod UseEndpoint(string endpoint);
    }

    public interface ICanSetAuthMethod
    {
        /// <summary>
        /// Optional method for setting the username and password for authentication.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrGetConnector WithUsernameAndPassword(string username, string password);

        /// <summary>
        /// Optional method for setting the Windows Integrated Authentication credentials.
        /// The currently logged in users credentials are used.
        /// </summary>
        /// <returns></returns>
        ICanSetProxyOrGetConnector WithWindowsIntegrated();

        /// <summary>
        /// Optional method for setting the Windows Integrated Authentication credentials.
        /// The fully qualified domain name will be in form "DOMAIN\username".
        /// </summary>
        /// <param name="fullyQualifiedDomainUsername"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ICanSetProxyOrGetConnector WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password);

        /// <summary>
        /// Optional method for setting the access token for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrGetConnector WithAccessToken(string accessToken);

        /// <summary>
        /// Optional method for setting the OAuth2 access token for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        ICanSetProxyOrGetConnector WithOAuth2Token(string accessToken);
    }

    public interface ICanGetConnector
    {
        /// <summary>
        /// Required terminating method that returns the V1Connector object.
        /// </summary>
        /// <returns></returns>
        V1Connector Build();
    }

    public interface ICanSetProxyOrGetConnector : ICanGetConnector
    {
        /// <summary>
        /// Optional method for setting the proxy credentials.
        /// </summary>
        /// <param name="proxyProvider"></param>
        /// <returns></returns>
        ICanGetConnector WithProxy(ProxyProvider proxyProvider);
    }

    #endregion
}
