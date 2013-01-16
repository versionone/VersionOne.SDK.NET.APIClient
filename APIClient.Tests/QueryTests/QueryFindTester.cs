using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests
{
    [TestFixture]
    public class QueryFindTester
    {

        private EnvironmentContext _context;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _context = new EnvironmentContext();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _context = null;
        }

        [Test]
        public void FindMemberTest()
        {
            var assetType = _context.MetaModel.GetAssetType("Member");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Username");
            query.Selection.Add(nameAttribute);
            query.Find = new QueryFind("admin", new AttributeSelection("Username", assetType));
            QueryResult result = _context.Services.Retrieve(query);
            Assert.AreEqual(1, result.TotalAvaliable);
        }
    }
}