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
    }

    public sealed class Urls : IUrls
    {

        public Urls()
        {
            V1Url = "https://www14.v1host.com/v1sdktesting/";
            MetaUrl = string.Concat(V1Url, "meta.v1/");
            DataUrl = string.Concat(V1Url, "rest-1.v1/");
        }

        public string V1Url { get; private set; }
        public string MetaUrl { get; private set; }
        public string DataUrl { get; private set; }
    }
}
