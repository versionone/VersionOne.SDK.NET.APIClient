using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.DBTests
{
    [TestClass]
    public class BitTester
    {
        private static void ConstructAndTest(bool? expected, object o)
        {
            bool? b = DB.Bit(o);
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
        public void ObjectBitNull()
        {
            ConstructAndTest(null, DB.Bit(null));
        }

        [TestMethod]
        public void ObjectBitFalse()
        {
            ConstructAndTest(false, DB.Bit(false));
        }

        [TestMethod]
        public void ObjectBitTrue()
        {
            ConstructAndTest(true, DB.Bit(true));
        }

        [TestMethod]
        public void ObjectBit0()
        {
            ConstructAndTest(false, 0);
        }

        [TestMethod]
        public void ObjectBit1()
        {
            ConstructAndTest(true, 1);
        }

        [TestMethod]
        public void ObjectChar0()
        {
            ConstructAndTest(false, "0");
        }

        [TestMethod]
        public void ObjectChar1()
        {
            ConstructAndTest(true, "1");
        }

        [TestMethod]
        public void ObjectFalse()
        {
            ConstructAndTest(false, false);
        }

        [TestMethod]
        public void ObjectTrue()
        {
            ConstructAndTest(true, true);
        }

        [TestMethod]
        public void ObjectStringFalse()
        {
            ConstructAndTest(false, "false");
        }

        [TestMethod]
        public void ObjectStringTrue()
        {
            ConstructAndTest(true, "true");
        }

        [TestMethod]
        public void ObjectINullableNull()
        {
            ConstructAndTest(null, new System.Data.SqlTypes.SqlBoolean());
        }
    }
}
