using System;
using System.Linq;
using System.Reflection;
public class Program
{
	private string instanceUrl = "https://www16.v1host.com/api-examples";
	private string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

	public void Run()
	{
		var allTypesInAssembly = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t =>
				t.Name != "Program"
				&& t.IsNotPublic == false
				&& t.GetMethod("Run") != null
			);

		foreach (var type in allTypesInAssembly)
		{
			var instance = Activator.CreateInstance(type, instanceUrl, accessToken);
			var run = type.GetMethod("Run");
			run.Invoke(instance, null);
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadLine();
	}

	public static void Main()
	{
		new Program().Run();
	}
}