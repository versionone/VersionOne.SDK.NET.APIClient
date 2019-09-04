using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Update_scalar_attribute_on_newly_created_Story_via_POCO
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Update_scalar_attribute_on_newly_created_Story_via_POCO();
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
				Name = $"Test Story Scope:1015 Update scalar attribute",
				Description = "I am not going to change this description after it is set"
			});

			dynamic retrievedStory = v1.Query(newStory.Oid).Select("Name", "Description").RetrieveFirst();
			retrievedStory.Name = $"{newStory.Name} - Name updated";

			v1.Update(retrievedStory);

			dynamic updatedRetrievedStory = v1.Query(retrievedStory.Oid).Select("Name", "Description").RetrieveFirst();
			WriteLine($"{newStory.Oid} original name: {newStory.Name}");
			WriteLine($"{retrievedStory.Oid} updated name: {updatedRetrievedStory.Name}");
			WriteLine($"{newStory.Oid} original description: {newStory.Description}");
			WriteLine($"{updatedRetrievedStory.Oid} non-updated description: {updatedRetrievedStory.Description}");

			WriteLine("Now we are going to try updating the original newStory object...");

			newStory.Name = "Test Story Scope:1015 updated on original newStory object!";
			v1.Update(newStory);

			dynamic newStoryFetchedAfterUpdate = v1.Query(newStory.Oid).Select("Name").RetrieveFirst();
			WriteLine($"{newStoryFetchedAfterUpdate.Oid} updated name is: {newStoryFetchedAfterUpdate.Name}");

		}
	}
}
