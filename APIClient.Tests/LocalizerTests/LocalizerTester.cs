using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.LocalizerTests
{
	[TestFixture]
	public class LocalizerTester : LocalizerTesterBase
	{
		protected override string LocTestKeys { get { return "LocalizerTester"; } }

		[Test] public void SimpleString()
		{
			Assert.AreEqual("Resolve To Simple",Loc.Resolve("Simple"));
		}
		
		[Test] public void ReturnInput()
		{
			Assert.AreEqual("Blah",Loc.Resolve("Blah"));
		}
	}
}
