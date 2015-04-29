using System.Configuration;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    class IntegrationTestsHelper
    {
        const string TestProjectName = ".Net.SDK Integration Tests";

        private static Oid _testProjectId;

        public static Oid TestProjectOid
        {
            get
            {
                if (_testProjectId == null)
                    CreateTestProject();

                return _testProjectId;
            }
        }

        private static void CreateTestProject()
        {
            var services = new Services(V1Connector.WithInstanceUrl(ConfigurationManager.AppSettings.Get("V1Url"))
                .WithUserAgentHeader("IntegrationTests", "1.0")
                .WithAccessToken(ConfigurationManager.AppSettings.Get("V1AccessToken"))
                .Build());
            var assetType = services.Meta.GetAssetType("Scope");
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var projectId = services.GetOid("Scope:0");
            var newAsset = services.New(assetType, projectId);
            newAsset.SetAttributeValue(nameAttribute, TestProjectName);
            services.Save(newAsset);
            _testProjectId = newAsset.Oid.Momentless;
        }
    }
}
