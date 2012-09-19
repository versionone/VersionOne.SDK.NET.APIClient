using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
	[TestFixture]
	public class MetaModelTester : MetaTesterBase
	{
		protected override bool Preload { get { return false; } }
		protected override string MetaTestKeys { get { return "MetaModelTester"; } }

		[Test] public void VersionCheck()
		{
			Assert.AreEqual(new Version("1.2.3.4"),((MetaModel)Meta).Version);
		}
		
		[Test] public void LoadedAssetTypes()
		{
			IAssetType type = Meta.GetAssetType("Story");
			Assert.AreEqual("Story",type.Token);
		}
		
		[Test] public void LoadedAttributes()
		{
			IAttributeDefinition def = Meta.GetAttributeDefinition("Story.Name");
			Assert.AreEqual("Story.Name",def.Token);
			Assert.AreEqual("Name", def.Name);
		}		
		
		[Test] public void LoadedOperations()
		{
			IOperation op = Meta.GetOperation("Story.Copy");
			Assert.AreEqual("Story.Copy",op.Token);
		}				
	}
}
