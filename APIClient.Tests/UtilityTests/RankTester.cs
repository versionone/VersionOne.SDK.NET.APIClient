using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class RankTester
    {
        [TestMethod]
        public void Compare()
        {
            Assert.IsTrue(new Rank("5") == new Rank("5"));
            Assert.IsTrue(new Rank("5") > new Rank("4"));
            Assert.IsTrue(new Rank("5") < new Rank("6"));
            Assert.IsTrue(new Rank("5") >= new Rank("4"));
            Assert.IsTrue(new Rank("5") >= new Rank("5"));
            Assert.IsTrue(new Rank("5") <= new Rank("6"));
            Assert.IsTrue(new Rank("5") <= new Rank("5"));
            Assert.IsTrue(new Rank("5").Equals(new Rank("5")));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TransientDontCompare1()
        {
            Assert.IsTrue(new Rank("5+") == new Rank("5-"));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TransientDontCompare2()
        {
            Assert.IsTrue(new Rank("5+") == new Rank("5"));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TransientDontCompare3()
        {
            Assert.IsTrue(new Rank("5") == new Rank("5+"));
        }
    }
}
