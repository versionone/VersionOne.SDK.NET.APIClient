using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests
{
    [TestClass]
    public class ServicesTester : ServicesTesterBase
    {
        protected override string ServicesTestKeys
        {
            get { return "ServicesTester"; }
        }

        [TestMethod]
        public void SaveNewAssetWithCommentHasCorrectPath()
        {

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

        [TestMethod]
        public void OidQueryMultiValueAttribute()
        {
            var subject = new Services(Meta, DataConnector);
            var q = new Query(Oid.FromToken("Story:1036", Meta));
            var def = Meta.GetAttributeDefinition("Story.Owners");
            q.Selection.Add(def);
            var r = subject.Retrieve(q);
            var a = r.Assets[0];
            var attrib = a.GetAttribute(def);
            Assert.IsNotNull(attrib);

            var isValuesEmpty = !attrib.Values.Cast<object>().Any();
            Assert.IsTrue(isValuesEmpty);
        }

        [TestMethod]
        public void NewMultiValueRelationLoads()
        {
            var subject = new Services(Meta, DataConnector);
            var storyType = Meta.GetAssetType("Story");
            var storyRequests = storyType.GetAttributeDefinition("Requests");
            var contextOid = Oid.FromToken("Request:6075", Meta);
            var storyAsset = subject.New(storyType, contextOid);

            Assert.IsTrue(storyAsset.GetAttribute(storyRequests).HasChanged, "Story Requests has changed");

            var x = storyAsset.GetAttribute(storyRequests).NewValues.Cast<object>().ToList();

            Assert.IsTrue(x.Contains(contextOid), "Story Requests contains " + contextOid.Token);
        }
    }
}
