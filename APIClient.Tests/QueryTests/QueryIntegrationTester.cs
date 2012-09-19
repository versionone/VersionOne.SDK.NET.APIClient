using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests {
	[TestFixture]
	[Ignore("These tests need VersionOne instance to run; several stories will be created and deleted at the end of test run.")]
	public class QueryIntegrationTester {
		private const string V1Url = "http://integsrv01/VersionOneSDK";
		private const string Username = "admin";
		private const string Password = "admin";

		private const string InitialStoryName = "Initial name";
		private const string ChangedStoryName = "Changed name";
		private const string FinalStoryName = "Final name";

		private IMetaModel metaModel;
		private IServices services;
		private IAssetType storyType;
		private IOperation storyDeleteOperation;

		private IAttributeDefinition nameDef;
		private IAttributeDefinition scopeDef;
		private IAttributeDefinition changeDateDef;
		private IAttributeDefinition momentDef;
		private IEnumerable<IAttributeDefinition> attributesToQuery;

		private readonly ICollection<Asset> assetsToDispose = new List<Asset>();

		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			var metaConnector = new V1APIConnector(V1Url + "/meta.v1/");
			var dataConnector = new V1APIConnector(V1Url + "/rest-1.v1/", Username, Password);
			metaModel = new MetaModel(metaConnector);
			services = new Services(metaModel, dataConnector);
			
			storyType = metaModel.GetAssetType("Story");
			storyDeleteOperation = storyType.GetOperation("Delete");

			nameDef = storyType.GetAttributeDefinition("Name");
			scopeDef = storyType.GetAttributeDefinition("Scope");
			changeDateDef = storyType.GetAttributeDefinition("ChangeDate");
			momentDef = storyType.GetAttributeDefinition("Moment");
			attributesToQuery = new[] {nameDef, scopeDef, changeDateDef, momentDef};
		}

		[TearDown]
		public void TearDown() {
			foreach (var story in assetsToDispose) {
				services.ExecuteOperation(storyDeleteOperation, story.Oid);
			}
		}

		[Test]
		public void QueryStoryByMoment() {
			var storyAsset = CreateDisposableStory(InitialStoryName, "Scope:0");

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			var moment = storyAsset.GetAttribute(momentDef).Value;
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, InitialStoryName);

			storyAsset.SetAttributeValue(nameDef, ChangedStoryName);
			services.Save(storyAsset);

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, ChangedStoryName);

			var filter = new FilterTerm(momentDef);
			filter.Equal(moment);
			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery, filter)[0];
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, ChangedStoryName, "Data query should return latest workitem snapshot ignoring Moment filter");
		}

		[Test]
		public void QueryStoryHistoryByMoment() {
			var storyAsset = CreateDisposableStory(InitialStoryName, "Scope:0");

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			var moment = storyAsset.GetAttribute(momentDef).Value;
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, InitialStoryName);

			storyAsset.SetAttributeValue(nameDef, ChangedStoryName);
			services.Save(storyAsset);

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, ChangedStoryName);

			var filter = new FilterTerm(momentDef);
			filter.Equal(moment);
			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery, filter, true)[0];
			Assert.AreEqual(storyAsset.GetAttribute(nameDef).Value, InitialStoryName, "Historical query should behave with respect to provided Moment");
		}

		[Test]
		public void QueryStoryChangesWithInequalityFilter() {
			var storyAsset = CreateDisposableStory(InitialStoryName, "Scope:0");

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			var moment1 = storyAsset.GetAttribute(momentDef).Value;

			storyAsset.SetAttributeValue(nameDef, ChangedStoryName);
			services.Save(storyAsset);

			storyAsset.SetAttributeValue(nameDef, FinalStoryName);
			services.Save(storyAsset);
			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			var moment3 = storyAsset.GetAttribute(momentDef).Value;

			var filter = new FilterTerm(momentDef);
			filter.GreaterOrEqual(moment1);
			var assets = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery, filter, true);
			Assert.AreEqual(3, assets.Count);
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(InitialStoryName)));
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(ChangedStoryName)));
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(FinalStoryName)));

			filter = new FilterTerm(momentDef);
			filter.Greater(moment1);
			assets = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery, filter, true);
			Assert.AreEqual(2, assets.Count);
			Assert.IsFalse(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(InitialStoryName)));
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(ChangedStoryName)));
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(FinalStoryName)));

			var lessFilter = new FilterTerm(momentDef);
			lessFilter.Less(moment3);
			var greaterFilter = new FilterTerm(momentDef);
			greaterFilter.Greater(moment1);
			var groupFilter = new AndFilterTerm(lessFilter, greaterFilter);
			assets = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery, groupFilter, true);
			Assert.AreEqual(1, assets.Count);
			Assert.IsFalse(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(InitialStoryName)));
			Assert.IsTrue(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(ChangedStoryName)));
			Assert.IsFalse(assets.Any(x => x.GetAttribute(nameDef).Value.Equals(FinalStoryName)));
		}

		[Test]
		public void QueryStoryByChangeDate() {
			const int millisecondOffset = 5;

			var storyAsset = CreateDisposableStory(InitialStoryName, "Scope:0");

			storyAsset = GetAssetsByOid(storyAsset.Oid.Momentless, attributesToQuery)[0];
			var changeDate = (DateTime) storyAsset.GetAttribute(changeDateDef).Value;

			if(changeDate.Millisecond < millisecondOffset) {
				Assert.Ignore("Querying items by date with high precision does not make sense because seconds number will be changed by offset");
			}

			var dateTerm = new FilterTerm(changeDateDef);
			dateTerm.Greater(changeDate.AddMilliseconds(-millisecondOffset));
			var stories = GetStoryAssets(dateTerm);
			Assert.IsTrue(stories.Any(x => x.Oid.Momentless.Equals(storyAsset.Oid.Momentless)));

			dateTerm = new FilterTerm(changeDateDef);
			dateTerm.Less(changeDate.AddMilliseconds(-millisecondOffset));
			stories = GetStoryAssets(dateTerm);
			Assert.IsFalse(stories.Any(x => x.Oid.Momentless.Equals(storyAsset.Oid.Momentless)));
		}

		private Asset CreateDisposableStory(string name, string scopeToken) {
			var story = new Asset(storyType);
			assetsToDispose.Add(story);
			story.SetAttributeValue(nameDef, name);
			story.SetAttributeValue(scopeDef, Oid.FromToken(scopeToken, metaModel));
			services.Save(story);
			return story;
		}

		private AssetList GetAssetsByOid(Oid oid, IEnumerable<IAttributeDefinition> attributesToLoad, IFilterTerm filter = null, bool historicalQuery = false) {
			var query = new Query(oid, historicalQuery);
			query.Selection.AddRange(attributesToLoad);

			if(filter != null) {
				query.Filter = filter;
			}

			return services.Retrieve(query).Assets;
		}

		private AssetList GetStoryAssets(IFilterTerm filter) {
			var query = new Query(storyType) {Filter = filter};
			query.Selection.AddRange(attributesToQuery);
			return services.Retrieve(query).Assets;
		}
	}
}