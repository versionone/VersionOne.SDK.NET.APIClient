using System;
using System.Net;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.Authentication
{
	[TestFixture]
	[Ignore("This test shows how to use the ApiConnector")]
	public class ApiConnectorTester
	{
		private const string V1Path = "http://localhost/VersionOne.Web/";
		private readonly Uri V1Uri = new Uri(V1Path);
		private const string V1Username = "admin";
		private const string V1Password = "admin";

		[Test]
		public void fluent_configuration_with_multiple_credentials()
		{
			var connector = new VersionOneAPIConnector(V1Path)
				.WithVersionOneUsernameAndPassword(V1Password, V1Username)
				.WithOAuth2()
				.WithWindowsIntegratedAuthentication();
			connector.HttpGet("rest-1.v1/Data/Member/20");
		}

		[Test]
		public void single_supplied_credential()
		{
			var simpleCred = new NetworkCredential(V1Username, V1Password);

			var connector = new VersionOneAPIConnector(V1Path, simpleCred);

			connector.HttpGet("rest-1.v1/Data/Member/20");
		}

		[Test]
		public void multiple_credentials_via_user_supplied_credential_cache()
		{
			var cred = new OAuth2Client.OAuth2Credential(
				"apiv1",
				new OAuth2Client.Storage.JsonFileStorage(
					@"C:\Projects\github\oauth2_files\local_versiononeweb_client_secrets.json",
					@"C:\Projects\github\oauth2_files\local_versiononeweb_creds.json"),
				null
				);

			var cache = new CredentialCache();

			var simpleCred = new NetworkCredential(V1Username, V1Password);

			cache.Add(V1Uri, "Basic", simpleCred);
			cache.Add(V1Uri, "Bearer", cred);

			var windowsIntegratedCredential = CredentialCache.DefaultNetworkCredentials;
			// TODO explore: CredentialCache.DefaultCredentials
			// Suppose for some weird reason you just wanted to support NTLM:
			cache.Add(V1Uri, "NTLM", windowsIntegratedCredential);
			
			var connector = new VersionOneAPIConnector(V1Path, cache);

			connector.HttpGet("rest-1.v1/Data/Member/20");
		}
	}
}