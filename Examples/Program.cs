using System;
using System.Linq;
using System.Reflection;

public class Program
{
	string instanceUrl = "https://www16.v1host.com/api-examples";
	string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

	public void Execute()
	{
		var exampleTypesInAssembly = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t =>
				t.Name != "Program"
				&& t.IsNotPublic == false
				&& t.GetMethod("Execute") != null
			);

		foreach (var type in exampleTypesInAssembly)
		{
			var example = Activator.CreateInstance(type);
			var instanceUrlField = type.GetField("instanceUrl", BindingFlags.Instance | BindingFlags.NonPublic);
			var accessTokenField = type.GetField("accessToken", BindingFlags.Instance | BindingFlags.NonPublic);
			instanceUrlField.SetValue(example, instanceUrl);
			accessTokenField.SetValue(example, accessToken);
			var run = type.GetMethod("Execute");
			run.Invoke(example, null);
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}

	public static void Main()
	{
		var program = new Program();
		program.Execute();
	}
}