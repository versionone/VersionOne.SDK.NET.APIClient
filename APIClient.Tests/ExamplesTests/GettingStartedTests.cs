using NUnit.Framework;
using VersionOne.SDK.APIClient.Examples;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class GettingStartedTests
    {

        private GettingStarted _examples;

        [SetUp]
        public void Setup()
        {
            _examples = new GettingStarted();
        }

        [TearDown]
        public void TearDown()
        {
            _examples = null;
        }

        [Test]
        public void GetV1ConfigurationTest()
        {
            Assert.IsNotNull(_examples.GetV1Configuration());
        }

        [Test]
        public void GetSingleAssetTest()
        {
            Assert.IsNotNull(_examples.GetSingleAsset());
        }

    }
}