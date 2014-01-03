using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public interface ICredentialProvider
    {
        void CacheCredential(Uri uriPrefix, CredentialCache credentialCache, ProxyProvider proxyProvider);
    }
}
