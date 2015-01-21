using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TestConfig()
        {
            var v1Config = APIClientIntegrationTestSuitIT.Context.V1Configuration;

            Assert.IsTrue(v1Config.EffortTracking);
        }
    }
}
