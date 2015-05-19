using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class V1ConfigurationManagerTester
    {
        [TestMethod]
        public void NullKeyTest()
        {
            var actual = V1ConfigurationManager.GetValue(null, "Shabadoo");
            Assert.AreEqual("Shabadoo", actual);
        }

        [TestMethod]
        public void NullValueTest()
        {
            var actual = V1ConfigurationManager.GetValue("SomeRandomKeyThatDoesntExist", "Shabadoo");
            Assert.AreEqual("Shabadoo", actual);
        }

        [TestMethod]
        public void GetSettingTest()
        {
            var v1Url = V1ConfigurationManager.GetValue<string>(Settings.V1Url, null);
            Assert.AreNotEqual(null, v1Url);
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void NonPrimativeTypeTest()
        {
            V1ConfigurationManager.GetValue(Settings.V1Url, new Uri("http://www.versionone.com/"));
        }
    }
}
