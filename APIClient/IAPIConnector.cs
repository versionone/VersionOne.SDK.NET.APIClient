using System.Collections.Generic;
using System.IO;

namespace VersionOne.SDK.APIClient {
    public interface IAPIConnector {
        Stream GetData();
        Stream GetData(string path);
        Stream SendData(string path, string data);
        Stream BeginRequest(string path);
        Stream EndRequest(string path, string contentType);
        IDictionary<string, string> CustomHttpHeaders { get; }
    }
}