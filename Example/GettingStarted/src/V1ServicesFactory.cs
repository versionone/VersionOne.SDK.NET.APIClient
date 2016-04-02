using System;
using ApiVNext;
using VersionOne.SDK.APIClient;

namespace GettingStarted
{
	public class V1ServicesFactory
	{
		public IServices CreateServices(string baseUrl = "http://localhost/VersionOne.Web", string username = "admin", string password = "admin", bool integratedAuth = false)
		{
			var builder = V1Connector.WithInstanceUrl(baseUrl)
				.WithUserAgentHeader("Sample", "0.0.0");

			var services = integratedAuth ? 
				new Services(builder.WithWindowsIntegrated().Build()) :
				new Services((builder.WithUsernameAndPassword(username, password).Build()));

			// TODO remove temp hack:
			MetaModelProvider.Meta = services.Meta;

			return services;
		}
	}
}