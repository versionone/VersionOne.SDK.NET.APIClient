using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests.QueryBuildersTesters
{
    [TestFixture]
    public class FindBuilderTester
    {
        
        private FindBuilder _target;
        private EnvironmentContext _context;

        [SetUp]
        public void Setup()
        {
            _target = new FindBuilder();
            _context = new EnvironmentContext();
        }

        [TearDown]
        public void TearDown()
        {
            _target = null;
            _context = null;
        }

        [Test]
        public void BuildWithInvalidParametersTest()
        {
            var assetType = _context.MetaModel.GetAssetType("Member");
            _target.Build(null, null);
            _target.Build(new Query(assetType), new BuildResult());
            var result = new BuildResult();
            _target.Build(new Query(assetType), result);
            Assert.AreEqual(0, result.QuerystringParts.Count);
        }

        [Test]
        public void BuildWithValidParametersTest()
        {
            var assetType = _context.MetaModel.GetAssetType("Member");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Username");
            query.Selection.Add(nameAttribute);
            query.Find = new QueryFind("admin", new AttributeSelection("Username", assetType));
            var result = new BuildResult();
            _target.Build(query, result);
            Assert.AreEqual(2, result.QuerystringParts.Count); //one part for find, one part for findin
            Assert.AreEqual("?find=admin&findin=Member.Username", result.ToUrl());
        }

        [Test]
        public void QueryStringEscapeTest()
        {
            var assetType = _context.MetaModel.GetAssetType("Member");
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