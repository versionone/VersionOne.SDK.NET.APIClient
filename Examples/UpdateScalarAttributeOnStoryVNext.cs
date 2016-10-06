using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class UpdateScalarAttributeOnStoryVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new UpdateScalarAttributeOnStoryVNext();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			const string scope = "Scope: 1015";

			var v1 = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken);

			var originalName = $"Test Story {scope} Update scalar attribute";

			var story = v1.Create("Story", new {
				Scope = scope,
				Name = originalName
			});

			var oidToken = story.OidToken;

			dynamic retrievedStory = v1
				.Query("Story")
				.Id(oidToken)
				.Select("Name")
				.RetrieveFirst();

			var retrievedOriginalName = retrievedStory.Name;
			var updatedName = $"{originalName} - Name updated";

			v1.Update(oidToken, new {
				Name = updatedName
			});

			dynamic updatedStory = v1
				.Query("Story")
				.Id(oidToken)
				.Select("Name")
				.RetrieveFirst();

			var retrievedUpdatedName = updatedStory.Name;

			WriteLine($"Retrieved original name: {retrievedOriginalName}");
			WriteLine($"Retrieved updated name: {retrievedUpdatedName}");
		}
	}
}
