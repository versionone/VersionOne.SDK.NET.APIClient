using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests.ConnectorTests
{
    [TestClass]
    public class V1ConnectorTester
    {
        private readonly string _prefix = ConfigurationManager.AppSettings["V1Url"];
        private readonly string _username = ConfigurationManager.AppSettings["V1UserName"];
        private readonly string _password = ConfigurationManager.AppSettings["V1Password"];
        private const string Member20 = "Member/20";
        private const string TestMemberName = "V1Connector Test Member";
        private const string ProxyUserName = "";
        private const string ProxyPassword = "";
        private const string Proxy = "http://ip:123";

        [TestMethod]
        [Ignore]
        public void DataApiWithProxyConstructor()
        {
            var uri = new Uri(Proxy);
            var proxyProvider = new ProxyProvider(uri, ProxyUserName, ProxyPassword);
            var connector = new V1Connector(_prefix, proxyProvider: proxyProvider)
                .UseDataAPI()
                .WithUsernameAndPassword(_username, _password);

            using (var s = connector.GetData(Member20))
            {
                Assert.IsNotNull(s);
            }
        }

        [TestMethod]
        [Ignore]
        public void DataApiWithProxyFluent()
        {
            var uri = new Uri(Proxy);
            var proxyProvider = new ProxyProvider(uri, ProxyUserName, ProxyPassword);
            var connector = new V1Connector(_prefix)
                .UseDataAPI()
                .WithUsernameAndPassword(_username, _password)
                .WithProxy(proxyProvider);

            using (var s = connector.GetData(Member20))
            {
                Assert.IsNotNull(s);
            }
        }

        [TestMethod]
        public void MetaApi()
        {
            IMetaModel metaModel = new MetaModel(new V1Connector(_prefix).UseMetaAPI());
            var assetType = metaModel.GetAssetType("Story");

            Assert.IsNotNull(assetType);
        }

        [TestMethod]
        public void DataApiWithUsernameAndPassword()
        {
            var connector = new V1Connector(_prefix)
                .UseDataAPI()
                .WithUsernameAndPassword(_username, _password);

            using (var s = connector.GetData(Member20))
            {
                Assert.IsNotNull(s);
            }
        }

        [TestMethod]
        public void QueryApi()
        {
            var testMemeber = CreateMember();

            var connector = new V1Connector(_prefix)
                .UseQueryAPI()
                .WithUsernameAndPassword(_username, _password);

            const string queryBody =
                "{\"from\": \"Member\", \"select\": [\"Name\"], \"where\": {\"Name\": \"" + TestMemberName + "\"} }";

            using (var s = connector.SendData(queryBody))
            using (var reader = new StreamReader(s))
            {
                var json = reader.ReadToEnd();
                
                Assert.IsFalse(string.IsNullOrEmpty(json));
                Assert.IsTrue(json.Trim().Equals("\"Name\": \"" + TestMemberName + "\""));
            }
        }

        private Asset CreateMember()
        {
            IMetaModel metaModel = new MetaModel(new V1Connector(_prefix).UseMetaAPI());
            IServices services = new Services(metaModel,
                new V1Connector(_prefix).UseNewAPI().WithUsernameAndPassword(_username, _password));

            var assetType = metaModel.GetAssetType("Member");
            var newMember = services.New(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            newMember.SetAttributeValue(nameAttribute, TestMemberName);
            services.Save(newMember);

            return newMember;
        }

        private void DeleteMember(Asset member)
        {
            IMetaModel metaModel = new MetaModel(new V1Connector(_prefix).UseMetaAPI());
            IServices services = new Services(metaModel,
                new V1Connector(_prefix).WithUsernameAndPassword(_username, _password));

            var deleteOperation = metaModel.GetOperation("Member.Delete");
            services.ExecuteOperation(deleteOperation, member.Oid);
        }

        //[TestMethod]
        //public void senddata_exercise()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix)
        //        .WithVersionOneUsernameAndPassword(_username, _password);
        //    var content = "<Asset><Attribute name=\"Phone\" act=\"set\">555-555-1212</Attribute></Asset>";
        //    using (var s = connector.SendData(Path, content)) { };
        //}

        //[TestMethod]
        //public void getdata_parameterless_exercise()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix)
        //        .WithVersionOneUsernameAndPassword(_username, _password);

        //    using (var s = connector.GetData(Path)) { }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        //public void cache_credential_when_init_with_credentials_exception()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix, new NetworkCredential(_username, _password));
        //    connector.CacheCredential(new NetworkCredential(_username, _password), "Basic");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void cache_credential_with_null_credentials_exception()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix);
        //    connector.CacheCredential(null, "Basic");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void cache_credential_with_null_authtype_exception()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix);
        //    connector.CacheCredential(new NetworkCredential(_username, _password), null);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void cache_same_auth_type_twice_exception()
        //{
        //    var c1 = new NetworkCredential("user1", "pass2");
        //    var c2 = new NetworkCredential("user2", "pass2");
        //    var connector = new VersionOneAPIConnector(_prefix);

        //    connector.CacheCredential(c1, "Basic");
        //    connector.CacheCredential(c2, "Basic");
        //}

        //[TestMethod]
        //[ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        //public void no_authentication_exception()
        //{
        //    var anonymousConnector = new VersionOneAPIConnector(_prefix);
        //    using (var s = anonymousConnector.GetData(Path)) { }
        //}

        //[TestMethod]
        //[ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        //public void basic_authentication_with_wrong_password_exception()
        //{
        //    var wrongCredentialsConnector = new VersionOneAPIConnector(_prefix).
        //        WithVersionOneUsernameAndPassword(_username, "foo");

        //    using (var s = wrongCredentialsConnector.GetData(Path)) { }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void basic_authentication_with_null_username_exception()
        //{
        //    new VersionOneAPIConnector(_prefix)
        //       .WithVersionOneUsernameAndPassword(null, _password);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void basic_authentication_with_null_password_exception()
        //{
        //    new VersionOneAPIConnector(_prefix)
        //       .WithVersionOneUsernameAndPassword(_username, null);
        //}

        //[TestMethod]
        //public void basic_authentication_with_construtctor_supplied_credential()
        //{
        //    var simpleCred = new NetworkCredential(_username, _password);
        //    var connector = new VersionOneAPIConnector(_prefix, simpleCred);

        //    using (var s = connector.GetData(Path)) { }
        //}

        //[TestMethod]
        //public void fluent_configuration_with_multiple_credentials()
        //{
        //    var connector = new VersionOneAPIConnector(_prefix)
        //        .WithVersionOneUsernameAndPassword(_username, _password)
        //        .WithWindowsIntegratedAuthentication();

        //    using (var s = connector.HttpGet(Path)) { };
        //}

        //[TestMethod]
        //public void multiple_credentials_via_user_supplied_credential_cache()
        //{
        //    var simpleCred = new NetworkCredential(_username, _password);

        //    var windowsIntegratedCredential = CredentialCache.DefaultNetworkCredentials;

        //    var cache = new CredentialCache();
        //    var uri = new Uri(_prefix);
        //    cache.Add(uri, "Basic", simpleCred);
        //    // Suppose for some weird reason you just wanted to support NTLM:
        //    cache.Add(uri, "NTLM", windowsIntegratedCredential);

        //    var connector = new VersionOneAPIConnector(_prefix, cache);
        //    using (var s = connector.HttpGet(Path)) { };
        //}
    }
}
