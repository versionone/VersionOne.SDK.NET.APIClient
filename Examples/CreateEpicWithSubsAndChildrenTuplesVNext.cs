using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;
using static Examples.PrintHelper;
using VersionOne.Assets;

namespace Examples
{
	public class CreateEpicWithSubsAndChildrenTuplesVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new CreateEpicWithSubsAndChildrenTuplesVNext();
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


			dynamic epic = v1.Create(Attributes(
				("AssetType", "Epic"),
				("Scope", "Scope:0"),
				("Name", "Epic made from a Tuple"),
				("Subs", Assets(
					Asset(
						"Story",
						("Name", "Story 1 from a Tuple"),
						("Children", Assets(
							Asset("Test", ("Name", "Test 1 from a Tuple")),
							Asset("Task", ("Name", "Task 1 from a Tuple"))
						))
					),
					Asset(
						"Story",
						("Name", "Story 2 from a Tuple"),
						("Children", Assets(
							Asset("Test", ("Name", "Test 2 from a Tuple")),
							Asset("Task", ("Name", "Task 2 from a Tuple"))
						))
					)
				))
			));

			WriteLine("Epic returned from .Create (which does not requery the system, but fills in Oids linearly from server response):");
			PrintEpic(epic);

			epic = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Query(epic.Oid)
				.Select(
					"Name",
					"Scope",
					From("Subs")
					.Select(
						"AssetType",
						"Name",
						From("Children")
						.Select(
							"AssetType",
							"Name"
						)
					)
				)
				.RetrieveFirst();

			WriteLine();
			WriteLine("Epic returned from .Query, requerying the system with subselect syntax to pull in nested relationships:");
			PrintEpic(epic);
		}
	}
}
