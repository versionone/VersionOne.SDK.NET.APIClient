using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests {
	/// <summary>
	/// Summary description for ConnectionValidatorTest.
	/// </summary>
	[TestFixture]
	public class ConnectionValidatorTester {
		[Test]
		[Ignore("Requires working VersionOne instance")]
		public void Test() {			
			V1ConnectionValidator validator = new V1ConnectionValidator("http://nitrogen/V1WindowsAuthentication/", string.Empty, string.Empty, true);

			try {
				validator.Test("6.3");
			} catch (Exception ex) {
				Assert.Fail(ex.Message);
			}
		}
	}
}