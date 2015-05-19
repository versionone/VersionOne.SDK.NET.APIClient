using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.DBTests
{
    [TestClass]
    public class IntTester
    {
        private static void ConstructAndTest(int? expected, object o)
        {
            var b = DB.Int(o);
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
        public void ObjectIntNull()
        {
            ConstructAndTest(null, DB.Int(null));
        }

        [TestMethod]
        public void ObjectIntNotNull()
        {
            ConstructAndTest(18, DB.Int(18));
        }

        [TestMethod]
        public void ObjectInt()
        {
            ConstructAndTest(19, 19);
        }

        [TestMethod]
        public void ObjectDouble()
        {
            ConstructAndTest(20, 20.0);
        }

        [TestMethod]
        public void ObjectString()
        {
            ConstructAndTest(21, "21");
        }

        [TestMethod]
        public void ObjectINullableNull()
        {
            ConstructAndTest(null, new System.Data.SqlTypes.SqlInt32());
        }
    }
}
