using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class QueryStoryByOidTokenVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new QueryStoryByOidTokenVNext();
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
				.Query("Story:1006")
				.Retrieve();

			dynamic story = assets[0];
			WriteLine(story.id); // TODO: OidToken
			//WriteLine(story.Attributes.Ideas);
		}
	}
}