using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.QueryTests
{
    [TestClass]
    public class PagingTester
    {
        [TestMethod]
        public void ConstructorToken()
        {
            Paging p = new Paging();
            Assert.AreEqual(string.Format("{0},{1}", int.MaxValue, 0), p.Token);

            p = new Paging(7, 55);
            Assert.AreEqual(string.Format("{0},{1}", 55, 7), p.Token);
        }

        [TestMethod]
        public void ChangeToken()
        {
            Paging p = new Paging();
            p.PageSize = 12;
            Assert.AreEqual(string.Format("{0},{1}", 12, 0), p.Token);
            p.Start = 38;
            Assert.AreEqual(string.Format("{0},{1}", 12, 38), p.Token);
            p.PageSize = 16;
            p.Start = 3;
            Assert.AreEqual(string.Format("{0},{1}", 16, 3), p.Token);
        }

        [TestMethod]
        public void TokenEqualsToString()
        {
            Paging p = new Paging(5, 25);

            string value = string.Format("{0},{1}", 25, 5);
            Assert.AreEqual(value, p.Token);
            Assert.AreEqual(value, p.ToString());
        }
    }
}
