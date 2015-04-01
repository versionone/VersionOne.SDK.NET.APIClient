using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests
{
    [TestClass]
    public class MultiValueAttributeTester : ServicesTesterBase
    {
        protected override string ServicesTestKeys
        {
            get { return "MultiValueAttributeTester"; }
        }

        [TestMethod]
        public void MultiValueAttribute()
        {
            Services subject = new Services(Meta, DataConnector);
            Query queryStories = new Query(Oid.FromToken("Story:1063", Meta));
            IAttributeDefinition ownersDef = Meta.GetAttributeDefinition("Story.Owners");
            queryStories.Selection.Add(ownersDef);
            QueryResult resultStories = subject.Retrieve(queryStories);

            Asset story = resultStories.Assets[0];
            Oid oldMember = Oid.FromToken("Member:1001", Meta);
            Oid newMember = Oid.FromToken("Member:20", Meta);
            IEnumerator owners = story.GetAttribute(ownersDef).Values.GetEnumerator();
            Assert.IsTrue(owners.MoveNext());
            Assert.AreEqual(oldMember, owners.Current);
            Assert.IsFalse(owners.MoveNext());

            story.AddAttributeValue(ownersDef, newMember);
            owners = story.GetAttribute(ownersDef).Values.GetEnumerator();
            Assert.IsTrue(owners.MoveNext());
            Assert.AreEqual(oldMember, owners.Current);
            Assert.IsTrue(owners.MoveNext());
            Assert.AreEqual(newMember, owners.Current);
            Assert.IsFalse(owners.MoveNext());

            story.RemoveAttributeValue(ownersDef, oldMember);
            owners = story.GetAttribute(ownersDef).Values.GetEnumerator();
            Assert.IsTrue(owners.MoveNext());
            Assert.AreEqual(newMember, owners.Current);
            Assert.IsFalse(owners.MoveNext());

            story.RemoveAttributeValue(ownersDef, newMember);
            owners = story.GetAttribute(ownersDef).Values.GetEnumerator();
            Assert.IsFalse(owners.MoveNext());
        }
    }
}
