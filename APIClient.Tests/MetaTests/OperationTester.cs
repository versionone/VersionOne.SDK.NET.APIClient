
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
	[TestFixture]
	public class OperationTester : MetaTesterBase
	{
		protected override string MetaTestKeys { get { return "OperationTester"; } }
		
		[ExpectedException(typeof(MetaException), ExpectedMessage = "Unknown Operation: Story.DoNothing")]
		[Test] public void InvalidOperation()
		{
			Meta.GetOperation("Story.DoNothing");
		}
		
		[Test] public void BaseAssetDelete()
		{
			IOperation op = Meta.GetOperation("BaseAsset.Delete");
			Assert.AreEqual("BaseAsset",op.AssetType.Token);
			Assert.AreEqual("BaseAsset.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.AreEqual("BaseAsset.IsDeletable",op.ValidatorAttribute.Token);
		}
		
		[Test] public void LoadedByGetAssetType()
		{
			Meta.GetAssetType("List");
			IOperation op = Meta.GetOperation("List.Delete");

			Assert.AreEqual("List",op.AssetType.Token);
			Assert.AreEqual("List.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.AreEqual("List.IsDeletable",op.ValidatorAttribute.Token);			
		}
		
		[Test] public void MetaModelLookupOperation()
		{
			IOperation op = Meta.GetOperation("MyType.Delete");
			
			Assert.AreEqual("MyType",op.AssetType.Token);
			Assert.AreEqual("MyType.Delete",op.Token);
			Assert.AreEqual("Delete",op.Name);
			Assert.IsNull(op.ValidatorAttribute);
		}
	}
}