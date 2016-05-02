using HttpMock;
using System.Configuration;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    public abstract class ServicesConstructorTesterBase
    {
        private static readonly string BASE_URL = "http://localhost:9191";
        private IHttpServer _mockServer;

        public ServicesConstructorTesterBase()
        {
            _mockServer = HttpMockRepository.At(BASE_URL);
            // The client itself relies upon this configuration setting:
            ConfigurationManager.AppSettings["V1Url"] = BASE_URL;
        }

        protected V1Connector CreateConnector()
        {
            return V1Connector.WithInstanceUrl(BASE_URL)
                .WithUserAgentHeader("ServicesConstructorTester", "0.0")
                .WithUsernameAndPassword("admin", "admin")
                .Build();
        }

        protected void ConfigureRoute(string route, string payload)
        {
            _mockServer.Stub(s => s.Get(route))
                .Return(payload)
                .OK();
        }

        protected void AssertRouteCalled(string route)
        {
            _mockServer.AssertWasCalled(s => s.Get(route));
        }

        protected void AssertRouteNotCalled(string route)
        {
            _mockServer.AssertWasNotCalled(s => s.Get(route));
        }
    }
}
