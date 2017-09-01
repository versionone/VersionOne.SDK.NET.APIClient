using System;
using System.Collections.Generic;
using VersionOne.SDK.APIClient.vNext;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	public class QueryTestBase
	{
		protected Func<string, IList<dynamic>> ExecutorStub = resource => new List<dynamic>();
		protected FluentQueryBuilder SUT;
		protected string ActualPath;
		protected string ExpectedPath;

		protected void ConfigureSUT(string querySource, Func<string, IList<dynamic>> executor = null, bool useExecutorParameter = false)
		{
			var ex = ExecutorStub;
			if (useExecutorParameter) ex = executor;
			SUT = new FluentQueryBuilder(querySource, ex);
		}
	}
}
