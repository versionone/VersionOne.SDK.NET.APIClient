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
            Services = _modelsAndServices.Services;
        }

        public IMetaModel MetaModel { get; private set; }
        public IServices Services { get; private set; }


    }
}
