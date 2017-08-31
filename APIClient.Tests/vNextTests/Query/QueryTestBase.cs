using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VersionOne.SDK.APIClient.vNext;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	public static class QueryTestBase
	{
		public static Func<string, IList<dynamic>> ExecutorStub = resource => new List<dynamic>();
		public static FluentQueryBuilder SUT;
		public static string ActualPath;
		public static string ExpectedPath;
		public static TestContext Context;

		public static void ConfigureSUT(TestContext context, string querySource, Func<string, IList<dynamic>> executor = null, bool useExecutorParameter = false)
		{
			Context = context;
			var ex = ExecutorStub;
			if (useExecutorParameter) ex = executor;
			SUT = new FluentQueryBuilder(querySource, ex);
		}
	}
}
