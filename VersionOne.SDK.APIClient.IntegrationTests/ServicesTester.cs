using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    [TestClass]
    public class ServicesTester
    {
        private readonly string _v1InstanceUrl = ConfigurationManager.AppSettings.Get("InstanceUrl");
        private readonly string _v1Username = ConfigurationManager.AppSettings.Get("V1Username");
        private readonly string _v1Password = ConfigurationManager.AppSettings.Get("V1Password");
        private readonly string _v1AccessToken = ConfigurationManager.AppSettings.Get("V1AccessToken");
        private readonly string _windowsUsername = ConfigurationManager.AppSettings.Get("WinUsername");
        private readonly string _windowsPassword = ConfigurationManager.AppSettings.Get("WinPassword");
        private readonly string _proxyUrl = ConfigurationManager.AppSettings.Get("ProxyUrl");
        private readonly string _proxyDomain = ConfigurationManager.AppSettings.Get("ProxyDomain");
        private readonly string _proxyUsername = ConfigurationManager.AppSettings.Get("ProxyUsername");
        private readonly string _proxyPassword = ConfigurationManager.AppSettings.Get("ProxyPassword");

        [TestMethod]
        public void CreateGetAndDeleteSingleAsset()
        {
            IServices services = new Services(
                V1Connector
                    .WithInstanceUrl(_v1InstanceUrl)
                    .WithUserAgentHeader("MyApp", "1.0")
                    .WithUsernameAndPassword(_v1Username, _v1Password)
                    .Connect());

            // create a new story
            var contextId = Oid.FromToken("Scope:0", services.MetaModel);
            var storyType = services.MetaModel.GetAssetType("Story");
            var firstStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            firstStory.SetAttributeValue(nameAttribute, "Services Test Story");
            services.Save(firstStory);

            Assert.IsNotNull(firstStory.Oid);

            // get the story
            Query query = new Query(firstStory.Oid);
            query.Selection.Add(nameAttribute);
            var queryResult = services.Retrieve(query);

            Assert.IsNotNull(queryResult);
            Assert.IsNotNull(queryResult.Assets);
            var secondStory = queryResult.Assets[0];
            Assert.IsNotNull(secondStory);
            Assert.IsTrue(firstStory.Oid.Equals(secondStory.Oid));
            Assert.IsTrue(firstStory.GetAttribute(nameAttribute).Value.Equals(secondStory.GetAttribute(nameAttribute).Value));

            // delete the story
            services.ExecuteOperation(services.MetaModel.GetOperation("Story.Delete"), firstStory.Oid);
        }
    }
}
