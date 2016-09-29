using System;
using VersionOne.SDK.APIClient;
using static VersionOne.Assets.ComparisonFunctions;
using static VersionOne.Assets.ClientUtilities;
using static System.Console;

namespace GettingStarted
{
	public class Program
	{
		// Modify to point to your application URL:
		//private const string BaseUrl = "http://localhost/VersionOne.Web";
		private const string BaseUrl = "https://www14.v1host.com/v1sdktesting";

		// If you want to use the standard username and password credentials, set your credentials here:
		private const string UserName = "admin";
		private const string Password = "admin";

		public void Run()
		{
			const string continueMsg = "Press any key to continue...";
			const string exitMsg = "Press any key to exit...";

			//RunExample(GetTeamRoomsWithRetrieve,
			//			"Getting the TeamRooms with Retrieve",
			//			continueMsg);

			//RunExample(ErrorExampleWithExecute,
			//			"Showing an exception message via Execute",
			//			continueMsg);

			//RunExample(ErrorExampleWithRetrieve,
			//			"Showing an exception message via Retrievev",
			//			continueMsg);

			//RunExample(GetStoryByName,
			//			"Query a Story asset by its Name attribute",
			//			continueMsg);

			//RunExample(CreateStory,
			//			"Create a Story on a Scope",
			//			exitMsg);

			RunExample(CreateStoryWithConversation,
						"Create a Story with a Conversation",
						exitMsg);
		}

		public void GetTeamRoomsWithRetrieve()
		{
			var results = V1Connector
			.WithInstanceUrl(BaseUrl)
			.WithUserAgentHeader("Sample", "0.0.0")
			.WithUsernameAndPassword(UserName, Password)
			.Query("TeamRoom")
			.Select("Team.Name", "Name")
			.Where(
				Equal("Team.Name", "Brainstorm Team")
			)
			.Retrieve();

			foreach (var asset in results)
			{
				var team = asset["Team.Name"] + ":" + asset["Name"];
				WriteLine(team);
			}
		}

		public void ErrorExampleWithExecute()
		{
			var results = V1Connector
			.WithInstanceUrl(BaseUrl)
			.WithUserAgentHeader("Sample", "0.0.0")
			.WithUsernameAndPassword(UserName, Password)
			.Query("JiraRoom")
			.Select("Team.Name", "Name")
			//.Error(exception => WriteLine("Exception! " + exception.Message))
			//.Success(assets => WriteLine("Assets count: " + assets))
			.Retrieve();

			WriteLine("Assets count: " + results.Count);

		}

		public void ErrorExampleWithRetrieve()
		{
			var results = V1Connector
			.WithInstanceUrl(BaseUrl)
			.WithUserAgentHeader("Sample", "0.0.0")
			.WithUsernameAndPassword(UserName, Password)
			.Query("JiraRoom")
			.Select("Team.Name", "Name")
			//.Error(exception => WriteLine("Exception! " + exception.Message))
			.Retrieve();
		}

		public void GetStoryByName()
		{
			var results = V1Connector
				.WithInstanceUrl("https://www16.v1host.com/api-examples")
				.WithUserAgentHeader("TestApp", "0.1")
				.WithUsernameAndPassword("admin", "admin")
				.Query("Story")
				.Select("Name", "Number")
				.Where("Number", "S-01001")
				.Retrieve();

			foreach (dynamic story in results)
			{
				//This first line grabs and prints the system identifier OID of the current Story 
				WriteLine(story.OidToken);
				WriteLine(story.Name);
				WriteLine(story.Number);
			}
		}

		public void CreateStory()
		{
			var scope = "Scope:86271";

			dynamic story = V1Connector
			.WithInstanceUrl(BaseUrl)
			.WithUserAgentHeader("Sample", "0.0.0")
			.WithUsernameAndPassword(UserName, Password)
			.Create("Story", new
			{
				Name = "Testing the client.Create method at " + DateTime.Now.ToLongTimeString(),
				Description = "Just playing around...",
				Scope = scope,
				Owners = Relation("Member:20")
			});

			WriteLine(story.OidToken);
			WriteLine(story.Name);
			WriteLine(story.Description);
			//WriteLine(story.Scope);
			WriteLine(story.Owners);
		}


		public void CreateStoryWithConversation()
		{
			var client = V1Connector
				.WithInstanceUrl(BaseUrl)
				.WithUserAgentHeader("Sample", "0.0.0")
				.WithUsernameAndPassword(UserName, Password);

			var scope = "Scope:86271";
			var name = $"Test Story {scope} Create story with conversation and mention";

			var newStory = client.Create("Story", new {
				Scope = scope,
				Name = name
			});

			var newConversation = client.Create("Conversation");

			var questionExpression = client.Create("Expression", new {
				Author = "Member:20",
				AuthoredAt = DateTime.Now,
				Content = "Is this a test conversation?",
				BelongsTo = newConversation.OidToken,
				Mentions = Relation(newStory.OidToken)
			});

			var answerExpression = client.Create("Expression", new {
				Author = "Member:20",
				AuthoredAt = DateTime.Now.AddMinutes(15),
				Content = "Yes it is!",
				InReplyTo = questionExpression.OidToken
			});

			WriteLine($"Story OID Token: {newStory.OidToken}");
		}

		private static void RunExample(Action exampleMethod, string exampleMessage = null, string nextMessage = null,
			bool pauseBeforeContinue = true)
		{
			if (exampleMessage != null)
			{
				WriteLine(exampleMessage);
			}
			WriteLine();
			exampleMethod();
			WriteLine();
			if (nextMessage != null)
			{
				WriteLine(nextMessage);
			}
			WriteLine();
			if (pauseBeforeContinue)
			{
				ReadKey();
			}
		}

		private string ReadString(string message)
		{
			WriteLine(message);
			return ReadLine();
		}

		public static void Main(string[] args)
		{
			var program = new Program();
			program.Run();
		}

	}
}