using System;
using System.Configuration;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    class IntegrationTestsHelper
    {
        readonly static string TestProjectName = ".Net.SDK Integration Tests: " + DateTime.Now;

        private static Oid _testProjectId;

        public static Oid GetTestProjectOid(bool useOAuthendpoints = false)
        {
                if (_testProjectId == null)
                    CreateTestProject(useOAuthendpoints);

                return _testProjectId;
        }
        
        private static void CreateTestProject(bool useOAuthEndpoints)
        {
            V1Connector connector;
            if (useOAuthEndpoints)
            {
                connector = V1Connector.WithInstanceUrl(ConfigurationManager.AppSettings.Get("V1Url"))
                    .WithUserAgentHeader("IntegrationTests", "1.0")
                    .WithAccessToken(ConfigurationManager.AppSettings.Get("V1AccessToken"))
                    .UseOAuthEndpoints()
                    .Build();
            }
            else
            {
                connector = V1Connector.WithInstanceUrl(ConfigurationManager.AppSettings.Get("V1Url"))
                    .WithUserAgentHeader("IntegrationTests", "1.0")
                    .WithAccessToken(ConfigurationManager.AppSettings.Get("V1AccessToken"))
                    .Build();
            }
            var services = new Services(connector);
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
