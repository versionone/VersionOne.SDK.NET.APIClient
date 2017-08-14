using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class QueryRelationshipAttributesOnScopeVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new QueryRelationshipAttributesOnScopeVNext();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			var assets = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken)
				.Query("Scope")
				.Select("Name", "Description", "Status", "Members", "Workitems:Defect")
				.Retrieve();

			foreach (dynamic scope in assets)
			{
				WriteLine(scope.OidToken);
				WriteLine(scope.Description);
				WriteLine(scope.Status);
				WriteLine($"Members count: {scope.Members.Count}");
				foreach (dynamic member in scope.Members)
				{
					WriteLine(member);
				}
				WriteLine($"Defects count: {scope["Workitems:Defect"].Count}");
				foreach (dynamic defect in scope["Workitems:Defect"])
				{
					WriteLine(defect);
				}
				WriteLine("---");
			}

			/* Expect to produce:

			If 3 Scopes available, then:

			Scope:00001
			First scope
			null // when there is no Status
			Members count: 2
			Member:20
			Member:90 
			Defects count: 2
			Defect:00010
			Defect:00011
			---
			Scope:00002
			Second scope
			ScopeStatus:1012
			Members count: 2
			Member:20
			Member:400
			Defects count: 1
			Defect:00012
			----
			Scope:00003
			Third scope
			null // when there is no Status
			Members count: 1
			Member:20 // Always one member in this particular Multi-Value relation
			Defects count: 0 
			*/
		}
	}
}
