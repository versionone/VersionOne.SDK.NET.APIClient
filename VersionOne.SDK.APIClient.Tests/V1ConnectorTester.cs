using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests
{
    [TestClass]
    public class V1ConnectorTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUrlException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(null)
                .WithUserAgentHeader("MyApp", "1.0")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUrlException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("   ")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(ConnectionException), "Instance url is not valid.")]
        public void InvalidUrlException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("InvalidUrl")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUserAgentNameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader(null, "1.0")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUserAgentVersionException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", null)
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUserAgentNameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("", "1.0")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUserAgentVersionException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "   ")
                .WithAccessToken("accesstoken")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUsernameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword(null, "password")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("username", null)
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUsernameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("    ", "password")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("username", "")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullWindowsIntegratedFQDNException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithWindowsIntegrated(null, "password")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullWindowsIntegratedPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithWindowsIntegrated("fqdn", null)
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyWindowsIntegratedFQDNException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("  ", "password")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyWindowsIntegratedPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("fqdn", "")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullAccessTokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithAccessToken(null)
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyAccessTokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithAccessToken("   ")
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyOAuth2TokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithOAuth2Token("")
                .Connect();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullProxyException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .WithUsernameAndPassword("username", "password")
                .WithProxy(null)
                .Connect();
        }
    }
}
