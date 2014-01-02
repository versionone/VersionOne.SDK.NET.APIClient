using System;
using System.Net;


namespace VersionOne.SDK.APIClient.Authentication
{
    public class ApiConnector : V1CredsAPIConnector
    {
        public ApiConnector(string urlPrefix, IHandleAuthentication authHandler)
            : base(urlPrefix, new CredentialCache())
        {
            authHandler.Handle(new Uri(urlPrefix), _creds as CredentialCache);
        }
    }
}
