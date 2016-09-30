using System;
using VersionOne.SDK.APIClient;

namespace Examples
{
	public class QueryStoryByNumber
	{
		string instanceUrl = "https://www14.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		public void Run()
		{
			//Set up a connection to VersionOne using simple authentication
			V1Connector connector = V1Connector
				  .WithInstanceUrl(instanceUrl)
				  .WithUserAgentHeader("Examples", "0.1")
				  .WithAccessToken(accessToken)
				  .Build();

			IServices services = new Services(connector);

			//Determine which VersionOne Asset you would like to look for
			IAssetType storyType = services.Meta.GetAssetType("Story");

			//Prepare this query object.  I am saying "Hey, I want to query a story
			Query query = new Query(storyType);

			//Define the attributes that you would like to access from that Story
			IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
			IAttributeDefinition numberAttribute = storyType.GetAttributeDefinition("Number");

			//Add them to the query object since we need to get these specific attributes
			query.Selection.Add(nameAttribute);
			query.Selection.Add(numberAttribute);

			//Since we need to get a specific Story or Stories that meet some criteria, we set up a filter
			FilterTerm term = new FilterTerm(numberAttribute);
			term.Equal("S-01001");
			query.Filter = term;

			// We do the actually query on the server here and get our results to be processed soon after
			QueryResult result = services.Retrieve(query);


			foreach (Asset story in result.Assets)
			{
				//This first line grabs and prints the system identifier OID of the current Story 
				Console.WriteLine(story.Oid.Token);
				Console.WriteLine(story.GetAttribute(nameAttribute).Value);
				Console.WriteLine(story.GetAttribute(numberAttribute).Value);
			}
		}

		static void Main(string[] args)
		{
			var example = new QueryStoryByNumber();
			example.Run();
		}
	}
}