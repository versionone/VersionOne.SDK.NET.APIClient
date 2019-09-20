using System;
using System.Collections.Generic;
using System.IO;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated. Please use V1Connector instead.")]
    public interface IAPIConnector
    {
        Stream GetData();
        Stream GetData(string path);
        Stream SendData(string path, string data);
        Stream BeginRequest(string path);
        Stream EndRequest(string path, string contentType);
        void SetUpstreamUserAgent(string userAgent);
        IDictionary<string, string> CustomHttpHeaders { get; }
    }
}