using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class EnvironmentContextTester
    {

        private EnvironmentContext _defaultTarget;
        private EnvironmentContext _nonDefaultTarget;

        [SetUp]
        public void SetUp()
        {
            _defaultTarget = new EnvironmentContext();
            _nonDefaultTarget = new EnvironmentContext(new ModelsAndServices()); //can inject your own modelsAndServices implementation
        }

        [TearDown]
        public void TearDown()
        {
            _defaultTarget = null;
            _nonDefaultTarget = null;
        }

        [Test]
        public void MetaModelTest()
        {
            Assert.IsNotNull(_defaultTarget.MetaModel);
            Assert.IsNotNull(_nonDefaultTarget.MetaModel);
        }

        [Test]
        public void ServicesTest()
        {
            Assert.IsNotNull(_defaultTarget.Services);
            Assert.IsNotNull(_nonDefaultTarget.Services);
        }

    }
}
