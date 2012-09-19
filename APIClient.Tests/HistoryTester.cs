using System;
using NUnit.Framework;

namespace VersionOne.APIClient.Tests
{
	/// <summary>
	/// Maggie Created this to test her mods to the services class. It is dependent on the demo data
	/// </summary>
	[TestFixture]
	[Ignore("requires demo data")]
	public class HistoryTester
	{
		private string v1Url = "http://localhost/v1_newdemo";
		private string username = "admin";
		private string password = "admin";

		private string dataPath = "/rest-1.v1/";
		private string metaPath = "/meta.v1/";
		private string localizationPath = "/loc.v1/";

		private Services services;
		private MetaModel metaModel;
		private Localizer localizer;
		private IAssetType timeboxType;
		private IAttributeDefinition timeboxName;
		private IAttributeDefinition timeboxID;


		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			V1APIConnector dataConnector = new V1APIConnector(v1Url + dataPath, username, password);
			V1APIConnector metaConnector = new V1APIConnector(v1Url + metaPath);
			V1APIConnector localConnector = new V1APIConnector(v1Url + localizationPath);
			
			localizer = new Localizer(localConnector);
			metaModel = new MetaModel(metaConnector);
			services = new Services(metaModel, dataConnector);

			timeboxType = metaModel.GetAssetType("Timebox");
			timeboxName = timeboxType.GetAttributeDefinition("Name");
			timeboxID = timeboxType.GetAttributeDefinition("ID");
		}

		[Test]
		public void TestGetTimeboxHistory()
		{
			Query query = new Query(timeboxType, true);
			query.Selection.Add(timeboxName);
			query.Filter.Include(timeboxID, "Timebox:1025");
			QueryResult result = services.Retrieve(query);
			Assert.AreEqual(2, result.Assets.Count);
			Assert.AreEqual("Month C 1st Half", result.Assets[0].GetAttribute(timeboxName).Value);
			Assert.AreEqual("Month C 1st Half", result.Assets[1].GetAttribute(timeboxName).Value);
			Assert.AreEqual("Timebox:1025:126", result.Assets[0].Oid.ToString());
			Assert.AreEqual("Timebox:1025:599", result.Assets[1].Oid.ToString());
		}

		[Test]
		public void TestGetTimeboxHistoryAsOf()
		{
			Query query = new Query(timeboxType, true);
			query.Selection.Add(timeboxName);
			query.Filter.Include(timeboxID, "Timebox:1025");
			query.AsOf = DateTime.Parse("2006-10-28T23:59:59.00");
			QueryResult result = services.Retrieve(query);
			Assert.AreEqual(1, result.Assets.Count);
			Assert.AreEqual("Month C 1st Half", result.Assets[0].GetAttribute(timeboxName).Value);
		}

	}
}
