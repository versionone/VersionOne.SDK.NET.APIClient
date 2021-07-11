using VersionOne.Assets;
using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Create_Story_with_Scalars_via_Asset_class_instance
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Create_Story_with_Scalars_via_Asset_class_instance();
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
			story.Name = "Story created from newed up Asset instance";

			dynamic createdStory = v1.Create(story);

      		WriteLine("Created: " + createdStory.Oid);
		}
	}
}
