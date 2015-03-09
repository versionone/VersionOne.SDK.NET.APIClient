using System.IO;
using System.Net;
using VersionOne.SDK.APIClient.Model;
using VersionOne.SDK.APIClient.Obsolete;

namespace VersionOne.SDK.APIClient {
    public class Attachments : IAttachments {
        private readonly IAPIConnector connector;

        public Attachments(IAPIConnector connector) {
            this.connector = connector;
        }

        public Stream GetReadStream(string key) {
            if(!string.IsNullOrEmpty(key)) {
                return connector.GetData(key.Substring(key.LastIndexOf('/') + 1));
            }

            return null;
        }

        public Stream GetWriteStream(string key) {
            if(!string.IsNullOrEmpty(key)) {
                return connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1));
            }

            return null;
        }

        public void SetWriteStream(string key, string contentType) {
            try {
                if(!string.IsNullOrEmpty(key)) {
                    connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), contentType);
                }
            } catch (WebException ex) {
                if(ex.Response != null && ex.Response is HttpWebResponse && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.RequestEntityTooLarge) {
                    throw new AttachmentLengthException(ex.Message);
                }

                throw;
            }
        }
    }
}