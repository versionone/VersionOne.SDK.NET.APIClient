using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class CreateStoryWithScalarAttributesVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new CreateStoryWithScalarAttributesVNext();
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

      			// TODO: what should newStory contain now?
		}
	}
}
