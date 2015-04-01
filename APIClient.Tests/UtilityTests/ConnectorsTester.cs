using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class ConnectorsTester
    {
        private IConnectors _connectors;
        private IConnectors _connectorsWithInjectedUrlsAndCreds;

        [TestInitialize]
        public void TestFixtureSetup()
        {

            _connectors = new Connectors();
            _connectorsWithInjectedUrlsAndCreds = new Connectors(new Urls(), new Credentials()); //can inject your own urls/credentials implementations...

        }

        [TestCleanup]
        public void TestFixtureTearDown()
        {
            _connectors = null;
            _connectorsWithInjectedUrlsAndCreds = null;
        }

        [TestMethod]
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
