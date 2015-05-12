using System;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This interface has been deprecated. Please use V1Connector instead.")]
    public interface IModelsAndServices
    {
        IMetaModel MetaModel { get; }
        IMetaModel MetaModelWithProxy { get; }
        IServices Services { get; }
        IServices ServicesWithProxy { get; }
        IV1Configuration V1Configuration { get; }
        IV1Configuration V1ConfigurationWithProxy { get; }
    }

    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public sealed class ModelsAndServices : IModelsAndServices
    {

        private readonly IConnectors _connectors;
        private IMetaModel _metaModel;
        private IMetaModel _metaModelWithProxy;
        private IServices _services;
        private IServices _servicesWithProxy;
        private V1Configuration _v1Config;
        private V1Configuration _v1ConfigWithProxy;

        public ModelsAndServices()
        {
            _connectors = new Connectors();
        }

        public ModelsAndServices(IConnectors connectors)
        {
            if (connectors == null) throw new ArgumentNullException("connectors");
            _connectors = connectors;
        }

        public IMetaModel MetaModel
        {
            get 
            { 
                if (_metaModel != null) return _metaModel;
                _metaModel = new MetaModel(_connectors.MetaConnector);
                return _metaModel;
            }
        }

        public IMetaModel MetaModelWithProxy
        {
            get
            {
                if (_metaModelWithProxy != null) return _metaModel;
                _metaModelWithProxy = new MetaModel(_connectors.MetaConnectorWithProxy);
                return _metaModelWithProxy;
            }
        }

        public IServices Services
        {
            get
            {
                if (_services != null) return _services;
                _services = new Services(MetaModel,  _connectors.DataConnector);
                return _services;
            }
        }

        public IServices ServicesWithProxy
        {
            get
            {
                if (_servicesWithProxy != null) return _servicesWithProxy;
                _servicesWithProxy = new Services(MetaModel, _connectors.DataConnectorWithProxy);
                return _servicesWithProxy;
            }
        }

        public IV1Configuration V1Configuration
        {
            get
            {
                if (_v1Config != null) return _v1Config;
                _v1Config = new V1Configuration(_connectors.ConfigurationConnector);
                return _v1Config;
            }
        }

        public IV1Configuration V1ConfigurationWithProxy
        {
            get
            {
                if (_v1ConfigWithProxy != null) return _v1ConfigWithProxy;
                _v1ConfigWithProxy = new V1Configuration(_connectors.ConfigurationConnectorWithProxy);
                return _v1ConfigWithProxy;
            }
        }

    }
}
