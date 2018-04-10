using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.QueryTests
{
	public class UrlEncodingTester : MetaTesterBase
	{
		protected override string MetaTestKeys => "UrlEncodingTester";

		private IAssetType X => AssetType("X");
		private IAttributeDefinition Y => X.GetAttributeDefinition("Y");

		[Test] public void TokenTerms_are_encoded()
		{
			var query = new Query(X) {
				Filter = new TokenTerm("Y='Fish & Chips'")
			};
			var url = new QueryURLBuilder(query).ToString();
			Assert.AreEqual("Data/X?sel=&where=Y='Fish+%26+Chips'", url);
		}

		[Test] public void equal_FilterTerms_are_encoded()
		{
			var filter = new FilterTerm(Y);
			filter.Equal("Fish & Chips");

			var query = new Query(AssetType("X")) {
				Filter = filter
			};
			var url = new QueryURLBuilder(query).ToString();
			Assert.AreEqual("Data/X?sel=&where=X.Y='Fish+%26+Chips'", url);
		}

		[Test] public void exists_FilterTerms_are_encoded()
		{
			var filter = new FilterTerm(Y);
			filter.Exists();

			var query = new Query(AssetType("X")) {
				Filter = filter
			};
			var url = new QueryURLBuilder(query).ToString();
			Assert.AreEqual("Data/X?sel=&where=%2BX.Y", url);
		}
	}
}
