using System;
using NUnit.Framework;
using VersionOne.SDK.APIClient.Authentication;

namespace VersionOne.SDK.APIClient.Tests.Authentication {
	[TestFixture]
	[Ignore("This test shows how to use the ApiConnector")]
	public class ApiConnectorTester {
		private const string V1Path = "http://localhost/VersionOne.Web/";
		private const string V1Username = "admin";
		private const string V1Password = "admin";

		[Test]
		public void verbose_constructor()
		{
			var connector = new ApiConnector(V1Path,
				new VersionOneCredential(V1Username, V1Password),
				new WindowsIntegratedCredential()
				);
			connector.BeginRequest("blah");
		}
		[Test]
		public void fluent_constructor()
		{
			var connector = new ApiConnector(V1Path)
				.UseVersionOneUsernameAndPassword(V1Password, V1Username)
				.UseOAuth2()
				.UseWindowsIntegratedAuthentication();
			connector.BeginRequest("blah");
		}

	}
}