using VersionOne.SDK.APIClient;
using static System.Console;

	public class PassthroughRest
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
			var data = @"
<Asset>
	<Attribute name=""Name"" act=""set"">My Test</Attribute>
	<Attribute name=""Scope"" act=""set"">Scope:0</Attribute>
</Asset>
";
			var services = new Services(connector);
			var result = services.ExecutePassThroughRest("Story", data);
			WriteLine(result);
		}

		public static void Main(string[] args)
		{
			var example = new PassthroughRest();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}
	}
