using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	public class Query_by_OID_Token : QueryTestBase
	{
		[ClassInitialize]
		public void Initialize(TestContext context)
		{
			ConfigureSUT("Story:1006");

			ExpectedPath = "Story/1006";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Path_should_be_slashified_OID_Token() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}




