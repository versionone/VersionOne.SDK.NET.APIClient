using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VersionOne.SDK.APIClient.vNext;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class When_Query_for_Asset_By_OID_Token
	{
		private static FluentQueryBuilder SUT;
		private static string ResultPath; 
		private static TestContext Context;

		public static Func<string, IList<dynamic>> ExecutorStub = resource => new List<dynamic>();

		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			Context = context;
			SUT = new FluentQueryBuilder("Story:1006", ExecutorStub);
			ResultPath = SUT.ToString();
		}

		[TestMethod]
		public void Path_should_contain_a_slashified_version_of_the_OID_Token() => Assert.IsTrue(ResultPath.Contains("Story/1006"));
	}
}




