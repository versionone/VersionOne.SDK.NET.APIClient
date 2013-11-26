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
		private readonly string _urlPrefix;
		private readonly IStorage _storage;
		private CookieContainer _cookieContainer;
		private OAuth2Client.Credentials _creds;
		private OAuth2Client.Secrets _secrets;
		private string _callerUserAgent = "";

		private const string EndpointScope="apiv1";
 
		private readonly ProxyProvider _proxyProvider;

		private CookieContainer CookieContainer
		{
			get { return _cookieContainer ?? (_cookieContainer = new CookieContainer()); }
		}

		public void SetCallerUserAgent(string userAgent)
		{
			_callerUserAgent = userAgent;
		}


		public V1OAuth2APIConnector(string urlPrefix, IStorage storage = null, ProxyProvider proxy = null)
		{
			_urlPrefix = urlPrefix;
			_storage = storage ?? OAuth2Client.Storage.JsonFileStorage.Default;
			_proxyProvider = proxy;
			ReadSecretsAndCreds();
		}

		private void ReadSecretsAndCreds()
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

		private HttpWebRequest CreateRequest(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			AddBearer(request);
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

		public Stream HttpGet(string apipath, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
		{
			var url = _urlPrefix + apipath;
			var req = CreateRequest(url);
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
					Debug.WriteLine("URL: " + url);
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
					var proxy = _proxyProvider != null ? _proxyProvider.CreateWebProxy() : null;
					var authclient = new OAuth2Client.AuthClient(_secrets, EndpointScope, proxy, null);
					_creds = authclient.refreshAuthCode(_creds);
					_creds = _storage.StoreCredentials(_creds);
					return HttpGet(apipath, refreshTokenIfNeeded: false);
				}
				throw;
			}
		}

		public Stream HttpPost(string apipath, byte[] body, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
		{
			var url = _urlPrefix + apipath;
			var req = CreateRequest(url);
			req.Method = "POST";
			req.ContentType = contentType;
			if (Config.IsDebugMode)
			{
				Debug.WriteLine(string.Empty);
				Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
				Debug.WriteLine("POST....");
				Debug.WriteLine("URL: " + url);
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
				if (refreshTokenIfNeeded && ShouldRefresh(ex))
				{
					var proxy = _proxyProvider != null ? _proxyProvider.CreateWebProxy() : null;
					var authclient = new OAuth2Client.AuthClient(_secrets, EndpointScope, proxy, null);
					_creds = authclient.refreshAuthCode(_creds);
					_creds = _storage.StoreCredentials(_creds);
					return HttpPost(apipath, body, refreshTokenIfNeeded: false);
				}
				throw;
			}
		}

		private List<HttpStatusCode> CodesToRefresh = new List<HttpStatusCode>
			{
				HttpStatusCode.BadRequest,
				HttpStatusCode.Forbidden,
				HttpStatusCode.MethodNotAllowed,
				HttpStatusCode.Unauthorized
			};

		private bool isV1WithBrokenBearer(HttpWebResponse response)
		{
			var v1 = response.Headers["VersionOne"];
			if (string.IsNullOrEmpty(v1)) return false;
			var re = new System.Text.RegularExpressions.Regex(@"(.*)/(\d+).(\d+).(\d+).(\d+); (.*)");
			var match = re.Match(v1);
			if (match.Success)
			{
				var edition = match.Groups[0].Value;
				var major = Int32.Parse(match.Groups[1].Value);
				var minor = Int32.Parse(match.Groups[2].Value);
				var release = Int32.Parse(match.Groups[3].Value);
				var patch = Int32.Parse(match.Groups[4].Value);
				var lexicon = match.Groups[4].Value;
				if (major < 13) return true;
				if (major == 13 && minor <= 3) return true;
			}
			return false;
		}

		private bool ShouldRefresh(WebException ex)
		{
			var response = ex.Response as HttpWebResponse;
			if (response != null)
			{
				if (isV1WithBrokenBearer(response))
				{
					if (CodesToRefresh.Contains(response.StatusCode))
					{
						return true;
					}
				}
				else
				{
					if (CodesToRefresh.Contains(response.StatusCode))
					{
						var h = response.GetResponseHeader("WWW-Authenticate");
						return h.Contains("Bearer") && h.Contains("invalid_token");
					}
				}
			}
			return false;
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

		private readonly IDictionary<string, string> _customHttpHeaders = new Dictionary<string, string>();
		private readonly Dictionary<string, MemoryStream> _pendingStreams = new Dictionary<string, MemoryStream>();


		/// <summary>
		/// Headers from this Dictionary will be added to all HTTP requests to VersionOne server.
		/// </summary>
		public IDictionary<string, string> CustomHttpHeaders
		{
			get { return _customHttpHeaders; }
		}
	}
}