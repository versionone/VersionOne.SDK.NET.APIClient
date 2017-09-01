using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VersionOne.SDK.APIClient.Tests.vNextTests.Query
{
	[TestClass]
	public class Query_with_null_querySource : QueryTestBase
	{
		private Exception _expectedException;

		[TestInitialize]
		public void Initialize()
		{
			try
			{
				ConfigureSUT(null);
			}
			catch (Exception ex)
			{
				_expectedException = ex;
			}
		}

		[TestMethod]
		public void Exception_should_be_ArgumentNullException() => Assert.IsInstanceOfType(_expectedException, typeof(ArgumentNullException));

		[TestMethod]
		public void Exception_message() => Assert.AreEqual("Value cannot be null.\r\nParameter name: querySource", _expectedException.Message);
	}
}