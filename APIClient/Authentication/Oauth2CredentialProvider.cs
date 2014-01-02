using System;
using System.Net;
using OAuth2Client;

namespace VersionOne.SDK.APIClient.Authentication
{
    public class Oauth2CredentialProvider : ICredentialProvider
    {
        private IStorage _storage;

        public Oauth2CredentialProvider() { }

        public Oauth2CredentialProvider(IStorage storage)
        {
            _storage = storage;
        }

        public void Handle(Uri uriPrefix, CredentialCache credentialCache, ProxyProvider proxyProvider)
        {
            if (_storage == null)
                TrySetStorage();

            var oAuth2Credential = new OAuth2Credential("apiv1", _storage, GetWebProxy(proxyProvider));
            credentialCache.Add(uriPrefix, "Bearer", oAuth2Credential);
        }

        private IWebProxy GetWebProxy(ProxyProvider proxyProvider)
        {
            return proxyProvider != null ? proxyProvider.CreateWebProxy() : null;
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
