using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;

namespace Examples
{
	public class CreateMultipleAssetsTupledVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new CreateMultipleAssetsTupledVNext();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			var v1 = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken);

			dynamic result = v1.Create(
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 1 from Tuple")
				),
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 2 from Tuple")
				),				
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 3 from Tuple")
				),
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 4 from Tuple")
				)
			);

			WriteLine("Result returned from .Create with multiple assets:");
			WriteLine(result);
		}
	}
}
