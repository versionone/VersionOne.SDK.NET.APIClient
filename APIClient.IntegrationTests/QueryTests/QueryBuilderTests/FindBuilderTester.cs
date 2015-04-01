using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests.QueryTests.QueryBuilderTests
{
    [TestClass]
    public class FindBuilderTester
    {
        private FindBuilder _target;
        private IMetaModel _metaModel;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _target = new FindBuilder();
            string metaUrl = ConfigurationManager.AppSettings["V1Url"] + "meta.v1/";
            var metaConnector = new VersionOneAPIConnector(metaUrl);
            _metaModel = new MetaModel(metaConnector);
        }

        [TestMethod]
        public void BuildWithInvalidParametersTest()
        {
            var assetType = _metaModel.GetAssetType("Member");
            _target.Build(null, null);
            _target.Build(new Query(assetType), new BuildResult());
            var result = new BuildResult();
            _target.Build(new Query(assetType), result);
            Assert.AreEqual(0, result.QuerystringParts.Count);
        }

        [TestMethod]
        public void BuildWithValidParametersTest()
        {
            var assetType = _metaModel.GetAssetType("Member");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Username");
            query.Selection.Add(nameAttribute);
            query.Find = new QueryFind("admin", new AttributeSelection("Username", assetType));
            var result = new BuildResult();
            _target.Build(query, result);
            Assert.AreEqual(2, result.QuerystringParts.Count); //one part for find, one part for findin
            Assert.AreEqual("?find=admin&findin=Member.Username", result.ToUrl());
        }

        [TestMethod]
        public void QueryStringEscapeTest()
        {
            var assetType = _metaModel.GetAssetType("Member");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Username");
            query.Selection.Add(nameAttribute);
            query.Find = new QueryFind("admin@mydomain.com", new AttributeSelection("Username", assetType));  //make sure ampersand get url encoded
            var result = new BuildResult();
            _target.Build(query, result);
            Assert.AreEqual(2, result.QuerystringParts.Count); //one part for find, one part for findin
            Assert.AreEqual("?find=admin%40mydomain.com&findin=Member.Username", result.ToUrl());
        }
    }
}
