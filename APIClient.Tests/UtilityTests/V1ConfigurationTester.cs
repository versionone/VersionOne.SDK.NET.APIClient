using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests {
	[TestFixture]
	public class V1ConfigurationTester {
		private static void RunTest(string testName, bool exepectedTracking, TrackingLevel exepectedStoryLevel, TrackingLevel expectedDefectLevel) {
			V1Configuration testSubject = new V1Configuration(new XmlResponseConnector("TestData.xml", "config.v1/" + testName, "V1ConfigurationTester"));
			Assert.AreEqual(exepectedTracking, testSubject.EffortTracking);
			Assert.AreEqual(exepectedStoryLevel, testSubject.StoryTrackingLevel);
			Assert.AreEqual(expectedDefectLevel, testSubject.DefectTrackingLevel);
		}

		[Test]
		public void TrueOffOff() {
			RunTest("TrueOffOff", true, TrackingLevel.Off, TrackingLevel.Off);
		}

		[Test]
		public void TrueOnOn() {
			RunTest("TrueOnOn", true, TrackingLevel.On, TrackingLevel.On);
		}

		[Test]
		public void TrueOffOn() {
			RunTest("TrueOffOn", true, TrackingLevel.Off, TrackingLevel.On);
		}

		[Test]
		public void TrueOnOff() {
			RunTest("TrueOnOff", true, TrackingLevel.On, TrackingLevel.Off);
		}

		[Test]
		public void FalseOffOff() {
			RunTest("FalseOffOff", false, TrackingLevel.Off, TrackingLevel.Off);
		}

		[Test]
		public void FalseOnOn() {
			RunTest("FalseOnOn", false, TrackingLevel.On, TrackingLevel.On);
		}

		[Test]
		public void FalseOffOn() {
			RunTest("FalseOffOn", false, TrackingLevel.Off, TrackingLevel.On);
		}

		[Test]
		public void FalseOnOff() {
			RunTest("FalseOnOff", false, TrackingLevel.On, TrackingLevel.Off);
		}
	}
}