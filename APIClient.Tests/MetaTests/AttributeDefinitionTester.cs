using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
    [TestClass]
    public class AttributeDefinitionTester : MetaTesterBase
    {
        protected override string MetaTestKeys
        {
            get { return "AttributeDefinitionTester"; }
        }

        [ExpectedExceptionAndMessage(typeof(MetaException), "Unknown AttributeDefinition: Story.Blah")]
        [TestMethod]
        public void InvalidAttribute()
        {
            Meta.GetAttributeDefinition("Story.Blah");
        }

        [TestMethod]
        public void TextAttribute()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.Name");
            Assert.AreEqual("Story", def.AssetType.Token);
            Assert.AreEqual("Name", def.Name);
            Assert.AreEqual(AttributeType.Text, def.AttributeType);
            Assert.AreEqual("BaseAsset.Name", def.Base.Token);
            Assert.AreEqual("AttributeDefinition'Name'Story", def.DisplayName);
            Assert.IsFalse(def.IsMultiValue);
            Assert.IsFalse(def.IsReadOnly);
            Assert.IsTrue(def.IsRequired);
        }

        [TestMethod]
        public void GuidAttribute()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Publication.Payload");
            Assert.AreEqual("Publication", def.AssetType.Token);
            Assert.AreEqual("Payload", def.Name);
            Assert.AreEqual(AttributeType.Guid, def.AttributeType);
            Assert.AreEqual(null, def.Base);
            Assert.AreEqual("AttributeDefinition'Payload'Publication", def.DisplayName);
            Assert.IsFalse(def.IsReadOnly);
            Assert.IsTrue(def.IsRequired);
            Assert.IsFalse(def.IsMultiValue);
        }

        [TestMethod]
        public void CoerceAssetTypeNull()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.AssetType");
            Assert.IsNull(def.Coerce(null));
        }

        [TestMethod]
        public void CoerceAssetStateNull()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.AssetState");
            Assert.IsNull(def.Coerce(null));
        }

        [TestMethod]
        public void CanParseGuidAttributeDefinitionType()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Publication.Payload");
            Assert.AreEqual(AttributeType.Guid, def.AttributeType);
        }
    }
}
