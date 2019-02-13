using static System.Console;

namespace Examples
{
	public static class PrintHelper
	{
		public static void PrintEpic(dynamic epic)
		{
			WriteLine($"Epic:");
			WriteLine(epic.Oid);
			WriteLine(epic.Name);
			WriteLine(epic.Scope);
			WriteLine("\tSubs:");
			foreach (dynamic sub in epic.Subs)
			{
				WriteLine("\t" + sub.Oid);
				WriteLine("\t" + sub.AssetType);
				WriteLine("\t" + sub.Name);
				WriteLine("\t\tChildren:");
				foreach (dynamic child in sub.Children)
				{
					WriteLine("\t\t\t" + child.Oid);
					WriteLine("\t\t\t" + child.AssetType);
					WriteLine("\t\t\t" + child.Name);
					WriteLine("\t\t\t---");
				}
				WriteLine("\t---");
			}
		}
	}
}
