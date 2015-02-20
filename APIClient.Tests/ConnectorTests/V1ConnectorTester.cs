using System;
using System.Configuration;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.ConnectorTests
{
    [TestClass]
    public class V1ConnectorTester
    {
        private readonly string _prefix = ConfigurationManager.AppSettings["V1Url"];
        private readonly string _username = ConfigurationManager.AppSettings["V1UserName"];
        private readonly string _password = ConfigurationManager.AppSettings["V1Password"];

        [TestMethod]
        public void FluentApiConfig()
        {
            var connector = new V1Connector(_prefix);
            Assert.IsTrue(connector.Endpoint == "");
            connector.UseDataAPI();
            Assert.IsTrue(connector.Endpoint == "rest-1.v1/Data/");
            connector.UseMetaAPI();
            Assert.IsTrue(connector.Endpoint == "meta.v1/");
            connector.UseHistoryAPI();
            Assert.IsTrue(connector.Endpoint == "rest-1.v1/Hist/");
            connector.UseQueryAPI();
            Assert.IsTrue(connector.Endpoint == "query.v1/");
            connector.UseNewAPI();
            Assert.IsTrue(connector.Endpoint == "rest-1.v1/New/");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CacheCredentialWhenInitWithCredentialsException()
        {
            var connector = new V1Connector(_prefix, new NetworkCredential(_username, _password));
            connector.CacheCredential(new NetworkCredential(_username, _password), "Basic");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CacheCredentialWithNullCredentialsException()
        {
            var connector = new V1Connector(_prefix);
            connector.CacheCredential(null, "Basic");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CacheCredentialWithNullAuthtypeException()
        {
            var connector = new V1Connector(_prefix);
            connector.CacheCredential(new NetworkCredential(_username, _password), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CacheSameAuthTypeTwiceException()
        {
            var c1 = new NetworkCredential("user1", "pass2");
            var c2 = new NetworkCredential("user2", "pass2");
            var connector = new V1Connector(_prefix);

            connector.CacheCredential(c1, "Basic");
            connector.CacheCredential(c2, "Basic");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BasicAuthenticationWithNullUsernameException()
        {
            new V1Connector(_prefix)
               .WithUsernameAndPassword(null, _password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BasicAuthenticationWithNullPasswordException()
        {
            new V1Connector(_prefix)
               .WithUsernameAndPassword(_username, null);
        }
    }
}
