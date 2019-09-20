using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using VersionOne.Assets;

namespace VersionOne.SDK.APIClient
{
	/// <summary>
	/// Used to establish a connection to a VersionOne instance.
	/// </summary>
	public class V1Connector
	{
		private const string META_API_ENDPOINT = "meta.v1/";
		private const string DATA_API_ENDPOINT = "rest-1.v1/Data/";
		private const string DATA_API_OAUTH_ENDPOINT = "rest-1.oauth.v1/Data/";
		private const string HISTORY_API_ENDPOINT = "rest-1.v1/Hist/";
		private const string HISTORY_API_OAUTH_ENDPOINT = "rest-1.oauth.v1/Hist/";
		private const string NEW_API_ENDPOINT = "rest-1.v1/New";
		private const string NEW_API_OAUTH_ENDPOINT = "rest-1.oauth.v1/New/";
		private const string QUERY_API_ENDPOINT = "query.v1/";
		private const string LOC_API_ENDPOINT = "loc.v1/";
		private const string LOC2_API_ENDPOINT = "loc-2.v1/";
		private const string CONFIG_API_ENDPOINT = "config.v1/";
		private const string ATTACHMENT_API_ENDPOINT = "attachment.img/";
		private const string ATTACHMENT_API_OAUTH_ENDPOINT = "attachment.oauth.img/";
		private const string EMBEDDED_API_ENDPOINT = "embedded.img/";
		private const string EMBEDDED_API_OAUTH_ENDPOINT = "embedded.oauth.img/";
		private const string ASSET_API_ENDPOINT = "api/asset/";

		private readonly Dictionary<string, MemoryStream> _pendingStreams = new Dictionary<string, MemoryStream>();
		private readonly Dictionary<string, string> _requestHeaders = new Dictionary<string, string>();
		private readonly bool _isDebugEnabled;
		//private readonly ILog _log = LogManager.GetLogger(typeof(V1Connector));
		private readonly Uri _baseAddress;
		private IWebProxy _webProxy;
		private System.Net.ICredentials _credentials;
		private string _endpoint;
		private string _upstreamUserAgent;
		private bool _useOAuthEndpoints;

		private V1Connector(string instanceUrl)
		{
			if (string.IsNullOrWhiteSpace(instanceUrl))
				throw new ArgumentNullException("instanceUrl");
			if (!instanceUrl.EndsWith("/"))
				instanceUrl += "/";

			_isDebugEnabled = Config.IsDebugMode;

			Uri baseAddress;
			if (Uri.TryCreate(instanceUrl, UriKind.Absolute, out baseAddress))
			{
				_baseAddress = baseAddress;
				_upstreamUserAgent = FormatAssemblyUserAgent(Assembly.GetEntryAssembly());
			}
			else
			{
				throw new ConnectionException("Instance url is not valid.");
			}
		}

		/// <summary>
		/// Required method for setting the URL of the VersionOne instance.
		/// </summary>
		/// <param name="versionOneInstanceUrl">The URL to the VersionOne instance. Format is "http(s)://server/instance".</param>
		/// <returns>ICanSetUserAgentHeader</returns>
		public static ICanSetUserAgentHeader WithInstanceUrl(string versionOneInstanceUrl)
		{
			return new Builder(versionOneInstanceUrl);
		}

		internal Stream BeginRequest(string apipath)
		{
			var stream = new MemoryStream();
			_pendingStreams[apipath] = stream;

			return stream;
		}

		internal Stream EndRequest(string apipath, string contentType)
		{
			var inputstream = _pendingStreams[apipath];
			_pendingStreams.Remove(apipath);
			var body = inputstream.ToArray();

			return SendData(apipath, body, contentType);
		}

		internal Stream GetData(string resource = null)
		{
			Stream result;
			using (var httpClient = CreateHttpClient())
			{
				var resourceUrl = GetResourceUrl(resource);
				var response = httpClient.GetAsync(resourceUrl).Result;
				ThrowWebExceptionIfNeeded(response);
				result = response.Content.ReadAsStreamAsync().Result;
				LogResponse(response, result.ToString());
			}

			return result;
		}

		internal Stream SendData(string resource = null, object data = null, string contentType = "application/xml")
		{
			var response = Post(resource, data, contentType);
			ThrowWebExceptionIfNeeded(response);
			var result = response.Content.ReadAsStreamAsync().Result;
			LogResponse(response, result.ToString(), data != null ? data.ToString() : string.Empty);

			return result;
		}

		internal string StringSendData(string resource = null, object data = null, string contentType = "application/xml")
		{
			var response = Post(resource, data, contentType);
			var result = response.Content.ReadAsStringAsync().Result;
			LogResponse(response, result, data != null ? data.ToString() : string.Empty);

			return result;
		}

		internal string RestApiUrl { get { return _baseAddress.AbsoluteUri + _endpoint; } }
		internal string AssetApiUrl => _baseAddress.AbsoluteUri + ASSET_API_ENDPOINT;
		internal string Username { get; set; }
		internal string Password { get; set; }

		internal string AccessToken { get; set; }

		internal void UseDataApi()
		{
			_endpoint = _useOAuthEndpoints ? DATA_API_OAUTH_ENDPOINT : DATA_API_ENDPOINT;
		}

		internal void UseHistoryApi()
		{
			_endpoint = _useOAuthEndpoints ? HISTORY_API_OAUTH_ENDPOINT : HISTORY_API_ENDPOINT;
		}

		internal void UseNewApi()
		{
			_endpoint = _useOAuthEndpoints ? NEW_API_OAUTH_ENDPOINT : NEW_API_ENDPOINT;
		}

		internal void UseMetaApi()
		{
			_endpoint = META_API_ENDPOINT;
		}

		internal void UseQueryApi()
		{
			_endpoint = QUERY_API_ENDPOINT;
		}

		internal void UseLoc2Api()
		{
			_endpoint = LOC2_API_ENDPOINT;
		}

		internal void UseLocApi()
		{
			_endpoint = LOC_API_ENDPOINT;
		}

		internal void UseConfigApi()
		{
			_endpoint = CONFIG_API_ENDPOINT;
		}

		internal void UseAttachmentApi()
		{
			_endpoint = _useOAuthEndpoints ? ATTACHMENT_API_OAUTH_ENDPOINT : ATTACHMENT_API_ENDPOINT;
		}

		internal void UseEmbeddedApi()
		{
			_endpoint = _useOAuthEndpoints ? EMBEDDED_API_OAUTH_ENDPOINT : EMBEDDED_API_ENDPOINT;
		}

		internal void SetUpstreamUserAgent(string userAgent)
		{
			_upstreamUserAgent = userAgent;
		}

		private HttpResponseMessage Post(string resource = null, object data = null, string contentType = "application/xml")
		{
			HttpResponseMessage result;
			using (var httpClient = CreateHttpClient())
			{
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
				string stringData = data != null ? data.ToString() : string.Empty;
				HttpContent content;
				if (data is byte[])
				{
					content = new ByteArrayContent((byte[])data);
				}
				else
				{
					content = new StringContent(stringData);
				}
				var resourceUrl = GetResourceUrl(resource);
				result = httpClient.PostAsync(resourceUrl, content).Result;
				ThrowWebExceptionIfNeeded(result);
			}

			return result;
		}

		private string GetResourceUrl(string resource)
		{
			if (string.IsNullOrWhiteSpace(_endpoint))
				throw new ConnectionException("V1Connector is not properly configured. The API endpoint was not specified.");

			return _endpoint + ValidateResource(resource);
		}

		private void ThrowWebExceptionIfNeeded(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var statusCode = Convert.ToInt32(response.StatusCode);
				var message = string.Format("The remote server returned an error: ({0}) {1}.", statusCode, Microsoft.AspNetCore.WebUtilities.ReasonPhrases.GetReasonPhrase(statusCode));
				APIException innerException = null;
				var apiMessage = GetErrorMessageFromResponse(response);
				if (!string.IsNullOrWhiteSpace(apiMessage))
					innerException = new APIException(apiMessage);

				var webException = new WebException(message, innerException, (WebExceptionStatus)statusCode, null);

				throw webException;
			}
		}

		private string GetErrorMessageFromResponse(HttpResponseMessage response)
		{
			string result;
			try
			{
				if (response.Content.Headers.ContentType.ToString().Contains("text/xml"))
				{
					var doc = XDocument.Load(response.Content.ReadAsStreamAsync().Result);
					var lastMessage = doc.Descendants().LastOrDefault(e => e.Name.LocalName == "Message");
					result = lastMessage != null ? lastMessage.Value : string.Empty;
				}
				else
				{
					dynamic errorResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result);
					result = errorResponse.exceptions[0]["message"].Value;
				}
			}
			catch (Exception)
			{
				result = null;
			}

			return result;
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

		internal string UserAgent
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
			//var stringBuilder = new StringBuilder();
			//stringBuilder.AppendLine("REQUEST");
			//stringBuilder.AppendLine("\tMethod: " + rm.Method);
			//stringBuilder.AppendLine("\tRequest URL: " + rm.RequestUri);
			//stringBuilder.AppendLine("\tHeaders: ");
			//foreach (var header in rm.Headers)
			//{
			//    stringBuilder.AppendLine("\t\t" + header.Key + "=" + header.Value);
			//}
			//stringBuilder.AppendLine("\tBody: ");
			//stringBuilder.AppendLine("\t\t" + requestBody);

			//_log.Info(stringBuilder.ToString());

			if (_isDebugEnabled)
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

				Debug.WriteLine(stringBuilder.ToString());
				Debug.WriteLine("");
			}
		}

		private void LogResponse(HttpResponseMessage resp, string responseBody, string requestBody = "")
		{
			LogRequest(resp.RequestMessage, requestBody);
			//var stringBuilder = new StringBuilder();
			//stringBuilder.AppendLine("RESPONSE");
			//stringBuilder.AppendLine("\tStatus code: " + resp.StatusCode);
			//stringBuilder.AppendLine("\tHeaders: ");
			//foreach (var header in resp.Headers)
			//{
			//    stringBuilder.AppendLine("\t\t" + header.Key + "=" + header.Value);
			//}
			//stringBuilder.AppendLine("\tBody: ");
			//stringBuilder.AppendLine("\t\t" + responseBody);

			//_log.Info(stringBuilder.ToString());

			if (_isDebugEnabled)
			{
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

				Debug.WriteLine(stringBuilder.ToString());
				Debug.WriteLine("");
			}
		}

		private HttpClient CreateHttpClient()
		{
			var httpClient = new HttpClient(CreateHttpClientHandler()) { BaseAddress = _baseAddress };
			foreach (var requestHeader in _requestHeaders)
			{
				httpClient.DefaultRequestHeaders.Add(requestHeader.Key, requestHeader.Value);
			}
			httpClient.DefaultRequestHeaders.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
			httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

			return httpClient;
		}

		private HttpClientHandler CreateHttpClientHandler()
		{
			var httpClientHandler = new HttpClientHandler();
			//httpClientHandler.PreAuthenticate = true;
			//httpClientHandler.AllowAutoRedirect = true;
			if (_webProxy != null)
				httpClientHandler.Proxy = _webProxy;
			httpClientHandler.Credentials = _credentials;

			return httpClientHandler;
		}

		#region Fluent Builder

		private class Builder : ICanSetUserAgentHeader, ICanSetAuthMethod, ICanSetProxyOrEndpointOrGetConnector, ICanSetEndpointOrGetConnector, ICanSetProxyOrGetConnector
		{
			private readonly V1Connector _instance;

			public Builder(string versionOneInstanceUrl)
			{
				_instance = new V1Connector(versionOneInstanceUrl);
			}
			
			public ICanSetAuthMethod WithUserAgentHeader(string name, string version)
			{
				if (string.IsNullOrWhiteSpace(name))
					throw new ArgumentNullException("name");
				if (string.IsNullOrWhiteSpace(version))
					throw new ArgumentNullException("version");

				_instance._requestHeaders.Add(name, version);

				return this;
			}

			internal bool IsWithUsernameAndPassord
			{
				get { return _instance._credentials != null; }
			}

			public ICanSetProxyOrEndpointOrGetConnector WithUsernameAndPassword(string username, string password)
			{
				if (string.IsNullOrWhiteSpace(username))
					throw new ArgumentNullException("username");
				if (string.IsNullOrWhiteSpace(password))
					throw new ArgumentNullException("password");

				_instance._credentials = new NetworkCredential(username, password);

				_instance.Username = username;
				_instance.Password = password;

				return this;
			}

			public ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated()
			{
				var credentialCache = new CredentialCache
				{
					{_instance._baseAddress, "NTLM", CredentialCache.DefaultNetworkCredentials},
					{_instance._baseAddress, "Negotiate", CredentialCache.DefaultNetworkCredentials}
				};
				_instance._credentials = credentialCache;

				return this;
			}

			public ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password)
			{
				if (string.IsNullOrWhiteSpace(fullyQualifiedDomainUsername))
					throw new ArgumentNullException("fullyQualifiedDomainUsername");
				if (string.IsNullOrWhiteSpace(password))
					throw new ArgumentNullException("password");

				_instance._credentials = new NetworkCredential(fullyQualifiedDomainUsername, password);

				return this;
			}

			public ICanSetProxyOrEndpointOrGetConnector WithAccessToken(string accessToken)
			{
				if (string.IsNullOrWhiteSpace(accessToken))
					throw new ArgumentNullException("accessToken");

				_instance._requestHeaders.Add("Authorization", "Bearer " + accessToken);
				_instance.AccessToken = accessToken;

				return this;
			}

			public ICanSetProxyOrEndpointOrGetConnector WithOAuth2Token(string accessToken)
			{
				if (string.IsNullOrWhiteSpace(accessToken))
					throw new ArgumentNullException("accessToken");

				_instance._requestHeaders.Add("Authorization", "Bearer " + accessToken);

				return this;
			}

			public ICanSetProxyOrGetConnector UseEndpoint(string endpoint)
			{
				if (string.IsNullOrWhiteSpace(endpoint))
					throw new ArgumentNullException("endpoint");

				_instance._endpoint = endpoint;

				return this;
			}

			public ICanSetProxyOrGetConnector UseOAuthEndpoints()
			{
				_instance._useOAuthEndpoints = true;

				return this;
			}

			public ICanSetEndpointOrGetConnector WithProxy(ProxyProvider proxyProvider)
			{
				if (proxyProvider == null)
					throw new ArgumentNullException("proxyProvider");

				_instance._webProxy = proxyProvider.CreateWebProxy();

				return this;
			}

			public V1Connector Build()
			{
				return _instance;
			}

			ICanGetConnector ICanSetProxyOrGetConnector.WithProxy(ProxyProvider proxyProvider)
			{
				if (proxyProvider == null)
					throw new ArgumentNullException("proxyProvider");

				_instance._webProxy = proxyProvider.CreateWebProxy();

				return this;
			}

			ICanGetConnector ICanSetEndpointOrGetConnector.UseEndpoint(string endpoint)
			{
				if (string.IsNullOrWhiteSpace(endpoint))
					throw new ArgumentNullException("endpoint");

				_instance._endpoint = endpoint;

				return this;
			}

			public IFluentQueryBuilder Query(string from)
			{
				_instance.UseDataApi();
				return new Services(Build()).Query(from);
			}

			public IAsset Create(IAsset asset)
			{
				_instance.UseDataApi();

				if (asset == null) throw new ArgumentNullException(nameof(asset));

				return new Services(Build()).Create(asset);
			}

			public IAsset Create(object attributes)
			{
				_instance.UseDataApi();

				if (attributes == null) throw new ArgumentNullException(nameof(attributes));

				return new Services(Build()).Create(attributes);
			}

			public IAsset Create(params (string name, object value)[] attributes)
			{
				_instance.UseDataApi();

				if (attributes == null) throw new ArgumentNullException(nameof(attributes));

				return new Services(Build()).Create(attributes);
			}

			public CreateAssetsResult Create(params IAsset[] assets)
			{
				_instance.UseDataApi();

				return new Services(Build()).Create(assets);
			}

			public IAsset Update(string oidToken, object attributes)
			{
				_instance.UseDataApi();

				if (attributes == null) throw new NullReferenceException("attributes");

				return new Services(Build()).Update(oidToken, attributes);
			}

			public IAsset Update(IAsset asset)
			{
				_instance.UseDataApi();

				if (asset == null) throw new NullReferenceException("asset");

				return new Services(Build()).Update(asset);
			}

			public IEnumerable<string> Update(QueryApiQueryBuilder querySpec, object attributes)
			{
				_instance.UseDataApi();

				if (querySpec == null) throw new NullReferenceException(nameof(querySpec));
				if (attributes == null) throw new NullReferenceException(nameof(attributes));

				return new Services(Build()).Update(querySpec, attributes);
			}

			public IEnumerable<string> ExecuteOperation(QueryApiQueryBuilder querySpec, string operation)
			{
				_instance.UseDataApi();

				if (querySpec == null) throw new NullReferenceException(nameof(querySpec));
				if (string.IsNullOrWhiteSpace(operation)) throw new NullReferenceException(nameof(operation));

				return new Services(Build()).ExecuteOperation(querySpec, operation);
			}
		}

		#endregion
	}

	#region Result types
	public class CreateAssetsResult {
		public int Count { get; internal set; } = -1;
		public IEnumerable<string> OidTokens { get; internal set; }  = new List<string> ();
		public IEnumerable<IAsset> Assets { get; internal set; } = new List<IAsset> ();
	}

	#endregion

	#region Interfaces

	public interface ICanSetUserAgentHeader
	{
		/// <summary>
		/// Required method for setting a custom user agent header for all HTTP requests made to the VersionOne API.
		/// </summary>
		/// <param name="name">The name of the application.</param>
		/// <param name="version">The version number of the application.</param>
		/// <returns></returns>
		ICanSetAuthMethod WithUserAgentHeader(string name, string version);
	}

	public interface ICanSetAuthMethod
	{
		/// <summary>
		/// Optional method for setting the username and password for authentication.
		/// </summary>
		/// <param name="username">The username of a valid VersionOne member account.</param>
		/// <param name="password">The password of a valid VersionOne member account.</param>
		/// <returns>ICanSetProxyOrEndpointOrGetConnector</returns>
		ICanSetProxyOrEndpointOrGetConnector WithUsernameAndPassword(string username, string password);

		/// <summary>
		/// Optional method for setting the Windows Integrated Authentication credentials for authentication based on the currently logged in user.
		/// </summary>
		/// <returns>ICanSetProxyOrEndpointOrGetConnector</returns>
		ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated();

		/// <summary>
		/// Optional method for setting the Windows Integrated Authentication credentials for authentication based on specified user credentials.
		/// </summary>
		/// <param name="fullyQualifiedDomainUsername">The fully qualified domain name in form "DOMAIN\username".</param>
		/// <param name="password">The password of a valid VersionOne member account.</param>
		/// <returns>ICanSetProxyOrEndpointOrGetConnector</returns>
		ICanSetProxyOrEndpointOrGetConnector WithWindowsIntegrated(string fullyQualifiedDomainUsername, string password);

		/// <summary>
		/// Optional method for setting the access token for authentication.
		/// </summary>
		/// <param name="accessToken">The access token.</param>
		/// <returns>ICanSetProxyOrEndpointOrGetConnector</returns>
		ICanSetProxyOrEndpointOrGetConnector WithAccessToken(string accessToken);

		/// <summary>
		/// Optional method for setting the OAuth2 access token for authentication.
		/// </summary>
		/// <param name="accessToken">The OAuth2 access token.</param>
		/// <returns>ICanSetProxyOrEndpointOrGetConnector</returns>
		ICanSetProxyOrEndpointOrGetConnector WithOAuth2Token(string accessToken);
	}

	public interface ICanGetConnector
	{
		/// <summary>
		/// Required terminating method that returns the V1Connector object.
		/// </summary>
		/// <returns>V1Connector</returns>
		V1Connector Build();
	}

	public interface ICanSetProxyOrEndpointOrGetConnector : ICanSetEndpoint, ICanGetConnector
	{
		/// <summary>
		/// Optional method for setting the proxy credentials.
		/// </summary>
		/// <param name="proxyProvider">The ProxyProvider containing the proxy URI, username, and password.</param>
		/// <returns>ICanSetEndpointOrGetConnector</returns>
		ICanSetEndpointOrGetConnector WithProxy(ProxyProvider proxyProvider);
		IFluentQueryBuilder Query(string assetTypeName);
		IAsset Create(object attributes);
		IAsset Create(params (string name, object value)[] attributes);
		IAsset Create(IAsset asset);
		CreateAssetsResult Create(params IAsset[] assets);
		IAsset Update(string oidToken, object attributes);
		IAsset Update(IAsset asset);
		IEnumerable<string> Update(QueryApiQueryBuilder querySpec, object attributes);
		IEnumerable<string> ExecuteOperation(QueryApiQueryBuilder querySpec, string operation);
	}

	public interface ICanSetEndpointOrGetConnector : ICanGetConnector
	{
		/// <summary>
		/// Optional method for specifying an API endpoint to connect to.
		/// </summary>
		/// <param name="endpoint">The API endpoint.</param>
		/// <returns>ICanGetConnector</returns>
		ICanGetConnector UseEndpoint(string endpoint);
	}

	public interface ICanSetProxyOrGetConnector : ICanGetConnector
	{
		/// <summary>
		/// Optional method for setting the proxy credentials.
		/// </summary>
		/// <param name="proxyProvider">The ProxyProvider containing the proxy URI, username, and password.</param>
		/// <returns>ICanGetConnector</returns>
		ICanGetConnector WithProxy(ProxyProvider proxyProvider);
	}

	public interface ICanSetEndpoint
	{
		/// <summary>
		/// Optional method for specifying an API endpoint to connect to.
		/// </summary>
		/// <param name="endpoint">The API endpoint.</param>
		/// <returns>ICanSetProxyOrGetConnector</returns>
		[Obsolete("This method has been deprecated.")]
		ICanSetProxyOrGetConnector UseEndpoint(string endpoint);

		/// <summary>
		/// Optional method for specifying that the connection should be made using the OAuth endpoints.
		/// </summary>
		/// <returns>ICanSetProxyOrGetConnector</returns>
		ICanSetProxyOrGetConnector UseOAuthEndpoints();
	}

	#endregion
}
