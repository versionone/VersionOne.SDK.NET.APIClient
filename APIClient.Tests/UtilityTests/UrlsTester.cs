using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class UrlsTester
    {

        private IUrls _target;

        [SetUp]
        public void Setup()
        {
            _target = new Urls(); 
        }

        [TearDown]
        public void TearDown()
        {
            _target = null;
        }

        [Test]
        public void V1UrlTest()
        {
            Assert.IsNotNullOrEmpty(_target.V1Url);
        }

        [Test]
        public void DataUrlTest()
        {
            Assert.IsNotNullOrEmpty(_target.DataUrl);
        }

        [Test]
        public void MetaUrlTest()
        {
            Assert.IsNotNullOrEmpty(_target.MetaUrl);
        }

        [Test]
        public void ProxyUrlTest()
        {
            Assert.IsNotNullOrEmpty(_target.ProxyUrl);
        }

        [Test]
        public void ConfigUrlTest()
        {
            Assert.IsNotNullOrEmpty(_target.ConfigUrl);
        }

    }
}