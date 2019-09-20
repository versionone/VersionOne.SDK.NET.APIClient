using System;
using System.IO;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated. Please use methods of the IServices interface instead.")]
    public interface IAttachments
    {
        Stream GetReadStream(string key);
        Stream GetWriteStream(string key);
        void SetWriteStream(string key, string contentType);
    }
}