using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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
		public static IAsset Asset(string assetTypeName, object attributes = null) => new Asset(assetTypeName, attributes);
		public static IAsset Asset(params (string name, object value)[] attributes) => new Asset(Attributes(attributes));
		public static IAsset Asset(string assetTypeName, params (string name, object value)[] attributes) =>
			Asset(assetTypeName, Attributes(attributes));
        public static List<IAsset> Assets() => new List<IAsset>();
		public static List<IAsset> Assets(params IAsset[] assets) => new List<IAsset>(assets);
		public static IDictionary<string, object> Attributes(params (string name, object value)[] attributes) =>
			attributes.ToDictionary(n => n.name, v => v.value);
		public static Array Relations(params object[] relations) => relations;
        public static Array Relation(object relation) => new[] { relation };
        public static object Add(string oidToken) => new AssetReference { idref = oidToken, act = "add" };
        public static object Add(string assetType, int id) => new AssetReference { idref = $"{assetType}:{id}", act = "add" };
        public static object Remove(string oidToken) => new AssetReference { idref = oidToken, act = "remove" };
        public static object Remove(string assetType, int id) => new AssetReference { idref = $"{assetType}:{id}", act = "remove" };
        public static QueryApiQueryBuilder From(string from) => new QueryApiQueryBuilder(from);
    }
}
