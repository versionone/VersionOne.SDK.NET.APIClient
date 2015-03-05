using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using log4net;
using VersionOne.SDK.APIClient.Connector.Interfaces;

namespace VersionOne.SDK.APIClient.Connector
{
    public class V1Connector : ICanSetAuthMethod, ICanSetProxyOrApi, ICanAddHeaderOrMakeRequest
    {
        private HttpClient _client;
        private HttpClientHandler _handler;
        private string _endpoint;
        private string _upstreamUserAgent;
        private ILog _log = LogManager.GetLogger(typeof (V1Connector));

        private V1Connector(string versionOneInstanceUrl)
        {
            if (string.IsNullOrWhiteSpace(versionOneInstanceUrl))
                throw new ArgumentNullException("versionOneInstanceUrl");
            _handler = new HttpClientHandler();
            _client = new HttpClient(_handler) {BaseAddress = new Uri(versionOneInstanceUrl)};
            _upstreamUserAgent = FormatAssemblyUserAgent(Assembly.GetEntryAssembly());
        }

        public static ICanSetAuthMethod CreateConnector(string versionOneInstanceUrl)
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

        public ICanSetApi WithProxy(ProxyProvider proxyProvider)
        {
            _handler.Proxy = proxyProvider.CreateWebProxy();

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseMetaApi()
        {
            _endpoint = "meta.v1/";

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseDataApi()
        {
            _endpoint = "rest-1.v1/Data/";

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseHistoryApi()
        {
            _endpoint = "rest-1.v1/Hist/";

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseNewApi()
        {
            _endpoint = "rest-1.v1/";

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseQueryApi()
        {
            _endpoint = "query.v1/";

            return this;
        }

        public ICanAddHeaderOrMakeRequest UseEndpoint(string endpoint)
        {
            _endpoint = endpoint;

            return this;
        }

        public ICanMakeRequest WithUserAgentHeader(string name, string version)
        {
            _client.DefaultRequestHeaders.Add(name, version);

            return this;
        }

        public Stream GetData(string resource = null)
        {
            ConfigureRequest();
            var response = _client.GetAsync(GetResourceUrl(resource)).Result;
            var result = response.Content.ReadAsStreamAsync().Result;
            LogResponse(response, result.ToString());

            return result;
        }

        public Stream SendData(object data, string resource = null, RequestFormat requestFormat = RequestFormat.Xml)
        {
            ConfigureRequest();
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
            var response = _client.PostAsync(GetResourceUrl(resource), content).Result;
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

        private string ValidateResource(string resource)
        {
            var result = string.Empty;
            if (resource != null && !resource.StartsWith("/"))
            {
                result = "/" + resource;
            }

            return result;
        }

        private void ConfigureRequest()
        {
            _handler.PreAuthenticate = true;
            _handler.AllowAutoRedirect = true;
            _client.DefaultRequestHeaders.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
            _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
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
