using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class UrlsTester
    {
        private IUrls _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new Urls();
        }

        [TestCleanup]
        public void TearDown()
        {
            _target = null;
        }

        [TestMethod]
        public void V1UrlTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.V1Url));
        }

        [TestMethod]
        public void DataUrlTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.DataUrl));
        }

        [TestMethod]
        public void MetaUrlTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.MetaUrl));
        }

        [TestMethod]
        public void ProxyUrlTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.ProxyUrl));
        }

        [TestMethod]
        public void ConfigUrlTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_target.ConfigUrl));
        }
    }
}
