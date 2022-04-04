﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace VersionOne.SDK.APIClient.IntegrationTests
{
	[TestClass]
	public class IntegrationTests
	{
		private readonly string _v1InstanceUrl = ConfigurationManager.AppSettings.Get("V1Url");
		private readonly bool _useOAuthEndpoints = bool.Parse(ConfigurationManager.AppSettings.Get("UseOAuthEndpoints"));
		private readonly string _v1AccessToken = ConfigurationManager.AppSettings.Get("V1AccessToken");
		private readonly string _v1Username = ConfigurationManager.AppSettings.Get("V1UserName");
		private readonly string _v1Password = ConfigurationManager.AppSettings.Get("V1Password");

		#region Connection

		[TestMethod]
		public void ConnectionWithUsernameAndPassword()
		{
			if (_useOAuthEndpoints)
			{
				Assert.Inconclusive();
			}
			else
			{
				var services = new Services(
					V1Connector
						.WithInstanceUrl(_v1InstanceUrl)
						.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
						.WithUsernameAndPassword(_v1Username, _v1Password)
						.Build());

				var member20Id = services.GetOid("Member:20");
				var result = services.Retrieve(new Query(member20Id));

				Assert.IsTrue(result.Assets.Count == 1);
			}
		}

		[TestMethod]
		public void ConnectionWithAccessToken()
		{
			var services = GetServices();

			var member20Id = services.GetOid("Member:20");
			var result = services.Retrieve(new Query(member20Id));

			Assert.IsTrue(result.Assets.Count == 1);
		}

		#endregion

		#region Creates

		[TestMethod]
		public void CreateEpic()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var epicType = services.Meta.GetAssetType("Epic");
			var newEpic = services.New(epicType, contextId);
			var nameAttribute = epicType.GetAttributeDefinition("Name");
			var name = string.Format("Test Epic {0} Create epic", contextId);
			newEpic.SetAttributeValue(nameAttribute, name);
			services.Save(newEpic);

			Assert.IsNotNull(newEpic.Oid);
		}

		[TestMethod]
		public void CreateEpicWithNestedStory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);

			var epicType = services.Meta.GetAssetType("Epic");
			var newEpic = services.New(epicType, contextId);
			var epicNameAttribute = epicType.GetAttributeDefinition("Name");
			var generateSubStoryOperation = epicType.GetOperation("GenerateSubStory ");
			var name = string.Format("Test Epic {0} Create epic with nested story", contextId);
			newEpic.SetAttributeValue(epicNameAttribute, name);

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

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Create story", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			Assert.IsNotNull(newStory.Oid);
		}

		[TestMethod]
		public void CreateStoryWithConversation()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Create story with conversation", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var conversationType = services.Meta.GetAssetType("Conversation");
			var expressionType = services.Meta.GetAssetType("Expression");
			var authorAttribute = expressionType.GetAttributeDefinition("Author");
			var authoredAtAttribute = expressionType.GetAttributeDefinition("AuthoredAt");
			var contentAttribute = expressionType.GetAttributeDefinition("Content");
			var belongsToAttribute = expressionType.GetAttributeDefinition("BelongsTo");
			var inReplyToAttribute = expressionType.GetAttributeDefinition("InReplyTo");
			var mentionsAttribute = expressionType.GetAttributeDefinition("Mentions");

			var newConversation = services.New(conversationType);
			var questionExpression = services.New(expressionType);

			services.Save(newConversation);
			questionExpression.SetAttributeValue(authorAttribute, services.GetOid("Member:20"));
			questionExpression.SetAttributeValue(authoredAtAttribute, DateTime.Now);
			questionExpression.SetAttributeValue(contentAttribute, "Is this a test conversation?");
			questionExpression.SetAttributeValue(belongsToAttribute, newConversation.Oid);
			questionExpression.AddAttributeValue(mentionsAttribute, newStory.Oid);
			services.Save(questionExpression);
			var answerExpression = services.New(expressionType, questionExpression.Oid);
			answerExpression.SetAttributeValue(authorAttribute, services.GetOid("Member:20"));
			answerExpression.SetAttributeValue(authoredAtAttribute, DateTime.Now.AddMinutes(15));
			answerExpression.SetAttributeValue(contentAttribute, "Yes it is!");
			answerExpression.SetAttributeValue(inReplyToAttribute, questionExpression.Oid);
			services.Save(answerExpression);
		}

		[TestMethod]
		public void CreateStoryWithConversationAndMention()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var mentionedInExpressionsAttribute = storyType.GetAttributeDefinition("MentionedInExpressions");
			var name = string.Format("Test Story {0} Create story with conversation and mention", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var storyTobeMentioned = services.New(storyType, contextId);
			storyTobeMentioned.SetAttributeValue(nameAttribute, name + " (to be mentioned)");
			services.Save(storyTobeMentioned);

			var conversationType = services.Meta.GetAssetType("Conversation");
			var expressionType = services.Meta.GetAssetType("Expression");
			var authorAttribute = expressionType.GetAttributeDefinition("Author");
			var authoredAtAttribute = expressionType.GetAttributeDefinition("AuthoredAt");
			var contentAttribute = expressionType.GetAttributeDefinition("Content");
			var belongsToAttribute = expressionType.GetAttributeDefinition("BelongsTo");
			var inReplyToAttribute = expressionType.GetAttributeDefinition("InReplyTo");

			var newConversation = services.New(conversationType, newStory.Oid);
			var questionExpression = services.New(expressionType, newStory.Oid);

			services.Save(newConversation);
			questionExpression.SetAttributeValue(authorAttribute, services.GetOid("Member:20"));
			questionExpression.SetAttributeValue(authoredAtAttribute, DateTime.Now);
			questionExpression.SetAttributeValue(contentAttribute, "Can I mention another story in a conversation?");
			questionExpression.SetAttributeValue(belongsToAttribute, newConversation.Oid);
			services.Save(questionExpression);
			var answerExpression = services.New(expressionType, questionExpression.Oid);
			answerExpression.SetAttributeValue(authorAttribute, services.GetOid("Member:20"));
			answerExpression.SetAttributeValue(authoredAtAttribute, DateTime.Now.AddMinutes(15));
			answerExpression.SetAttributeValue(contentAttribute, "Yes I can!");
			answerExpression.SetAttributeValue(inReplyToAttribute, questionExpression.Oid);
			services.Save(answerExpression);

			newStory.AddAttributeValue(mentionedInExpressionsAttribute, questionExpression.Oid);
			services.Save(newStory);
			storyTobeMentioned.AddAttributeValue(mentionedInExpressionsAttribute, answerExpression.Oid);
			services.Save(storyTobeMentioned);
		}

		[TestMethod]
		public void CreateStoryWithNestedTask()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var childrenAttribute = storyType.GetAttributeDefinition("Children");
			var name = string.Format("Test Story {0} Create story with nested task", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var taskType = services.Meta.GetAssetType("Task");
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

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var childrenAttribute = storyType.GetAttributeDefinition("Children");
			var name = string.Format("Test Story {0} Create story with nested test", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var testType = services.Meta.GetAssetType("Test");
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

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var attachmentsAttribute = storyType.GetAttributeDefinition("Attachments");
			var name = string.Format("Test Story {0} Create story with attachment", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			services.SaveAttachment(file, newStory, "Test Attachment on " + newStory.Oid);

			var query = new Query(newStory.Oid.Momentless);
			query.Selection.Add(attachmentsAttribute);
			var story = services.Retrieve(query).Assets[0];

			Assert.AreEqual(1, story.GetAttribute(attachmentsAttribute).Values.Cast<object>().Count());
		}

		[TestMethod]
		[DeploymentItem("versionone.png")]
		public void CreateStoryWithEmbeddedImage()
		{
			var services = GetServices();
			string file = "versionone.png";

			Assert.IsTrue(File.Exists(file));

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var descriptionAttribute = storyType.GetAttributeDefinition("Description");
			var name = string.Format("Test Story {0} Create story with embedded image", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.SetAttributeValue(descriptionAttribute, "Test description");
			services.Save(newStory);

			var embeddedImageOid = services.SaveEmbeddedImage(file, newStory);
			var embeddedImageTag = string.Format("<img src=\"{0}\" alt=\"\" data-oid=\"{1}\" />", "embedded.img/" + embeddedImageOid.Key,
				embeddedImageOid.Momentless);
			newStory.SetAttributeValue(descriptionAttribute, embeddedImageTag);
			services.Save(newStory);

			var query = new Query(embeddedImageOid);
			Assert.AreEqual(1, services.Retrieve(query).Assets.Count);

			query = new Query(newStory.Oid);
			query.Selection.Add(descriptionAttribute);
			var defect = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(defect);
			Assert.IsTrue(defect.GetAttribute(descriptionAttribute).Value.ToString().Contains(embeddedImageTag));
		}

		[TestMethod]
		public void CreateStoryWithTaggedWithMultiValueAttribute()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var taggedWithAttribute = storyType.GetAttributeDefinition("TaggedWith");
			var name = $"Test Story {contextId} Create story with TaggedWith values";
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 1");
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 2");
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 3");
			services.Save(newStory);
			newStory.AcceptChanges();

			var query = new Query(newStory.Oid.Momentless);
			query.Selection.Add(taggedWithAttribute);
			var results = services.Retrieve(query).Assets;
			Assert.AreEqual(1, results.Count);
			var story = results[0];
			Assert.IsNotNull(story);
			var expected = new[] { "Tag 1", "Tag 2", "Tag 3" };
			var actuals = story.GetAttribute(taggedWithAttribute).Values.Cast<string>().ToArray();
			Assert.AreEqual(3, actuals.Length);
			CollectionAssert.AreEqual(expected, actuals);
		}

		[TestMethod]
		public void CreateDefect()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			var name = string.Format("Test Defect {0} Create defect", contextId);
			newDefect.SetAttributeValue(nameAttribute, name);
			services.Save(newDefect);

			Assert.IsNotNull(newDefect.Oid);
		}

		[TestMethod]
		public void CreateDefectWithNestedTask()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			var childrenAttribute = defectType.GetAttributeDefinition("Children");
			var name = string.Format("Test Defect {0} Create defect with nested task", contextId);
			newDefect.SetAttributeValue(nameAttribute, name);
			services.Save(newDefect);

			var taskType = services.Meta.GetAssetType("Task");
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

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			var childrenAttribute = defectType.GetAttributeDefinition("Children");
			var name = string.Format("Test Defect {0} Create defect with nested test", contextId);
			newDefect.SetAttributeValue(nameAttribute, name);
			services.Save(newDefect);

			var testType = services.Meta.GetAssetType("Test");
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

			string mimeType = MimeType.Resolve(file);
			IAttachments attachments = new Attachments(V1Connector
				.WithInstanceUrl(_v1InstanceUrl)
				.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
				.WithAccessToken(_v1AccessToken).UseEndpoint("attachment.img/")
				.Build());

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			var attachmentsAttribute = defectType.GetAttributeDefinition("Attachments");
			var name = string.Format("Test Defect {0} Create defect with attachment", contextId);
			newDefect.SetAttributeValue(nameAttribute, name);
			services.Save(newDefect);

			services.SaveAttachment(file, newDefect, "Test Attachment on " + newDefect.Oid);

			var query = new Query(newDefect.Oid.Momentless);
			query.Selection.Add(attachmentsAttribute);
			var defect = services.Retrieve(query).Assets[0];

			Assert.AreEqual(1, defect.GetAttribute(attachmentsAttribute).Values.Cast<object>().Count());
		}

		[TestMethod]
		[DeploymentItem("versionone.png")]
		public void CreateDefectWithEmbeddedImage()
		{
			var services = GetServices();
			string file = "versionone.png";

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			var descriptionAttribute = defectType.GetAttributeDefinition("Description");
			var name = string.Format("Test Defect {0} Create defect with embedded image", contextId);
			newDefect.SetAttributeValue(nameAttribute, name);
			services.Save(newDefect);

			var embeddedImageOid = services.SaveEmbeddedImage(file, newDefect);
			var embeddedImageTag = string.Format("<img src=\"{0}\" alt=\"\" data-oid=\"{1}\" />", "embedded.img/" + embeddedImageOid.Key,
				embeddedImageOid.Momentless);
			newDefect.SetAttributeValue(descriptionAttribute, embeddedImageTag);
			services.Save(newDefect);

			var query = new Query(embeddedImageOid);
			Assert.AreEqual(1, services.Retrieve(query).Assets.Count);

			query = new Query(newDefect.Oid);
			query.Selection.Add(descriptionAttribute);
			var defect = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(defect);
			Assert.IsTrue(defect.GetAttribute(descriptionAttribute).Value.ToString().Contains(embeddedImageTag));
		}

		[TestMethod]
		public void CreateRequest()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var requestType = services.Meta.GetAssetType("Request");
			var newRequest = services.New(requestType, contextId);
			var nameAttribute = requestType.GetAttributeDefinition("Name");
			var name = string.Format("Test Request {0} Create request", contextId);
			newRequest.SetAttributeValue(nameAttribute, name);
			services.Save(newRequest);

			Assert.IsNotNull(newRequest.Oid);
		}

		[TestMethod]
		public void CreateIssue()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var issueType = services.Meta.GetAssetType("Issue");
			var newIssue = services.New(issueType, contextId);
			var nameAttribute = issueType.GetAttributeDefinition("Name");
			var name = string.Format("Test Issue {0} Create issue", contextId);
			newIssue.SetAttributeValue(nameAttribute, name);
			services.Save(newIssue);

			Assert.IsNotNull(newIssue.Oid);
		}

		[TestMethod]
		[ExpectedException(typeof(MetaException))]
		public void CreateUnknownSingleAsset()
		{
			var services = GetServices();
			var unknownAsset = services.Meta.GetAssetType("Unknown");
		}

		#endregion

		#region Updates

		[TestMethod]
		public void UpdateScalarAttributeOnStory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Update scalar attribute", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			Assert.IsNotNull(newStory.Oid);

			var query = new Query(newStory.Oid);
			query.Selection.Add(nameAttribute);
			var story = services.Retrieve(query).Assets[0];
			var oldName = story.GetAttribute(nameAttribute).Value.ToString();
			story.SetAttributeValue(nameAttribute, name + " - Name updated");
			services.Save(story);

			Assert.AreNotSame(oldName, story.GetAttribute(nameAttribute).Value.ToString());
		}

		[TestMethod]
		public void UpdateSingleRelationAttributeOnStory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Update single-relation attribute", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
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

		[TestMethod]
		public void UpdateMultiRelationAttributeOnStory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var nameAttribute = storyType.GetAttributeDefinition("Name");

			var parentStory = services.New(storyType, contextId);
			var name = string.Format("Test Story {0} Update multi-relation attribute", contextId);
			parentStory.SetAttributeValue(nameAttribute, name);
			services.Save(parentStory);
			var child1Story = services.New(storyType, contextId);
			child1Story.SetAttributeValue(nameAttribute, name + " - Child 1");
			services.Save(child1Story);
			var child2Story = services.New(storyType, contextId);
			child2Story.SetAttributeValue(nameAttribute, name + " - Child 2");
			services.Save(child2Story);

			var dependantsAttribute = storyType.GetAttributeDefinition("Dependants");
			parentStory.AddAttributeValue(dependantsAttribute, child1Story.Oid);
			services.Save(parentStory);

			var query = new Query(parentStory.Oid);
			query.Selection.Add(dependantsAttribute);
			var story = services.Retrieve(query).Assets[0];

			Assert.AreEqual(1, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());

			parentStory.AddAttributeValue(dependantsAttribute, child2Story.Oid);
			services.Save(parentStory);

			var query2 = new Query(parentStory.Oid);
			query2.Selection.Add(dependantsAttribute);
			story = services.Retrieve(query2).Assets[0];

			Assert.AreEqual(2, story.GetAttribute(dependantsAttribute).Values.Cast<object>().Count());
		}

		[TestMethod]
		public void UpdateMultiValueAttributeTaggedWithOnStory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var taggedWithAttribute = storyType.GetAttributeDefinition("TaggedWith");
			var name = $"Test Story {contextId} Update story with TaggedWith values";
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 1");
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 2");
			newStory.AddAttributeValue(taggedWithAttribute, "Tag 3");
			services.Save(newStory);
			newStory.AcceptChanges();

			var query = new Query(newStory.Oid.Momentless);
			query.Selection.Add(taggedWithAttribute);
			var results = services.Retrieve(query).Assets;
			var story = results[0];
			Assert.IsNotNull(story);
			var expected = new[] { "Tag 1", "Tag 2", "Tag 3" };
			var actuals = story.GetAttribute(taggedWithAttribute).Values.Cast<string>().ToArray();
			Assert.AreEqual(3, actuals.Length);
			CollectionAssert.AreEqual(expected, actuals);

			story.AddAttributeValue(taggedWithAttribute, "Tag 4");
			story.AddAttributeValue(taggedWithAttribute, "Tag 5");
			story.RemoveAttributeValue(taggedWithAttribute, "Tag 1");
			story.RemoveAttributeValue(taggedWithAttribute, "Tag 2");
			services.Save(story);
			story.AcceptChanges();

			query = new Query(newStory.Oid.Momentless);
			query.Selection.Add(taggedWithAttribute);
			results = services.Retrieve(query).Assets;
			Assert.AreEqual(1, results.Count);
			story = results[0];
			expected = new[] { "Tag 3", "Tag 4", "Tag 5" };
			actuals = story.GetAttribute(taggedWithAttribute).Values.Cast<string>().ToArray();
			Assert.AreEqual(3, actuals.Length);
			CollectionAssert.AreEqual(expected, actuals);
		}

		#endregion

		#region Queries

		[TestMethod]
		[ExpectedException(typeof(OidException))]
		public void QueryInvalidOid()
		{
			var services = GetServices();
			var invalidOid = services.GetOid("unknown:007");
		}

		[TestMethod]
		public void QuerySingleAsset()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query single asset", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var query = new Query(newStory.Oid);
			query.Selection.Add(nameAttribute);
			var story = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(story);
			Assert.IsTrue(story.GetAttribute(nameAttribute).Value.ToString().Equals(name));
		}

		[TestMethod]
		[ExpectedException(typeof(MetaException))]
		public void QueryUnknownSingleAsset()
		{
			var services = GetServices();
			var storyType = services.Meta.GetAssetType("Unknown");

		}

		[TestMethod]
		public void QueryMultipleAssets()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query multiple assets", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			var result = services.Retrieve(query);

			Assert.IsTrue(result.Assets.Count > 2);
		}

		[TestMethod]
		public void QueryAttributes()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var benefitsAttribute = storyType.GetAttributeDefinition("Benefits");
			var estimateAttribute = storyType.GetAttributeDefinition("Estimate");
			newStory.SetAttributeValue(nameAttribute, "Test Story on " + contextId + " - Name attribute");
			newStory.SetAttributeValue(benefitsAttribute, "Test Story on " + contextId + " - Benefits attribute");
			newStory.SetAttributeValue(estimateAttribute, "24");
			services.Save(newStory);

			var query = new Query(newStory.Oid);
			query.Selection.Add(nameAttribute);
			query.Selection.Add(benefitsAttribute);
			query.Selection.Add(estimateAttribute);

			var story = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(story);
			var nameAttr = story.GetAttribute(nameAttribute);
			Assert.IsNotNull(nameAttr);
			Assert.IsTrue(nameAttr.Value.ToString().Equals("Test Story on " + contextId + " - Name attribute"));
			var benefitsAttr = story.GetAttribute(benefitsAttribute);
			Assert.IsNotNull(benefitsAttr);
			Assert.IsTrue(benefitsAttr.Value.ToString().Equals("Test Story on " + contextId + " - Benefits attribute"));
			var estimateAttr = story.GetAttribute(estimateAttribute);
			Assert.IsNotNull(estimateAttr);
			Assert.IsTrue(estimateAttr.Value.ToString().Equals("24"));
		}

		[TestMethod]
		[ExpectedException(typeof(MetaException))]
		public void QueryUnknownAttribute()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var queryUnknowAttribute = storyType.GetAttributeDefinition("Unknown");
		}

		[TestMethod]
		public void QueryRelations()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query relations", contextId);
			newStory.SetAttributeValue(nameAttribute, contextId);
			var workitemPriorityType = services.Meta.GetAssetType("WorkitemPriority");
			var newWorkitemPriority = services.New(workitemPriorityType, contextId);
			newWorkitemPriority.SetAttributeValue(workitemPriorityType.GetAttributeDefinition("Name"),
				"Test WorkItemPriority on " + contextId);
			services.Save(newWorkitemPriority);
			var priorityAttribute = storyType.GetAttributeDefinition("Priority");
			newStory.SetAttributeValue(priorityAttribute, newWorkitemPriority.Oid);
			services.Save(newStory);

			var query = new Query(newStory.Oid);
			query.Selection.Add(priorityAttribute);
			var story = services.Retrieve(query).Assets[0];
			Assert.IsNotNull(story);
			var workitemPriority = story.GetAttribute(priorityAttribute);
			Assert.IsNotNull(workitemPriority);
			Assert.IsTrue(
				workitemPriority.Value.ToString().Equals(newWorkitemPriority.Oid.ToString()));
		}

		[TestMethod]
		public void QueryFilter()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query filter", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, "Another " + name);
			services.Save(newStory);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			var filterTerm = new FilterTerm(nameAttribute);
			filterTerm.Equal(name);
			query.Filter = filterTerm;
			var result = services.Retrieve(query);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Assets.Count == 2);

			result.Assets.ForEach(
				asset => Assert.IsTrue(asset.GetAttribute(nameAttribute).Value.ToString().Equals(name)));
		}

		[TestMethod]
		public void QueryFilterWithMultipleAttributes()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var estimateAttribute = storyType.GetAttributeDefinition("Estimate");
			var name = string.Format("Test Story {0} Query filter with multiple attributes", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.SetAttributeValue(estimateAttribute, "24");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.SetAttributeValue(estimateAttribute, "2");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, "Another " + name);
			newStory.SetAttributeValue(estimateAttribute, "2");
			services.Save(newStory);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			query.Selection.Add(estimateAttribute);
			var nameFilterTerm = new FilterTerm(nameAttribute);
			nameFilterTerm.Equal(name);
			var estimateFilterTerm = new FilterTerm(estimateAttribute);
			estimateFilterTerm.Equal("24");
			query.Filter = new AndFilterTerm(nameFilterTerm, estimateFilterTerm);
			var result = services.Retrieve(query);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Assets.Count == 1);
			result.Assets.ForEach(
				asset => Assert.IsTrue(asset.GetAttribute(nameAttribute).Value.ToString().Equals(name)));
			result.Assets.ForEach(
				asset => Assert.IsTrue(asset.GetAttribute(estimateAttribute).Value.ToString().Equals("24")));

		}

		[TestMethod]
		public void QueryFind()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var descriptionAttribute = storyType.GetAttributeDefinition("Description");
			var name = string.Format("Test Story {0} Query find", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.SetAttributeValue(descriptionAttribute, "Description for " + name);
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, "Another " + name);
			newStory.SetAttributeValue(descriptionAttribute, "Description for " + name);
			services.Save(newStory);

			System.Threading.Thread.Sleep(10000);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			query.Selection.Add(descriptionAttribute);
			var attributeSelection = new AttributeSelection(descriptionAttribute);
			query.Find = new QueryFind(name, attributeSelection);
			var result = services.Retrieve(query);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Assets.Count == 2);
			result.Assets.ForEach(
				asset =>
					Assert.IsTrue(
						asset.GetAttribute(descriptionAttribute)
							.Value.ToString()
							.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0));
		}

		[TestMethod]
		[ExpectedException(typeof(MetaException))]
		public void QueryFindUnknownAsset()
		{
			var services = GetServices();
			var query = new Query(services.Meta.GetAssetType("Unknown"));
		}

		[TestMethod]
		public void QuerySort()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query sort", contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 2");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 1");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 3");
			services.Save(newStory);

			System.Threading.Thread.Sleep(10000);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			var attributeSelection = new AttributeSelection(nameAttribute);
			query.Find = new QueryFind(name, attributeSelection);
			query.OrderBy.MinorSort(nameAttribute, OrderBy.Order.Ascending);
			var result = services.Retrieve(query);

			Assert.IsTrue(result.Assets.Count == 3);
			Assert.IsTrue(result.Assets[0].GetAttribute(nameAttribute).Value.ToString().EndsWith("1"));
			Assert.IsTrue(result.Assets[1].GetAttribute(nameAttribute).Value.ToString().EndsWith("2"));
			Assert.IsTrue(result.Assets[2].GetAttribute(nameAttribute).Value.ToString().EndsWith("3"));
		}

		[TestMethod]
		public void QueryPaging()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query paging", contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 1");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 2");
			services.Save(newStory);
			newStory = services.New(storyType, contextId);
			newStory.SetAttributeValue(nameAttribute, name + " 3");
			services.Save(newStory);

			System.Threading.Thread.Sleep(10000);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			var attributeSelection = new AttributeSelection(nameAttribute);
			query.Find = new QueryFind(name, attributeSelection);
			query.Paging = new Paging(0, 2);
            query.NeedTotal = true;
            var result = services.Retrieve(query);

			Assert.IsTrue(result.Assets.Count == 2);
            Assert.IsTrue(result.TotalAvaliable == 3);
		}

        [TestMethod]
		public void QueryHistory()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query history", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			newStory.SetAttributeValue(nameAttribute, name + " - updated");
			services.Save(newStory);
			newStory.SetAttributeValue(nameAttribute, name + " - updated again");
			services.Save(newStory);

			var query = new Query(storyType, true);
			query.Selection.Add(nameAttribute);
			var filterTerm = new FilterTerm(storyType.GetAttributeDefinition("ID"));
			filterTerm.Equal(newStory.Oid.Momentless);
			query.Filter = filterTerm;
			var result = services.Retrieve(query);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Assets.Count == 3);
		}

		[TestMethod]
		public void QueryAsof()
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query asof", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);
			System.Threading.Thread.Sleep(10000);
			newStory.SetAttributeValue(nameAttribute, name + " - updated");
			services.Save(newStory);
			newStory.SetAttributeValue(nameAttribute, name + " - updated again");
			services.Save(newStory);

			var query = new Query(storyType);
			query.Selection.Add(nameAttribute);
			query.AsOf = DateTime.Now.AddMilliseconds(-3500);
			var result = services.Retrieve(query);

			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, result.TotalAvaliable);
		}

		[TestMethod]
		[DeploymentItem("versionone.png")]
		public void QueryAttachment()
		{
			var services = GetServices();
			string file = "versionone.png";

			Assert.IsTrue(File.Exists(file));

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Query attachment", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var attachmentOid = services.SaveAttachment(file, newStory, "Test Attachment on " + newStory.Oid);

			IAssetType attachmentType = services.Meta.GetAssetType("Attachment");
			IAttributeDefinition attachmentFilename = attachmentType.GetAttributeDefinition("Filename");
			var query = new Query(attachmentOid);
			query.Selection.Add(attachmentFilename);
			var attachment = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(attachment);
			var fileNameValue = attachment.GetAttribute(attachmentFilename).Value;
			Assert.IsNotNull(fileNameValue);

			Directory.CreateDirectory("C:\\temp\\attachments");
			using (var fileStream = File.Create("C:\\temp\\attachments\\" + fileNameValue))
			{
				using (var s = services.GetAttachment(attachmentOid))
				{
					s.Seek(0, SeekOrigin.Begin);
					s.CopyTo(fileStream);
				}
			}

			Assert.IsTrue(File.Exists("C:\\temp\\attachments\\" + fileNameValue));
		}

		[TestMethod]
		[DeploymentItem("versionone.png")]
		public void QueryEmbeddedImage()
		{
			var services = GetServices();
			string file = "versionone.png";

			Assert.IsTrue(File.Exists(file));

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var descriptionAttribute = storyType.GetAttributeDefinition("Description");
			var name = string.Format("Test Story {0} Create story with embedded image", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			newStory.SetAttributeValue(descriptionAttribute, "Test description");
			services.Save(newStory);

			var embeddedImageOid = services.SaveEmbeddedImage(file, newStory);
			var embeddedImageTag = string.Format("<img src=\"{0}\" alt=\"\" data-oid=\"{1}\" />", "embedded.img/" + embeddedImageOid.Key,
				embeddedImageOid.Momentless);
			newStory.SetAttributeValue(descriptionAttribute, embeddedImageTag);
			services.Save(newStory);

			IAssetType embeddedImageType = services.Meta.GetAssetType("EmbeddedImage");
			IAttributeDefinition attachmentContentType = embeddedImageType.GetAttributeDefinition("ContentType");
			var query = new Query(embeddedImageType);
			query.Selection.Add(attachmentContentType);
			var embeddedImage = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(embeddedImage);
			var fileNameValue = "embeddedImage" + embeddedImageOid.Momentless.Key + new FileInfo(file).Extension;
			Assert.IsNotNull(fileNameValue);

			Directory.CreateDirectory("C:\\temp\\embedded");
			using (var fileStream = File.Create("C:\\temp\\embedded\\" + fileNameValue))
			{
				using (var s = services.GetEmbeddedImage(embeddedImageOid))
				{
					s.Seek(0, SeekOrigin.Begin);
					s.CopyTo(fileStream);
				}
			}

			Assert.IsTrue(File.Exists("C:\\temp\\embedded\\" + fileNameValue));
		}

		#endregion

		#region Operations

		[TestMethod]
		public void OperationDeleteOnEpic()
		{
			var services = GetServices();
			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var epicType = services.Meta.GetAssetType("Epic");
			var newEpic = services.New(epicType, contextId);
			var nameAttribute = epicType.GetAttributeDefinition("Name");
			var name = string.Format("Test Epic {0} Create epic", contextId);
			newEpic.SetAttributeValue(nameAttribute, name);
			services.Save(newEpic);

			var deletedEpicId = services.ExecuteOperation(epicType.GetOperation("Delete"), newEpic.Oid);
			var query = new Query(deletedEpicId.Momentless);
			query.Selection.Add(nameAttribute);

			Assert.IsTrue(services.Retrieve(query).Assets.Count == 0);
		}

		[TestMethod]
		[ExpectedException(typeof(OidException))]
		public void OperationDeleteUnknownAsset()
		{
			var services = GetServices();
			var deleteUnknown = services.ExecuteOperation(services.Meta.GetOperation("Delete"), services.GetOid("unknown:007"));
		}

		[TestMethod]
		public void OperationCloseOnStory()
		{
			var services = GetServices();
			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Create story", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var closedStoryId = services.ExecuteOperation(storyType.GetOperation("Inactivate"), newStory.Oid);
			var query = new Query(closedStoryId);
			var isClosedAttr = storyType.GetAttributeDefinition("IsClosed");
			query.Selection.Add(isClosedAttr);
			var story = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(story);
			Assert.IsTrue(Boolean.Parse(story.GetAttribute(isClosedAttr).Value.ToString()));
		}

		[TestMethod]
		public void OperationReopenOnStory()
		{
			var services = GetServices();
			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var storyType = services.Meta.GetAssetType("Story");
			var newStory = services.New(storyType, contextId);
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var name = string.Format("Test Story {0} Create story", contextId);
			newStory.SetAttributeValue(nameAttribute, name);
			services.Save(newStory);

			var closedStoryId = services.ExecuteOperation(storyType.GetOperation("Inactivate"), newStory.Oid);
			var query = new Query(closedStoryId);
			var isClosedAttr = storyType.GetAttributeDefinition("IsClosed");
			query.Selection.Add(isClosedAttr);
			var story = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(story);
			Assert.IsTrue(Boolean.Parse(story.GetAttribute(isClosedAttr).Value.ToString()));

			var reopenedId = services.ExecuteOperation(storyType.GetOperation("Reactivate"), closedStoryId);
			query = new Query(reopenedId);
			query.Selection.Add(isClosedAttr);
			story = services.Retrieve(query).Assets[0];

			Assert.IsNotNull(story);
			Assert.IsFalse(Boolean.Parse(story.GetAttribute(isClosedAttr).Value.ToString()));
		}

		#endregion

		#region Localization

		[TestMethod]
		public void LocStoryNameAndEstimate()
		{
			var services = GetServices();

			var storyType = services.Meta.GetAssetType("Story");
			var nameAttribute = storyType.GetAttributeDefinition("Name");
			var estimateAttribute = storyType.GetAttributeDefinition("Estimate");

			var locDict = services.Localization(nameAttribute, estimateAttribute);
			Assert.IsTrue(locDict.Keys.Count > 0);
			var locName = locDict[nameAttribute.Token];
			Assert.IsTrue(!string.IsNullOrWhiteSpace(locName));
			var locEstimate = locDict[estimateAttribute.Token];
			Assert.IsTrue(!string.IsNullOrWhiteSpace(locEstimate));
		}

		[TestMethod]
		public void LocEpicName()
		{
			var services = GetServices();

			var epicType = services.Meta.GetAssetType("Epic");
			var nameAttribute = epicType.GetAttributeDefinition("Name");

			var locName = services.Localization(nameAttribute);
			Assert.IsTrue(!string.IsNullOrWhiteSpace(locName));
		}

		#endregion

		#region Config

		[TestMethod]
		public void GetConfig()
		{
			var connector = V1Connector
				.WithInstanceUrl(_v1InstanceUrl)
				.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
				.WithAccessToken(_v1AccessToken)
				.Build();
			var configuration = new V1Configuration(connector);

			Assert.IsNotNull(configuration.EffortTracking);
			Assert.IsNotNull(configuration.StoryTrackingLevel);
			Assert.IsNotNull(configuration.DefectTrackingLevel);
			Assert.IsNotNull(configuration.MaxAttachmentSize);
			Assert.IsNotNull(configuration.CapacityPlanning);
		}

		#endregion

		#region Query.v1

		[TestMethod]
		public void ExecuteSingleJsonQuery()
		{
			var services = GetServices();

			var jsonQuery =
				"{" +
				"  \"from\": \"Story\"," +
				"  \"select\": [\"Name\",\"Estimate\"]," +
				"  \"filter\": [\"Name='StoryName'|Estimate>'0'\"]" +
				"}";

			var res = services.ExecutePassThroughQuery(jsonQuery);
			var stories = JArray.Parse(res).First;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"].Value<double>();

				Assert.IsTrue(storyName.Equals("StoryName") || storyEstimate > 0);
			}
		}

		[TestMethod]
		public void ExecuteSingleYamlQuery()
		{
			var services = GetServices();

			var yaml = "from: Story\n" +
					   "select:\n" +
					   "  - Name\n" +
					   "  - Estimate\n" +
					   "filter:\n" +
					   "  - Name='StoryName'|Estimate>'0'";

			var res = services.ExecutePassThroughQuery(yaml);
			var stories = JArray.Parse(res).First;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"].Value<double>();

				Assert.IsTrue(storyName.Equals("StoryName") || storyEstimate > 0);
			}
		}

		[TestMethod]
		public void ExecuteMultipleJsonQuery()
		{
			var services = GetServices();

			var json =
				"[" +
				" {" +
				"    \"from\": \"Story\"," +
				"    \"select\": [\"Name\",\"Estimate\"]," +
				"    \"filter\": [\"Name='StoryName'|Estimate>'0'\"]" +
				" }," +
				" {" +
				"    \"from\": \"Member\"," +
				"    \"select\": [\"Name\"]" +
				" }" +
				"]";

			var res = services.ExecutePassThroughQuery(json);
			var stories = JArray.Parse(res).First;
			var members = JArray.Parse(res).Last;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"].Value<double>();

				Assert.IsTrue(storyName.Equals("StoryName") || storyEstimate > 0);
			}

			foreach (var member in members)
			{
				var memberName = member["Name"].Value<string>();

				Assert.IsTrue(!string.IsNullOrWhiteSpace(memberName));
			}
		}

		[TestMethod]
		public void ExecuteMultipleYamlQuery()
		{
			var services = GetServices();

			var yaml = "  - from: Story\n" +
					   "    select:\n" +
					   "      - Name\n" +
					   "      - Estimate\n" +
					   "    filter:\n" +
					   "      - Name='StoryName'|Estimate>'0'\n" +
					   "  - from: Member\n" +
					   "    select:\n" +
					   "      - Name";

			var res = services.ExecutePassThroughQuery(yaml);
			var stories = JArray.Parse(res).First;
			var members = JArray.Parse(res).Last;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"].Value<double>();

				Assert.IsTrue(storyName.Equals("StoryName") || storyEstimate > 0);
			}

			foreach (var member in members)
			{
				var memberName = member["Name"].Value<string>();

				Assert.IsTrue(!string.IsNullOrWhiteSpace(memberName));
			}
		}

		[TestMethod]
		public void ExecuteSubSelectJsonQuery()
		{
			var services = GetServices();

			var json =
				"{" +
				"   \"from\": \"Story\"," +
				"   \"select\": [\"Name\",\"Estimate\", " +
				"                {\"from\": \"Owners\", " +
				"                 \"select\": [\"Name\", \"Nickname\"]" +
				"                }" +
				"               ]}";

			var res = services.ExecutePassThroughQuery(json);
			var stories = JArray.Parse(res).First;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"];
				var storyOwners = story["Owners"];

				Assert.IsTrue(!string.IsNullOrWhiteSpace(storyName));
				Assert.IsNotNull(storyEstimate);
				Assert.IsNotNull(storyOwners);
				foreach (var owner in storyOwners)
				{
					Assert.IsTrue(!string.IsNullOrWhiteSpace(owner["Name"].Value<string>()));
					Assert.IsTrue(!string.IsNullOrWhiteSpace(owner["Nickname"].Value<string>()));
				}

			}
		}

		[TestMethod]
		public void ExecuteSubSelectYamlQuery()
		{
			var services = GetServices();

			var yaml = "  - from: Story\n" +
					   "    select:\n" +
					   "      - Name\n" +
					   "      - Estimate\n" +
					   "      - from: Owners\n" +
					   "        select:\n" +
					   "          - Name\n" +
					   "          - Nickname\n";

			var res = services.ExecutePassThroughQuery(yaml);
			var stories = JArray.Parse(res).First;

			foreach (var story in stories)
			{
				var storyName = story["Name"].Value<string>();
				var storyEstimate = story["Estimate"];
				var storyOwners = story["Owners"];

				Assert.IsTrue(!string.IsNullOrWhiteSpace(storyName));
				Assert.IsNotNull(storyEstimate);
				Assert.IsNotNull(storyOwners);
				foreach (var owner in storyOwners)
				{
					Assert.IsTrue(!string.IsNullOrWhiteSpace(owner["Name"].Value<string>()));
					Assert.IsTrue(!string.IsNullOrWhiteSpace(owner["Nickname"].Value<string>()));
				}

			}
		}

		[TestMethod]
		public void ExecuteGroupJsonQuery()
		{
			var services = GetServices();

			var json =
				"{" +
				   "\"from\": \"Story\"," +
				   "\"select\": [" +
					   "\"Name\", \"Number\" " +
					 "]," +
				   "\"group\": [" +
					  "{" +
						"\"from\": \"Status\"," +
						"\"select\": [" +
							"\"Name\"" +
						 "]" +
					  "}" +
				   "]" +
				"}";

			var res = services.ExecutePassThroughQuery(json);
			var groups = JArray.Parse(res).First;

			foreach (var group in groups)
			{
				Assert.IsTrue(group["_children"].Values<object>().Any());
			}
		}

		[TestMethod]
		public void ExecuteGroupYamlQuery()
		{
			var services = GetServices();

			var yaml = "  - from: Story\n" +
					   "    select:\n" +
					   "      - Name\n" +
					   "      - Number\n" +
					   "    group:\n" +
					   "      - from: Status\n" +
					   "        select:\n" +
					   "          - Name\n";

			var res = services.ExecutePassThroughQuery(yaml);
			var groups = JArray.Parse(res).First;

			foreach (var group in groups)
			{
				Assert.IsTrue(group["_children"].Values<object>().Any());
			}
		}

		[TestMethod]
		[ExpectedException(typeof(WebException))]
		public void MalformedJsonQuery()
		{
			var services = GetServices();

			var json =
				"{" +
				"  \"from\": \"Story\"," +
				"  \"select\": \"Name\",\"Estimate\"," +
				"  \"filter\": [\"Name='StoryName'|Estimate>'0'\"" +
				"}";

			var res = services.ExecutePassThroughQuery(json);
		}

		[TestMethod]
		[ExpectedException(typeof(WebException))]
		public void MalformedYamlQuery()
		{
			var services = GetServices();

			var yaml = "from: Story\n" +
					   "   select:\n" +
					   "   Name\n" +
					   "  - Estimate\n" +
					   "filter:\n" +
					   "- Name='StoryName'|Estimate>'0'";

			var res = services.ExecutePassThroughQuery(yaml);

		}
		#endregion

		private IServices GetServices()
		{
			V1Connector connector;
			if (_useOAuthEndpoints)
			{
				connector = V1Connector
					.WithInstanceUrl(_v1InstanceUrl)
					.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
					.WithAccessToken(_v1AccessToken)
					.UseOAuthEndpoints()
					.Build();
			}
			else
			{
				connector = V1Connector
					.WithInstanceUrl(_v1InstanceUrl)
					.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
					.WithAccessToken(_v1AccessToken)
					.Build();
			}
			IServices services = new Services(connector);

			return services;
		}
	}
}
