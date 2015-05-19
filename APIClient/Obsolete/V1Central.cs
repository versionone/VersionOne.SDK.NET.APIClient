using System;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated. Please use V1Connector instead.")]
    public interface ICentral
    {
        IServices Services { get; }
        IMetaModel MetaModel { get; }
        ILocalizer Loc { get; }
    }

    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public class V1Central : ICentral
    {
        public V1Central(XmlNode config)
        {
            _applicationUrl = config["ApplicationUrl"].InnerText;

            if (_applicationUrl == null)
            {
                _applicationUrl = string.Empty;
            }
            else if (!_applicationUrl.EndsWith(@"/"))
            {
                _applicationUrl += @"/";
            }

            _username = config["Username"].InnerText;
            _password = config["Password"].InnerText;
            _apiVersion = config["APIVersion"].InnerText;
            _integratedAuth = false;
            bool.TryParse(config["IntegratedAuth"].InnerText, out _integratedAuth);

            //proxy settings
            if (config["ProxySettings"] != null)
            {
                _proxyDisabled = IsProxyDisabled(config["ProxySettings"].GetAttribute("disabled"));
                _proxyUrl = new Uri(SafeGetInnerText(config["ProxySettings"], "Url"));
                _proxyUserName = SafeGetInnerText(config["ProxySettings"], "UserName");
                _proxyPassword = SafeGetInnerText(config["ProxySettings"], "Password");
                _proxyDomain = SafeGetInnerText(config["ProxySettings"], "Domain");
            }
        }

        private string SafeGetInnerText(XmlNode parent, string childNodeName)
        {
            var childNode = parent[childNodeName];
            return childNode != null ? childNode.InnerText : null;
        }

        private bool IsProxyDisabled(string status)
        {
            return status != "0";
        }

        private IServices _services;

        public IServices Services
        {
            get { return _services ?? (_services = new Services(MetaModel, GetConnector("rest-1.v1/", false))); }
        }

        private IMetaModel _metamodel;

        public IMetaModel MetaModel
        {
            get { return _metamodel ?? (_metamodel = new MetaModel(GetConnector("meta.v1/", true))); }
        }

        private ILocalizer _localizer;

        public ILocalizer Loc
        {
            get { return _localizer ?? (_localizer = new Localizer(GetConnector("loc.v1/", true))); }
        }

        private IAPIConnector GetConnector(string path, bool anonymous)
        {
            var connector = new VersionOneAPIConnector(ApplicationUrl + path, proxyProvider: Proxy);

            if (anonymous)
                return connector;

            connector.WithVersionOneUsernameAndPassword(_username, _password);
            if (_integratedAuth)
                connector.WithWindowsIntegratedAuthentication();

            return connector;

        }

        private ProxyProvider Proxy
        {
            get
            {
                return _proxyDisabled ? null : new ProxyProvider(_proxyUrl, _proxyUserName, _proxyPassword, _proxyDomain);
            }
        }

        private readonly bool _integratedAuth;
        private readonly string _apiVersion;
        private readonly string _applicationUrl = "http://localhost/VersionOne.Web/";
        private readonly string _username = "admin";
        private readonly string _password = "admin";
        private readonly bool _proxyDisabled = true;
        private readonly Uri _proxyUrl = new Uri("http://proxy:123");
        private readonly string _proxyUserName = "user";
        private readonly string _proxyPassword = "password";
        private readonly string _proxyDomain = "DOMAIN";

        private bool _isValidKnown;
        private bool _isValid;

        public bool IsValid
        {
            get
            {
                if (!_isValidKnown)
                {
                    _isValidKnown = true;

                    try
                    {
                        Validate();
                        _isValid = true;
                    }
                    catch (ConnectionException)
                    {
                        _isValid = false;
                    }
                }

                return _isValid;
            }
        }

        public void Validate()
        {
            new V1ConnectionValidator(ApplicationUrl, _username, _password, _integratedAuth, Proxy).Test(_apiVersion);
        }

        public string ApplicationUrl
        {
            get { return _applicationUrl; }
        }
    }
}