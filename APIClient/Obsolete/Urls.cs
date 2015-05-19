using System;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated. Please use V1Connector instead.")]
    public interface  IUrls
    {
        string V1Url { get; }
        string MetaUrl { get; }
        string DataUrl { get; }
        string ProxyUrl { get; }
        string ConfigUrl { get; }
    }

    /// <summary>
    /// Retrieves url information from the executing assemblies .config file.
    /// </summary>
    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public sealed class Urls : IUrls
    {

        private string _v1Url;
        public string V1Url
        {
            get
            {
                if (string.IsNullOrEmpty(_v1Url) == false) return _v1Url;
                _v1Url = V1ConfigurationManager.GetValue(Settings.V1Url, "http://localhost/VersionOne");
                return _v1Url;
            }
        }

        private string _metaUrl;
        public string MetaUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_metaUrl) == false) return _metaUrl;
                _metaUrl = string.Concat(V1Url, V1ConfigurationManager.GetValue(Settings.MetaUrl, "meta.v1/"));
                return _metaUrl;
            }
        }

        private string _dataUrl;
        public string DataUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_dataUrl) == false) return _dataUrl;
                _dataUrl = string.Concat(V1Url, V1ConfigurationManager.GetValue(Settings.DataUrl, "rest-1.v1/"));
                return _dataUrl;
            }
        }

        private string _proxyUrl;
        public string ProxyUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_proxyUrl) == false) return _proxyUrl;
                _proxyUrl = V1ConfigurationManager.GetValue(Settings.ProxyUrl, "https://myProxyServer:3128");
                return _proxyUrl;
            }
        }

        private string _configUrl;
        public string ConfigUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_configUrl) == false) return _configUrl;
                _configUrl = string.Concat(V1Url, V1ConfigurationManager.GetValue(Settings.ConfigUrl, "config.v1/"));
                return _configUrl;
            }
        }
    }
}
