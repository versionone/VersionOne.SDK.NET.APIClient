using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;

namespace Examples
{
	public class Create_Epic_with_Subs_and_Children_via_tuples_approach_1
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Create_Epic_with_Subs_and_Children_via_tuples_approach_1();
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
				("Name", "Epic made from a Tuple"),
				("Subs", Assets(
					Asset(
						("AssetType", "Story"),
						("Name", "Story 1 from a Tuple"),
						("Children", Assets(
							Asset(("AssetType", "Test"), ("Name", "Test 1 from a Tuple")),
							Asset(("AssetType", "Task"), ("Name", "Task 1 from a Tuple"))
						))
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story 2 from a Tuple"),
						("Children", Assets(
							Asset(("AssetType", "Test"), ("Name", "Test 2 from a Tuple")),
							Asset(("AssetType", "Task"), ("Name", "Task 2 from a Tuple"))
						))
					)
				))
			);

			WriteLine("Epic returned from .Create (which does not requery the system, but fills in Oids linearly from server response):");
			PrintEpic(epic);

			epic = v1
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

		public static void PrintEpic(dynamic epic)
		{
			WriteLine($"Epic:");
			WriteLine(epic.Oid);
			WriteLine(epic.Name);
			WriteLine(epic.Scope);
			WriteLine("\tSubs:");
			foreach (dynamic sub in epic.Subs)
			{
				WriteLine("\t" + sub.Oid);
				WriteLine("\t" + sub.AssetType);
				WriteLine("\t" + sub.Name);
				WriteLine("\t\tChildren:");
				foreach (dynamic child in sub.Children)
				{
					WriteLine("\t\t\t" + child.Oid);
					WriteLine("\t\t\t" + child.AssetType);
					WriteLine("\t\t\t" + child.Name);
					WriteLine("\t\t\t---");
				}
				WriteLine("\t---");
			}
		}
	}
}
