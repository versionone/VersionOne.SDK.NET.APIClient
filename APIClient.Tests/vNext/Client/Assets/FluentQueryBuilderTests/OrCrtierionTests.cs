using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.Assets;
using static VersionOne.Assets.ComparisonFunctions;

namespace VersionOne.SDK.APIClient.Tests.vNext.Client.Assets.FluentQueryBuilderTests
{
	[TestClass]
	public class OrTermTests
	{
		[TestMethod]
		public void Can_Or_two_simple_Terms()
		{
			var subject = new FluentQueryBuilder("Story", s => new List<IAsset>());
			subject.Where(
				Or(
					Equal("Name", "Jogo"),
					Equal("Estimate", 55)
				)
			);
			var actual = subject.ToString();

			Assert.AreEqual("/Story?where=(Name='Jogo'|Estimate='55')", actual);
		}

		[TestMethod]
		public void Can_nest_Or_Terms()
		{
			var subject = new FluentQueryBuilder("Story", s => new List<IAsset>());
			subject.Where(
				Or(
					Or(
						Equal("Name", "Jogo"),
						Equal("Estimate", 55)
					),
					Or(
						Equal("Name", "$Money$"),
						Equal("Number", "E-01005")
					)
				)
			);
			var actual = subject.ToString();

			Assert.AreEqual("/Story?where=((Name='Jogo'|Estimate='55')|(Name='%24Money%24'|Number='E-01005'))", actual);
		}
	}
}
