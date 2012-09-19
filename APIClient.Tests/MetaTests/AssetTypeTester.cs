using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.MetaTests
{
	[TestFixture]
	public class AssetTypeTester : MetaTesterBase
	{
		protected override string MetaTestKeys { get { return "AssetTypeTester"; } }
		
		private IAssetType ListType { get { return AssetType("List"); } }
		private IAssetType StateType { get { return AssetType("State"); } }
		private IAssetType WorkitemType { get { return AssetType("Workitem"); } }
		private IAssetType StoryType { get { return AssetType("Story"); } }
		private IAssetType TaskType { get { return AssetType("Task"); } }
		
		[Test] public void Story()
		{
			IAssetType story = Meta.GetAssetType("Story");
			Assert.AreEqual("Story",story.Token);
			Assert.AreEqual("AssetType'Story",story.DisplayName);
			Assert.AreEqual("PrimaryWorkitem",story.Base.Token);
			Assert.AreEqual("Story.Order",story.DefaultOrderBy.Token);
		}
		
		[ExpectedException(typeof(MetaException), ExpectedMessage = "Unknown AttributeDefinition: Story.Blah")]
		[Test] public void FailLookupAttribute()
		{
			StoryType.GetAttributeDefinition("Blah");
		}
		
		[Test] public void LookupAttribute()
		{
			StoryType.GetAttributeDefinition("Name");
		}
		
		[Test] public void CachedAttribute()
		{
			StoryType.GetAttributeDefinition("Order");
		}
		
		[Test] public void BaseAsset()
		{
			IAssetType baseasset = Meta.GetAssetType("BaseAsset");
			Assert.AreEqual("BaseAsset",baseasset.Token);
			Assert.AreEqual("AssetType'BaseAsset",baseasset.DisplayName);			
			Assert.IsNull(baseasset.Base);
			Assert.AreEqual("BaseAsset.Name", baseasset.DefaultOrderBy.Token);
		}
		
		[ExpectedException(typeof(MetaException), ExpectedMessage = "Unknown AssetType: Blah")]
		[Test] public void InvalidAssetType()
		{
			Meta.GetAssetType("Blah");
		}
	
		#region Is Tests
		[Test] public void ClassIsSelf()
		{
			Assert.IsTrue(ListType.Is(ListType));
		}

		[Test] public void TypeIsSelf()
		{
			Assert.IsTrue(StateType.Is(StateType));
		}

		[Test] public void TypeIsClass()
		{
			Assert.IsTrue(StoryType.Is(WorkitemType));
		}

		[Test] public void ClassIsNotType()
		{
			Assert.IsFalse(WorkitemType.Is(StoryType));
		}

		[Test] public void TypeIsNotPeerType()
		{
			Assert.IsFalse(StoryType.Is(TaskType));
		}

		[Test] public void TypeIsNotClass()
		{
			Assert.IsFalse(StateType.Is(WorkitemType));
		}

		[Test] public void TypeIsNotType()
		{
			Assert.IsFalse(StateType.Is(StoryType));
		}		
#endregion
	}
}
