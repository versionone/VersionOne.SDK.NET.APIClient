using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.APIClient.Meta;
using VersionOne.SDK.APIClient.Obsolete;
using VersionOne.SDK.APIClient.Queries;
using VersionOne.SDK.APIClient.Services;
using MetaModel = VersionOne.SDK.APIClient.Obsolete.MetaModel;

namespace VersionOne.SDK.APIClient.IntegrationTests.QueryTests
{
    [TestClass]
    public class QueryFindTester
    {
        private IMetaModel _metaModel;
        private IServices _services;

        [TestInitialize]
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
            _services = new Obsolete.Services(_metaModel, dataConnector);
        }

        [TestMethod]
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
                Assert.IsFalse(string.IsNullOrEmpty(name));
                if (name != null) Assert.IsTrue(name.IndexOf("admin") > -1);
            }
        }
    }
}
