using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class QueryStoryByNumberVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new QueryStoryByNumberVNext();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			var assets = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Query("Story")
				.Where("Number", "S-01001")
				.Select("Name", "Number")
				.Retrieve();

			foreach (dynamic story in assets)
			{
				WriteLine(story.OidToken);
				WriteLine(story.Name);
				WriteLine(story.Number);
			}
		}
	}
}