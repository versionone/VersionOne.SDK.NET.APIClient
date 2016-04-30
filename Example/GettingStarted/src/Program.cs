using System;
using VersionOne.SDK.APIClient;

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

            RunExample(GetTeamRoomsWithLambdas,
                        "Getting the TeamRooms with lambda style",
                        continueMsg);

            RunExample(GetTeamRoomsWithRetrieve,
                        "Getting the TeamRooms with Retrieve",
                        continueMsg);

            RunExample(ErrorExampleWithExecute,
                        "Showing an exception message via Execute",
                        continueMsg);

            RunExample(ErrorExampleWithRetrieve,
                        "Showing an exception message via Retrievev",
                        exitMsg);
        }

        public void GetTeamRoomsWithLambdas()
        {
            V1Connector
            .WithInstanceUrl(BaseUrl)
            .WithUserAgentHeader("Sample", "0.0.0")
            .WithUsernameAndPassword(UserName, Password)
            .Query("TeamRoom")
            .Select("Team.Name", "Name")
            .Success(assets => {
                foreach (Asset asset in assets)
                {
                    var team = asset["Team.Name"] + ":" + asset["Name"];
                    Console.WriteLine(team);
                }
            })
            .Execute();
            //.WhenEmpty(() => Console.WriteLine("No results found..."))
        }

        public void GetTeamRoomsWithRetrieve()
        { 
            var queryResult = V1Connector
            .WithInstanceUrl(BaseUrl)
            .WithUserAgentHeader("Sample", "0.0.0")
            .WithUsernameAndPassword(UserName, Password)
            .Query("TeamRoom")
            .Select("Team.Name", "Name")
            .Retrieve();
            System.Console.WriteLine(queryResult);
        }

        public void ErrorExampleWithExecute()
        {
            V1Connector
            .WithInstanceUrl(BaseUrl)
            .WithUserAgentHeader("Sample", "0.0.0")
            .WithUsernameAndPassword(UserName, Password)
            .Query("JiraRoom")
            .Select("Team.Name", "Name")
            .Error(exception => Console.WriteLine("Exception! " + exception.Message))
            .Success(assets => Console.WriteLine("Assets count: " + assets))
            .Execute();
        }

        public void ErrorExampleWithRetrieve()
        {
            var queryResult = V1Connector
            .WithInstanceUrl(BaseUrl)
            .WithUserAgentHeader("Sample", "0.0.0")
            .WithUsernameAndPassword(UserName, Password)
            .Query("JiraRoom")
            .Select("Team.Name", "Name")
            .Error(exception => Console.WriteLine("Exception! " + exception.Message))
            .Retrieve();
        }

        private static void RunExample(Action exampleMethod, string exampleMessage = null, string nextMessage = null,
			bool pauseBeforeContinue = true)
		{
			if (exampleMessage != null)
			{
				Console.WriteLine(exampleMessage);
			}
			Console.WriteLine();
			exampleMethod();
			Console.WriteLine();
			if (nextMessage != null)
			{
				Console.WriteLine(nextMessage);
			}
			Console.WriteLine();
			if (pauseBeforeContinue)
			{
				Console.ReadKey();
			}
		}

        private string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void Main(string[] args)
		{
			var program = new Program();
			program.Run();
		}

	}
}