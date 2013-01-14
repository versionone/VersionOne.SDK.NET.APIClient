using System;

namespace VersionOne.SDK.APIClient
{
    public sealed class EnvironmentContext
    {

        private readonly IModelsAndServices _modelsAndServices;

        public EnvironmentContext()
        {
            _modelsAndServices = new ModelsAndServices();
            SetModelsAndServices();
        }  
        
        public EnvironmentContext(IModelsAndServices modelsAndServices)
        {
            if (modelsAndServices == null) throw new ArgumentNullException("modelsAndServices");
            _modelsAndServices = modelsAndServices;
            SetModelsAndServices();
        }

        private void SetModelsAndServices()
        {
            MetaModel = _modelsAndServices.MetaModel;
            MetaModelWithProxy = _modelsAndServices.MetaModelWithProxy;
            Services = _modelsAndServices.Services;
            ServicesWithProxy = _modelsAndServices.ServicesWithProxy;
            V1Configuration = _modelsAndServices.V1Configuration;
            V1ConfigurationWithProxy = _modelsAndServices.V1ConfigurationWithProxy;
        }

        public IMetaModel MetaModel { get; private set; }
        public IMetaModel MetaModelWithProxy { get; private set; }
        public IServices Services { get; private set; }
        public IServices ServicesWithProxy { get; private set; }
        public IV1Configuration V1Configuration { get; private set; }
        public IV1Configuration V1ConfigurationWithProxy { get; private set; }

    }
}
