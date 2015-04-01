using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
    [TestClass]
    public class OperationTester : MetaTesterBase
    {
        protected override string MetaTestKeys { get { return "OperationTester"; } }
		
        [ExpectedExceptionAndMessage(typeof(MetaException), "Unknown Operation: Story.DoNothing")]
		[TestMethod] 
        public void InvalidOperation()
		{
			Meta.GetOperation("Story.DoNothing");
		}
		
		[TestMethod] 
        public void BaseAssetDelete()
		{
			IOperation op = Meta.GetOperation("BaseAsset.Delete");
			Assert.AreEqual("BaseAsset",op.AssetType.Token);
			Assert.AreEqual("BaseAsset.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.AreEqual("BaseAsset.IsDeletable",op.ValidatorAttribute.Token);
		}
		
		[TestMethod] 
        public void LoadedByGetAssetType()
		{
			Meta.GetAssetType("List");
			IOperation op = Meta.GetOperation("List.Delete");

			Assert.AreEqual("List",op.AssetType.Token);
			Assert.AreEqual("List.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.AreEqual("List.IsDeletable",op.ValidatorAttribute.Token);			
		}
		
		[TestMethod] 
        public void MetaModelLookupOperation()
		{
			IOperation op = Meta.GetOperation("MyType.Delete");
			
			Assert.AreEqual("MyType",op.AssetType.Token);
			Assert.AreEqual("MyType.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.IsNull(op.ValidatorAttribute);
		}
	}
}
