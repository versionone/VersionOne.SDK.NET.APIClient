using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Query_newly_created_Story_by_OID
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Query_newly_created_Story_by_OID();
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

			var story = v1.Create(new
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

			dynamic queriedStory = v1
				.Query(story.Oid)
				.Select("Name", "Scope")
				.RetrieveFirst();

			WriteLine(queriedStory.Oid);
			WriteLine(queriedStory.Name);
			WriteLine(queriedStory["Scope"].Oid);
			WriteLine(queriedStory.Scope.Oid);
		}
	}
}