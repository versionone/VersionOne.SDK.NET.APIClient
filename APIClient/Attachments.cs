using System.IO;
using System.Net;

namespace VersionOne.SDK.APIClient
{
    public class Attachments : IAttachments
    {
        private readonly IAPIConnector _connector;
        private readonly V1Connector _v1Connector;

        public Attachments(IAPIConnector connector)
        {
            _connector = connector;
        }

        public Attachments(V1Connector v1Connector)
        {
            _v1Connector = v1Connector;
        }

        public Stream GetReadStream(string key)
        {
            Stream result = null;
            if (!string.IsNullOrEmpty(key))
            {
                if (_connector != null)
                {
                    result = _connector.GetData(key.Substring(key.LastIndexOf('/') + 1));
                }
                else if (_v1Connector != null)
                {
                    result = _v1Connector.GetData(key.Substring(key.LastIndexOf('/') + 1));
                }
            }

            return result;
        }

        public Stream GetWriteStream(string key)
        {
            Stream result = null;
            if (!string.IsNullOrEmpty(key))
            {
                if (_connector != null)
                {
                    result = _connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1));
                }
                else if (_v1Connector != null)
                {
                    result = _v1Connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1));
                }
            }

            return result;
        }

        public void SetWriteStream(string key, string contentType)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    if (_connector != null)
                    {
                        _connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), contentType);
                    }
                    else if (_v1Connector != null)
                    {
                        _v1Connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), contentType);
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null && ex.Response is HttpWebResponse && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.RequestEntityTooLarge)
                {
                    throw new AttachmentLengthException(ex.Message);
                }

                throw;
            }
        }
    }
}