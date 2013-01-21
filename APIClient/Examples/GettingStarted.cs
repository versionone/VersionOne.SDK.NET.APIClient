using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.SDK.APIClient.Examples
{
    class GettingStarted
    {

        private readonly EnvironmentContext _context;

        private IMetaModel _metaModel;
        private IMetaModel _metaModelWithProxy;
        private IServices _services;
        private IServices _servicesWithProxy;
        private IV1Configuration _config;

        public GettingStarted()
        {

            _context = new EnvironmentContext();

            _metaModel = _context.MetaModel;
            _metaModelWithProxy = _context.MetaModelWithProxy;  //if you use a proxy server
            _services = _context.Services;
            _servicesWithProxy = _context.ServicesWithProxy;  //if you use a proxy server
            _config = _context.V1Configuration;

        }

    }
}
