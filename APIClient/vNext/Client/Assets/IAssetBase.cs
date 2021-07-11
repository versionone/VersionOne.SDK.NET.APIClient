namespace VersionOne.Assets
{
	public interface IAsset
	{
		string Oid { get; }
		string AssetTypeName { get; }
		object Attributes { get; }
		void AddRelatedAsset(string relationName, IAsset asset);
		object this[string attributeName] { get; set; }
	}
}