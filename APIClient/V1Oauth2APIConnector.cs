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
		private CookieContainer _cookieContainer;
		private readonly OAuth2Credentials _creds;
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
			_proxyProvider = proxy;
			AuthenticationManager.Unregister("basic");
			AuthenticationManager.Register(new OAuth2BearerModule());
			var mystorage =
				new Microsoft.FSharp.Core.FSharpOption<IStorage>(storage ?? OAuth2Client.Storage.JsonFileStorage.Default);
			var myproxy = _proxyProvider != null
				              ? new Microsoft.FSharp.Core.FSharpOption<IWebProxy>(_proxyProvider.CreateWebProxy())
				              : Microsoft.FSharp.Core.FSharpOption<IWebProxy>.None;
			_creds = new OAuth2Credentials(EndpointScope, mystorage, myproxy);
		}


		public static System.Reflection.AssemblyName MyAssemblyName =
			System.Reflection.Assembly.GetAssembly(typeof(V1APIConnector)).GetName();

		private string MyUserAgent
		{
			get
			{
				return String.Format("{0}/{1} ({2}) {3}", MyAssemblyName.Name, MyAssemblyName.Version,
												MyAssemblyName.FullName, _callerUserAgent);
			}
		}

		private HttpWebRequest CreateRequest(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Credentials = _creds;
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

		public Stream HttpGet(string apipath, bool refreshTokenIfNeeded = true, string contentType = "text/xml")
		{
			var url = _urlPrefix + apipath;
			var req = CreateRequest(url);
			req.ContentType = contentType;
			req.Method = "GET";
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
			req.ContentLength = body.Length;
			req.GetRequestStream().Write(body, 0, body.Length);
			var resp = req.GetResponse();
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