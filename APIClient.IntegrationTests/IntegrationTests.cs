using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        private readonly string _v1InstanceUrl = ConfigurationManager.AppSettings.Get("V1Url");
        private readonly string _v1AccessToken = ConfigurationManager.AppSettings.Get("V1AccessToken");

        #region Creates

        [TestMethod]
        public void CreateEpic()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var epicType = services.MetaModel.GetAssetType("Epic");
            var newEpic = services.New(epicType, contextId);
            var nameAttribute = epicType.GetAttributeDefinition("Name");
            newEpic.SetAttributeValue(nameAttribute, "Test Epic");
            services.Save(newEpic);

            Assert.IsNotNull(newEpic.Oid);
        }

        [TestMethod]
        public void CreateEpicWithNestedStory()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            
            var epicType = services.MetaModel.GetAssetType("Epic");
            var newEpic = services.New(epicType, contextId);
            var epicNameAttribute = epicType.GetAttributeDefinition("Name");
            var generateSubStoryOperation = epicType.GetOperation("GenerateSubStory ");
            newEpic.SetAttributeValue(epicNameAttribute, "Test Epic With Nested Story");

            services.Save(newEpic);
            services.ExecuteOperation(generateSubStoryOperation, newEpic.Oid);

            Assert.IsNotNull(newEpic.Oid);

            var query = new Query(newEpic.Oid.Momentless);
            var subsAttributeDefinition = epicType.GetAttributeDefinition("Subs");
            query.Selection.Add(subsAttributeDefinition);
            var epic = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, epic.GetAttribute(subsAttributeDefinition).Values.Cast<object>().Count());
        }

        [TestMethod]
        public void CreateStory()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, "Test Story");
            services.Save(newStory);

            Assert.IsNotNull(newStory.Oid);
        }

        [TestMethod]
        public void CreateStoryWithNestedTask()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            var childrenAttribute = storyType.GetAttributeDefinition("Children");
            newStory.SetAttributeValue(nameAttribute, "Test Story With Nested Task");
            services.Save(newStory);

            var taskType = services.MetaModel.GetAssetType("Task");
            var newTask = services.New(taskType, newStory.Oid);
            newTask.SetAttributeValue(nameAttribute, "Test Task Nested in " + newStory.Oid);

            services.Save(newTask);

            Assert.IsNotNull(newStory.Oid);
            Assert.IsNotNull(newTask.Oid);

            var query = new Query(newStory.Oid.Momentless);
            query.Selection.Add(childrenAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(childrenAttribute).Values.Cast<object>().Count());
        }

        [TestMethod]
        public void CreateStoryWithNestedTest()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            var childrenAttribute = storyType.GetAttributeDefinition("Children");
            newStory.SetAttributeValue(nameAttribute, "Test Story With Nested Test");
            services.Save(newStory);

            var testType = services.MetaModel.GetAssetType("Test");
            var newTest = services.New(testType, newStory.Oid);
            newTest.SetAttributeValue(nameAttribute, "Test Test Nested in " + newStory.Oid);

            services.Save(newTest);

            Assert.IsNotNull(newStory.Oid);
            Assert.IsNotNull(newTest.Oid);

            var query = new Query(newStory.Oid.Momentless);
            query.Selection.Add(childrenAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(childrenAttribute).Values.Cast<object>().Count());
        }

        [TestMethod]
        [DeploymentItem("versionone.png")]
        public void CreateStoryWithAttachment()
        {
            var services = GetServices();
            string file = "versionone.png";

            Assert.IsTrue(File.Exists(file));
            
            string mimeType = MimeType.Resolve(file);
            IAttachments attachments = new Attachments(V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
                .WithAccessToken(_v1AccessToken).UseEndpoint("attachment.img/")
                .Connect());

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            var attachmentsAttribute = storyType.GetAttributeDefinition("Attachments");
            newStory.SetAttributeValue(nameAttribute, "Test Story");
            services.Save(newStory);


            IAssetType attachmentType = services.MetaModel.GetAssetType("Attachment");
            IAttributeDefinition attachmentAssetDef = attachmentType.GetAttributeDefinition("Asset"); 
            IAttributeDefinition attachmentContent = attachmentType.GetAttributeDefinition("Content");
            IAttributeDefinition attachmentContentType =
                attachmentType.GetAttributeDefinition("ContentType");
            IAttributeDefinition attachmentFileName = attachmentType.GetAttributeDefinition("Filename"); 
            IAttributeDefinition attachmentName = attachmentType.GetAttributeDefinition("Name"); 
            Asset attachment = services.New(attachmentType, Oid.Null); 
            attachment.SetAttributeValue(attachmentName, "Test Attachment"); 
            attachment.SetAttributeValue(attachmentFileName, file); 
            attachment.SetAttributeValue(attachmentContentType, mimeType); 
            attachment.SetAttributeValue(attachmentContent, string.Empty); 
            attachment.SetAttributeValue(attachmentAssetDef, newStory.Oid); 
            services.Save(attachment);
            string key = attachment.Oid.Key.ToString();
            using(Stream input = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (Stream output = attachments.GetWriteStream(key))
                {
                    byte[] buffer = new byte[input.Length + 1];
                    while (true)
                    {
                        int read = input.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            break;

                        output.Write(buffer, 0, read);
                    }
                }
            }
            attachments.SetWriteStream(key, mimeType);

            var query = new Query(newStory.Oid.Momentless);
            query.Selection.Add(attachmentsAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(attachmentsAttribute).Values.Cast<object>().Count());
        }

        [Ignore]
        [TestMethod]
        public void CreateStoryWithEmbeddedImage()
        {
            //TODO CreateStoryWithEmbeddedImage
        }

        [TestMethod]
        public void CreateDefect()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var defectType = services.MetaModel.GetAssetType("Defect");
            var newDefect = services.New(defectType, contextId);
            var nameAttribute = defectType.GetAttributeDefinition("Name");
            newDefect.SetAttributeValue(nameAttribute, "Test Defect");
            services.Save(newDefect);

            Assert.IsNotNull(newDefect.Oid);
        }

        [TestMethod]
        public void CreateDefectWithNestedTask()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var defectType = services.MetaModel.GetAssetType("Defect");
            var newDefect = services.New(defectType, contextId);
            var nameAttribute = defectType.GetAttributeDefinition("Name");
            var childrenAttribute = defectType.GetAttributeDefinition("Children");
            newDefect.SetAttributeValue(nameAttribute, "Test Defect With Nested Task");
            services.Save(newDefect);

            var taskType = services.MetaModel.GetAssetType("Task");
            var newTask = services.New(taskType, newDefect.Oid);
            newTask.SetAttributeValue(nameAttribute, "Test Task Nested in " + newDefect.Oid);

            services.Save(newTask);

            Assert.IsNotNull(newDefect.Oid);
            Assert.IsNotNull(newTask.Oid);

            var query = new Query(newDefect.Oid.Momentless);
            query.Selection.Add(childrenAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(childrenAttribute).Values.Cast<object>().Count());
        }

        [TestMethod]
        public void CreateDefectWithNestedTest()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var defectType = services.MetaModel.GetAssetType("Defect");
            var newDefect = services.New(defectType, contextId);
            var nameAttribute = defectType.GetAttributeDefinition("Name");
            var childrenAttribute = defectType.GetAttributeDefinition("Children");
            newDefect.SetAttributeValue(nameAttribute, "Test Defect With Nested Test");
            services.Save(newDefect);

            var testType = services.MetaModel.GetAssetType("Test");
            var newTest = services.New(testType, newDefect.Oid);
            newTest.SetAttributeValue(nameAttribute, "Test Test Nested in " + newDefect.Oid);

            services.Save(newTest);

            Assert.IsNotNull(newDefect.Oid);
            Assert.IsNotNull(newTest.Oid);

            var query = new Query(newDefect.Oid.Momentless);
            query.Selection.Add(childrenAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(childrenAttribute).Values.Cast<object>().Count());
        }

        [TestMethod]
        [DeploymentItem("versionone.png")]
        public void CreateDefectWithAttachment()
        {
            var services = GetServices();
            string file = "versionone.png";

            Assert.IsTrue(File.Exists(file));

            string mimeType = MimeType.Resolve(file);
            IAttachments attachments = new Attachments(V1Connector
                .WithInstanceUrl(_v1InstanceUrl)
                .WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
                .WithAccessToken(_v1AccessToken).UseEndpoint("attachment.img/")
                .Connect());

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var defectType = services.MetaModel.GetAssetType("Defect");
            var newDefect = services.New(defectType, contextId);
            var nameAttribute = defectType.GetAttributeDefinition("Name");
            var attachmentsAttribute = defectType.GetAttributeDefinition("Attachments");
            newDefect.SetAttributeValue(nameAttribute, "Test Defect");
            services.Save(newDefect);


            IAssetType attachmentType = services.MetaModel.GetAssetType("Attachment");
            IAttributeDefinition attachmentAssetDef = attachmentType.GetAttributeDefinition("Asset");
            IAttributeDefinition attachmentContent = attachmentType.GetAttributeDefinition("Content");
            IAttributeDefinition attachmentContentType =
                attachmentType.GetAttributeDefinition("ContentType");
            IAttributeDefinition attachmentFileName = attachmentType.GetAttributeDefinition("Filename");
            IAttributeDefinition attachmentName = attachmentType.GetAttributeDefinition("Name");
            Asset attachment = services.New(attachmentType, Oid.Null);
            attachment.SetAttributeValue(attachmentName, "Test Attachment");
            attachment.SetAttributeValue(attachmentFileName, file);
            attachment.SetAttributeValue(attachmentContentType, mimeType);
            attachment.SetAttributeValue(attachmentContent, string.Empty);
            attachment.SetAttributeValue(attachmentAssetDef, newDefect.Oid);
            services.Save(attachment);
            string key = attachment.Oid.Key.ToString();
            using (Stream input = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (Stream output = attachments.GetWriteStream(key))
                {
                    byte[] buffer = new byte[input.Length + 1];
                    while (true)
                    {
                        int read = input.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            break;

                        output.Write(buffer, 0, read);
                    }
                }
            }
            attachments.SetWriteStream(key, mimeType);

            var query = new Query(newDefect.Oid.Momentless);
            query.Selection.Add(attachmentsAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.AreEqual(1, story.GetAttribute(attachmentsAttribute).Values.Cast<object>().Count());
        }

        [Ignore]
        [TestMethod]
        public void CreateDefectWithEmbeddedImage()
        {
            //TODO CreateDefectWithEmbeddedImage
        }

        [TestMethod]
        public void CreateRequest()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var requestType = services.MetaModel.GetAssetType("Request");
            var newRequest = services.New(requestType, contextId);
            var nameAttribute = requestType.GetAttributeDefinition("Name");
            newRequest.SetAttributeValue(nameAttribute, "Test Request");
            services.Save(newRequest);

            Assert.IsNotNull(newRequest.Oid);
        }

        [TestMethod]
        public void CreateIssue()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var issueType = services.MetaModel.GetAssetType("Issue");
            var newIssue = services.New(issueType, contextId);
            var nameAttribute = issueType.GetAttributeDefinition("Name");
            newIssue.SetAttributeValue(nameAttribute, "Test Issue");
            services.Save(newIssue);

            Assert.IsNotNull(newIssue.Oid);
        }

        #endregion

        #region Updates

        [TestMethod]
        public void UpdateScalarAttributeOnStory()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, "Test Story to update scalar attribute");
            services.Save(newStory);

            Assert.IsNotNull(newStory.Oid);

            var query = new Query(newStory.Oid);
            query.Selection.Add(nameAttribute);
            var story = services.Retrieve(query).Assets[0];
            var oldName = story.GetAttribute(nameAttribute).Value.ToString();
            story.SetAttributeValue(nameAttribute, "Test Story to update scalar attribute - Name updated");
            services.Save(story);

            Assert.AreNotSame(oldName, story.GetAttribute(nameAttribute).Value.ToString());
        }

        [TestMethod]
        public void UpdateSingleRelationAttributeOnStory()
        {
            var services = GetServices();

            var contextId = IntegrationTestsHelper.TestProjectOid;
            var storyType = services.MetaModel.GetAssetType("Story");
            var newStory = services.New(storyType, contextId);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            newStory.SetAttributeValue(nameAttribute, "Test Story to update single-relation attribute");
            services.Save(newStory);

            Assert.IsNotNull(newStory.Oid);

            var sourceAttribute = storyType.GetAttributeDefinition("Source");
            newStory.SetAttributeValue(sourceAttribute, "StorySource:156");
            services.Save(newStory);

            var query = new Query(newStory.Oid);
            query.Selection.Add(sourceAttribute);
            var story = services.Retrieve(query).Assets[0];

            Assert.IsNotNull(story.GetAttribute(sourceAttribute).Value.ToString());
        }

        #endregion

        private IServices GetServices()
        {
            IServices services = new Services(
                V1Connector
                    .WithInstanceUrl(_v1InstanceUrl)
                    .WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
                    .WithAccessToken(_v1AccessToken)
                    .Connect());
            return services;
        }
    }
}
