using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class ModelsAndServicesTester
    {

        private IModelsAndServices _defaultTarget;
        private IModelsAndServices _nonDefaultTarget;

        [SetUp]
        public void Setup()
        {
            _defaultTarget = new ModelsAndServices();
            IConnectors connectors = new Connectors();
            _nonDefaultTarget = new ModelsAndServices(connectors);
        }

        [TearDown]
        public void TearDown()
        {
            _defaultTarget = null;
            _nonDefaultTarget = null;
        }

        [Test]
        public void ServicesTest()
        {
            Assert.IsNotNull(_defaultTarget.Services);
            Assert.IsNotNull(_nonDefaultTarget.Services);
        }

        [Test]
        public void MetaModelTests()
        {
            Assert.IsNotNull(_defaultTarget.MetaModel);
            Assert.IsNotNull(_nonDefaultTarget.MetaModel);
        }

    }
}