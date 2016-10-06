using Newtonsoft.Json.Linq;
using System;

namespace VersionOne.Assets
{
    internal class Update
    {
        public string name { get; set; }
        public object value { get; set; }
    }

    internal class UpdateAttribute : Update
    {
        public string act { get; set; }
    }

    internal class AssetReference
    {
        public string idref { get; set; }
        public string act { get; set; }
	}

	internal class AssetReferenceResponse
	{
		public AssetReferenceResponse(string idref, string href)
		{
			Idref = idref;
			Href = href;
		}
		public string Idref { get; set; }
		public string Href { get; set; }

		public override string ToString() => Idref;
	}

    public static class ClientUtilities
    {
        public static IAssetBase Asset(string assetTypeName, object attributes=null) => new AssetBase(assetTypeName, attributes);
        public static JArray Assets() => new JArray();
        public static Array Relations(params object[] relations) => relations;
        public static Array Relation(object relation) => new[] { relation };
        public static object Add(string oidToken) => new AssetReference { idref = oidToken, act = "add" };
        public static object Add(string assetType, int id) => new AssetReference { idref = $"{assetType}:{id}", act = "add" };
        public static object Remove(string oidToken) => new AssetReference { idref = oidToken, act = "remove" };
        public static object Remove(string assetType, int id) => new AssetReference { idref = $"{assetType}:{id}", act = "remove" };
        public static QueryApiQueryBuilder From(string assetSelectionExpression) => new QueryApiQueryBuilder(assetSelectionExpression);
    }
}
