using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;

namespace Examples
{
	public class Query_Epics_with_Subs_and_Children
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Query_Epics_with_Subs_and_Children();
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

			dynamic results = v1
				.Query("Epic")
				.Where("Scope.Name", "Josh API Test")
				.Select(
					"Name",
					From("Subs")
					.Select(
						"Name",
						From("Children")
						.Select(
							"Name", "AssetType"
						)
					)
				)
				.Retrieve();

			foreach (var result in results)
			{
				WriteLine(result);
			}
		}
	}
}