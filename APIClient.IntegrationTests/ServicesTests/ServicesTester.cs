using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests.ServicesTests
{
    [TestClass]
    public class ServicesTester
    {
        private readonly string _v1InstanceUrl = ConfigurationManager.AppSettings.Get("V1Url");
        private readonly string _v1Username = ConfigurationManager.AppSettings.Get("V1UserName");
        private readonly string _v1Password = ConfigurationManager.AppSettings.Get("V1Password");

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
