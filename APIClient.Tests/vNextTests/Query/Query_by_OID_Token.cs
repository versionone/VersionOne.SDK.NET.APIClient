using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class Query_by_OID_Token
	{
		[ClassInitialize]
		public static void Initialize(TestContext context) => Setup(context, "Story:1006");

		[TestMethod]
		public void Path_should_be_slashified_OID_Token() => Assert.AreEqual("Story/1006", ResultPath);
	}
}




