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
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUrlException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("   ")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(V1Exception), "Instance url is not valid.")]
        public void InvalidUrlException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("InvalidUrl")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUserAgentNameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader(null, "1.0")
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUserAgentVersionException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", null)
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUserAgentNameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("", "1.0")
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUserAgentVersionException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "   ")
                .UseMetaApi()
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUsernameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(null, "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("username", null)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUsernameException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("    ", "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("username", "")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullWindowsIntegratedFQDNException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(null, "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullWindowsIntegratedPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("fqdn", null)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyWindowsIntegratedFQDNException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("  ", "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyWindowsIntegratedPasswordException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("fqdn", "")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullAccessTokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken(null)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyAccessTokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("   ")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyOAuth2TokenException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithOAuth2Token("")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullEndpointException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseEndpoint(null)
                .WithUsernameAndPassword("username", "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyEndpointException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseEndpoint("  ")
                .WithUsernameAndPassword("username", "password")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullProxyException()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("http://localhost/VersionOne/")
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("username", "password")
                .WithProxy(null)
                .Build();
        }
    }
}
