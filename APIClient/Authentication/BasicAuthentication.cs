using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class BasicAuthentication : IHandleAuthentication
    {
        private readonly string _userName;
        private readonly string _password;
        public ProxyProvider ProxyProvider { get; set; }

        public BasicAuthentication()
        {
        }

        public BasicAuthentication(string userName, string password)
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
            var credentials = new NetworkCredential(_userName, _password);
            credentialCache.Add(uriPrefix, "Basic", credentials);
        }
    }
}
