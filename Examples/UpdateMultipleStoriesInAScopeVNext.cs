using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;
using static VersionOne.Assets.ComparisonFunctions;

namespace Examples
{
	public class UpdateMultipleStoriesInAScopeVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new UpdateMultipleStoriesInAScopeVNext();
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

			dynamic epic = v1.Create(
				("AssetType", "Epic"),
				("Scope", "Scope:0"),
				("Name", "Epic with four Stories"),
				("Subs", Assets(
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Another Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Another Story in Epic")
					)
				))
			);

			IEnumerable<string> updated = v1.Update(
				From("Story")
				.Where(
					Equal("Name", "Story in Epic", "Another Story in Epic"),
					Equal("Scope", "Scope:0"),
					Equal("Super", epic.Oid)
				), new
				{
					Description = "Updated via bulk API"
				});

			WriteLine("Updated the following Assets: " + string.Join(", ", updated));
		}
	}
}
