using System;
using NUnit.Framework;
using VersionOne.SDK.APIClient.Authentication;

namespace VersionOne.SDK.APIClient.Tests.Authentication {
	[TestFixture]
	[Ignore("This test shows how to use the ApiConnector")]
	public class BasicCredentialProviderTester {
		private const string V1Path = "http://localhost/VersionOne.Web/";
		private const string V1Username = "admin";
		private const string V1Password = "admin";

		[Test]
		public void BasicCredential_test()
		{
			var connector = new ApiConnector(V1Path,
				new BasicCredentialProvider(V1Username, V1Password),
				new WindowsIntegratedCredentialProvider()
				);
			connector.BeginRequest("blah");
		}
	}
}