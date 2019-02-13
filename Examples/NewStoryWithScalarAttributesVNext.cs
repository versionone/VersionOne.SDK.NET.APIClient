using VersionOne.Assets;
using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class NewStoryWithScalarAttributesVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new NewStoryWithScalarAttributesVNext();
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

			dynamic story = new VersionOne.Assets.Asset("Story");
			story.Scope = "Scope:1015";
			story.Name = "Story created from newed up Asset obj";

			dynamic newStory = v1.Create(story);

      		WriteLine("Created: " + newStory.Oid);
		}
	}
}
