using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class ConnectorsTester
    {

        private IConnectors _connectors;
        private IConnectors _connectorsWithInjectedUrlsAndCreds;

        [SetUp]
        public void TestFixtureSetup()
        {

            _connectors = new Connectors();
            _connectorsWithInjectedUrlsAndCreds = new Connectors(new Urls(), new Credentials()); //can inject your own urls/credentials implementations...

        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            _connectors = null;
            _connectorsWithInjectedUrlsAndCreds = null;
        }

        [Test]
        public void ConnectorTest()
        {
            Assert.IsNotNull(_connectors.DataConnector);
            Assert.IsNotNull(_connectors.DataConnectorWithProxy);
            Assert.IsNotNull(_connectorsWithInjectedUrlsAndCreds.DataConnector);
            Assert.IsNotNull(_connectorsWithInjectedUrlsAndCreds.DataConnectorWithProxy);
            Assert.IsNotNull(_connectors.ConfigurationConnector);
            Assert.IsNotNull(_connectors.ConfigurationConnectorWithProxy);
        }
    }
}