using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;

namespace VersionOne.SDK.APIClient {
    public class V1APIConnector : IAPIConnector {
        private readonly string url;
        private readonly string username;
        private readonly string password;
        private readonly bool integratedAuth;
        private CookieContainer cookieContainer;
        private CredentialCache credentials;

	    private string _callerUserAgent = "";
        private readonly ProxyProvider proxyProvider;

        private CredentialCache Credentials {
            get {
                if (credentials == null) {
                    credentials = new CredentialCache();
                    var uri = new Uri(url);

                    if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password)) {
                        var credential = new NetworkCredential(username, password);

                        if(integratedAuth) {
                            credentials.Add(uri, "Negotiate", credential);
                            credentials.Add(uri, "NTLM", credential);
                        } else {
                            credentials.Add(uri, "Basic", credential);
                        }
                    } else {
                        var credential = CredentialCache.DefaultCredentials as NetworkCredential;
                        
                        if (credential != null) {
                            credentials.Add(uri, "Negotiate", credential);
                            credentials.Add(uri, "NTLM", credential);
                        }
                    }
                }

                return credentials;
            }
        }

        private CookieContainer CookieContainer {
            get { return cookieContainer ?? (cookieContainer = new CookieContainer()); }
        }

		public void SetCallerUserAgent(string userAgent)
		{
			_callerUserAgent = userAgent;
		}

		private string MyUserAgent
		{
			get
			{
				var myAssemblyName = System.Reflection.Assembly.GetAssembly(typeof(V1APIConnector)).GetName();
				return String.Format("{0}/{1} ({2}) {3}", myAssemblyName.Name, myAssemblyName.Version,
												myAssemblyName.FullName, _callerUserAgent);
			}
		}

        public V1APIConnector(string url) {
            this.url = url;
            integratedAuth = true;
        }

        public V1APIConnector(string url, string username, string password) : this(url, username, password, false) { }

        public V1APIConnector(string url, string username, string password, bool integratedAuth) {
            this.url = url;
            this.username = username;
            this.password = password;
            this.integratedAuth = integratedAuth;
        }

        public V1APIConnector(string url, string username, string password, bool integratedAuth, ProxyProvider proxyProvider)
            : this(url, username, password, integratedAuth) {
            this.proxyProvider = proxyProvider;
        }

        public Stream GetData() {
            return GetData(string.Empty);
        }

        public Stream GetData(string path) {
            var response = CreateRequest(url + path).GetResponse();
            
            if(Config.IsDebugMode) {
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
                Debug.WriteLine("Get....");
                Debug.WriteLine("URL: " + url + path);
                Debug.WriteLine("Response from: " + response.ResponseUri);
                Debug.WriteLine(response.Headers.ToString());
                Debug.WriteLine(response.ToString());
                Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Debug.WriteLine(string.Empty);
            }
            return response.GetResponseStream();
        }

        public Stream SendData(string path, string data) {
            HttpWebRequest request = CreateRequest(url + path);
            request.ServicePoint.Expect100Continue = false;

            request.Method = "POST";
            request.ContentType = "type/xml";

            if (Config.IsDebugMode) {
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
                Debug.WriteLine("POST....");
                Debug.WriteLine("URL: " + url + path);
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

        private readonly IDictionary<string, HttpWebRequest> requests = new Dictionary<string, HttpWebRequest>();
        private readonly IDictionary<string, string> customHttpHeaders = new Dictionary<string, string>();

        public Stream BeginRequest(string path) {
            var req = CreateRequest(url + path);
            requests[path] = req;
            req.Method = "POST";
            return req.GetRequestStream();
        }

        public Stream EndRequest(string path, string contentType) {
            var req = requests[path];
            requests.Remove(path);
            req.ContentType = contentType;
            return req.GetResponse().GetResponseStream();
        }

        private HttpWebRequest CreateRequest(string path) {
            var request = (HttpWebRequest) WebRequest.Create(path);

            if (proxyProvider != null) {
                request.Proxy = proxyProvider.CreateWebProxy();
            }

            request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
	        request.Headers["User-Agent"] = MyUserAgent
            
            foreach (var pair in customHttpHeaders) {
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
            get { return customHttpHeaders; }
        }
    }
}