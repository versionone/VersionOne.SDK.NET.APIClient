using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using OAuth2Client;
using OAuth2Client.Extensions;


namespace VersionOne.SDK.APIClient
{
	public class V1OAuth2APIConnector : IAPIConnector
	{
		private readonly string url;
		private readonly OAuth2Client.IStorage _storage;
		private CookieContainer cookieContainer;
		private OAuth2Client.Credentials _creds;
		private OAuth2Client.Secrets _secrets;
		private string _callerUserAgent = "";

		private const string EndpointScope="apiv1";
 
		private readonly ProxyProvider proxyProvider;

		private CookieContainer CookieContainer
		{
			get { return cookieContainer ?? (cookieContainer = new CookieContainer()); }
		}

		public void SetCallerUserAgent(string userAgent)
		{
			_callerUserAgent = userAgent;
		}


		public V1OAuth2APIConnector(string url)
			: this(url, OAuth2Client.Storage.JsonFileStorage.Default)
		{
		}

		public V1OAuth2APIConnector(string url, IStorage storage)
		{
			this.url = url;
			_storage = storage;
			RefreshCreds();
		}

		public V1OAuth2APIConnector(string url, ProxyProvider proxyProvider = null)
			: this(url)
		{
			this.proxyProvider = proxyProvider;
		}


		public V1OAuth2APIConnector(string url, IStorage storage, ProxyProvider proxyProvider=null)
			: this(url, storage)
		{
			this.proxyProvider = proxyProvider;
		}

		private void RefreshCreds()
		{
			_secrets = _storage.GetSecrets();
			_creds = _storage.GetCredentials();
		}

		private void AddBearer(HttpWebRequest request)
		{
			request.Headers["Authorization"] =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _creds.AccessToken).ToString();
		}

		public static System.Reflection.AssemblyName MyAssemblyName =
			System.Reflection.Assembly.GetAssembly(typeof(V1APIConnector)).GetName();

		private string MyUserAgent
		{
			get
			{
				return String.Format("{0}/{1} ({2}, client_id={3}) {4}", MyAssemblyName.Name, MyAssemblyName.Version,
												MyAssemblyName.FullName, _secrets.client_id, _callerUserAgent);
			}
		}

		private HttpWebRequest CreateRequest(string path)
		{
			var request = (HttpWebRequest)WebRequest.Create(path);
			AddBearer(request);
			if (proxyProvider != null)
			{
				request.Proxy = proxyProvider.CreateWebProxy();
			}

			request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
			request.UserAgent = MyUserAgent;
			foreach (var pair in customHttpHeaders)
			{
				request.Headers.Add(pair.Key, pair.Value);
			}

			request.CookieContainer = CookieContainer;
			request.UnsafeAuthenticatedConnectionSharing = true;
			return request;
		}

		public Stream HttpGet(string path, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
		{
			var req = CreateRequest(path);
			req.ContentType = contentType;
			req.Method = "GET";
			try
			{
				var resp = req.GetResponse();

				if (Config.IsDebugMode)
				{
					Debug.WriteLine(string.Empty);
					Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
					Debug.WriteLine("Get....");
					Debug.WriteLine("URL: " + url + path);
					Debug.WriteLine("Response from: " + resp.ResponseUri);
					Debug.WriteLine(resp.Headers.ToString());
					Debug.WriteLine(resp.ToString());
					Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
					Debug.WriteLine(string.Empty);
				}


				return resp.GetResponseStream();
			}
			catch (WebException ex)
			{
				var resp = (HttpWebResponse)ex.Response;
				if (refreshTokenIfNeeded && ex.Status == WebExceptionStatus.ProtocolError && resp.StatusCode == HttpStatusCode.Unauthorized)
				{
					var authclient = new OAuth2Client.AuthClient(_secrets, EndpointScope);
					_creds = authclient.refreshAuthCode(_creds);
					_creds = _storage.StoreCredentials(_creds);
					return HttpGet(path, refreshTokenIfNeeded: false);
				}
				throw;
			}
		}

		public Stream HttpPost(string path, byte[] body, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
		{
			var req = CreateRequest(path);
			req.Method = "POST";
			req.ContentType = contentType;
			if (Config.IsDebugMode)
			{
				Debug.WriteLine(string.Empty);
				Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
				Debug.WriteLine("POST....");
				Debug.WriteLine("URL: " + url + path);
				Debug.WriteLine(req.Headers.ToString());
				Debug.WriteLine(body);
				Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
				Debug.WriteLine("");
			}
			try
			{
				req.ContentLength = body.Length;
				req.GetRequestStream().Write(body, 0, body.Length);
				var resp = req.GetResponse();
				return resp.GetResponseStream();
			}
			catch (WebException ex)
			{
				var resp = (HttpWebResponse)ex.Response;
				if (refreshTokenIfNeeded && ex.Status == WebExceptionStatus.ProtocolError && resp.StatusCode == HttpStatusCode.Unauthorized)
				{
					var authclient = new OAuth2Client.AuthClient(_secrets, EndpointScope);
					_creds = authclient.refreshAuthCode(_creds);
					_creds = _storage.StoreCredentials(_creds);
					return HttpPost(path, body, refreshTokenIfNeeded: false);
				}
				throw;
			}
		}

		public Stream GetData()
		{
			return GetData(string.Empty);
		}

		public Stream GetData(string path)
		{
			return HttpGet(url + path);
		}

		public Stream SendData(string path, string data)
		{
			return HttpPost(url + path, System.Text.Encoding.UTF8.GetBytes(data));
		}

		public Stream BeginRequest(string path)
		{
			var stream = new MemoryStream();
			_pendingStreams[path] = stream;
			return stream;
		}

		public Stream EndRequest(string path, string contentType)
		{
			var inputstream = _pendingStreams[path];
			var body = inputstream.ToArray();
			return HttpPost(path, body, contentType: contentType);
		}

		private readonly IDictionary<string, HttpWebRequest> requests = new Dictionary<string, HttpWebRequest>();
		private readonly IDictionary<string, string> customHttpHeaders = new Dictionary<string, string>();
		private readonly Dictionary<string, MemoryStream> _pendingStreams = new Dictionary<string, MemoryStream>();


		/// <summary>
		/// Headers from this Dictionary will be added to all HTTP requests to VersionOne server.
		/// </summary>
		public IDictionary<string, string> CustomHttpHeaders
		{
			get { return customHttpHeaders; }
		}
	}
}