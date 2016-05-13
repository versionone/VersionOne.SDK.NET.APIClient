using Machine.Specifications;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    using System.Collections.Generic;
    using static ServicesConstructorTestsHelpers;

    [Subject(typeof(Services), "Constructor")]
    public class When_preLoadMeta_is_true : ServicesConstructorSpecs
    {
        private static IServices Subject;
        private static IAssetType AssetTypeType;
        private static IAssetType PrimaryRelationType;

        Establish context = () =>
        {
            ServicesConstructorSpecs.Initialize(); // TODO: don't know if this is clean...

            Configure(Context);
            ConfigureRoute(Context, "/meta.v1//", MetaSamplePayloads.FullSubset);
            var connector = CreateConnector();
            Subject = new Services(connector, true); // preLoadMeta = true!
        };

        Because of = () =>
        {
            AssetTypeType = Subject.Meta.GetAssetType("AssetType");
            PrimaryRelationType = Subject.Meta.GetAssetType("PrimaryRelation");
        };

        It should_call_full_meta_route = () => AssertRouteCalled(Context, "/meta.v1//");

        It should_let_me_get_the_AssetType_type = () => AssetTypeType.ShouldNotBeNull();

        It should_not_access_the_AssetType_route = () => AssertRouteNotCalled(Context, "/meta.v1//AssetType");

        It should_let_me_get_the_PrimaryRelation_type = () => PrimaryRelationType.ShouldNotBeNull();

        It should_not_access_the_PrimaryRelation_route = () => AssertRouteNotCalled(Context, "/meta.v1//PrimaryRelation");
    }
}
