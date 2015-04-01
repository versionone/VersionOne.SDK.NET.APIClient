using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
    [TestClass]
    public class MetaModelTester : MetaTesterBase
    {
        protected override bool Preload { get { return false; } }
        protected override string MetaTestKeys { get { return "MetaModelTester"; } }

        [TestMethod]
        public void VersionCheck()
        {
            Assert.AreEqual(new Version("1.2.3.4"), ((MetaModel)Meta).Version);
        }

        [TestMethod]
        public void LoadedAssetTypes()
        {
            IAssetType type = Meta.GetAssetType("Story");
            Assert.AreEqual("Story", type.Token);
        }

        [TestMethod]
        public void LoadedAttributes()
        {
            IAttributeDefinition def = Meta.GetAttributeDefinition("Story.Name");
            Assert.AreEqual("Story.Name", def.Token);
            Assert.AreEqual("Name", def.Name);
        }

        [TestMethod]
        public void LoadedOperations()
        {
            IOperation op = Meta.GetOperation("Story.Copy");
            Assert.AreEqual("Story.Copy", op.Token);
        }				
    }
}
