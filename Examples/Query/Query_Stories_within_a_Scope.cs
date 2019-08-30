﻿using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class Query_Stories_within_a_Scope
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Query_Stories_within_a_Scope();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
			const string scopeOid = "Scope:1015";

			var v1 = V1Connector
				.WithInstanceUrl(instanceUrl)
				.WithUserAgentHeader("Examples", "0.1")
				.WithAccessToken(accessToken);

			dynamic scope = v1
				.Query(scopeOid)
				.Select("Workitems:Story")
				.RetrieveFirst();

			WriteLine($"Story count: {scope["Workitems:Story"].Count}");
			foreach (var story in scope["Workitems:Story"])
			{
				WriteLine(story);
			}
		}
	}
}