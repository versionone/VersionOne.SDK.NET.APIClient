using System;
using NUnit.Framework;
using Oid=VersionOne.SDK.APIClient.Oid;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
	[TestFixture]
	public class OidTester : MetaTesterBase
	{
		protected override string MetaTestKeys { get { return "OidTester"; } }
		
		[ExpectedException(typeof(ArgumentNullException))]
		[Test] public void InvalidAssetType()
		{
			new Oid(null, 0, null);
		}
		
		[Test] public void AssetType()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
			Assert.AreEqual("Story",o.AssetType.Token);
		}
		
		[Test] public void Key()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"), 5, null);
			Assert.AreEqual(5,o.Key);
		}		
		
		[Test] public void Moment()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"), 5, 10);
			Assert.AreEqual(10,o.Moment);
		}
		
		[Test] public void NullToken()
		{
			Assert.AreEqual("NULL",Oid.Null.Token);
		}
		
		[Test] public void MomentedToken()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,10);
			Assert.IsTrue(o.HasMoment);
			Assert.AreEqual("Story:5:10",o.Token);
		}
		
		[Test] public void MomentlessOid()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,10);
			Oid m = new Oid(Meta.GetAssetType("Story"),5,null);
			Assert.AreEqual(m,o.Momentless);
		}		
		
		[Test] public void OidNotEqual()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,10);
			Oid m = new Oid(Meta.GetAssetType("Story"),5,null);
			Assert.IsTrue(m != o);
		}
		
		[Test] public void OidWithoutMomentIsMomentless()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,null);
            Assert.AreEqual(o.Momentless, o);
            Assert.AreSame(o.Momentless, o);
		}
		
		[Test] public void OidNotNull()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,null);
			Assert.IsFalse(o.Equals(null));
		}
		
		[Test] public void OidEqualSelf()
		{
			Oid o = new Oid(Meta.GetAssetType("Story"),5,null);
			Assert.IsTrue(o.Equals(o));
		}
		
		[Test] public void FromTokenIsNull()
		{
			Oid oid = Oid.FromToken("NULL",Meta);
			Assert.AreEqual(Oid.Null, oid);
			Assert.AreSame(Oid.Null, oid);
			Assert.AreEqual(Oid.Null.GetHashCode(), oid.GetHashCode());
		}
		
		[Test] public void FromToken()
		{
			Oid o = Oid.FromToken("Story:5", Meta);
			Assert.AreEqual("Story:5",o.Token);
		}
		
		[Test] public void FromTokenWithMoment()
		{
			Oid o = Oid.FromToken("Story:5:6", Meta);
			Assert.AreEqual("Story:5:6",o.Token);
		}
		
		[ExpectedException(typeof(OidException), ExpectedMessage = "Invalid OID token: Blah:5:6")]
		[Test] public void InvalidOidToken()
		{
			Oid o = Oid.FromToken("Blah:5:6", Meta);
			Assert.AreEqual("Story:5:6",o.Token);
		}		
		
		[ExpectedException(typeof(OidException), ExpectedMessage = "Invalid OID token: Story")]
		[Test] public void InvalidOidTokenBadId()
		{
			Oid.FromToken("Story", Meta);
		}
		
		[Test] public void HashCodeAndEqualTest()
		{
            Oid oid = new Oid(Meta.GetAssetType("Story"), 5, null);
            Oid oid2 = Oid.FromToken("Story:5", Meta);
		    Assert.AreEqual(oid, oid2);
		    Assert.AreEqual(oid.GetHashCode(), oid2.GetHashCode());
		}

		[Test] public void HashCodeAndEqualWithMomentTest()
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

        [Test]
        public void NullHashCodeTest()
        {
            Assert.AreEqual(0, Oid.Null.GetHashCode());
        }

        [Test]
        public void NullEqualsTest()
        {
            Assert.AreNotEqual(Oid.Null, Oid.FromToken("Story:5", Meta));
            Assert.AreNotEqual(Oid.FromToken("Story:5", Meta), Oid.Null);
        }
    }
}
