using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ConnectorsTests
{
    [TestFixture]
    [Ignore("This test shows how to use the ApiConnector")]
    public class VersionOneAPIConnectorTester
    {
        private const string Prefix = "http://localhost/VersionOne.Web/";
        private const string Username = "admin";
        private const string Password = "admin";
        private const string Path = "rest-1.v1/Data/Member/20";
        private const string ProxyUserName = "";
        private const string ProxyPassword = "";
        private const string Proxy = "http://ip:123";

        [Test]
        public void create_connector_with_proxy()
        {
            var uri = new Uri(Proxy);
            var proxyProvider = new ProxyProvider(uri, ProxyUserName, ProxyPassword);
            var connector = new VersionOneAPIConnector(Prefix, proxyProvider: proxyProvider)
                .WithVersionOneUsernameAndPassword(Username, Password);

            connector.GetData(Path);
        }

        [Test]
        public void senddata_exercise()
        {
            var connector = new VersionOneAPIConnector(Prefix)
                .WithVersionOneUsernameAndPassword(Username, Password);

            connector.SendData(Path, string.Empty);
        }

        [Test]
        public void getdata_parameterless_exercise()
        {
            var connector = new VersionOneAPIConnector(Prefix)
                .WithVersionOneUsernameAndPassword(Username, Password);

            connector.GetData();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void cache_credential_when_init_with_credentials_exception()
        {
            var connector = new VersionOneAPIConnector(Prefix, new NetworkCredential(Username, Password));
            connector.CacheCredential(new NetworkCredential(Username, Password), "Basic");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void cache_credential_with_null_credentials_exception()
        {
            var connector = new VersionOneAPIConnector(Prefix);
            connector.CacheCredential(null, "Basic");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void cache_credential_with_null_authtype_exception()
        {
            var connector = new VersionOneAPIConnector(Prefix);
            connector.CacheCredential(new NetworkCredential(Username, Password), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void cache_same_auth_type_twice_exception()
        {
            var c1 = new NetworkCredential("user1", "pass2");
            var c2 = new NetworkCredential("user2", "pass2");
            var connector = new VersionOneAPIConnector(Prefix);

            connector.CacheCredential(c1, "Basic");
            connector.CacheCredential(c2, "Basic");
        }

        [Test]
        [ExpectedException(typeof(WebException), ExpectedMessage = "The remote server returned an error: (401) Unauthorized.")]
        public void no_authentication_exception()
        {
            var anonymousConnector = new VersionOneAPIConnector(Prefix);
            anonymousConnector.GetData(Path);
        }

        [Test]
        [ExpectedException(typeof(WebException), ExpectedMessage = "The remote server returned an error: (401) Unauthorized.")]
        public void basic_authentication_with_wrong_password_exception()
        {
            var wrongCredentialsConnector = new VersionOneAPIConnector(Prefix).
                WithVersionOneUsernameAndPassword(Username, "foo");

            wrongCredentialsConnector.GetData(Path);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void basic_authentication_with_null_username_exception()
        {
            new VersionOneAPIConnector(Prefix)
               .WithVersionOneUsernameAndPassword(null, Password);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void basic_authentication_with_null_password_exception()
        {
            new VersionOneAPIConnector(Prefix)
               .WithVersionOneUsernameAndPassword(Username, null);
        }

        [Test]
        public void basic_authentication_with_construtctor_supplied_credential()
        {
            var simpleCred = new NetworkCredential(Username, Password);
            var connector = new VersionOneAPIConnector(Prefix, simpleCred);

            connector.GetData(Path);
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void oauth_authentication_when_files_do_not_exist_exception()
        {
            new VersionOneAPIConnector(Prefix)
                .WithOAuth2(@"C:\foo.json", @"C:\foo.json");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void oauth_authentication_with_null_secrets_exception()
        {
            const string credentialsPath = @"C:\foo.json";
            new VersionOneAPIConnector(Prefix)
                .WithOAuth2(null, credentialsPath);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void oauth_authentication_with_null_credentials_exception()
        {
            const string secretsPath = @"C:\foo.json";
            new VersionOneAPIConnector(Prefix)
                .WithOAuth2(secretsPath, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void oauth_authentication_with_null_storage_exception()
        {
            new VersionOneAPIConnector(Prefix)
                .WithOAuth2(null);
        }

        [Test]
        public void oauth_authentication_with_file_path_parameters()
        {
            const string secretsPath = @"C:\Temp\client_secrets.json";
            const string credentialsPath = @"C:\Temp\stored_credentials.json";

            var connector = new VersionOneAPIConnector(Prefix)
                .WithOAuth2(secretsPath, credentialsPath);

            connector.HttpGet(Path);
        }

        [Test]
        public void fluent_configuration_with_multiple_credentials()
        {
            var connector = new VersionOneAPIConnector(Prefix)
                .WithVersionOneUsernameAndPassword(Username, Password)
                .WithWindowsIntegratedAuthentication()
                .WithOAuth2();

            connector.HttpGet(Path);
        }

        [Test]
        public void multiple_credentials_via_user_supplied_credential_cache()
        {
            const string secretsPath = @"C:\Temp\client_secrets.json";
            const string credentialsPath = @"C:\Temp\stored_credentials.json";

            var simpleCred = new NetworkCredential(Username, Password);

            var windowsIntegratedCredential = CredentialCache.DefaultNetworkCredentials;

            var oAuth2Credential = new OAuth2Client.OAuth2Credential(
                "apiv1",
                new OAuth2Client.Storage.JsonFileStorage(
                    secretsPath,
                    credentialsPath),
                null
                );

            var cache = new CredentialCache();
            var uri = new Uri(Prefix);
            cache.Add(uri, "Basic", simpleCred);
            cache.Add(uri, "Bearer", oAuth2Credential);
            // Suppose for some weird reason you just wanted to support NTLM:
            cache.Add(uri, "NTLM", windowsIntegratedCredential);

            var connector = new VersionOneAPIConnector(Prefix, cache);
            connector.HttpGet(Path);
        }
    }
}