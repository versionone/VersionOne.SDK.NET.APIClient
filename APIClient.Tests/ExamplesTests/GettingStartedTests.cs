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
        public void StoryAndDefectTrackingLevelTest()
        {
            _examples.GetStoryAndDefectTrackingLevel();
        }

        [Test]
        public void AddNewAssetTest()
        {
            Assert.IsNotNull(_examples.AddNewAsset());
        }

        [Test]
        public void DeleteAnAssetTest()
        {
            Assert.IsTrue(_examples.DeleteAnAsset());
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

        [Test]
        public void HistorySingleAssetTest()
        {
            var assets = _examples.HistorySingleAsset();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void HistoryListOfAssetsTest()
        {
            var assets = _examples.HistoryListOfAssets();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void HistoryAsOfTimeTest()
        {
            var assets = _examples.HistoryAsOfTime();
            Assert.AreNotEqual(0, assets.Count);
        }

        [Test]
        public void UpdateScalarAttributeTest()
        {
            Assert.IsTrue(_examples.UpdateScalarAttribute());
        }

        [Test]
        public void UpdateSingleValueRelationTest()
        {
            Assert.IsTrue(_examples.UpdateSingleValueRelation());
        }

        [Test]
        public void UpdateMultiValueRelationTest()
        {
            Assert.IsTrue(_examples.UpdateMultiValueRelation());
        }
    }
}