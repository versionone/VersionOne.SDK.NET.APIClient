using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.DBTests {
	[TestFixture]
	public class StrTester {
		private static void ConstructAndTest(string expected, object o) {
			var b = DB.Str(o);
			Assert.AreEqual(expected, b);
		}

		[Test]
		public void ObjectNull() {
			ConstructAndTest(null, null);
		}

		[Test]
		public void ObjectEmptyString() {
			ConstructAndTest(null, string.Empty);
		}

		[Test]
		public void ObjectStrNull() {
			ConstructAndTest(null, DB.Str(null));
		}

		[Test]
		public void ObjectStrNotNull() {
			ConstructAndTest("bbb", DB.Str("bbb"));
		}

		[Test]
		public void ObjectString() {
			ConstructAndTest("aaa", "aaa");
		}

		[Test]
		public void ObjectINullable() {
			ConstructAndTest("ccc", new System.Data.SqlTypes.SqlString("ccc"));
		}

		[Test]
		public void ObjectINullableNull() {
			ConstructAndTest(null, new System.Data.SqlTypes.SqlString());
		}

		[Test]
		public void Trims() {
			Assert.AreEqual(DB.Str("xyz"), DB.Str("   xyz"), "Leading");
			Assert.AreEqual(DB.Str("xyz"), DB.Str("xyz   "), "Trailing");
			Assert.AreEqual(DB.Str("xyz"), DB.Str("   xyz   "), "Leading and Trailing");
			Assert.AreEqual(DB.Str(null), DB.Str("	"), "All Blank");
		}
	}
}