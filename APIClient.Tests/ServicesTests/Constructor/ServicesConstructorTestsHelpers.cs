using HttpMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    public static class ServicesConstructorTestsHelpers
    {
        private static readonly string BASE_URL = "http://localhost:9191";
        private static readonly string MOCK_SERVER = "MockServer";

        public static void Configure(TestContext context)
        {
            IHttpServer mockServer = HttpMockRepository.At(BASE_URL);
            SetMockServer(context, mockServer);
        
            // The client itself relies upon this configuration setting:
            ConfigurationManager.AppSettings["V1Url"] = BASE_URL;
        }

        private static void SetMockServer(TestContext context, IHttpServer mockServer)
        {
            context.Properties[MOCK_SERVER] = mockServer;
        }

        private static IHttpServer GetMockServer(TestContext context)
        {
            return context.Properties[MOCK_SERVER] as IHttpServer;
        }

        public static V1Connector CreateConnector()
        {
            return V1Connector.WithInstanceUrl(BASE_URL)
                .WithUserAgentHeader("ServicesConstructorTester", "0.0")
                .WithUsernameAndPassword("admin", "admin")
                .Build();
        }

        public static void ConfigureRoute(TestContext context, string route, string payload)
        {
            GetMockServer(context).Stub(s => s.Get(route))
                .Return(payload)
                .OK();
        }

        public static void AssertRouteCalled(TestContext context, string route)
        {
            GetMockServer(context).AssertWasCalled(s => s.Get(route));
        }

        public static void AssertRouteNotCalled(TestContext context, string route)
        {
            GetMockServer(context).AssertWasNotCalled(s => s.Get(route));
        }
    }
}
