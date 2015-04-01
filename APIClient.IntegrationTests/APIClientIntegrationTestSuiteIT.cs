namespace VersionOne.SDK.APIClient.IntegrationTests
{
    public class APIClientIntegrationTestSuiteIT
    {
        private static IMetaModel _metaModel;
        private static IServices _services;
        private static EnvironmentContext _context;
        private static Oid _projectId;

        const string TestProjectName = ".Net.SDK Integration Tests";

        public static Oid ProjectId
        {
            get
            {
                if (_projectId == null)
                {
                    Setup();
                }

                return _projectId;
            }
        }

        public static EnvironmentContext Context
        {
            get
            {
                if (_context == null)
                {
                    Setup();
                }

                return _context;
            }
        }

        public static void Setup()
        {
            _context = new EnvironmentContext();
            _metaModel = _context.MetaModel;
            _services = _context.Services;

            CreateTestProject();
        }

        /// <summary>
        /// Creates a new V1 project for integration test assets.
        /// </summary>
        private static void CreateTestProject()
        {
            var assetType = _metaModel.GetAssetType("Scope");
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var projectId = Oid.FromToken("Scope:0", _metaModel);
            var newAsset = _services.New(assetType, projectId);
            newAsset.SetAttributeValue(nameAttribute, TestProjectName);
            _services.Save(newAsset);
            _projectId = newAsset.Oid.Momentless;
        }
    }
}
