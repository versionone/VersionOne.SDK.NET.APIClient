using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class V1ConfigurationTester
    {
        private static void RunTest(string testName, bool exepectedTracking, TrackingLevel exepectedStoryLevel, TrackingLevel expectedDefectLevel, CapacityPlanning expectedCapacityPlanning = CapacityPlanning.Off)
        {
            V1Configuration testSubject = new V1Configuration(new XmlResponseConnector("TestData.xml", "config.v1/" + testName, "V1ConfigurationTester"));
            Assert.AreEqual(exepectedTracking, testSubject.EffortTracking);
            Assert.AreEqual(exepectedStoryLevel, testSubject.StoryTrackingLevel);
            Assert.AreEqual(expectedDefectLevel, testSubject.DefectTrackingLevel);
            Assert.AreEqual(expectedCapacityPlanning, testSubject.CapacityPlanning);
        }

        [TestMethod]
        public void TrueOffOff()
        {
            RunTest("TrueOffOff", true, TrackingLevel.Off, TrackingLevel.Off);
        }

        [TestMethod]
        public void TrueOnOn()
        {
            RunTest("TrueOnOn", true, TrackingLevel.On, TrackingLevel.On);
        }

        [TestMethod]
        public void TrueOffOn()
        {
            RunTest("TrueOffOn", true, TrackingLevel.Off, TrackingLevel.On);
        }

        [TestMethod]
        public void TrueOnOff()
        {
            RunTest("TrueOnOff", true, TrackingLevel.On, TrackingLevel.Off);
        }

        [TestMethod]
        public void FalseOffOff()
        {
            RunTest("FalseOffOff", false, TrackingLevel.Off, TrackingLevel.Off);
        }

        [TestMethod]
        public void FalseOnOn()
        {
            RunTest("FalseOnOn", false, TrackingLevel.On, TrackingLevel.On);
        }

        [TestMethod]
        public void FalseOffOn()
        {
            RunTest("FalseOffOn", false, TrackingLevel.Off, TrackingLevel.On);
        }

        [TestMethod]
        public void FalseOnOff()
        {
            RunTest("FalseOnOff", false, TrackingLevel.On, TrackingLevel.Off);
        }

        [TestMethod]
        public void FalseOnOnOff()
        {
            RunTest("FalseOnOnOff", false, TrackingLevel.On, TrackingLevel.On, CapacityPlanning.Off);
        }

        [TestMethod]
        public void FalseOnOnOn()
        {
            RunTest("FalseOnOnOn", false, TrackingLevel.On, TrackingLevel.On, CapacityPlanning.On);
        }
    }
}
