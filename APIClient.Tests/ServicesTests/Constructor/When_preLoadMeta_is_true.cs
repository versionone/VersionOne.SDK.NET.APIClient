using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    [TestFixture]
    public class When_preLoadMeta_is_true : ServicesConstructorTesterBase
    {
        private IServices _sut;
        private IAssetType _assetTypeType;
        private IAssetType _primaryRelationType;

        [TestFixtureSetUp]
        public void Context()
        {
            ConfigureRoute("/meta.v1//", MetaSamplePayloads.FullSubset);
            var connector = CreateConnector();
            _sut = new Services(connector, true); // preLoadMeta = true!S

            _assetTypeType = _sut.Meta.GetAssetType("AssetType");
            _primaryRelationType = _sut.Meta.GetAssetType("PrimaryRelation");
        }

        [Test]
        public void It_should_call_full_meta_route() => AssertRouteCalled("/meta.v1//");

        [Test]
        public void It_should_let_me_get_the_AssetType_type() => Assert.IsNotNull(_assetTypeType);

        [Test]
        public void It_should_not_access_the_AssetType_route() => AssertRouteNotCalled("/meta.v1//AssetType");

        [Test]
        public void It_should_let_me_get_the_PrimaryRelation_type() => Assert.IsNotNull(_primaryRelationType);

        [Test]
        public void It_should_not_access_the_PrimaryRelation_route() => AssertRouteNotCalled("/meta.v1//PrimaryRelation");
    }
}
