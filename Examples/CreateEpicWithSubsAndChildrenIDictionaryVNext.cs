using System.Collections.Generic;
using VersionOne.SDK.APIClient;
using static System.Console;
using static VersionOne.Assets.ClientUtilities;
using static Examples.PrintHelper;

namespace Examples
{
	public class CreateEpicWithSubsAndChildrenIDictionaryVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new CreateEpicWithSubsAndChildrenIDictionaryVNext();
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
