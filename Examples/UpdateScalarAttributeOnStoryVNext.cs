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
			var v1 = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken);

			dynamic newStory = v1.Create("Story", new {
				Scope = "Scope: 1015",
				Name = $"Test Story Scope:1015 Update scalar attribute"
			});

			dynamic retrievedStory = v1.Query(newStory.OidToken).Select("Name").RetrieveFirst();
			retrievedStory.Name = $"{newStory.Name} - Name updated";

			v1.Update(retrievedStory);

			dynamic updatedStory = v1.Query(retrievedStory.OidToken).Select("Name").RetrieveFirst();
			WriteLine($"{newStory.OidToken} original name: {newStory.Name}");
			WriteLine($"{retrievedStory.OidToken} updated name: {updatedStory.Name}");
		}
	}
}
