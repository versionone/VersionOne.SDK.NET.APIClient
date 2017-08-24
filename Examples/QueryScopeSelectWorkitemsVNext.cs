using VersionOne.SDK.APIClient;
using static System.Console;

namespace Examples
{
	public class QueryScopeSelectWorkitemsVNext
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new QueryScopeSelectWorkitemsVNext();
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
				.Select("Name","Workitems:Defect")
				.Where("Parent","Scope:0")
				.Retrieve();

			dynamic list = assets[0].Assets[0];
			//TODO Create ouput for both attributes and the list of workitems.
			//assets[0].Assets[1].Attributes.Name   is how I accessed the friggin Name and it still returned extra attributes
			foreach (var asset in list) {
				WriteLine(asset.Name);	
			}
			
		/*	WriteLine(story.id); // TODO: OidToken
			WriteLine(story.href); // TODO: OidToken
			WriteLine(story.Attributes.Name); // TODO: OidToken
			WriteLine(story.Attributes.Name); // TODO: OidToken
			//WriteLine(story.Attributes.Ideas);
			*/
		}
	}
}