using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
	public class VersionOneAPIConnector : IAPIConnector
	{
		#region Credential helpers

		public VersionOneAPIConnector WithVersionOneUsernameAndPassword(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new ArgumentNullException("username");

			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException("password");

			var credential = new NetworkCredential(username, password);
			CacheCredential(credential, "Basic");
			return this;
		}

		public VersionOneAPIConnector WithWindowsIntegratedAuthentication()
		{
			CacheCredential(CredentialCache.DefaultNetworkCredentials, "NTLM");
			CacheCredential(CredentialCache.DefaultNetworkCredentials, "Negotiate");
			return this;
		}

		#endregion

		public string UrlPrefix
		{
			get { return _urlPrefix; }
		}

		private readonly string _urlPrefix;
		private readonly ProxyProvider _proxyProvider;
		private readonly CredentialCache _credentialCache;
		private readonly bool _initializedWithCredentials;
		// TODO: make it private after removing V1APIConnector?
		protected readonly System.Net.ICredentials Credentials;

		public VersionOneAPIConnector(string urlPrefix, System.Net.ICredentials credentials = null, ProxyProvider proxyProvider = null)
		{
			_urlPrefix = urlPrefix;
			_proxyProvider = proxyProvider;
			if (credentials != null)
			{
				_initializedWithCredentials = true;
				Credentials = credentials;
			}
			else
			{
				_credentialCache = new CredentialCache();
				Credentials = _credentialCache;
			}
		}

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

		private CookieContainer _cookieContainer;
		private CookieContainer CookieContainer
		{
			get { return _cookieContainer ?? (_cookieContainer = new CookieContainer()); }
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

		private string _upstreamUserAgent = FormatAssemblyUserAgent(Assembly.GetEntryAssembly());

		public void SetUpstreamUserAgent(string userAgent)
		{
			_upstreamUserAgent = userAgent;
		}

		private string MyUserAgent
		{
			get
			{
				var myAssembly = Assembly.GetAssembly(typeof(VersionOneAPIConnector));
				return FormatAssemblyUserAgent(myAssembly, _upstreamUserAgent);
			}
		}

		private readonly IDictionary<string, string> _customHttpHeaders = new Dictionary<string, string>();

		public IDictionary<string, string> CustomHttpHeaders
		{
			get { return _customHttpHeaders; }
		}

		private HttpWebRequest CreateRequest(string url, string method = "GET", string contenttype = "text/xml")
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = method;
			request.ContentType = contenttype;
			request.Credentials = Credentials;
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

		public void DebugReq(HttpWebRequest req, WebResponse resp)
		{
			if (Config.IsDebugMode)
			{
				var methodtxt = req.Method;
				Debug.WriteLine(string.Empty);
				Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
				Debug.WriteLine("Method: " + req.Method);
				Debug.WriteLine("Request URL: " + req.RequestUri);
				Debug.WriteLine(req.Headers.ToString());
				Debug.WriteLine(req.ToString());
				Debug.WriteLine("Response from: " + resp.ResponseUri);
				Debug.WriteLine("Status Code: " + Convert.ToInt32((resp as HttpWebResponse).StatusCode));
				Debug.WriteLine("Status Name: " + (resp as HttpWebResponse).StatusCode);
				Debug.WriteLine("Status Description: " + (resp as HttpWebResponse).StatusDescription);
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

		private readonly Dictionary<string, MemoryStream> _pendingStreams = new Dictionary<string, MemoryStream>();

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
	}
}
