using System;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public sealed class EnvironmentContext
    {

        private readonly IModelsAndServices _modelsAndServices;

        public EnvironmentContext()
        {
            _modelsAndServices = new ModelsAndServices();
        }  
        
        public EnvironmentContext(IModelsAndServices modelsAndServices)
        {
            if (modelsAndServices == null) throw new ArgumentNullException("modelsAndServices");
            _modelsAndServices = modelsAndServices;
        }

        private IMetaModel _metaModel;
        public IMetaModel MetaModel
        {
            get
            {
                if (_metaModel != null) return _metaModel;
                _metaModel = _modelsAndServices.MetaModel;
                return _metaModel;
            }
        }

        private IMetaModel _metaModelWithProxy;
        public IMetaModel MetaModelWithProxy {
            get
            {
                if (_metaModelWithProxy != null) return _metaModelWithProxy;
                _metaModelWithProxy = _modelsAndServices.MetaModelWithProxy;
                return _metaModelWithProxy;
            }
        }

        private IServices _services;
        public IServices Services
        {
            get
            {
                if (_services != null) return _services;
                _services = _modelsAndServices.Services;
                return _services;
            }
        }

        private IServices _servicesWithProxy;
        public IServices ServicesWithProxy
        {
            get
            {
                if (_servicesWithProxy != null) return _servicesWithProxy;
                _servicesWithProxy = _modelsAndServices.ServicesWithProxy;
                return _servicesWithProxy;
            }
        }

        private IV1Configuration _v1Configuration;
        public IV1Configuration V1Configuration
        {
            get
            {
                if (_v1Configuration != null) return _v1Configuration;
                _v1Configuration = _modelsAndServices.V1Configuration;
                return _v1Configuration;
            }
        }

        private IV1Configuration _v1ConfigurationWithProxy;
        public IV1Configuration V1ConfigurationWithProxy
        {
            get
            {
                if (_v1ConfigurationWithProxy != null) return _v1ConfigurationWithProxy;
                _v1ConfigurationWithProxy = _modelsAndServices.V1ConfigurationWithProxy;
                return _v1ConfigurationWithProxy;
            }
        }

    }
}
