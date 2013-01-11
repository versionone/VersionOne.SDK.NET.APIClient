using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.SDK.APIClient
{

    public interface IModelsAndServices
    {
        IMetaModel MetaModel { get; }
        IServices Services { get; }
    }

    public sealed class ModelsAndServices : IModelsAndServices
    {

        private readonly IConnectors _connectors;
        private IMetaModel _metaModel;
        private IServices _services;

        public ModelsAndServices()
        {
            _connectors = new Connectors();
        }

        public ModelsAndServices(IConnectors connectors)
        {
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
            private set { _metaModel = value; }
        }
        public IServices Services
        {
            get
            {
                if (_services != null) return _services;
                _services = new Services(MetaModel,  _connectors.DataConnector);
                return _services;
            }
            private set { _services = value; }
        }

    }
}
