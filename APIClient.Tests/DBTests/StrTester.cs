using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.DBTests
{
    [TestClass]
    public class StrTester
    {
        private static void ConstructAndTest(string expected, object o)
        {
            var b = DB.Str(o);
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
        public void ObjectStrNull()
        {
            ConstructAndTest(null, DB.Str(null));
        }

        [TestMethod]
        public void ObjectStrNotNull()
        {
            ConstructAndTest("bbb", DB.Str("bbb"));
        }

        [TestMethod]
        public void ObjectString()
        {
            ConstructAndTest("aaa", "aaa");
        }

        [TestMethod]
        public void ObjectINullable()
        {
            ConstructAndTest("ccc", new System.Data.SqlTypes.SqlString("ccc"));
        }

        [TestMethod]
        public void ObjectINullableNull()
        {
            ConstructAndTest(null, new System.Data.SqlTypes.SqlString());
        }

        [TestMethod]
        public void Trims()
        {
            Assert.AreEqual(DB.Str("xyz"), DB.Str("   xyz"), "Leading");
            Assert.AreEqual(DB.Str("xyz"), DB.Str("xyz   "), "Trailing");
            Assert.AreEqual(DB.Str("xyz"), DB.Str("   xyz   "), "Leading and Trailing");
            Assert.AreEqual(DB.Str(null), DB.Str("	"), "All Blank");
        }
    }
}
