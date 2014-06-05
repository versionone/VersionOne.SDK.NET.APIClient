using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class GettingStartedTests
    {
        private string _username;
        private string _password;
        private string _metaUrl;
        private string _dataUrl;

        [SetUp]
        public void Setup()
        {
            _username = ConfigurationManager.AppSettings["V1UserName"];
            _password = ConfigurationManager.AppSettings["V1Password"];
            _metaUrl = ConfigurationManager.AppSettings["V1Url"] + "meta.v1/";
            _dataUrl = ConfigurationManager.AppSettings["V1Url"] + "rest-1.v1/";
        }

        #region Queries

        [Test]
        public void GetSingleAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var memberId = Oid.FromToken("Member:20", metaModel);
            var query = new Query(memberId);
            var nameAttribute = metaModel.GetAttributeDefinition("Member.Name");
            var emailAttribute = metaModel.GetAttributeDefinition("Member.Email");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(emailAttribute);
            var result = services.Retrieve(query);
            Asset member = result.Assets[0];

            Assert.IsNotNull(member);
            Assert.AreEqual("Administrator", member.GetAttribute(nameAttribute).Value);
            Assert.AreEqual("versionone@mailinator.com", member.GetAttribute(emailAttribute).Value);
        }

        [Test]
        public void GetMultipleAssetsTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var assetType = metaModel.GetAssetType("Story");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var estimateAttribute = assetType.GetAttributeDefinition("Estimate");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(estimateAttribute);
            var result = services.Retrieve(query);

            Assert.Greater(result.Assets.Count, 1);
        }


        [Test]
        public void FindListOfAssetsTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var assetType = metaModel.GetAssetType("Story");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var priorityAttribute = assetType.GetAttributeDefinition("Priority");
            query.Selection.Add(nameAttribute);
            query.Selection.Add(priorityAttribute);
            // This query will retrieve only assets with the word "high" in the name (case insensitive)
            query.Find = new QueryFind("High");
            var result = services.Retrieve(query);

            result.Assets.ForEach(
                asset => Assert.GreaterOrEqual(asset.GetAttribute(nameAttribute)
                    .Value
                    .ToString()
                    .IndexOf("High", StringComparison.OrdinalIgnoreCase)
                    , 0));

            Assert.Greater(result.Assets.Count, 1);
        }


        [Test]
        public void PageListOfAssetsTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var storyType = metaModel.GetAssetType("Story");
            var query = new Query(storyType) { Paging = { PageSize = 3, Start = 0 } };
            var result = services.Retrieve(query);

            Assert.AreEqual(3, result.Assets.Count);
        }

        [Test]
        public void HistorySingleAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var memberType = metaModel.GetAssetType("Member");
            var idAttribute = memberType.GetAttributeDefinition("ID");
            var changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
            var emailAttribute = memberType.GetAttributeDefinition("Email");

            // the boolean parameter specifies we want the historical data
            var query = new Query(memberType, true);
            query.Selection.Add(changeDateAttribute);
            query.Selection.Add(emailAttribute);

            var idTerm = new FilterTerm(idAttribute);
            idTerm.Equal("Member:20");
            query.Filter = idTerm;

            var result = services.Retrieve(query);

            Assert.AreNotEqual(0, result.Assets.Count);
        }

        [Test]
        public void HistoryListOfAssetsTest()
        {
            // This example will retrieve history for all Member assets
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var memberType = metaModel.GetAssetType("Member");
            var query = new Query(memberType, true);
            var changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
            var emailAttribute = memberType.GetAttributeDefinition("Email");
            query.Selection.Add(changeDateAttribute);
            query.Selection.Add(emailAttribute);
            var result = services.Retrieve(query);

            Assert.AreNotEqual(0, result.TotalAvaliable);
        }

        // How to query an asset "as of" a specific time
        // Use the AsOf property of the Query object to retrieve data as it existed at some point in time. 
        // This query finds the version of each Story asset as it existed seven days ago.
        [Test]
        public void HistoryAsOfTimeTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var storyType = metaModel.GetAssetType("Story");
            var query = new Query(storyType, true);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            var estimateAttribute = storyType.GetAttributeDefinition("Estimate");
            query.Selection.Add(nameAttribute);
            query.Selection.Add(estimateAttribute);

            query.AsOf = DateTime.Now.AddDays(-7);
            QueryResult result = services.Retrieve(query);

            Assert.AreNotEqual(0, result.TotalAvaliable);
        }

        #endregion

        #region Assets
        [Test]
        public void AddNewAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var projectId = Oid.FromToken("Scope:0", metaModel);
            var assetType = metaModel.GetAssetType("Story");
            var newStory = services.New(assetType, projectId);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, "My New Story");
            services.Save(newStory);

            Assert.False(newStory.Oid.IsNull);
        }

        [Test]
        public void DeleteAnAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            // create a new story so we can delete it
            var projectId = Oid.FromToken("Scope:0", metaModel);
            var assetType = metaModel.GetAssetType("Story");
            var newStory = services.New(assetType, projectId);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, "My New Story");
            services.Save(newStory);
            // delete the story
            var deleteOperation = metaModel.GetOperation("Story.Delete");
            var deletedId = services.ExecuteOperation(deleteOperation, newStory.Oid);
            var query = new Query(deletedId.Momentless);
            QueryResult result = services.Retrieve(query);

            Assert.AreEqual(0, result.TotalAvaliable);
        }

        [Test]
        public void CloseAnAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            // create a new story
            var projectId = Oid.FromToken("Scope:0", metaModel);
            var assetType = metaModel.GetAssetType("Story");
            var story = services.New(assetType, projectId);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            story.SetAttributeValue(nameAttribute, "My New Story");
            services.Save(story);

            // closes the story
            var closeOperation = metaModel.GetOperation("Story.Inactivate");
            var closeId = services.ExecuteOperation(closeOperation, story.Oid);

            var query = new Query(closeId.Momentless);
            var assetName = metaModel.GetAttributeDefinition("Story.Name");
            var assetState = metaModel.GetAttributeDefinition("Story.AssetState");
            query.Selection.Add(assetState);
            query.Selection.Add(assetName);
            QueryResult result = services.Retrieve(query);
            Asset closedStory = result.Assets[0];

            Assert.AreEqual("Closed", closedStory.GetAttribute(assetState).Value.ToString());
        }

        [Test]
        public void ReOpenAnAssetTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            // create a new story
            var projectId = Oid.FromToken("Scope:0", metaModel);
            var assetType = metaModel.GetAssetType("Story");
            var story = services.New(assetType, projectId);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            story.SetAttributeValue(nameAttribute, "My New Story");
            services.Save(story);

            // closes the story
            var closeOperation = metaModel.GetOperation("Story.Inactivate");
            var closeId = services.ExecuteOperation(closeOperation, story.Oid);

            //reopens the story
            var activateOperation = metaModel.GetOperation("Story.Reactivate");
            var activeId = services.ExecuteOperation(activateOperation, story.Oid);

            var query = new Query(activeId.Momentless);
            var assetState = metaModel.GetAttributeDefinition("Story.AssetState");
            query.Selection.Add(assetState);
            var result = services.Retrieve(query);
            Asset activeStory = result.Assets[0];

            Assert.AreEqual("Active", activeStory.GetAttribute(assetState).Value.ToString());
        }

        #endregion

        #region Updates
        [Test]
        public void UpdateScalarAttributeTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var storyId = Oid.FromToken("Story:1094", metaModel);
            var query = new Query(storyId);
            var storyType = metaModel.GetAssetType("Story");
            var nameAttribute = storyType.GetAttributeDefinition("Name");

            query.Selection.Add(nameAttribute);
            var result = services.Retrieve(query);
            var story = result.Assets[0];
            var oldName = story.GetAttribute(nameAttribute).Value.ToString();
            story.SetAttributeValue(nameAttribute, Guid.NewGuid().ToString());
            services.Save(story);

            Assert.AreNotEqual(oldName, story.GetAttribute(nameAttribute).Value.ToString());
        }

        [Test]
        public void UpdateSingleValueRelationTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var storyId = Oid.FromToken("Story:1094", metaModel);
            var query = new Query(storyId);
            var storyType = metaModel.GetAssetType("Story");
            var sourceAttribute = storyType.GetAttributeDefinition("Source");
            query.Selection.Add(sourceAttribute);
            var result = services.Retrieve(query);
            var story = result.Assets[0];
            var oldSource = story.GetAttribute(sourceAttribute).Value.ToString();
            story.SetAttributeValue(sourceAttribute, GetNextSourceId(oldSource));
            services.Save(story);
        }

        private static string GetNextSourceId(string oldSource)
        {
            if (oldSource == "StorySource:148") return "StorySource:149";
            if (oldSource == "StorySource:149") return "StorySource:150";
            return "StorySource:148";
        }

        [Test]
        public void UpdateMultiValueRelationTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var storyId = Oid.FromToken("Story:1124", metaModel);
            var query = new Query(storyId);
            var storyType = metaModel.GetAssetType("Story");
            var ownersAttribute = storyType.GetAttributeDefinition("Owners");

            query.Selection.Add(ownersAttribute);

            var result = services.Retrieve(query);
            var story = result.Assets[0];
            var values = story.GetAttribute(ownersAttribute).Values;
            var owners = values.Cast<object>().ToList();

            if (owners.Count >= 1) story.RemoveAttributeValue(ownersAttribute, owners[0]);

            services.Save(story);
        }

        #endregion
    }
}