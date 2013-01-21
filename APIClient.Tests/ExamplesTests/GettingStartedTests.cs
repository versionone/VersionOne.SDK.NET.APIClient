using NUnit.Framework;
using VersionOne.SDK.APIClient.Examples;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class GettingStartedTests
    {

        private GettingStarted _examples;

        [SetUp]
        public void Setup()
        {
            _examples = new GettingStarted();
        }

        [TearDown]
        public void TearDown()
        {
            _examples = null;
        }

        [Test]
        public void GetV1ConfigurationTest()
        {
            Assert.IsNotNull(_examples.GetV1Configuration());
        }

        [Test]
        public void GetSingleAssetTest()
        {
            var asset = _examples.GetSingleAsset();
            Assert.IsNotNull(asset);
            Assert.IsFalse(string.IsNullOrEmpty(asset.Oid.Token));
        }

        [Test]
        public void EffortTrackingTest()
        {
            Assert.IsTrue(_examples.EffortTrackingIsEnabled());
        }

        [Test]
        public void GetMultipleAssetsTest()
        {
            var assets = _examples.GetMultipleAssets();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void FindListOfAssetsTest()
        {
            var assets = _examples.FindListOfAssets();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void FilterListOfAssetsTest()
        {
            var assets = _examples.FindListOfAssets();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void PageListOfAssetsTest()
        {
            var assets = _examples.PageListOfAssets();
            Assert.AreEqual(3, assets.Count);
        }

    }
}