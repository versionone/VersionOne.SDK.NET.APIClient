using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.DBTests {
	[TestFixture]
	public class IntTester {
		private static void ConstructAndTest(int? expected, object o) {
			var b = DB.Int(o);
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
		public void ObjectIntNull() {
			ConstructAndTest(null, DB.Int(null));
		}

		[Test]
		public void ObjectIntNotNull() {
			ConstructAndTest(18, DB.Int(18));
		}

		[Test]
		public void ObjectInt() {
			ConstructAndTest(19, 19);
		}

		[Test]
		public void ObjectDouble() {
			ConstructAndTest(20, 20.0);
		}

		[Test]
		public void ObjectString() {
			ConstructAndTest(21, "21");
		}

		[Test]
		public void ObjectINullableNull() {
			ConstructAndTest(null, new System.Data.SqlTypes.SqlInt32());
		}
	}
}