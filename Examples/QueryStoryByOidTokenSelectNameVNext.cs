using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class QueryStoryByOidTokenSelectNameVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new QueryStoryByOidTokenSelectNameVNext();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			var story = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Create(new
				{
					AssetType = "Story",
					Scope = "Scope:0",
					Name = "My Story",
					Children = new []
					{
						new
						{
							AssetType = "Test",
							Name = "Test"
						},
						new
						{
							AssetType = "Task",
							Name = "Task"
						}
					}
				});

			var assets = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Query(story.Oid)
				.Select("Name", "Scope")
				.Retrieve();

			dynamic fetchedStory = assets[0];
			WriteLine(fetchedStory.Oid);
			WriteLine(fetchedStory.Name);
			WriteLine(fetchedStory["Scope"].Oid);
			WriteLine(fetchedStory.Scope.Oid);
		}
	}
}