using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class EnvironmentContextTester
    {
        private EnvironmentContext _defaultTarget;
        private EnvironmentContext _nonDefaultTarget;

        [TestInitialize]
        public void SetUp()
        {
            _defaultTarget = new EnvironmentContext();
            _nonDefaultTarget = new EnvironmentContext(new ModelsAndServices()); //can inject your own modelsAndServices implementation
        }

        [TestCleanup]
        public void TearDown()
        {
            _defaultTarget = null;
            _nonDefaultTarget = null;
        }

        [TestMethod]
        public void MetaModelTest()
        {
            Assert.IsNotNull(_defaultTarget.MetaModel);
            Assert.IsNotNull(_nonDefaultTarget.MetaModel);
        }

        [TestMethod]
        public void ServicesTest()
        {
            Assert.IsNotNull(_defaultTarget.Services);
            Assert.IsNotNull(_nonDefaultTarget.Services);
        }
    }
}
