using System.Xml;
using System;

namespace VersionOne.SDK.APIClient {
    public interface ICentral {
        IServices Services { get; }
        IMetaModel MetaModel { get; }
        ILocalizer Loc { get; }
    }

    public class V1Central : ICentral {
        public V1Central(XmlNode config) {
            applicationUrl = config["ApplicationUrl"].InnerText;

            if(applicationUrl == null) {
                applicationUrl = string.Empty;
            } else if(!applicationUrl.EndsWith(@"/")) {
                applicationUrl += @"/";
            }

            username = config["Username"].InnerText;
            password = config["Password"].InnerText;
            apiVersion = config["APIVersion"].InnerText;
            integratedAuth = false;
            bool.TryParse(config["IntegratedAuth"].InnerText, out integratedAuth);
            
            //proxy settings
            if (config["ProxySettings"] != null) {
                proxyDisabled = IsProxyDisabled(config["ProxySettings"].GetAttribute("disabled"));
                proxyUri = new Uri(SafeGetInnerText(config["ProxySettings"], "Uri"));
                proxyUserName = SafeGetInnerText(config["ProxySettings"], "UserName");
                proxyPassword = SafeGetInnerText(config["ProxySettings"], "Password");
                proxyDomain = SafeGetInnerText(config["ProxySettings"], "Domain");
            }
        }

        private string SafeGetInnerText(XmlNode parent, string childNodeName) {
            var childNode = parent[childNodeName];
            return childNode != null ? childNode.InnerText : null;
        }

        private bool IsProxyDisabled(string status) {
            return status != "0";
        }

        private IServices services;

        public IServices Services {
            get { return services ?? (services = new Services(MetaModel, GetConnector("rest-1.v1/", false))); }
        }

        private IMetaModel metamodel;

        public IMetaModel MetaModel {
            get { return metamodel ?? (metamodel = new MetaModel(GetConnector("meta.v1/", true))); }
        }

        private ILocalizer localizer;

        public ILocalizer Loc {
            get { return localizer ?? (localizer = new Localizer(GetConnector("loc.v1/", true))); }
        }

        private V1APIConnector GetConnector(string path, bool anonymous) {
            return anonymous ? new V1APIConnector(ApplicationUrl + path, null, null, true, Proxy) : new V1APIConnector(ApplicationUrl + path, username, password, integratedAuth, Proxy);
        }

        private ProxyProvider Proxy {
            get {
                return proxyDisabled ? null : new ProxyProvider(proxyUri, proxyUserName, proxyPassword, proxyDomain);
            }
        }

        private readonly string applicationUrl = "http://localhost/VersionOne.Web/";
        private readonly string username = "admin";
        private readonly string password = "admin";
        private readonly bool integratedAuth = false;
        private readonly string apiVersion = null;
        private readonly bool proxyDisabled = true;
        private readonly Uri proxyUri = new Uri("http://proxy:123");
        private readonly string proxyUserName = "user";
        private readonly string proxyPassword = "password";
        private readonly string proxyDomain = "DOMAIN";

        private bool isValidKnown;
        private bool isValid;

        public bool IsValid {
            get {
                if (!isValidKnown) {
                    isValidKnown = true;
                    
                    try {
                        Validate();
                        isValid = true;
                    } catch (ConnectionException) {
                        isValid = false;
                    }
                }

                return isValid;
            }
        }

        public void Validate() {
            new V1ConnectionValidator(ApplicationUrl, username, password, integratedAuth, Proxy).Test(apiVersion);
        }

        public string ApplicationUrl {
            get { return applicationUrl; }
        }
    }
}