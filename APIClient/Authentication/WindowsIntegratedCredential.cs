using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class WindowsIntegratedCredential : ICredentialProvider
    {
        private readonly string _userName;
        private readonly string _password;

        public WindowsIntegratedCredential() { }

        public void CacheCredential(Uri uriPrefix, CredentialCache credentialCache, ProxyProvider proxyProvider)
        {
            SetDefaultCredentials(uriPrefix, credentialCache);
        }

        private void SetDefaultCredentials(Uri uriPrefix, CredentialCache credentialCache)
        {
            credentialCache.Add(uriPrefix, "NTLM", CredentialCache.DefaultNetworkCredentials);
            credentialCache.Add(uriPrefix, "Negotiate", CredentialCache.DefaultNetworkCredentials);
        }
    }
}
