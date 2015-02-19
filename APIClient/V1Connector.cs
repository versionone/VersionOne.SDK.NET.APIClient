using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;

namespace VersionOne.SDK.APIClient
{
    public class V1Connector : IAPIConnector
    {
        private string _urlPrefix;
        private CookieContainer _cookieContainer;
        private string _upstreamUserAgent = FormatAssemblyUserAgent(Assembly.GetEntryAssembly());
        private readonly IDictionary<string, string> _customHttpHeaders = new Dictionary<string, string>();
        private readonly Dictionary<string, MemoryStream> _pendingStreams = new Dictionary<string, MemoryStream>();
		private ProxyProvider _proxyProvider;
		private readonly CredentialCache _credentialCache;
		private readonly bool _initializedWithCredentials;
		private readonly System.Net.ICredentials _credentials;
        private string _accessToken;
        

        public string UrlPrefix
		{
			get { return _urlPrefix; }
		}

        private CookieContainer CookieContainer
        {
            get { return _cookieContainer ?? (_cookieContainer = new CookieContainer()); }
        }

        private string MyUserAgent
		{
			get
			{
				var myAssembly = Assembly.GetAssembly(typeof(VersionOneAPIConnector));
				return FormatAssemblyUserAgent(myAssembly, _upstreamUserAgent);
			}
		}
        
		public IDictionary<string, string> CustomHttpHeaders
		{
			get { return _customHttpHeaders; }
		}

        #region Constructors

        public V1Connector(string urlPrefix, System.Net.ICredentials credentials = null, ProxyProvider proxyProvider = null)
        {
            _urlPrefix = urlPrefix;
            _proxyProvider = proxyProvider;
            if (credentials != null)
            {
                _initializedWithCredentials = true;
                _credentials = credentials;
            }
            else
            {
                _credentialCache = new CredentialCache();
                _credentials = _credentialCache;
            }
        }

        public V1Connector(string urlPrefix, string accessToken, ProxyProvider proxy = null)
            : this(urlPrefix, new CredentialCache(), proxy)
        {
            _accessToken = accessToken;
        }

        #endregion Constructors

        #region Fluent Helpers

        public V1Connector WithVersionOneUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("username");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            var credential = new NetworkCredential(username, password);
            CacheCredential(credential, "Basic");

            return this;
        }
        
        public V1Connector WithWindowsIntegratedAuthentication()
        {
            CacheCredential(CredentialCache.DefaultNetworkCredentials, "NTLM");
            CacheCredential(CredentialCache.DefaultNetworkCredentials, "Negotiate");

            return this;
        }

        public V1Connector WithAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException("accessToken");
            
            _accessToken = accessToken;

            return this;
        }

        public V1Connector WithProxy(ProxyProvider proxyProvider)
        {
            if (proxyProvider == null)
                throw new ArgumentNullException("proxyProvider");

            _proxyProvider = proxyProvider;

            return this;
        }

        public V1Connector UseMetaAPI()
        {
            if (string.IsNullOrEmpty(_urlPrefix))
                throw new InvalidOperationException("Url prefix not set.");

            _urlPrefix += "meta.v1/";

            return this;
        }

        public V1Connector UseDataAPI()
        {
            if (string.IsNullOrEmpty(_urlPrefix))
                throw new InvalidOperationException("Url prefix not set.");

            _urlPrefix += "rest-1.v1/Data/";

            return this;
        }

        public V1Connector UseHistoryAPI()
        {
            if (string.IsNullOrEmpty(_urlPrefix))
                throw new InvalidOperationException("Url prefix not set.");

            _urlPrefix += "rest-1.v1/Hist/";

            return this;
        }

        public V1Connector UseQueryAPI()
        {
            if (string.IsNullOrEmpty(_urlPrefix))
                throw new InvalidOperationException("Url prefix not set.");

            _urlPrefix += "query.v1/";

            return this;
        }

        #endregion Fluent Helpers

        public void CacheCredential(NetworkCredential credential, string authType)
		{
			if (credential == null)
				throw new ArgumentNullException("credential");

			if (string.IsNullOrWhiteSpace(authType))
				throw new ArgumentNullException("authType");

			if (_initializedWithCredentials)
				throw new InvalidOperationException(
					"Cannot cache an additional credential when you have already constructed this connector with an ICredentials instance. If you supplied your own CredentialCache, then add the credential to that instance instead.");

			_credentialCache.Add(new Uri(_urlPrefix), authType, credential);
		}

        public void SetUpstreamUserAgent(string userAgent)
        {
            _upstreamUserAgent = userAgent;
        }

        public void DebugReq(HttpWebRequest req, WebResponse resp)
        {
            if (Config.IsDebugMode)
            {
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
                Debug.WriteLine("Method: " + req.Method);
                Debug.WriteLine("Request URL: " + req.RequestUri);
                Debug.WriteLine(req.Headers.ToString());
                Debug.WriteLine(req.ToString());
                Debug.WriteLine("Response from: " + resp.ResponseUri);
                var httpWebResponse = resp as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    Debug.WriteLine("Status Description: " + httpWebResponse.StatusDescription);
                    Debug.WriteLine("Status Code: " + Convert.ToInt32(httpWebResponse.StatusCode));
                    Debug.WriteLine("Status Name: " + httpWebResponse.StatusCode);
                }
                else
                {
                    Debug.WriteLine("Status Description: null");
                    Debug.WriteLine("Status Code: null");
                    Debug.WriteLine("Status Name: null");
                }
                Debug.WriteLine(resp.Headers.ToString());
                Debug.WriteLine(resp.ToString());
                Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Debug.WriteLine(string.Empty);
            }
        }

        public Stream HttpGet(string apipath, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
        {
            var url = _urlPrefix + apipath;
            var req = CreateRequest(url, "GET", contentType);
            var resp = req.GetResponse();
            DebugReq(req, resp);
            return resp.GetResponseStream();
        }

        public Stream HttpPost(string apipath, byte[] body, string contentType = "text/xml")
        {
            var url = _urlPrefix + apipath;
            var req = CreateRequest(url, "POST", contentType);
            req.ContentLength = body.Length;
            req.GetRequestStream().Write(body, 0, body.Length);
            var resp = req.GetResponse();
            DebugReq(req, resp);
            return resp.GetResponseStream();
        }

        public Stream GetData()
        {
            return GetData(string.Empty);
        }

        public Stream GetData(string apipath)
        {
            return HttpGet(apipath);
        }

        public Stream SendData(string apipath, string data)
        {
            return HttpPost(apipath, System.Text.Encoding.UTF8.GetBytes(data));
        }

        public Stream BeginRequest(string apipath)
        {
            var stream = new MemoryStream();
            _pendingStreams[apipath] = stream;
            return stream;
        }

        public Stream EndRequest(string apipath, string contentType)
        {
            var inputstream = _pendingStreams[apipath];
            _pendingStreams.Remove(apipath);
            var body = inputstream.ToArray();
            return HttpPost(apipath, body, contentType: contentType);
        }

		private static string FormatAssemblyUserAgent(Assembly a, string upstream = null)
		{
			if (a == null) return null;
			var n = a.GetName();
			var s = String.Format("{0}/{1} ({2})", n.Name, n.Version, n.FullName);
			if (!String.IsNullOrEmpty(upstream))
				s = s + " " + upstream;
			return s;
		}
        
        private HttpWebRequest CreateRequest(string url, string method = "GET", string contenttype = "text/xml")
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = method;
			request.ContentType = contenttype;
			request.Credentials = _credentials;
			request.PreAuthenticate = true;
			request.AllowAutoRedirect = true;

			if (_proxyProvider != null)
			{
				request.Proxy = _proxyProvider.CreateWebProxy();
			}

			request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
			request.UserAgent = MyUserAgent;
			foreach (var pair in _customHttpHeaders)
			{
				request.Headers.Add(pair.Key, pair.Value);
			}

			request.CookieContainer = CookieContainer;
			request.UnsafeAuthenticatedConnectionSharing = true;
			return request;
		}
	}
}
