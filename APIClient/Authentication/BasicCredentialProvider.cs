using System;
using System.Net;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class BasicCredentialProvider : ICredentialProvider
    {
        private readonly string _userName;
        private readonly string _password;

        public BasicCredentialProvider(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            _userName = userName;
            _password = password;
        }

        public void Handle(Uri uriPrefix, CredentialCache credentialCache, ProxyProvider proxyProvider)
        {
            var credentials = new NetworkCredential(_userName, _password);
            credentialCache.Add(uriPrefix, "Basic", credentials);
        }
    }
}
