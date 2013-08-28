using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;

namespace VersionOne.SDK.APIClient {
    public class V1APIConnector : IAPIConnector {
        private readonly string _urlPrefix;
        private readonly string _username;
        private readonly string _password;
        private readonly bool _integratedAuth;
        private CookieContainer _cookieContainer;
        private CredentialCache _credentials;

        private readonly ProxyProvider _proxyProvider;

		private readonly IDictionary<string, HttpWebRequest> _requests = new Dictionary<string, HttpWebRequest>();
		private readonly IDictionary<string, string> _customHttpHeaders = new Dictionary<string, string>();

        private CredentialCache Credentials {
            get {
                if (_credentials == null) {
                    _credentials = new CredentialCache();
                    var uri = new Uri(_urlPrefix);

                    if (!string.IsNullOrEmpty(_username) || !string.IsNullOrEmpty(_password)) {
                        var credential = new NetworkCredential(_username, _password);

                        if(_integratedAuth) {
                            _credentials.Add(uri, "Negotiate", credential);
                            _credentials.Add(uri, "NTLM", credential);
                        } else {
                            _credentials.Add(uri, "Basic", credential);
                        }
                    } else {
                        var credential = CredentialCache.DefaultCredentials as NetworkCredential;
                        
                        if (credential != null) {
                            _credentials.Add(uri, "Negotiate", credential);
                            _credentials.Add(uri, "NTLM", credential);
                        }
                    }
                }

                return _credentials;
            }
        }

        private CookieContainer CookieContainer {
            get { return _cookieContainer ?? (_cookieContainer = new CookieContainer()); }
        }

		private string _callerUserAgent = MakeUserAgent(RunningAssemblyName);
		public void SetCallerUserAgent(string userAgent)
		{
			_callerUserAgent = userAgent;
		}
	    public static AssemblyName MyAssemblyName = Assembly.GetAssembly(typeof (V1APIConnector)).GetName();
	    public static AssemblyName RunningAssemblyName = Assembly.GetExecutingAssembly().GetName();
		private static string MakeUserAgent(AssemblyName n, string upstream="")
		{
			return String.Format("{0}/{1} ({2}) {3}", n.Name, n.Version, n.FullName, upstream);
		}
		private string MyUserAgent
		{
			get
			{
				return MakeUserAgent(MyAssemblyName,  _callerUserAgent);
			}
		}

		public V1APIConnector(string urlPrefix, string username = null, string password = null, bool? integratedAuth = null,
		                      ProxyProvider proxyProvider = null)
		{
			_urlPrefix = urlPrefix;
			_proxyProvider = proxyProvider;
			if(username == null && password == null && !integratedAuth.HasValue)
			{
				_integratedAuth = true;
			}
			else
			{
				_username = username;
				_password = password;
				_integratedAuth = integratedAuth.GetValueOrDefault();
			}

		}

        public Stream GetData() {
            return GetData(string.Empty);
        }

        public Stream GetData(string apipath) {
			var response = CreateRequest(_urlPrefix + apipath).GetResponse();
            
            if(Config.IsDebugMode) {
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
                Debug.WriteLine("Get....");
				Debug.WriteLine("URL: " + _urlPrefix + apipath);
                Debug.WriteLine("Response from: " + response.ResponseUri);
                Debug.WriteLine(response.Headers.ToString());
                Debug.WriteLine(response.ToString());
                Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Debug.WriteLine(string.Empty);
            }
            return response.GetResponseStream();
        }

		public Stream SendData(string apipath, string data)
		{
			HttpWebRequest request = CreateRequest(_urlPrefix + apipath);
            request.ServicePoint.Expect100Continue = false;

            request.Method = "POST";
            request.ContentType = "type/xml";

            if (Config.IsDebugMode) {
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
                Debug.WriteLine("POST....");
				Debug.WriteLine("URL: " + _urlPrefix + apipath);
                Debug.WriteLine(request.Headers.ToString());
                Debug.WriteLine(data);
                Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Debug.WriteLine("");
            }

            using(var stream = new StreamWriter(request.GetRequestStream())) {
                stream.Write(data);
            }

            return request.GetResponse().GetResponseStream();
        }

		public Stream BeginRequest(string apipath)
		{
			var req = CreateRequest(_urlPrefix + apipath);
			_requests[apipath] = req;
            req.Method = "POST";
            return req.GetRequestStream();
        }

		public Stream EndRequest(string apipath, string contentType)
		{
			var req = _requests[apipath];
			_requests.Remove(apipath);
            req.ContentType = contentType;
            return req.GetResponse().GetResponseStream();
        }

        private HttpWebRequest CreateRequest(string url) {
			var request = (HttpWebRequest)WebRequest.Create(url);

            if (_proxyProvider != null) {
                request.Proxy = _proxyProvider.CreateWebProxy();
            }

            request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
			request.UserAgent = MyUserAgent;
            
            foreach (var pair in _customHttpHeaders) {
                request.Headers.Add(pair.Key, pair.Value);
            }
            
            request.CookieContainer = CookieContainer;
            request.Credentials = Credentials;
            request.UnsafeAuthenticatedConnectionSharing = true;
            return request;
        }

        /// <summary>
        /// Headers from this Dictionary will be added to all HTTP requests to VersionOne server.
        /// </summary>
        public IDictionary<string, string> CustomHttpHeaders {
            get { return _customHttpHeaders; }
        }
    }
}