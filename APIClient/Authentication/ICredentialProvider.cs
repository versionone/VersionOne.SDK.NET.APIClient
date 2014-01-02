using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public interface ICredentialProvider
    {
        void Handle(Uri uriPrefix, CredentialCache credentialCache, ProxyProvider proxyProvider);
    }
}
