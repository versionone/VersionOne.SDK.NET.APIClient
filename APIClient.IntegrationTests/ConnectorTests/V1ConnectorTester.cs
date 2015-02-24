using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.IntegrationTests.ConnectorTests
{
    [TestClass]
    public class V1ConnectorTester
    {
        private readonly string _prefix = ConfigurationManager.AppSettings["V1Url"];
        private readonly string _username = ConfigurationManager.AppSettings["V1UserName"];
        private readonly string _password = ConfigurationManager.AppSettings["V1Password"];
        private const string Member20Path = "Member/20";
        private const string TestStoryName = "V1Connector Test Story";
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

            using (var s = connector.GetData(Member20Path))
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

            using (var s = connector.GetData(Member20Path))
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
            Assert.IsTrue(assetType.Token.Equals("Story"));
        }

        [TestMethod]
        public void DataApiWithUsernameAndPassword()
        {
            var connector = new V1Connector(_prefix)
                .UseDataAPI()
                .WithUsernameAndPassword(_username, _password);

            using (var s = connector.GetData(Member20Path))
            {
                Assert.IsNotNull(s);
            }
        }

        [TestMethod]
        public void QueryApiWithUsernameAndPassword()
        {
            var connector = new V1Connector(_prefix)
                .WithUsernameAndPassword(_username, _password);

            // create a new test story
            var testStoryOid = CreateStory(connector);

            // get the test story using query api
            connector.UseQueryAPI();
            // json for the post's body
            var data =
                "{\"from\": \"Story\", \"select\": [\"Name\"], \"where\": {\"ID\": \"" + testStoryOid + "\"} }";

            dynamic dynJson;
            using (var s = connector.SendData(data))
            using (var reader = new StreamReader(s))
            {
                dynJson = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }

            // delete the test story
            DeleteStory(connector, testStoryOid);

            Assert.IsNotNull(dynJson[0][0]);
            // the story should have the same name and oid
            Assert.IsTrue(dynJson[0][0].Name.Value.Equals(TestStoryName));
            Assert.IsTrue(dynJson[0][0]._oid.ToString().Equals(testStoryOid.Momentless.ToString()));
        }

        [TestMethod]
        public void HistoryApiWithUsernameAndPassword()
        {
            var connector = new V1Connector(_prefix)
                .WithUsernameAndPassword(_username, _password);
            // create a new test story
            var testStoryOid = CreateStory(connector);
            var storyPath = "Story/" + testStoryOid.Key;

            const int numberOfUpdates = 3;
            // update the story name many times
            for (int i = 1; i <= numberOfUpdates; i++)
            {
                var data = "<Asset><Attribute name=\"Name\" act=\"set\">" + Guid.NewGuid() + "</Attribute> </Asset>";
                var stream = connector.UseDataAPI().SendData(storyPath, data);
                stream.Dispose();
            }

            // get the test story using history api
            connector.UseHistoryAPI();

            var doc = new XmlDocument();
            using (var s = connector.GetData(storyPath))
            using (var reader = new StreamReader(s))
            {
                doc.Load(s);
            }

            Assert.IsNotNull(doc);
            Assert.IsNotNull(doc.DocumentElement);
            // the value of "total" should be equal to the number of updates plus one
            Assert.IsTrue(doc.DocumentElement.Attributes.GetNamedItem("total").Value.Equals((numberOfUpdates + 1).ToString()));

            // delete the test story
            DeleteStory(connector, testStoryOid);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void NoAuthenticationException()
        {
            var anonymousConnector = new V1Connector(_prefix);
            var stream = anonymousConnector.UseDataAPI().GetData(Member20Path);
            stream.Dispose();
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void BasicAuthenticationWithWrongPasswordException()
        {
            var wrongCredentialsConnector = new V1Connector(_prefix)
                .WithUsernameAndPassword(_username, "foo");

            var stream = wrongCredentialsConnector.UseDataAPI().GetData(Member20Path);
            stream.Dispose();
        }

        [TestMethod]
        public void BasicAuthenticationWithConstrutctorSuppliedCredential()
        {
            var simpleCred = new NetworkCredential(_username, _password);
            var connector = new V1Connector(_prefix, simpleCred);

            var stream = connector.UseDataAPI().GetData(Member20Path);
            stream.Dispose();
        }

        [Ignore]
        [TestMethod]
        public void AccessToken()
        {
            var connector = new V1Connector(_prefix).WithAccessToken("1.hJcIPWcXJGWwprchTmVn2KTPxb8=");
            var stream = connector.UseDataAPI().GetData(Member20Path);
            var x = new XmlDocument();
            x.Load(stream);
            stream.Dispose();
        }

        /// <summary>
        /// Creates a test story in V1.
        /// </summary>
        /// <param name="connector"></param>
        /// <returns></returns>
        private Oid CreateStory(V1Connector connector)
        {
            IMetaModel metaModel = new MetaModel(new V1Connector(_prefix).UseMetaAPI());
            var data = "<Asset><Relation name=\"Scope\" act=\"set\"><Asset idref=\"Scope:0\" /></Relation>" +
                          "<Attribute name=\"Name\" act=\"set\">" + TestStoryName + "</Attribute></Asset>";
            var doc = new XmlDocument();
            using (var stream = connector.UseDataAPI().SendData("Story", data))
            {
                doc.Load(stream);
            }


            return Oid.FromToken(doc.DocumentElement.GetAttribute("id"), metaModel);
        }

        /// <summary>
        /// Deletes a story from V1.
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="storyOid"></param>
        private void DeleteStory(V1Connector connector, Oid storyOid)
        {
            IMetaModel metaModel = new MetaModel(new V1Connector(_prefix).UseMetaAPI());
            var deleteOperation = metaModel.GetOperation("Story.Delete");
            connector.UseDataAPI();
            var path = storyOid.AssetType.Token + "/" + storyOid.Key + "?op=" + deleteOperation.Name;

            var stream = connector.SendData(path, string.Empty);
            stream.Dispose();
        }
    }
}
