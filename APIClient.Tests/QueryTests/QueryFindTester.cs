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
            var memberType = _context.MetaModel.GetAssetType("Member");
            var memberQuery = new Query(memberType);
            var userNameAttr = memberType.GetAttributeDefinition("Username");
            memberQuery.Selection.Add(userNameAttr);
            memberQuery.Find = new QueryFind("admin", new AttributeSelection("Username", memberType));
            QueryResult result = _context.Services.Retrieve(memberQuery);
            foreach (var member in result.Assets)
            {
                var name = member.GetAttribute(userNameAttr).Value as string;
                Assert.IsNotNullOrEmpty(name);
                if (name != null) Assert.That(name.IndexOf("admin") > -1);
            }
        }
    }
}