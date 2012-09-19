using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
	[TestFixture]
	public class AttributeDefinitionTester : MetaTesterBase
	{
		protected override string MetaTestKeys { get { return "AttributeDefinitionTester"; } }
		
		[ExpectedException(typeof(MetaException),ExpectedMessage = "Unknown AttributeDefinition: Story.Blah")]
		[Test] public void InvalidAttribute()
		{
			Meta.GetAttributeDefinition("Story.Blah");
		}
		
		[Test] public void TextAttribute()
		{
			IAttributeDefinition def = Meta.GetAttributeDefinition("Story.Name");
			Assert.AreEqual("Story",def.AssetType.Token);
			Assert.AreEqual("Name",def.Name);
			Assert.AreEqual(AttributeType.Text, def.AttributeType);
			Assert.AreEqual("BaseAsset.Name",def.Base.Token);
			Assert.AreEqual("AttributeDefinition'Name'Story",def.DisplayName);
			Assert.IsFalse(def.IsMultiValue);
			Assert.IsFalse(def.IsReadOnly);
			Assert.IsTrue(def.IsRequired);
		}

        [Test]
        public void CoerceAssetTypeNull()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.AssetType");
            Assert.IsNull(def.Coerce(null));
        }

        [Test]
        public void CoerceAssetStateNull()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.AssetState");
            Assert.IsNull(def.Coerce(null));
        }
	}
}