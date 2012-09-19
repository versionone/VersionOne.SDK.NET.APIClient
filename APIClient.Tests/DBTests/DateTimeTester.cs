using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.DBTests {
	[TestFixture]
	public class DateTimeTester {
		private DateTime now;

		[SetUp]
		public void Setup() {
			now = DateTime.Now;
		}

		private static void ConstructAndTest(DateTime? expected, object o) {
			var b = DB.DateTime(o);
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
		public void ObjectDBNull() {
			ConstructAndTest(null, null);
		}

		[Test]
		public void ObjectDBDateTimeNull() {
			ConstructAndTest(null, DB.DateTime(null));
		}

		[Test]
		public void ObjectDBDateTimeNotNull() {
			ConstructAndTest(now, DB.DateTime(now));
		}

		[Test]
		public void ObjectSysDateTime() {
			ConstructAndTest(now, now);
		}

		[Test]
		public void ObjectString() {
			ConstructAndTest(new DateTime(2001, 2, 3, 4, 5, 6), "2001-02-03 04:05:06");
		}

		[Test]
		public void ObjectINullableNull() {
			ConstructAndTest(null, new System.Data.SqlTypes.SqlDateTime());
		}
	}
}