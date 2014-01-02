using System;
using System.Net;


namespace VersionOne.SDK.APIClient.Authentication
{
    public class ApiConnector : V1CredsAPIConnector
    {
        public ApiConnector(string urlPrefix, ICredentialProvider authHandler)
            : base(urlPrefix)
        {
            authHandler.Handle(new Uri(urlPrefix), Credentials as CredentialCache, GetProxyProvider());
        }


    }
}
