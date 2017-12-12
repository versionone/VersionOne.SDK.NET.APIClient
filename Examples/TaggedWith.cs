using System;
using System.Linq;
using VersionOne.SDK.APIClient;
using static System.Console;

	public class TaggedWith
	{
		string instanceUrl = "http://localhost/VersionOne.Web";
		string username = "admin";
		string password = "admin";

		private void Execute()
		{
			var connector = V1Connector
				  .WithInstanceUrl(instanceUrl)
				  .WithUserAgentHeader("Examples", "0.1")
				  .WithUsernameAndPassword(username, password)
				  .Build();

			var services = new Services(connector);

			var storyType = services.Meta.GetAssetType("Story");

			var query = new Query(storyType);

			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var idAttribute = storyType.GetAttributeDefinition("ID");
			var taggedWithAttribute = storyType.GetAttributeDefinition("TaggedWith");

			query.Selection.Add(nameAttribute);
			query.Selection.Add(taggedWithAttribute);

			var term = new FilterTerm(idAttribute);
			term.Equal("Story:1004");
			query.Filter = term;

			var result = services.Retrieve(query);

			foreach (var story in result.Assets)
			{
				WriteLine(story.Oid.Token);
				WriteLine(story.GetAttribute(nameAttribute).Value);
				WriteLine(string.Join(",", story.GetAttribute(taggedWithAttribute).Values.Cast<string>()));

				story.AddAttributeValue(taggedWithAttribute, "FIRST TAG");
				story.AddAttributeValue(taggedWithAttribute, "SECOND TAG");
				story.RemoveAttributeValue(taggedWithAttribute, "SECOND TAG");

				services.Save(story);
				story.AcceptChanges();
			}
		}

		public static void Main(string[] args)
		{
			var example = new TaggedWith();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}
	}
