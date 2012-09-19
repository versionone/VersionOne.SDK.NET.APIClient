using System.Linq;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests {
	[TestFixture]
	public class ServicesTester : ServicesTesterBase {
		protected override string ServicesTestKeys {
			get { return "ServicesTester"; }
		}
		
		[Test]
		public void SaveNewAssetWithCommentHasCorrectPath() {
			
			var myAsset = new Asset(AssetType("Story"));
			var storyNameDef = myAsset.AssetType.GetAttributeDefinition("Name");
			myAsset.SetAttributeValue(storyNameDef, "Fred");
			var subject = new Services(Meta, DataConnector);
			
			const string changeComment = "Expected Change Comment";
			const string expectedChangeComment = "Expected+Change+Comment";
			
			var expectedUpdatePath = string.Format("Data/Story?Comment='{0}'", expectedChangeComment);
			subject.Save(myAsset, changeComment);
			
			DataRequestEventArgs e = null;
			GetLastSendDataRequest(ref e);
			
			Assert.AreEqual(myAsset.Oid.Token, "Story:1025");
			Assert.AreEqual(expectedUpdatePath, e.Path);
		}
		
		[Test] public void OidQueryMultiValueAttribute()
		{
			var subject = new Services(Meta, DataConnector);
			var q = new Query(Oid.FromToken("Story:1036", Meta));
			var def = Meta.GetAttributeDefinition("Story.Owners");
			q.Selection.Add(def);
			var r = subject.Retrieve(q);
			var a = r.Assets[0];
			var attrib = a.GetAttribute(def);
			Assert.IsNotNull(attrib);
            Assert.That(attrib.Values, Is.Empty);
		}

		[Test] public void NewMultiValueRelationLoads()
		{
			var subject = new Services(Meta, DataConnector);
			var storyType = Meta.GetAssetType("Story");
			var storyRequests = storyType.GetAttributeDefinition("Requests");
			var contextOid = Oid.FromToken("Request:6075", Meta);
			var storyAsset = subject.New(storyType, contextOid);

			Assert.IsTrue(storyAsset.GetAttribute(storyRequests).HasChanged,"Story Requests has changed");

			var x = storyAsset.GetAttribute(storyRequests).NewValues.Cast<object>().ToList();

			Assert.Contains(contextOid, x, "Story Requests contains " + contextOid.Token);
		}
	}
}
