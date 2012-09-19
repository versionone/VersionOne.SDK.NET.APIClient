using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.DBTests {
	[TestFixture]
	public class BitTester {
		private static void ConstructAndTest(bool? expected, object o) {
			bool? b = DB.Bit(o);
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
		public void ObjectBitNull() {
			ConstructAndTest(null, DB.Bit(null));
		}

		[Test]
		public void ObjectBitFalse() {
			ConstructAndTest(false, DB.Bit(false));
		}

		[Test]
		public void ObjectBitTrue() {
			ConstructAndTest(true, DB.Bit(true));
		}

		[Test]
		public void ObjectBit0() {
			ConstructAndTest(false, 0);
		}

		[Test]
		public void ObjectBit1() {
			ConstructAndTest(true, 1);
		}

		[Test]
		public void ObjectChar0() {
			ConstructAndTest(false, "0");
		}

		[Test]
		public void ObjectChar1() {
			ConstructAndTest(true, "1");
		}

		[Test]
		public void ObjectFalse() {
			ConstructAndTest(false, false);
		}

		[Test]
		public void ObjectTrue() {
			ConstructAndTest(true, true);
		}

		[Test]
		public void ObjectStringFalse() {
			ConstructAndTest(false, "false");
		}

		[Test]
		public void ObjectStringTrue() {
			ConstructAndTest(true, "true");
		}

		[Test]
		public void ObjectINullableNull() {
			ConstructAndTest(null, new System.Data.SqlTypes.SqlBoolean());
		}
	}
}