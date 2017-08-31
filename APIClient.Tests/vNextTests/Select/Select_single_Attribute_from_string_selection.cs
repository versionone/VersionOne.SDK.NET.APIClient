using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Select
{
	[TestClass]
	public class Select_single_Attribute_from_string_selection
	{
		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			ConfigureSUT(context, "Story");
			SUT.Select("Name");

			ExpectedPath = "Story?sel=Name";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Selected_Attribute_should_only_be_returned() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}