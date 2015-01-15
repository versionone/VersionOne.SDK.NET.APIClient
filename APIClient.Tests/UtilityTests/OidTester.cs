using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class OidTester : MetaTesterBase
    {
        protected override string MetaTestKeys { get { return "OidTester"; } }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void InvalidAssetType()
        {
            new Oid(null, 0, null);
        }

        [TestMethod]
        public void AssetType()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.AreEqual("Story", o.AssetType.Token);
        }

        [TestMethod]
        public void Key()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.AreEqual(5, o.Key);
        }

        [TestMethod]
        public void Moment()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, 10);
            Assert.AreEqual(10, o.Moment);
        }

        [TestMethod]
        public void NullToken()
        {
            Assert.AreEqual("NULL", Oid.Null.Token);
        }

        [TestMethod]
        public void MomentedToken()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, 10);
            Assert.IsTrue(o.HasMoment);
            Assert.AreEqual("Story:5:10", o.Token);
        }

        [TestMethod]
        public void MomentlessOid()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, 10);
            Oid m = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.AreEqual(m, o.Momentless);
        }

        [TestMethod]
        public void OidNotEqual()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, 10);
            Oid m = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.IsTrue(m != o);
        }

        [TestMethod]
        public void OidWithoutMomentIsMomentless()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.AreEqual(o.Momentless, o);
            Assert.AreSame(o.Momentless, o);
        }

        [TestMethod]
        public void OidNotNull()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.IsFalse(o.Equals(null));
        }

        [TestMethod]
        public void OidEqualSelf()
        {
            Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
            Assert.IsTrue(o.Equals(o));
        }

        [TestMethod]
        public void FromTokenIsNull()
        {
            Oid oid = Oid.FromToken("NULL", Meta);
            Assert.AreEqual(Oid.Null, oid);
            Assert.AreSame(Oid.Null, oid);
            Assert.AreEqual(Oid.Null.GetHashCode(), oid.GetHashCode());
        }

        [TestMethod]
        public void FromToken()
        {
            Oid o = Oid.FromToken("Story:5", Meta);
            Assert.AreEqual("Story:5", o.Token);
        }

        [TestMethod]
        public void FromTokenWithMoment()
        {
            Oid o = Oid.FromToken("Story:5:6", Meta);
            Assert.AreEqual("Story:5:6", o.Token);
        }

        [ExpectedExceptionAndMessage(typeof(OidException), "Invalid OID token: Blah:5:6")]
        [TestMethod]
        public void InvalidOidToken()
        {
            Oid o = Oid.FromToken("Blah:5:6", Meta);
            Assert.AreEqual("Story:5:6", o.Token);
        }

        [ExpectedExceptionAndMessage(typeof(OidException), "Invalid OID token: Story")]
        [TestMethod]
        public void InvalidOidTokenBadId()
        {
            Oid.FromToken("Story", Meta);
        }

        [TestMethod]
        public void HashCodeAndEqualTest()
        {
            Oid oid = new Oid(Meta.GetAssetType("Story"), 5, null);
            Oid oid2 = Oid.FromToken("Story:5", Meta);
            Assert.AreEqual(oid, oid2);
            Assert.AreEqual(oid.GetHashCode(), oid2.GetHashCode());
        }

        [TestMethod]
        public void HashCodeAndEqualWithMomentTest()
        {
            Oid oid = new Oid(Meta.GetAssetType("Story"), 5, 555);
            Oid oid2 = Oid.FromToken("Story:5:555", Meta);
            Oid anotherOid = Oid.FromToken("Story:5:666", Meta);
            Oid momentlessOid = Oid.FromToken("Story:5", Meta);
            Assert.AreEqual(oid, oid2);
            Assert.AreEqual(oid.GetHashCode(), oid2.GetHashCode());
            Assert.AreNotEqual(oid, anotherOid);
            Assert.AreNotEqual(oid, momentlessOid);
            Assert.AreNotEqual(momentlessOid, anotherOid);
        }

        [TestMethod]
        public void NullHashCodeTest()
        {
            Assert.AreEqual(0, Oid.Null.GetHashCode());
        }

        [TestMethod]
        public void NullEqualsTest()
        {
            Assert.AreNotEqual(Oid.Null, Oid.FromToken("Story:5", Meta));
            Assert.AreNotEqual(Oid.FromToken("Story:5", Meta), Oid.Null);
        }
    }
}
