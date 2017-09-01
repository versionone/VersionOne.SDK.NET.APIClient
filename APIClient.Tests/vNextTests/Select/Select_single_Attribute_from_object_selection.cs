using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.APIClient.Tests.vNextTests.Query;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Select
{
	[TestClass]
	public class Select_single_Attribute_from_object_selection : QueryTestBase
	{
		class ThingThatToStringTurnsIntoAnAttributeName
		{
			public override string ToString() => "AttributeName";
		}

		[TestInitialize]
		public void Initialize()
		{
			ConfigureSUT("Story");

			var thing = new ThingThatToStringTurnsIntoAnAttributeName();

			SUT.Select(thing);

			ExpectedPath = "Story?sel=AttributeName";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Selected_Attribute_should_only_be_returned() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}