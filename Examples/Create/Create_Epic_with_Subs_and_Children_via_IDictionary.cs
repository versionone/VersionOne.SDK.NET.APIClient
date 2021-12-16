using System.Collections.Generic;
using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;

namespace Examples
{
	public class Create_Epic_with_Subs_and_Children_via_IDictionary
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Create_Epic_with_Subs_and_Children_via_IDictionary();
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

			var epicDict = new Dictionary<string, object>()
			{
				{ "AssetType", "Epic" },
				{ "Scope", "Scope:0" },
				{ "Name", "My Epic" },
				{ "Subs", new []
					{
						new Dictionary<string, object>()
						{
							{ "AssetType", "Story" },
							{ "Name", "My Epic : My Story 1" },
							{ "Children", new []
								{
									new Dictionary<string, object>()
									{
										{ "AssetType", "Test" },
										{ "Name", "My Story 1: Test" }
									},
									new  Dictionary<string, object>()
									{
										{ "AssetType", "Task" },
										{ "Name", "My Story 1: Task" }
									}
								}
							}
						},
						new Dictionary<string, object>()
						{
							{ "AssetType", "Story" },
							{ "Name", "My Epic : My Story 2" },
							{ "Children", new []
								{
									new Dictionary<string, object>()
									{
										{ "AssetType", "Test" },
										{ "Name", "My Story 2: Test" }
									},
									new  Dictionary<string, object>()
									{
										{ "AssetType", "Task" },
										{ "Name", "My Story 2: Task" }
									}
								}
							}
						}
					}
				}
			};

			dynamic epic = v1.Create(epicDict);

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
