using System.IO;

namespace VersionOne.SDK.APIClient {
    public interface IAttachments {
        Stream GetReadStream(string key);
        Stream GetWriteStream(string key);
        void SetWriteStream(string key, string contentType);
    }
}