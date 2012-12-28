using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class ConnectorsTester
    {

        private IConnectors _defaultTarget;
        private IConnectors _nonDefaultTarget;

        [SetUp]
        public void TestFixtureSetup()
        {

            _defaultTarget = new Connectors();
            _nonDefaultTarget = new Connectors(new Urls(), new Credentials()); //can inject your own urls/credentials implementations...

        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            _defaultTarget = null;
            _nonDefaultTarget = null;
        }

        [Test]
        public void DataConnectorTest()
        {
            Assert.IsNotNull(_defaultTarget.DataConnector);
            Assert.IsNotNull(_nonDefaultTarget.DataConnector);
        }
    }
}