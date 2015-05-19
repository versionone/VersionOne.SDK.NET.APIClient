using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    [TestClass]
    public class AssetTests
    {
        private  static IMetaModel _metaModel;
        private static IServices _services;
        private static IAssetType _storyAssetType;
        private static Oid _projectId;

        [TestInitialize]
        public void Setup()
        {
            var environment = new EnvironmentContext();
            _metaModel = environment.MetaModel;
            _services = environment.Services;
            _storyAssetType = _metaModel.GetAssetType("Story");
            _projectId = LegacyIntegrationTestHelper.ProjectId;
        }

        #region Private Methods

        /// <summary>
        /// Common method for creation of an asset.
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns>Asset</returns>
        /// <exception cref="V1Exception"></exception>
        private Asset CreatesAnAsset(string assetName)
        {
            var newStory = _services.New(_storyAssetType, _projectId);
            var nameAttribute = _storyAssetType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, assetName);
            _services.Save(newStory);

            return newStory;
        }

        private QueryResult Query(Oid memberId, IAttributeDefinition attribute)
        {
            QueryResult result = null;
            var query = new Query(memberId);
            if (attribute != null)
            {
                query.Selection.Add(attribute);
            }
            try
            {
                result = _services.Retrieve(query);
            }
            catch (Exception e)
            {
                if (e is ConnectionException || e is APIException || e is OidException)
                {
                    Console.WriteLine(e.StackTrace);
                }

                throw;
            }

            return result;
        }

        #endregion Private Methods

        [TestMethod]
        [ExpectedException(typeof(OidException))]
        public void TestSetInvalidOidOnAsset()
        {
            var newStory = _services.New(_storyAssetType, _projectId);
            newStory.Oid = Oid.FromToken("", _metaModel);

            Assert.IsNull(newStory.Oid);
        }

        [TestMethod]
        public void TestSetValidOidOnAsset()
        {
            var newStory = _services.New(_storyAssetType, _projectId);
            newStory.Oid = Oid.FromToken("Story:999999", _metaModel);

            Assert.IsNotNull(newStory.Oid);
        }

        [TestMethod]
        public void TestAddAnAsset()
        {
            var newStory = CreatesAnAsset("AssetTests: Add a new asset");
            var memberId = newStory.Oid;
            var member = Query(memberId, null).Assets[0];

            Assert.AreEqual(newStory.Oid, member.Oid);
        }

        [TestMethod]
        public void TestDeleteAnAsset()
        {
            var newStory = CreatesAnAsset("AssetTests: Delete an asset");
            var deleteOperation = _metaModel.GetOperation("Story.Delete");
            var deletedId = _services.ExecuteOperation(deleteOperation, newStory.Oid);

            Assert.AreEqual(0, Query(deletedId, null).TotalAvaliable);
        }

        [TestMethod]
        public void TestCloseAnAsset()
        {
            var newStory = CreatesAnAsset("AssetTests: Close an asset");
            var closeOperation = _metaModel.GetOperation("Story.Inactivate");
            var closedId = _services.ExecuteOperation(closeOperation, newStory.Oid);
            var assetState = _metaModel.GetAttributeDefinition("Story.AssetState");
            var closedStory = Query(closedId.Momentless, assetState).Assets[0];

            Assert.AreEqual(AssetState.Closed.ToString(), closedStory.GetAttribute(assetState).Value.ToString());
        }

        [TestMethod]
        public void TestReopenAnAsset()
        {
            var newStory = CreatesAnAsset("AssetTests: Reopen an asset");
            var closeOperation = _metaModel.GetOperation("Story.Inactivate");
            var closedId = _services.ExecuteOperation(closeOperation, newStory.Oid);
            var assetState = _metaModel.GetAttributeDefinition("Story.AssetState");
            var closedStory = Query(closedId.Momentless, assetState).Assets[0];

            var reopenOperation = _metaModel.GetOperation("Story.Reactivate");
            var reopenedId = _services.ExecuteOperation(reopenOperation, closedStory.Oid);
            var reopenedStory = Query(reopenedId.Momentless, assetState).Assets[0];

            Assert.AreEqual(AssetState.Active.ToString(), reopenedStory.GetAttribute(assetState).Value.ToString());
        }

        [TestMethod]
        public void TestUpdateScalarAttribute()
        {
            var newStory = CreatesAnAsset("AssetTests: Update an scalar attribute");
            var nameAttribute = _storyAssetType.GetAttributeDefinition("Name");

            var story = Query(newStory.Oid, nameAttribute).Assets[0];
            var oldName = story.GetAttribute(nameAttribute).Value.ToString();
            story.SetAttributeValue(nameAttribute, "AssetTests: Update an scalar attribute - Name updated");
            _services.Save(story);

            Assert.AreNotSame(oldName, story.GetAttribute(nameAttribute).Value.ToString());
        }

        [TestMethod]
        public void TestUpdateSingleValueRelation()
        {
            var newStory = CreatesAnAsset("AssetTests: Update single value relation");
            var sourceAttribute = _storyAssetType.GetAttributeDefinition("Source");
            newStory.SetAttributeValue(sourceAttribute, "StorySource:156");
            _services.Save(newStory);

            var story = Query(newStory.Oid, sourceAttribute).Assets[0];

            Assert.IsNotNull(story.GetAttribute(sourceAttribute).Value.ToString());
        }

        [TestMethod]
        public void TestAddMultipleValueRelation()
        {
            var parentStory = CreatesAnAsset("AssetTests: Add multiple value relation - Parent story");
            var child1Story = CreatesAnAsset("AssetTests: Add multiple value relation - Child1 story");
            var child2Story = CreatesAnAsset("AssetTests: Add multiple value relation - Child2 story");

            var dependantsAttribute = _storyAssetType.GetAttributeDefinition("Dependants");
            parentStory.AddAttributeValue(dependantsAttribute, child1Story.Oid);
            _services.Save(parentStory);

            var story = Query(parentStory.Oid, dependantsAttribute).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());

            parentStory.AddAttributeValue(dependantsAttribute, child2Story.Oid);
            _services.Save(parentStory);

            story = Query(parentStory.Oid, dependantsAttribute).Assets[0];

            Assert.AreEqual(2, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());
        }

        [TestMethod]
        public void TestRemoveMultipleValueRelation()
        {
            var parentStory = CreatesAnAsset("AssetTests: Remove multiple value relation - Parent story");
            var child1Story = CreatesAnAsset("AssetTests: Remove multiple value relation - Child1 story");
            var child2Story = CreatesAnAsset("AssetTests: Remove multiple value relation - Child2 story");

            var dependantsAttribute = _storyAssetType.GetAttributeDefinition("Dependants");
            parentStory.AddAttributeValue(dependantsAttribute, child1Story.Oid);
            parentStory.AddAttributeValue(dependantsAttribute, child2Story.Oid);
            _services.Save(parentStory);

            var story = Query(parentStory.Oid, dependantsAttribute).Assets[0];

            Assert.AreEqual(2, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());

            parentStory.RemoveAttributeValue(dependantsAttribute, child1Story.Oid);
            _services.Save(parentStory);

            story = Query(parentStory.Oid, dependantsAttribute).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());
        }
    }
}
