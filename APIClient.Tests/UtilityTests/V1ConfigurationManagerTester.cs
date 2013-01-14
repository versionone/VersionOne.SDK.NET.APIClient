using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class V1ConfigurationManagerTester
    {

        [Test]
        public void NullKeyTest()
        {
            var actual = V1ConfigurationManager.GetValue(null, "Shabadoo");
            Assert.AreEqual("Shabadoo", actual); 
        }

        [Test]
        public void NullValueTest()
        {
            var actual = V1ConfigurationManager.GetValue("SomeRandomKeyThatDoesntExist", "Shabadoo");
            Assert.AreEqual("Shabadoo", actual);
        }

        [Test]
        public void GetSettingTest()
        {
            var v1Url = V1ConfigurationManager.GetValue<string>(Settings.V1Url, null);
            Assert.AreNotEqual(null, v1Url);
        }

        [Test, ExpectedException(typeof(InvalidCastException))]
        public void NonPrimativeTypeTest()
        {
            V1ConfigurationManager.GetValue(Settings.V1Url, new Uri("http://www.versionone.com/"));
        }
    }
}