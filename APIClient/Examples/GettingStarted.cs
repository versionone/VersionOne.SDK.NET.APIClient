using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace VersionOne.SDK.APIClient.Examples
{
    public sealed class GettingStarted
    {

        private readonly EnvironmentContext _context;

        private readonly IMetaModel _metaModel;
        private readonly IMetaModel _metaModelWithProxy;
        private readonly IServices _services;
        private readonly IServices _servicesWithProxy;
        private readonly IV1Configuration _config;

        public GettingStarted()
        {

            _context = new EnvironmentContext();

            _metaModel = _context.MetaModel;
            _metaModelWithProxy = _context.MetaModelWithProxy;  //if you use a proxy server
            _services = _context.Services;
            _servicesWithProxy = _context.ServicesWithProxy;  //if you use a proxy server
            _config = _context.V1Configuration;

        }

        public IV1Configuration GetV1Configuration()
        {
            return _context.V1Configuration;
        }


        public Asset GetSingleAsset()
        {
            
            var memberId = Oid.FromToken("Member:20", _metaModel);
            var query = new Query(memberId);
            var nameAttribute = _metaModel.GetAttributeDefinition("Member.Name");
            var emailAttribute = _metaModel.GetAttributeDefinition("Member.Email");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(emailAttribute);
            
            var result = _services.Retrieve(query);
            var member = result.Assets[0];

            Trace.WriteLine(member.Oid.Token);
            Trace.WriteLine(member.GetAttribute(nameAttribute).Value);
            Trace.WriteLine(member.GetAttribute(emailAttribute).Value);

            /***** OUTPUT *****
             Member:20
             Administrator
             admin@company.com
             ******************/

            return member;

        }
    }
}
