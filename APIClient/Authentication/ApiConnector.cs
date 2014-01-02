using System;
using System.Net;


namespace VersionOne.SDK.APIClient.Authentication
{
	public class ApiConnector : V1CredsAPIConnector
	{
		public ApiConnector(string urlPrefix, params ICredentialProvider[] credentialProviders)
			: base(urlPrefix)
		{
			foreach (var credentialProvider in credentialProviders)
			{
				credentialProvider.Handle(new Uri(urlPrefix), Credentials as CredentialCache, GetProxyProvider());
			}
		}
	}
}
