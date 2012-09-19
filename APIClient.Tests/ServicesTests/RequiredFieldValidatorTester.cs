using System.Collections.Generic;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests {
	[TestFixture]
	public class RequiredFieldValidatorTester : ServicesTesterBase {
		protected override string ServicesTestKeys {
			get { return "RequiredFieldValidatorTester"; }
		}

		private const string TitleAttributeName = "Name";
		private const string ParentAttributeName = "Parent";
		private const string DefectTypeName = "Defect";

		private RequiredFieldValidator validator;

		[SetUp]
		public void SetUp() {
			IServices services = new Services(Meta, DataConnector);
			validator = new RequiredFieldValidator(Meta, services);
		}

		[Test]
		public void LoadRequiredFields() {
			Asset asset = new Asset(AssetType(DefectTypeName));
			IAttributeDefinition defectNameDef = asset.AssetType.GetAttributeDefinition(TitleAttributeName);
			Assert.IsTrue(validator.IsRequired(defectNameDef));

			IAttributeDefinition defectParentDef = asset.AssetType.GetAttributeDefinition(ParentAttributeName);
			Assert.IsFalse(validator.IsRequired(defectParentDef));
		}

		[Test]
		public void ValidateSingleFieldByName() {
			IAssetType defectType = AssetType(DefectTypeName);

			Assert.IsTrue(validator.IsRequired(defectType, TitleAttributeName));
			Assert.IsFalse(validator.IsRequired(defectType, ParentAttributeName));
		}

		[Test]
		public void ValidateSingleFieldByAttribute() {
			Asset asset = new Asset(AssetType(DefectTypeName));
			IAttributeDefinition defectNameDef = asset.AssetType.GetAttributeDefinition(TitleAttributeName);
			Assert.IsFalse(validator.Validate(asset, defectNameDef));

			asset.LoadAttributeValue(defectNameDef, "Valid defect name");
			Assert.IsTrue(validator.Validate(asset, defectNameDef));
		}

		[Test]
		public void ValidateAssetFailureNotLoadedRequiredAttribute() {
			Asset asset = new Asset(AssetType(DefectTypeName));
			ICollection<IAttributeDefinition> invalidAttributes = validator.Validate(asset);
			Assert.AreEqual(invalidAttributes.Count, 1);
		}

		[Test]
		public void ValidateAssetFailureWrongAttributeValue() {
			Asset asset = GetDefectWithLoadedName(string.Empty);

			ICollection<IAttributeDefinition> invalidAttributes = validator.Validate(asset);
			Assert.AreEqual(invalidAttributes.Count, 1);

			asset = GetDefectWithLoadedName(null);

			invalidAttributes = validator.Validate(asset);
			Assert.AreEqual(invalidAttributes.Count, 1);
		}

		[Test]
		public void ValidateAssetSuccess() {
			Asset asset = GetDefectWithLoadedName("Valid Defect name");

			ICollection<IAttributeDefinition> invalidAttributes = validator.Validate(asset);
			Assert.AreEqual(invalidAttributes.Count, 0);
		}

		[Test]
		public void ValidateAssetCollectionFailure() {
			Asset[] assetsToValidate = new Asset[]
										   {
											   GetDefectWithLoadedName("One"),
											   GetDefectWithLoadedName(string.Empty),
											   GetDefectWithLoadedName("Two"),
										   };

			IDictionary<Asset, ICollection<IAttributeDefinition>> results = validator.Validate(assetsToValidate);

			Assert.AreEqual(results.Count, 3);
			Assert.AreEqual(results[assetsToValidate[0]].Count, 0);
			Assert.AreEqual(results[assetsToValidate[1]].Count, 1);
			Assert.AreEqual(results[assetsToValidate[2]].Count, 0);

			Asset invalidAsset = assetsToValidate[1];
			ICollection<IAttributeDefinition> secondAssetResults = results[invalidAsset];
			IAttributeDefinition defectNameDef = invalidAsset.AssetType.GetAttributeDefinition(TitleAttributeName);
			Assert.IsTrue(secondAssetResults.Contains(defectNameDef));
		}

		[Test]
		public void ValidateAssetCollectionSuccess() {
			Asset[] assetsToValidate = new Asset[]
										   {
											   GetDefectWithLoadedName("One"),
											   GetDefectWithLoadedName("Two"),
											   GetDefectWithLoadedName("Three"),
										   };

			IDictionary<Asset, ICollection<IAttributeDefinition>> results = validator.Validate(assetsToValidate);

			Assert.AreEqual(results.Count, 3);
			Assert.AreEqual(results[assetsToValidate[0]].Count, 0);
			Assert.AreEqual(results[assetsToValidate[1]].Count, 0);
			Assert.AreEqual(results[assetsToValidate[2]].Count, 0);
		}

		private Asset GetDefectWithLoadedName(string name) {
			Asset asset = new Asset(AssetType(DefectTypeName));
			IAttributeDefinition defectNameDef = asset.AssetType.GetAttributeDefinition(TitleAttributeName);
			asset.LoadAttributeValue(defectNameDef, name);

			return asset;
		}
	}
}