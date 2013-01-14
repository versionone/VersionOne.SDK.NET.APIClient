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
            Assert.IsNotNull(_defaultTarget.ServicesWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.Services);
            Assert.IsNotNull(_nonDefaultTarget.ServicesWithProxy);
        }

        [Test]
        public void MetaModelTests()
        {
            Assert.IsNotNull(_defaultTarget.MetaModel);
            Assert.IsNotNull(_defaultTarget.MetaModelWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.MetaModel);
            Assert.IsNotNull(_nonDefaultTarget.MetaModelWithProxy);
        }

        [Test]
        public void ConfigTests()
        {
            Assert.IsNotNull(_defaultTarget.V1Configuration);
            Assert.IsNotNull(_defaultTarget.V1ConfigurationWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.V1Configuration);
            Assert.IsNotNull(_nonDefaultTarget.V1ConfigurationWithProxy);
        }


    }
}