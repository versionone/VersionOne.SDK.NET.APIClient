using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VersionOne.SDK.APIClient.Tests.vNextTests.Query.QueryTestBase;
using static VersionOne.SDK.APIClient.vNext.FluentQueryBuilder;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class Query_by_OID_Token
	{
		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			ConfigureSUT(context, "Story:1006");

			ExpectedPath = "Story/1006";
			ActualPath = SUT.ToString();
		}

		[TestMethod]
		public void Path_should_be_slashified_OID_Token() => Assert.AreEqual(ExpectedPath, ActualPath);
	}
}




