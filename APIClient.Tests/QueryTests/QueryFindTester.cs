using System.Configuration;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests
{
    [TestFixture]
    public class QueryFindTester
    {
        private IMetaModel _metaModel;
        private IServices _services;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string username = ConfigurationManager.AppSettings["V1UserName"];
            string password = ConfigurationManager.AppSettings["V1Password"];
            string metaUrl = ConfigurationManager.AppSettings["V1Url"] + "meta.v1/";
            string dataUrl = ConfigurationManager.AppSettings["V1Url"] + "rest-1.v1/";

            var metaConnector = new VersionOneAPIConnector(metaUrl);
            var dataConnector = new VersionOneAPIConnector(dataUrl)
                .WithVersionOneUsernameAndPassword(username, password);

            _metaModel = new MetaModel(metaConnector);
            _services = new Services(_metaModel, dataConnector);
        }

        [Test]
        public void FindMemberTest()
        {
            var memberType = _metaModel.GetAssetType("Member");
            var memberQuery = new Query(memberType);
            var userNameAttr = memberType.GetAttributeDefinition("Username");
            memberQuery.Selection.Add(userNameAttr);
            memberQuery.Find = new QueryFind("admin", new AttributeSelection("Username", memberType));
            QueryResult result = _services.Retrieve(memberQuery);
            foreach (var member in result.Assets)
            {
                var name = member.GetAttribute(userNameAttr).Value as string;
                Assert.IsNotNullOrEmpty(name);
                if (name != null) Assert.That(name.IndexOf("admin") > -1);
            }
        }
    }
}