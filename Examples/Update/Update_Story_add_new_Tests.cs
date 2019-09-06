using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;

namespace Examples.Update
{
	public class Update_Story_add_new_Tests
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";
		string scope = "Scope:1015";

		static void Main()
		{
			var example = new Update_Story_add_new_Tests();
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

			dynamic firstStory = v1.Create(Asset(
					("AssetType", "Story"),
					("Scope", scope),
					("Name", "My Story"),
					("Children", Assets(
						Asset(
							("AssetType", "Test"),
							("Name", "Test 1")
						))
					)
				)
			);

			WriteLine("Created first story which has one test: " + firstStory.Oid);

			dynamic secondStory = v1.Create(Asset(
					("AssetType", "Story"),
					("Scope", scope),
					("Name", "My Second Story")
				)
			);

			WriteLine("Created second story which has no tests: " + secondStory.Oid);

			var result = v1.Create(
				Asset(
					("AssetType", "Test"),
					("Name", "Test 2"),
					("Parent", firstStory.Oid)
				),
				Asset(
					("AssetType", "Test"),
					("Name", "Test 3"),
					("Parent", firstStory.Oid)
				)
			);

			var test1Oid = result.OidTokens[0];
			var test2Oid = result.OidTokens[1];

			WriteLine($"Added the following two new tests to the first story my explicitly setting the Parent attribute: {test1Oid}, {test2Oid}");

			dynamic asset = v1.Update(secondStory.Oid, new
			{
				Children = Relations(
					Add(test1Oid),
					Add(test2Oid)
				)
			});

			WriteLine("Moved tests from first story to second story using Update syntax");
			WriteLine(asset);
		}
	}
}
