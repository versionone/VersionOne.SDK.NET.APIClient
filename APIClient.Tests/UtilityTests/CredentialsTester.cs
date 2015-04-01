using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class CredentialsTester
    {
        public ICredentials _target;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _target = new Credentials();
        }

        [TestCleanup]
        public void TestFixtureTearDown()
        {
            _target = null;
        }

        [TestMethod]
        public void V1UserNameTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.V1UserName));
        }

        [TestMethod]
        public void V1PasswordTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.V1Password));

        }

        [TestMethod]
        public void ProxyUserNameTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.ProxyUserName));

        }

        [TestMethod]
        public void ProxyPasswordTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.ProxyPassword));

        }
    }
}
