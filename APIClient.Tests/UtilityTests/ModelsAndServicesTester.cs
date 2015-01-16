using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class ModelsAndServicesTester
    {
        private IModelsAndServices _defaultTarget;
        private IModelsAndServices _nonDefaultTarget;

        [TestInitialize]
        public void Setup()
        {
            _defaultTarget = new ModelsAndServices();
            IConnectors connectors = new Connectors();
            _nonDefaultTarget = new ModelsAndServices(connectors);
        }

        [TestCleanup]
        public void TearDown()
        {
            _defaultTarget = null;
            _nonDefaultTarget = null;
        }

        [TestMethod]
        public void ServicesTest()
        {
            Assert.IsNotNull(_defaultTarget.Services);
            Assert.IsNotNull(_defaultTarget.ServicesWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.Services);
            Assert.IsNotNull(_nonDefaultTarget.ServicesWithProxy);
        }

        [TestMethod]
        public void MetaModelTests()
        {
            Assert.IsNotNull(_defaultTarget.MetaModel);
            Assert.IsNotNull(_defaultTarget.MetaModelWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.MetaModel);
            Assert.IsNotNull(_nonDefaultTarget.MetaModelWithProxy);
        }

        [TestMethod]
        public void ConfigTests()
        {
            Assert.IsNotNull(_defaultTarget.V1Configuration);
            Assert.IsNotNull(_defaultTarget.V1ConfigurationWithProxy);
            Assert.IsNotNull(_nonDefaultTarget.V1Configuration);
            Assert.IsNotNull(_nonDefaultTarget.V1ConfigurationWithProxy);
        }
    }
}
