using System;
using System.Net;
using OAuth2Client;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class Oauth2Authentication : IHandleAuthentication
    {
        private IStorage _storage;
        public ProxyProvider ProxyProvider { get; set; }

        public Oauth2Authentication() { }

        public Oauth2Authentication(IStorage storage)
        {
            _storage = storage;
        }

        public void Handle(Uri uriPrefix, CredentialCache credentialCache)
        {
            if (_storage == null)
                TrySetStorage();

            var oAuth2Credential = new OAuth2Credential("apiv1", _storage, GetWebProxy());
            credentialCache.Add(uriPrefix, "Bearer", oAuth2Credential);
        }

        private IWebProxy GetWebProxy()
        {
            return ProxyProvider != null ? ProxyProvider.CreateWebProxy() : null;
        }

        private void TrySetStorage()
        {
            try
            {
                var s = Storage.JsonFileStorage.Default as IStorage;
                s.GetSecrets();
                _storage = s;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Oauth2SecretsNotConfiguredException();
            }
        }
    }
}
