using System;
using System.Net;


namespace VersionOne.SDK.APIClient.Authentication
{
    public class ApiConnector : V1CredsAPIConnector
    {
        public ApiConnector(string urlPrefix, ICredentialProvider authHandler, ProxyProvider proxyProvider = null)
            : base(urlPrefix, new CredentialCache(), proxyProvider)
        {
            authHandler.Handle(new Uri(urlPrefix), _creds as CredentialCache, proxyProvider);
        }
    }
}
