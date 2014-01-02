using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class NtlmAuthentication : IHandleAuthentication
    {
        private readonly string _userName;
        private readonly string _password;
        public ProxyProvider ProxyProvider { get; set; }

        public NtlmAuthentication(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            _userName = userName;
            _password = password;
        }

        public void Handle(Uri uriPrefix, CredentialCache credentialCache)
        {
            if (_userName == null)
                SetUserCredentials(uriPrefix, credentialCache);
            else
                SetDefaultCredentials(uriPrefix, credentialCache);
        }

        private void SetUserCredentials(Uri uriPrefix, CredentialCache credentialCache)
        {
            var credentials = new NetworkCredential(_userName, _password);
            credentialCache.Add(uriPrefix, "Basic", credentials);
            credentialCache.Add(uriPrefix, "NTLM", credentials);
            credentialCache.Add(uriPrefix, "Negotiate", credentials);
        }

        private void SetDefaultCredentials(Uri uriPrefix, CredentialCache credentialCache)
        {
            credentialCache.Add(uriPrefix, "NTLM", CredentialCache.DefaultNetworkCredentials);
            credentialCache.Add(uriPrefix, "Negotiate", CredentialCache.DefaultNetworkCredentials);
        }
    }
}
