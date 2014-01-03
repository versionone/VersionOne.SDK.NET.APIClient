using System;
using System.Net;
using OAuth2Client;


namespace VersionOne.SDK.APIClient.Authentication
{
	public class ApiConnector : V1CredsAPIConnector
	{
		public ApiConnector(string urlPrefix, params ICredentialProvider[] credentialProviders)
			: base(urlPrefix)
		{
			foreach (var credentialProvider in credentialProviders)
			{
				credentialProvider.CacheCredential(new Uri(urlPrefix), Credentials as CredentialCache, GetProxyProvider());
			}
		}

		public ApiConnector UseVersionOneUsernameAndPassword(string username, string password)
		{
			var provider = new VersionOneCredential(username, password);
			CacheCredential(provider);

			return this;
		}

		public ApiConnector UseWindowsIntegratedAuthentication()
		{
			var provider = new WindowsIntegratedCredential();
			CacheCredential(provider);
			return this;
		}

		public ApiConnector UseOAuth2()
		{
			var provider = new OAuth2Credential();
			CacheCredential(provider);
		}

		public ApiConnector UseOAuth2(IStorage storage)
		{
			var provider = new OAuth2Credential(storage);
			CacheCredential(provider);
		}

		private void CacheCredential(ICredentialProvider provider)
		{
			provider.CacheCredential(new Uri(UrlPrefix), Credentials as CredentialCache, GetProxyProvider());
		}
	}
}
