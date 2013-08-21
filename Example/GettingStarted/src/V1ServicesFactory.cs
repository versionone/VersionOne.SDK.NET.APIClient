using VersionOne.SDK.APIClient;

namespace GettingStarted
{
    public class V1ServicesFactory
    {
        private IMetaModel _metaModel;        

        public IServices CreateServices(string baseUrl, string userName, string password, bool integratedAuth = false)
        {
            var dataConnector = new V1APIConnector(baseUrl + "/rest-1.v1/", userName, password, integratedAuth);
            var metaConnector = new V1APIConnector(baseUrl + "/meta.v1/");
            _metaModel = new MetaModel(metaConnector);
            var services = new Services(_metaModel, dataConnector);

            return services;
        }

		public IServices CreateServices(string baseUrl, OAuth2Client.IStorage storage)
		{
			var dataConnector = new V1OAuth2APIConnector(baseUrl + "/rest-1.oauth.v1/", storage);
			var metaConnector = new V1OAuth2APIConnector(baseUrl + "/meta.v1/", storage);
			_metaModel = new MetaModel(metaConnector);
			var services = new Services(_metaModel, dataConnector);

			return services;
		}

        public IMetaModel GetMetaModel()
        {
            return _metaModel;
        }
    }
}