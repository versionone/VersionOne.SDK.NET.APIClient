using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.DBTests
{
    [TestClass]
    public class DateTimeTester
    {
        private DateTime now;

        [TestInitialize]
        public void Setup()
        {
            now = DateTime.Now;
        }

        private static void ConstructAndTest(DateTime? expected, object o)
        {
            var b = DB.DateTime(o);
            Assert.AreEqual(expected, b);
        }

        [TestMethod]
        public void ObjectNull()
        {
            ConstructAndTest(null, null);
        }

        [TestMethod]
        public void ObjectEmptyString()
        {
            ConstructAndTest(null, string.Empty);
        }

        [TestMethod]
        public void ObjectDBNull()
        {
            ConstructAndTest(null, null);
        }

        [TestMethod]
        public void ObjectDBDateTimeNull()
        {
            ConstructAndTest(null, DB.DateTime(null));
        }

        [TestMethod]
        public void ObjectDBDateTimeNotNull()
        {
            ConstructAndTest(now, DB.DateTime(now));
        }

        [TestMethod]
        public void ObjectSysDateTime()
        {
            ConstructAndTest(now, now);
        }

        [TestMethod]
        public void ObjectString()
        {
            ConstructAndTest(new DateTime(2001, 2, 3, 4, 5, 6), "2001-02-03 04:05:06");
        }

        [TestMethod]
        public void ObjectINullableNull()
        {
            ConstructAndTest(null, new System.Data.SqlTypes.SqlDateTime());
        }
    }
}
