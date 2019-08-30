using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Query_Story_by_Name
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Query_Story_by_Name();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			//Set up a connection to VersionOne using simple authentication
			var assets = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Query("Story")
				.Where("Name", "Hello, Lifecycle!")
				.Select("Name", "Number")
				.Retrieve();

			foreach (dynamic story in assets)
			{
				WriteLine(story.Oid);
				WriteLine(story.Name);
				WriteLine(story.Number);
			}
		}
	}
}