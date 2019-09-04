using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Create_Story_with_scalars_via_POCO
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Create_Story_with_scalars_via_POCO();
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

			dynamic newStory = v1.Create(new {
				AssetType = "Story",
				Scope = "Scope:1015",
				Name = $"Test Story Scope:1015 Create new Story with scalar attribute"
			});

			WriteLine("Created: " + newStory.Oid);
		}
	}
}
