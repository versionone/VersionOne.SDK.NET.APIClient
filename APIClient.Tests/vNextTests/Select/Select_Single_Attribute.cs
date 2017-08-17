using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Select
{
	[TestClass]
	public class Select_Single_Attribute
	{
		[ClassInitialize]
		public static void Initialize(TestContext context) => Setup(context, "Story");

		[TestMethod]
		public void Selected_Attributes_should_only_be_returned() => Assert.AreEqual("Story", ResultPath);
	}
}