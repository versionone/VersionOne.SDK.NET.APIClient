using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests {
	[TestFixture]
	public class QueryURLBuilderTester {
		private const string VersionOneUrl = "http://integsrv01/VersionOne12/";

		[Test]
		public void SimpleQuery() {
			var testMe = new QueryURLBuilder(new Query(new MockAssetType()));
			Assert.AreEqual("Data/Mock?sel=", testMe.ToString());
		}

		[Test]
		public void Find1() {
			var query = new Query(new MockAssetType()) {Find = new QueryFind("TextToFind")};
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=&find=\"TextToFind\"", testMe.ToString());
		}

		[Test]
		public void Find2() {
			var query = new Query(new MockAssetType());
			var findin = new AttributeSelection { new MockAttributeDefinition("Name"), new MockAttributeDefinition("Description") };
			query.Find = new QueryFind("TextToFind", findin);
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=&find=\"TextToFind\"&findin=Mock.Name,Mock.Description", testMe.ToString());
		}

		[Test]
		public void SimpleQueryWithAttributes() {
			var query = new Query(new MockAssetType());
			query.Selection.Add(new MockAttributeDefinition("DefaultRole"));
			query.Selection.Add(new MockAttributeDefinition("Name"));
			query.Selection.Add(new MockAttributeDefinition("Nickname"));
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.DefaultRole,Mock.Name,Mock.Nickname", testMe.ToString());
		}

		[Test]
		public void Filter() {
			var query = new Query(new MockAssetType());
			var term = new FilterTerm(new MockAttributeDefinition("Name"));
			term.Equal("Jerry's Story");
			query.Filter = term;
			var testMe = new QueryURLBuilder(query);
			const string expectedUrl = "Data/Mock?sel=&where=Mock.Name='Jerry''s+Story'";
			Assert.AreEqual(expectedUrl, Uri.UnescapeDataString(testMe.ToString()));
		}

		[Test]
		public void Name() {
			var query = new Query(new MockAssetType());
			var term = new FilterTerm(new MockAttributeDefinition("Name"));
			term.Exists();
			query.Filter = term;
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=&where=%2BMock.Name", testMe.ToString());
		}

		[Test]
		public void MultipleAttributes() {
			var query = new Query(new MockAssetType());
			query.Selection.Add(new MockAttributeDefinition("DefaultRole"));
			query.Selection.Add(new MockAttributeDefinition("Name"));
			query.Selection.Add(new MockAttributeDefinition("Nickname"));
			var term = new FilterTerm(new MockAttributeDefinition("Name"));
			term.Equal("Jerry");
			query.Filter = term;
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.DefaultRole,Mock.Name,Mock.Nickname&where=Mock.Name='Jerry'", testMe.ToString());
		}

		[Test]
		public void NameAndEstimate() {
			IAttributeDefinition estimateAttribute = new MockAttributeDefinition("Estimate");
			var query = new Query(new MockAssetType());

			query.Selection.Add(new MockAttributeDefinition("Name"));
			query.Selection.Add(estimateAttribute);
			query.OrderBy.MinorSort(estimateAttribute, OrderBy.Order.Ascending);

			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.Name,Mock.Estimate&sort=Mock.Estimate", testMe.ToString());
		}

		[Test]
		public void StoryByName() {
			var storyId = new Oid(new MockAssetType("Story"), 1094, null);
			var query = new Query(storyId);
			query.Selection.Add(new MockAttributeDefinition("Name"));
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Story/1094/Name?", testMe.ToString());
		}

		[Test]
		public void StoryWithMomentByName() {
			var storyId = new Oid(new MockAssetType("Story"), 1094, 15);
			var query = new Query(storyId);
			query.Selection.Add(new MockAttributeDefinition("Name"));
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Story/1094/15/Name?", testMe.ToString());
		}

		[ExpectedException(typeof (NotSupportedException))]
		[Test]
		public void StoryFailure() {
			var storyId = new Oid(new MockAssetType("Story"), 1094, 15);
			var query = new Query(storyId, true);
		}

		[Test]
		public void Task() {
			var query = new Query(new MockAssetType("Task"), new MockAttributeDefinition("Story", AttributeType.Relation));
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Task?sel=Mock.Story", testMe.ToString());
		}

		[Test]
		public void MockItemByNameWithPaging() {
			var query = new Query(new MockAssetType());
			query.Selection.Add(new MockAttributeDefinition("Name"));
			query.Paging.Start = 5;
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.Name&page=2147483647,5", testMe.ToString());

			query.Paging.PageSize = 10;
			testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.Name&page=10,5", testMe.ToString());
		}

		[Test]
		public void MockItemByDate() {
			var testDate = new DateTime(2007, 10, 1, 3, 0, 0);
			var query = new Query(new MockAssetType()) {AsOf = testDate};
			var testMe = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=&asof=2007-10-01T03:00:00", testMe.ToString());
		}

		[Test]
		public void MockItemWithVariables() {
			var variable = new QueryVariable("Name", "Name1", "Name2", "Name3");
			var nameAttribute = new MockAttributeDefinition("Name");

			var query = new Query(new MockAssetType());
			query.Variables.Add(variable);
			var filter = new FilterTerm(nameAttribute);
			filter.Operate(FilterTerm.Operator.Equal, variable);
			query.Filter = filter;
			query.Selection.Add(new MockAttributeDefinition("Reference"));
			var builder = new QueryURLBuilder(query);
			Assert.AreEqual("Data/Mock?sel=Mock.Reference&where=Mock.Name=$Name&with=$Name=Name1,Name2,Name3", builder.ToString());
		}

		[Test]
		public void DatePrecision() {
			var date = new DateTime(2012, 6, 21, 15, 17, 53, 504);
			var changeDateAttribute = new MockAttributeDefinition("ChangeDate");

			var query = new Query(new MockAssetType());
			query.Selection.Add(new MockAttributeDefinition("Name"));
			var filter = new FilterTerm(changeDateAttribute);
			filter.Greater(date);
			var builder = new QueryURLBuilder(query);
			query.Filter = filter;

			var queryString = builder.ToString();
			Assert.AreEqual("Data/Mock?sel=Mock.Name&where=Mock.ChangeDate>'2012-06-21T15%3a17%3a53.504'", queryString);
		}

		[Test]
		public void DatePrecisionInVariable() {
			var date = new DateTime(2012, 6, 21, 15, 17, 53, 504);
			var changeDateAttribute = new MockAttributeDefinition("ChangeDate");

			var query = new Query(new MockAssetType());
			var variable = new QueryVariable("requestedDate", date);
			query.Selection.Add(new MockAttributeDefinition("Name"));
			query.Variables.Add(variable);
			var filter = new FilterTerm(changeDateAttribute);
			filter.Operate(FilterTerm.Operator.Equal, variable);
			var builder = new QueryURLBuilder(query);
			query.Filter = filter;

			var queryString = builder.ToString();
			Assert.AreEqual("Data/Mock?sel=Mock.Name&where=Mock.ChangeDate=$requestedDate&with=$requestedDate=2012-06-21T15%3a17%3a53.504", queryString);
		}

		[Test]
		[Ignore("Integration test, requires V1 Server")]
		public void QueryTrackedEpicsByProject() {
			var metaConnector = new V1APIConnector(VersionOneUrl + "meta.v1/", "admin", "admin");
			var metaModel = new MetaModel(metaConnector);

			var epicType = metaModel.GetAssetType("Epic");
			var scopeType = metaModel.GetAssetType("Scope");

			var query = new Query(epicType);
			const string scopeId = "Scope:1025";

			var notClosedScopeAttribute = scopeType.GetAttributeDefinition("AssetState");
			var notClosedEpicAttribute = epicType.GetAttributeDefinition("AssetState");

			var notClosedEpicTerm = new FilterTerm(notClosedEpicAttribute);
			notClosedEpicTerm.NotEqual("Closed");

			var notClosedScopeTerm = new FilterTerm(notClosedScopeAttribute);
			notClosedScopeTerm.NotEqual("Closed");
			var scopeAttribute = epicType.GetAttributeDefinition("Scope.ParentMeAndUp");
			scopeAttribute = scopeAttribute.Filter(notClosedScopeTerm);

			var scopeTerm = new FilterTerm(scopeAttribute);
			scopeTerm.Equal(scopeId);
			var superAndUpAttribute = epicType.GetAttributeDefinition("SuperAndUp");
			superAndUpAttribute = superAndUpAttribute.Filter(scopeTerm);
			var superAndUpTerm = new FilterTerm(superAndUpAttribute);
			superAndUpTerm.NotExists();
			
			var filter = new AndFilterTerm(scopeTerm, notClosedEpicTerm, superAndUpTerm);
			query.Filter = filter;
			var builder = new QueryURLBuilder(query);
			var result = builder.ToString();
			Assert.AreEqual("Data/Epic?sel=&where=(Epic.Scope.ParentMeAndUp[AssetState!='Closed']='Scope%3a1025';Epic.AssetState!='Closed';-Epic.SuperAndUp[Scope.ParentMeAndUp[AssetState!='Closed']='Scope:1025'])", result);
		}

		[Test]
		[Ignore("Integration test, requires V1 Server")]
		public void QueryTrackedEpicsForMultipleProjectsUsingVariables() {
			var metaConnector = new V1APIConnector(VersionOneUrl + "meta.v1/", "admin", "admin");
			var metaModel = new MetaModel(metaConnector);

			var scopeVariable = new QueryVariable("Scope", "Scope:2176");

			var epicType = metaModel.GetAssetType("Epic");

			var query = new Query(epicType);

			var notClosedEpicAttribute = epicType.GetAttributeDefinition("AssetState");

			var notClosedEpicTerm = new FilterTerm(notClosedEpicAttribute);
			notClosedEpicTerm.NotEqual("Closed");

			var scopeAttribute = epicType.GetAttributeDefinition("Scope");
			var scopeTerm = new FilterTerm(scopeAttribute);
			scopeTerm.Operate(FilterTerm.Operator.Equal, scopeVariable);

			var superAndUpAttribute = epicType.GetAttributeDefinition("SuperAndUp").Filter(scopeTerm);
			var superAndUpTerm = new FilterTerm(superAndUpAttribute);
			superAndUpTerm.NotExists();
			
			var filter = new AndFilterTerm(notClosedEpicTerm, scopeTerm, superAndUpTerm);
			query.Filter = filter;
			query.Variables.Add(scopeVariable);
			var builder = new QueryURLBuilder(query);
			var result = builder.ToString();
			Assert.AreEqual("Data/Epic?sel=&where=(Epic.AssetState!='Closed';Epic.Scope=$Scope;-Epic.SuperAndUp[Scope=$Scope])&with=$Scope=Scope%3A2176", result);
		}

		internal class MockAssetType : IAssetType {
			#region IAssetType Members

			private readonly string token;

			public MockAssetType() : this("Mock") {}

			public MockAssetType(String token) {
				this.token = token;
			}

			public string Token {
				get { return token; }
			}

			public string DisplayName {
				get { return null; }
			}

			public IAttributeDefinition DefaultOrderBy {
				get { return null; }
			}

			public IAttributeDefinition ShortNameAttribute {
				get { return null; }
			}

			public IAttributeDefinition NameAttribute {
				get { return null; }
			}

			public IAttributeDefinition DescriptionAttribute {
				get { return null; }
			}

			public IAttributeDefinition GetAttributeDefinition(string name) {
				return null;
			}

			public bool TryGetAttributeDefinition(string name, out IAttributeDefinition def) {
				def = null;
				return false;
			}

			public bool Is(IAssetType targettype) {
				return false;
			}

			public IAssetType Base {
				get { return null; }
			}

			public IOperation GetOperation(string name) {
				return null;
			}

			public bool TryGetOperation(string name, out IOperation op) {
				op = null;
				return false;
			}

			#endregion
		}

		private class MockAttributeDefinition : IAttributeDefinition {
			private readonly string name;
			private readonly AttributeType type;

			public MockAttributeDefinition(string attributeName) : this(attributeName, AttributeType.Opaque) {}

			public MockAttributeDefinition(string attributeName, AttributeType type) {
				name = attributeName;
				this.type = type;
			}

			#region IAssetType Members

			public IAssetType AssetType {
				get { return null; }
			}

			public string Name {
				get { return name; }
			}

			public string Token {
				get { return "Mock." + name; }
			}

			public AttributeType AttributeType {
				get { return type; }
			}

			public IAttributeDefinition Base {
				get { return null; }
			}

			public bool IsReadOnly {
				get { return false; }
			}

			public bool IsRequired {
				get { return false; }
			}

			public bool IsMultiValue {
				get { return false; }
			}

			public IAssetType RelatedAsset {
				get { return null; }
			}

			public string DisplayName {
				get { return null; }
			}

			public object Coerce(object value) {
				return null;
			}

			public IAttributeDefinition Downcast(IAssetType assetType) {
				return null;
			}

			public IAttributeDefinition Filter(IFilterTerm filter) {
				return null;
			}

			public IAttributeDefinition Join(IAttributeDefinition joined) {
				return null;
			}

			public IAttributeDefinition Aggregate(Aggregate aggregate) {
				return null;
			}

			#endregion
		}
	}
}