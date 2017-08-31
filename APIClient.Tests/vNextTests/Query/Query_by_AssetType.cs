using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class Query_by_AssetType
	{
		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			ConfigureSUT(Context, "Story");
			ExpectedPath = "Story";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Path_should_be_the_AssetType_name() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}