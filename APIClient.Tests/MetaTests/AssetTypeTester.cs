using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
    [TestClass]
    public class AssetTypeTester : MetaTesterBase
    {
        protected override string MetaTestKeys { get { return "AssetTypeTester"; } }

        private IAssetType ListType { get { return AssetType("List"); } }
        private IAssetType StateType { get { return AssetType("State"); } }
        private IAssetType WorkitemType { get { return AssetType("Workitem"); } }
        private IAssetType StoryType { get { return AssetType("Story"); } }
        private IAssetType TaskType { get { return AssetType("Task"); } }

        [TestMethod]
        public void Story()
        {
            IAssetType story = Meta.GetAssetType("Story");
            Assert.AreEqual("Story", story.Token);
            Assert.AreEqual("AssetType'Story", story.DisplayName);
            Assert.AreEqual("PrimaryWorkitem", story.Base.Token);
            Assert.AreEqual("Story.Order", story.DefaultOrderBy.Token);
        }

        [ExpectedExceptionAndMessage(typeof(MetaException), "Unknown AttributeDefinition: Story.Blah")]
        [TestMethod]
        public void FailLookupAttribute()
        {
            StoryType.GetAttributeDefinition("Blah");
        }

        [TestMethod]
        public void LookupAttribute()
        {
            StoryType.GetAttributeDefinition("Name");
        }

        [TestMethod]
        public void CachedAttribute()
        {
            StoryType.GetAttributeDefinition("Order");
        }

        [TestMethod]
        public void BaseAsset()
        {
            IAssetType baseasset = Meta.GetAssetType("BaseAsset");
            Assert.AreEqual("BaseAsset", baseasset.Token);
            Assert.AreEqual("AssetType'BaseAsset", baseasset.DisplayName);
            Assert.IsNull(baseasset.Base);
            Assert.AreEqual("BaseAsset.Name", baseasset.DefaultOrderBy.Token);
        }

        [ExpectedException(typeof(MetaException), "Unknown AssetType: Blah")]
        [TestMethod]
        public void InvalidAssetType()
        {
            Meta.GetAssetType("Blah");
        }

        #region Is Tests
        [TestMethod]
        public void ClassIsSelf()
        {
            Assert.IsTrue(ListType.Is(ListType));
        }

        [TestMethod]
        public void TypeIsSelf()
        {
            Assert.IsTrue(StateType.Is(StateType));
        }

        [TestMethod]
        public void TypeIsClass()
        {
            Assert.IsTrue(StoryType.Is(WorkitemType));
        }

        [TestMethod]
        public void ClassIsNotType()
        {
            Assert.IsFalse(WorkitemType.Is(StoryType));
        }

        [TestMethod]
        public void TypeIsNotPeerType()
        {
            Assert.IsFalse(StoryType.Is(TaskType));
        }

        [TestMethod]
        public void TypeIsNotClass()
        {
            Assert.IsFalse(StateType.Is(WorkitemType));
        }

        [TestMethod]
        public void TypeIsNotType()
        {
            Assert.IsFalse(StateType.Is(StoryType));
        }
        #endregion
    }
}
