using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests.ExamplesTests
{
    [TestClass]
    [Ignore]
    public class GettingStartedTests
    {
        private string _username;
        private string _password;
        private string _metaUrl;
        private string _dataUrl;
        private string _prefix;

        [TestInitialize]
        public void Setup()
        {
            _username = ConfigurationManager.AppSettings["V1UserName"];
            _password = ConfigurationManager.AppSettings["V1Password"];
            _prefix = ConfigurationManager.AppSettings["V1Url"];
            _metaUrl = _prefix + "meta.v1/";
            _dataUrl = _prefix + "rest-1.v1/";
        }

        #region Queries
        // This section is a serie of examples, starting with simple queries and moving to more advanced queries.

        /// <summary>
        /// Retrieves the Member with ID 20 and list its name and email address
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Gets a list of all Story assets
        /// </summary>
        [TestMethod]
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

            Assert.IsTrue(result.Assets.Count > 1);
        }

        /// <summary>
        /// Use the Filter property of the Query object to filter the results that are returned. 
        /// This query will retrieve only Story assets with a "ToDo" of zero.
        /// </summary>
        public void FilterListOfAssetsTest()
        {
            IMetaModel metaModel = new MetaModel(new VersionOneAPIConnector(_metaUrl));
            IServices services = new Services(
                metaModel,
                new VersionOneAPIConnector(_dataUrl).WithVersionOneUsernameAndPassword(_username, _password));

            var assetType = metaModel.GetAssetType("Task");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var todoAttribute = assetType.GetAttributeDefinition("ToDo");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(todoAttribute);

            var toDoTerm = new FilterTerm(todoAttribute);
            toDoTerm.Equal(0);
            query.Filter = toDoTerm;
            var result = services.Retrieve(query);

            result.Assets.ForEach(asset =>
                    Assert.AreEqual(0, asset.GetAttribute(todoAttribute).Value));
        }

        /// <summary>
        /// Use the Find property of the Query object to search for text. 
        /// This query will retrieve only assets with the word "high" in the name (case insensitive)
        /// </summary>
        [TestMethod]
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
            query.Find = new QueryFind("High");
            var result = services.Retrieve(query);

            result.Assets.ForEach(
                asset => Assert.IsTrue(asset.GetAttribute(nameAttribute)
                    .Value
                    .ToString()
                    .IndexOf("High", StringComparison.OrdinalIgnoreCase)
                                       >= 0));

            Assert.IsTrue(result.Assets.Count > 1);
        }

        /// <summary>
        /// Use the OrderBy property of the Query object to sort the results. 
        /// This query will retrieve Story assets sorted by increasing estimate.
        /// 
        /// There are two methods you can call on the OrderBy class to sort your results: 
        /// MinorSort and MajorSort. 
        /// If you are sorting by only one field, it does not matter which one you use. 
        /// If you want to sort by multiple fields, you need to call either MinorSort or MajorSort multiple times. 
        /// The difference is that each time you call MinorSort, the parameter will be added to the end of the OrderBy
        /// statement. Each time you call MajorSort, the parameter will be inserted at the beginning of the OrderBy 
        /// statement.
        /// </summary>
        [TestMethod]
        public void SortListOfAssetsTest()
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
            query.OrderBy.MinorSort(estimateAttribute, OrderBy.Order.Ascending);

            var result = services.Retrieve(query);
        }

        /// <summary>
        /// Retrieve a "page" or portion of query results by using the Paging propery of the Query object. 
        /// This query will retrieve the first 3 Story assets.
        /// </summary>
        [TestMethod]
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
            // The PageSize property shown asks for 3 items, and the Start property indicates to start at 0. 
            // The next 3 items can be retrieved with PageSize=3, Start=3.
        }


        /// <summary>
        /// This query will retrieve the history of the Member asset with ID 20.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// This query will retrieve history for all Member assets.
        /// </summary>
        [TestMethod]
        public void HistoryListOfAssetsTest()
        {
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

        /// <summary>
        /// How to query an asset "as of" a specific time
        /// Use the AsOf property of the Query object to retrieve data as it existed at some point in time. 
        /// This query finds the version of each Story asset as it existed seven days ago.
        /// </summary>
        [TestMethod]
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

        #region Updates
        // Updating assets through the APIClient involves calling the Save method on the IServices object.

        /// <summary>
        /// Updating a scalar attribute on an asset is accomplished by calling the SetAttribute method on an asset,
        /// specifying the IAttributeDefinition of the attribute you wish to change and the new scalar value. 
        /// This code will update the Name attribute on the Story with ID 1094.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Updating a single-value relation is accomplished by calling the SetAttribute method on an asset, 
        /// specifying the IAttributeDefinition of the attribute you wish to change and the ID for the new relation. 
        /// This code will change the source of the Story with ID 1094.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Updating a multi-value relation is accomplished by calling either the RemoveAttributeValue 
        /// or AddAttributeValue method on an asset, specifying the IAttributeDefinition of the attribute 
        /// you wish to change and the ID of the relation you wish to add or remove. 
        /// This code will add one Member and remove another Member from the Story with ID 1124.
        /// </summary>
        [TestMethod]
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

        #region Assets operations
        // When you create a new asset in the APIClient you need to specify the "context" of another asset 
        // that will be the parent. For example, if you create a new Story asset you can specify which Scope 
        // it should be created in.

        /// <summary>
        /// This code will create a Story asset in the context of Scope with ID 0:
        /// </summary>
        [TestMethod]
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

            Assert.IsFalse(newStory.Oid.IsNull);
        }

        /// <summary>
        /// Get the Delete operation from the IMetaModel and use IServices to execute it against a story Oid.

        /// **Important note** it's a standard operating procedure to inactivate or close an asset instead of deleting it.
        /// </summary>
        [TestMethod]
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

            // The delete operation returns the Oid with the new Moment of the deleted asset. 
            // Future queries will automatically exclude deleted assets from results.
            // Currently there is no support for undeleting a deleted asset.
        }

        /// <summary>
        /// Get the Inactivate operation from the IMetaModel and use IServices to execute it against a story Oid.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Get the Reactivate operation from the IMetaModel and use IServices to execute it against a story Oid.
        /// </summary>
        [TestMethod]
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
    }
}
