using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests {
	[TestFixture]
	public class MimeTypeTester {
		private static void TestExtension(string extension, string expectedMimeType) {
			TestFilename("blah." + extension, expectedMimeType);
		}

		private static void TestFilename(string filename, string expectedMimeType) {
			Assert.AreEqual(expectedMimeType, MimeType.Resolve(filename));
		}

		[Test]
		public void TxtIsTextPlain() {
			TestExtension("txt", "text/plain");
		}

		[Test]
		public void RtfIsTextRtf() {
			TestExtension("rtf", "text/rtf");
		}

		[Test]
		public void CaseDoesNotMatter() {
			TestExtension("TXT", "text/plain");
		}

		[Test]
		public void PathDoesNotMatter() {
			TestFilename(@"e:\dog\cat\mouse.txt", "text/plain");
		}

		[Test]
		public void MSOfficeFileTypes() {
			TestExtension("doc", "application/msword");
			TestExtension("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");

			TestExtension("dot", "application/msword");
			TestExtension("dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template");

			TestExtension("xls", "application/vnd.ms-excel");
			TestExtension("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

			TestExtension("ppt", "application/vnd.ms-powerpoint");
			TestExtension("pps", "application/vnd.ms-powerpoint");
			TestExtension("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");

			TestExtension("pub", "application/vnd.ms-publisher");
		}

		[Test]
		public void DefaultIsOctetStream() {
			TestExtension("YouWillNeverFindAFileWithThisExtensionEverInYourEntireLifeOK", "application/octet-stream");
		}
	}
}