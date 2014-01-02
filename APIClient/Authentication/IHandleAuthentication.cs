using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public interface IHandleAuthentication
    {
        ProxyProvider ProxyProvider { get; set; }
        void Handle(Uri uriPrefix, CredentialCache credentialCache);
    }
}
