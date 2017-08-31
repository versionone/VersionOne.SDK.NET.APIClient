using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Select
{
	[TestClass]
	public class Select_single_Attribute_from_object_selection
	{
		class ThingThatToStringTurnsIntoAnAttributeName
		{
			public override string ToString() => "AttributeName";
		}

		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			ConfigureSUT(context, "Story");

			var thing = new ThingThatToStringTurnsIntoAnAttributeName();

			SUT.Select(thing);

			ExpectedPath = "Story?sel=AttributeName";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Selected_Attribute_should_only_be_returned() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}