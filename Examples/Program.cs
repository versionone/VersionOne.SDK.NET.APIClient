using System;
using System.Linq;
using System.Reflection;

public class Program
{
	string instanceUrl = "https://www16.v1host.com/api-examples";
	string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

	public void Run()
	{
		var exampleTypesInAssembly = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t =>
				t.Name != "Program"
				&& t.IsNotPublic == false
				&& t.GetMethod("Run") != null
			);

		foreach (var type in exampleTypesInAssembly)
		{
			var example = Activator.CreateInstance(type);
			var instanceUrlField = type.GetField("instanceUrl", BindingFlags.Instance | BindingFlags.NonPublic);
			var accessTokenField = type.GetField("accessToken", BindingFlags.Instance | BindingFlags.NonPublic);
			instanceUrlField.SetValue(example, instanceUrl);
			accessTokenField.SetValue(example, accessToken);
			var run = type.GetMethod("Run");
			run.Invoke(example, null);
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadLine();
	}

	public static void Main()
	{
		new Program().Run();
	}
}