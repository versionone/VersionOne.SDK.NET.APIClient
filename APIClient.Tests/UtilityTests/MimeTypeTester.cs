using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class MimeTypeTester
    {
        private static void TestExtension(string extension, string expectedMimeType)
        {
            TestFilename("blah." + extension, expectedMimeType);
        }

        private static void TestFilename(string filename, string expectedMimeType)
        {
            Assert.AreEqual(expectedMimeType, MimeType.Resolve(filename));
        }

        [TestMethod]
        public void TxtIsTextPlain()
        {
            TestExtension("txt", "text/plain");
        }

        [TestMethod]
        public void RtfIsTextRtf()
        {
            TestExtension("rtf", "text/rtf");
        }

        [TestMethod]
        public void CaseDoesNotMatter()
        {
            TestExtension("TXT", "text/plain");
        }

        [TestMethod]
        public void PathDoesNotMatter()
        {
            TestFilename(@"e:\dog\cat\mouse.txt", "text/plain");
        }

        [TestMethod]
        public void MSOfficeFileTypes()
        {
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

        [TestMethod]
        public void DefaultIsOctetStream()
        {
            TestExtension("YouWillNeverFindAFileWithThisExtensionEverInYourEntireLifeOK", "application/octet-stream");
        }
    }
}
