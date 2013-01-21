using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class GettingStartedTests
    {

        private EnvironmentContext _context;
        
        [SetUp]
        public void Setup()
        {
            _context = new EnvironmentContext();
        }

        [TearDown]
        public void TearDown()
        {
            _context = null;
        }

        [Test]
        public void Test()
        {

        }
    }
}