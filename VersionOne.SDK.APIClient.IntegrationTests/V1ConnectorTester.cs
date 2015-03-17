using System;
using System.Configuration;
using System.Net;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    [TestClass]
    public class V1ConnectorTester
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

        #region Meta API

        [TestMethod]
        public void GetData()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseMetaApi()
                .Build();

            var doc = new XmlDocument();
            using (var stream = connector.GetData("Story/Delete"))
            {
                doc.Load(stream);
            }

            var documentElement = doc.DocumentElement;
            Assert.IsNotNull(documentElement);
            Assert.IsNotNull(documentElement.GetAttribute("token").Equals("Story.Delete"));
            Assert.IsNotNull(documentElement.GetAttribute("name").Equals("Delete"));
        }

        [Ignore]
        [TestMethod]
        public void GetDataThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseMetaApi()
                .WithProxy(GetProxyProvider())
                .Build();

            var doc = new XmlDocument();
            using (var stream = connector.GetData("Story/Delete"))
            {
                doc.Load(stream);
            }

            var documentElement = doc.DocumentElement;
            Assert.IsNotNull(documentElement);
            Assert.IsNotNull(documentElement.GetAttribute("token").Equals("Story.Delete"));
            Assert.IsNotNull(documentElement.GetAttribute("name").Equals("Delete"));
        }

        #endregion

        #region Data API

        #region Authentication Exceptions

        #region Through Proxy
        
        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithoutCredentialsThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1UsernameAndPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", "wrongpassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1UsernameThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", _v1Password)
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1PasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, "wrongpassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongAccessTokenThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("wrongaccesstoken")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsUsernameAndPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", "wrongwindowspassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsUsernameThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", _windowsPassword)
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, "wrongwindowspassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1UsernameAndPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", "wrongpassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1UsernameThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", _v1Password)
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1PasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, "wrongpassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongAccessTokenThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("wrongaccesstoken")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsUsernameAndPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", "wrongwindowspassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsUsernameThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", _windowsPassword)
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [Ignore]
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, "wrongwindowspassword")
                .WithProxy(GetProxyProvider())
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }
        
        #endregion

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1UsernameAndPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", "wrongpassword")
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1Username()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", _v1Password)
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongV1Password()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, "wrongpassword")
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongAccessToken()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("wrongaccesstoken")
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsUsernameAndPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", "wrongwindowspassword")
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsUsername()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", _windowsPassword)
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void GetDataWithWrongWindowsPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, "wrongwindowspassword")
                .Build();

            using (var stream = connector.GetData("Member/20")) { }
        }
        
        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1UsernameAndPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", "wrongpassword")
                .Build();
            
            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1Username()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword("wrongusername", _v1Password)
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongV1Password()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, "wrongpassword")
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongAccessToken()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken("wrongaccesstoken")
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsUsernameAndPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", "wrongwindowspassword")
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsUsername()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated("wrongwindowsusername", _windowsPassword)
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(WebException), "The remote server returned an error: (401) Unauthorized.")]
        public void SendDataWithWrongWindowsPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, "wrongwindowspassword")
                .Build();

            using (var stream = connector.SendData("Story", GetNewStoryData())) { }
        }
        
        #endregion

        #region Through Proxy
        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithV1UsernameAndPasswordThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, _v1Password)
                .WithProxy(GetProxyProvider())
                .Build();

            SendAndGetDataTest(connector);
        }

        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithAccessTokenThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken(_v1AccessToken)
                .WithProxy(GetProxyProvider())
                .Build();

            SendAndGetDataTest(connector);
        }

        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithWindowsIntegratedCurrentUserThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated()
                .WithProxy(GetProxyProvider())
                .Build();

            SendAndGetDataTest(connector);
        }

        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithWindowsIntegratedThroughProxy()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, _windowsPassword)
                .WithProxy(GetProxyProvider())
                .Build();

            SendAndGetDataTest(connector);
        }
        #endregion

        [TestMethod]
        public void SendAndGetDataWithV1UsernameAndPassword()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithUsernameAndPassword(_v1Username, _v1Password)
                .Build();

            SendAndGetDataTest(connector);
        }

        [TestMethod]
        public void SendAndGetDataWithAccessToken()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithAccessToken(_v1AccessToken)
                .Build();

            SendAndGetDataTest(connector);
        }

        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithWindowsIntegratedCurrentUser()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated()
                .Build();

            SendAndGetDataTest(connector);
        }

        [Ignore]
        [TestMethod]
        public void SendAndGetDataWithWindowsIntegrated()
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader("MyApp", "1.0")
                .UseDataApi()
                .WithWindowsIntegrated(_windowsUsername, _windowsPassword)
                .Build();

            SendAndGetDataTest(connector);
        }
        
        #endregion

        private void SendAndGetDataTest(V1Connector connector)
        {
            // create a new story
            var doc = new XmlDocument();
            using (var stream = connector.SendData("Story", GetNewStoryData()))
            {
                doc.Load(stream);
            }
            var firstDocumentElement = doc.DocumentElement;
            Assert.IsNotNull(firstDocumentElement);
            var firstIdAttribute = firstDocumentElement.GetAttribute("id");
            Assert.IsNotNull(firstIdAttribute);


            // get the story by id
            using (var stream = connector.GetData(firstIdAttribute.Replace(':', '/')))
            {
                doc.Load(stream);
            }
            var secondDocumentElement = doc.DocumentElement;
            Assert.IsNotNull(secondDocumentElement);
            var secondIdAttribute = secondDocumentElement.GetAttribute("id");
            Assert.IsNotNull(secondIdAttribute);

            Assert.IsTrue(firstIdAttribute == secondIdAttribute);

            // delete the story
            using (var stream = connector.SendData(firstIdAttribute.Replace(':', '/') + "?op=Delete"))  { }
        }

        private string GetNewStoryData()
        {
            return "<Asset>" +
                       "<Relation name=\"Scope\" act=\"set\">" +
                           "<Asset idref=\"Scope:0\" />" +
                       "</Relation>" +
                       "<Attribute name=\"Name\" act=\"set\">V1Connector Test Story</Attribute>" +
                   "</Asset>";
        }

        private ProxyProvider GetProxyProvider()
        {
            return new ProxyProvider(new Uri(_proxyUrl), _proxyUsername, _proxyPassword,
                !string.IsNullOrWhiteSpace(_proxyDomain) ? _proxyDomain : null);
        }
    }
}
