using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    using static ServicesConstructorTestsHelpers;

    [TestClass]
    public class When_preLoadMeta_is_false
    {
        private static IServices SUT;
        private static IAssetType AssetTypeType;
        private static IAssetType PrimaryRelationType;
        private static TestContext Context;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Context = context;
            Configure(Context);
            ConfigureRoute(Context, "/meta.v1//AssetType", MetaSamplePayloads.AssetTypeType);
            ConfigureRoute(Context, "/meta.v1//PrimaryRelation", MetaSamplePayloads.PrimaryRelationType);

            var connector = CreateConnector();
            SUT = new Services(connector);

            AssetTypeType = SUT.Meta.GetAssetType("AssetType");
            PrimaryRelationType = SUT.Meta.GetAssetType("PrimaryRelation");
        }

        [TestMethod]
        public void It_should_not_call_full_meta_route() => AssertRouteNotCalled(Context, "/meta.v1//");

        [TestMethod]
        public void It_should_let_me_get_the_AssetType_type() => Assert.IsNotNull(AssetTypeType);

        [TestMethod]
        public void It_should_access_the_AssetType_route() => AssertRouteCalled(Context, "/meta.v1//AssetType");

        [TestMethod]
        public void It_should_let_me_get_the_PrimaryRelation_type() => Assert.IsNotNull(PrimaryRelationType);

        [TestMethod]
        public void It_should_accecss_the_PrimaryRelation_route() => AssertRouteCalled(Context, "/meta.v1//PrimaryRelation");
    }
}
