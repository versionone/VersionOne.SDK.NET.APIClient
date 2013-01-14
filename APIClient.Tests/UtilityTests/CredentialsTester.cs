using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class CredentialsTester
    {

        public ICredentials _target;

        [SetUp]
        public void TestFixtureSetup()
        {
            _target = new Credentials();
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            _target = null;
        }

        [Test]
        public void V1UserNameTest()
        {
            Assert.IsNotNullOrEmpty(_target.V1UserName);
        }

        [Test]
        public void V1PasswordTest()
        {
            Assert.IsNotNullOrEmpty(_target.V1Password);
        }

        [Test]
        public void ProxyUserNameTest()
        {
            Assert.IsNotNullOrEmpty(_target.ProxyUserName);
        }

        [Test]
        public void ProxyPasswordTest()
        {
            Assert.IsNotNullOrEmpty(_target.ProxyPassword);
        }

    }
}