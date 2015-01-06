using System;
using System.Configuration;
using System.Net;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ConnectorsTests
{
    [TestFixture]
    [Ignore("This test shows how to use the ApiConnector")]
    public class VersionOneAPIConnectorTester
    {
        private readonly string _prefix = ConfigurationManager.AppSettings["V1Url"];
        private readonly string _username = ConfigurationManager.AppSettings["V1UserName"];
        private readonly string _password = ConfigurationManager.AppSettings["V1Password"];
        private const string Path = "rest-1.v1/Data/Member/20";
        private const string ProxyUserName = "";
        private const string ProxyPassword = "";
        private const string Proxy = "http://ip:123";

        [Test]
        public void create_connector_with_proxy()
        {
            var uri = new Uri(Proxy);
            var proxyProvider = new ProxyProvider(uri, ProxyUserName, ProxyPassword);
            var connector = new VersionOneAPIConnector(_prefix, proxyProvider: proxyProvider)
                .WithVersionOneUsernameAndPassword(_username, _password);

            connector.GetData(Path);
        }

        [Test]
        public void senddata_exercise()
        {
            var connector = new VersionOneAPIConnector(_prefix)
                .WithVersionOneUsernameAndPassword(_username, _password);

            connector.SendData(Path, string.Empty);
        }

        [Test]
        public void getdata_parameterless_exercise()
        {
            var connector = new VersionOneAPIConnector(_prefix)
                .WithVersionOneUsernameAndPassword(_username, _password);

            connector.GetData();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void cache_credential_when_init_with_credentials_exception()
        {
            var connector = new VersionOneAPIConnector(_prefix, new NetworkCredential(_username, _password));
            connector.CacheCredential(new NetworkCredential(_username, _password), "Basic");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void cache_credential_with_null_credentials_exception()
        {
            var connector = new VersionOneAPIConnector(_prefix);
            connector.CacheCredential(null, "Basic");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void cache_credential_with_null_authtype_exception()
        {
            var connector = new VersionOneAPIConnector(_prefix);
            connector.CacheCredential(new NetworkCredential(_username, _password), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void cache_same_auth_type_twice_exception()
        {
            var c1 = new NetworkCredential("user1", "pass2");
            var c2 = new NetworkCredential("user2", "pass2");
            var connector = new VersionOneAPIConnector(_prefix);

            connector.CacheCredential(c1, "Basic");
            connector.CacheCredential(c2, "Basic");
        }

        [Test]
        [ExpectedException(typeof(WebException), ExpectedMessage = "The remote server returned an error: (401) Unauthorized.")]
        public void no_authentication_exception()
        {
            var anonymousConnector = new VersionOneAPIConnector(_prefix);
            anonymousConnector.GetData(Path);
        }

        [Test]
        [ExpectedException(typeof(WebException), ExpectedMessage = "The remote server returned an error: (401) Unauthorized.")]
        public void basic_authentication_with_wrong_password_exception()
        {
            var wrongCredentialsConnector = new VersionOneAPIConnector(_prefix).
                WithVersionOneUsernameAndPassword(_username, "foo");

            wrongCredentialsConnector.GetData(Path);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void basic_authentication_with_null_username_exception()
        {
            new VersionOneAPIConnector(_prefix)
               .WithVersionOneUsernameAndPassword(null, _password);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void basic_authentication_with_null_password_exception()
        {
            new VersionOneAPIConnector(_prefix)
               .WithVersionOneUsernameAndPassword(_username, null);
        }

        [Test]
        public void basic_authentication_with_construtctor_supplied_credential()
        {
            var simpleCred = new NetworkCredential(_username, _password);
            var connector = new VersionOneAPIConnector(_prefix, simpleCred);

            connector.GetData(Path);
        }

        [Test]
        public void fluent_configuration_with_multiple_credentials()
        {
            var connector = new VersionOneAPIConnector(_prefix)
                .WithVersionOneUsernameAndPassword(_username, _password)
                .WithWindowsIntegratedAuthentication();

            connector.HttpGet(Path);
        }

        [Test]
        public void multiple_credentials_via_user_supplied_credential_cache()
        {
            var simpleCred = new NetworkCredential(_username, _password);

            var windowsIntegratedCredential = CredentialCache.DefaultNetworkCredentials;

            var cache = new CredentialCache();
            var uri = new Uri(_prefix);
            cache.Add(uri, "Basic", simpleCred);
            // Suppose for some weird reason you just wanted to support NTLM:
            cache.Add(uri, "NTLM", windowsIntegratedCredential);

            var connector = new VersionOneAPIConnector(_prefix, cache);
            connector.HttpGet(Path);
        }
    }
}