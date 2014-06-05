using System.IO;
using NUnit.Framework;
using OAuth2Client;
using System;
using System.Configuration;
using System.Net;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class VersionOneAPIConnectorExamples
    {
        private string _username;
        private string _password;
        private string _prefix;
        private const string Path = "rest-1.v1/Data/Member/20";

        [SetUp]
        public void Setup()
        {
            _username = ConfigurationManager.AppSettings["V1UserName"];
            _password = ConfigurationManager.AppSettings["V1Password"];
            _prefix = ConfigurationManager.AppSettings["V1Url"];
        }


        /// <summary>
        /// This is the simplest scenario, you just need to provide the UserName and Password,
        /// where Prefix is the Url for your V1 instance, e.g. "http://localhost/VersionOne.Web/"
        /// </summary>
        [Test]
        public void basic_authentication_with_username_and_password()
        {
            // creating and configuring the connector
            var connector = new VersionOneAPIConnector(_prefix)
                .WithVersionOneUsernameAndPassword(_username, _password);

            // requesting some data that requires authentication
            using (connector.GetData(Path)) ;
        }

        [Test]
        public void basic_authentication_with_constructor_supplied_credential()
        {
            var simpleCred = new NetworkCredential(_username, _password);
            var connector = new VersionOneAPIConnector(_prefix, simpleCred);

            using (connector.GetData(Path)) ;
        }


        [Test]
        public void oauth_authentication_with_storage()
        {
            var storage = new Storage.JsonFileStorage(
                @"ExamplesTests\client_secrets.json",
                @"ExamplesTests\stored_credentials.json");

            var connector = new VersionOneAPIConnector(_prefix)
                .WithOAuth2(storage);

            using (connector.GetData(Path)) ;
        }

        [Test]
        public void oauth_authentication_with_file_parameters()
        {
            const string secretsPath = @"ExamplesTests\client_secrets.json";
            const string credentialsPath = @"ExamplesTests\stored_credentials.json";

            var connector = new VersionOneAPIConnector(_prefix)
                .WithOAuth2(secretsPath, credentialsPath);

            using (connector.GetData(Path)) ;
        }

        [Test]
        [Ignore]
        public void windows_integrated_authentication()
        {
            var connector = new VersionOneAPIConnector(_prefix)
                .WithWindowsIntegratedAuthentication();

            using (connector.GetData(Path)) ;
        }

        [Test]
        public void fluent_configuration_with_multiple_credentials()
        {
            const string secretsPath = @"ExamplesTests\client_secrets.json";
            const string credentialsPath = @"ExamplesTests\stored_credentials.json";

            var connector = new VersionOneAPIConnector(_prefix)
                .WithVersionOneUsernameAndPassword(_username, _password)
                .WithOAuth2(secretsPath, credentialsPath)
                .WithWindowsIntegratedAuthentication();

            using (connector.GetData(Path)) ;
        }

        [Test]
        public void multiple_credentials_via_user_supplied_credential_cache()
        {
            const string secretsPath = @"ExamplesTests\client_secrets.json";
            const string credentialsPath = @"ExamplesTests\stored_credentials.json";

            var simpleCred = new NetworkCredential(_username, _password);

            var windowsIntegratedCredential = CredentialCache.DefaultNetworkCredentials;

            var oAuth2Credential = new OAuth2Credential(
                "apiv1",
                new Storage.JsonFileStorage(
                    secretsPath,
                    credentialsPath),
                null
                );

            var cache = new CredentialCache();
            var uri = new Uri(_prefix);
            cache.Add(uri, "Basic", simpleCred);
            cache.Add(uri, "Bearer", oAuth2Credential);
            // Suppose for some weird reason you just wanted to support NTLM:
            cache.Add(uri, "NTLM", windowsIntegratedCredential);

            var connector = new VersionOneAPIConnector(_prefix, cache);
            using (connector.GetData(Path)) ;
        }

        [Test]
        public void full_working_example_with_basic_authentication()
        {
            // Setting up a basic connection with the connector and retrieving the Member with the ID 20
            var dataConnector = new VersionOneAPIConnector(_prefix + "rest-1.v1/")
                .WithVersionOneUsernameAndPassword(_username, _password);
            var metaConnector = new VersionOneAPIConnector(_prefix + "meta.v1/");

            IMetaModel metaModel = new MetaModel(metaConnector);
            IServices services = new Services(metaModel, dataConnector);

            var memberId = Oid.FromToken("Member:20", metaModel);
            var query = new Query(memberId);
            var memberName = metaModel.GetAttributeDefinition("Member.Name");
            query.Selection.Add(memberName);

            var result = services.Retrieve(query);
        }
    }
}
