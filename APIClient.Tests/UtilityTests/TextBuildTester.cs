using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class TextBuildTester
    {
        [TestMethod]
        public void JoinSingleItem()
        {
            Assert.AreEqual("5", TextBuilder.Join(new int[] { 5 }, ";"));
        }

        [TestMethod]
        public void Join()
        {
            Assert.AreEqual("5;4;3", TextBuilder.Join(new int[] { 5, 4, 3 }, ";"));
        }

        [TestMethod]
        public void JoinWithNull()
        {
            Assert.AreEqual("5;;3", TextBuilder.Join(new object[] { 5, null, 3 }, ";"));
        }

        [TestMethod]
        public void Join2()
        {
            Assert.AreEqual("a;b;c", TextBuilder.Join(";", "a", "b", "c"));
        }

        [TestMethod]
        public void SplitPrefixTwoParts()
        {
            string prefix;
            string suffix;
            TextBuilder.SplitPrefix("some string goes here", ' ', out prefix, out suffix);
            Assert.AreEqual("some", prefix);
            Assert.AreEqual("string goes here", suffix);
        }

        [TestMethod]
        public void FromTheCode()
        {
            string prefix;
            string suffix;
            TextBuilder.SplitPrefix("Story.Order", '.', out prefix, out suffix);
            Assert.AreEqual("Story", prefix);
            Assert.AreEqual("Order", suffix);
        }


        [TestMethod]
        public void SplitPrefixOnePart()
        {
            string prefix;
            string suffix;
            TextBuilder.SplitPrefix("some", ' ', out prefix, out suffix);
            Assert.AreEqual(string.Empty, prefix);
            Assert.AreEqual("some", suffix);
        }

        [TestMethod]
        public void SplitSuffixTwoParts()
        {
            string prefix;
            string suffix;
            TextBuilder.SplitSuffix("some string goes here", ' ', out prefix, out suffix);
            Assert.AreEqual("some", prefix);
            Assert.AreEqual("string goes here", suffix);
        }

        [TestMethod]
        public void SplitSuffixOnePart()
        {
            string prefix;
            string suffix;
            TextBuilder.SplitSuffix("some", ' ', out prefix, out suffix);
            Assert.AreEqual("some", prefix);
            Assert.AreEqual(string.Empty, suffix);
        }
    }
}
