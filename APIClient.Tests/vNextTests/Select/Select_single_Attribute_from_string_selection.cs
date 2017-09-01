using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.APIClient.Tests.vNextTests.Query;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Select
{
	[TestClass]
	public class Select_single_Attribute_from_string_selection : QueryTestBase
	{
		[TestInitialize]
		public void Initialize()
		{
			ConfigureSUT("Story");
			SUT.Select("Name");

			ExpectedPath = "Story?sel=Name";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Selected_Attribute_should_only_be_returned() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}