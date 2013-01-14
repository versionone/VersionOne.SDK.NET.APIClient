using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.SDK.APIClient
{

    public interface  IUrls
    {
        string V1Url { get; }
        string MetaUrl { get; }
        string DataUrl { get; }
        string ProxyUrl { get; }
        string ConfigUrl { get; }
    }

    public sealed class Urls : IUrls
    {

        public Urls()
        {
            V1Url = V1ConfigurationManager.GetValue(Settings.V1Url, "http://localhost/VersionOne");
            MetaUrl = string.Concat(V1Url, V1ConfigurationManager.GetValue(Settings.MetaUrl, "meta.v1/"));
            DataUrl = string.Concat(V1Url, V1ConfigurationManager.GetValue(Settings.DataUrl, "rest-1.v1/"));
            ProxyUrl = V1ConfigurationManager.GetValue(Settings.ProxyUrl, "https://myProxyServer:3128");
            ConfigUrl = V1ConfigurationManager.GetValue(Settings.ConfigUrl, "config.v1/");
        }

        public string V1Url { get; private set; }
        public string MetaUrl { get; private set; }
        public string DataUrl { get; private set; }
        public string ProxyUrl { get; private set; }
        public string ConfigUrl { get; private set; }
    }
}
