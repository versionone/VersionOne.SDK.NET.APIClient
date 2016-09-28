namespace VersionOne.Assets
{
	public interface IAssetBase : IOidToken
	{
		string AssetTypeName { get; }
		object Attributes { get; }
		void AddRelatedAsset(string relationName, IAssetBase asset);
		object this[string attributeName] { get; set; }
	}
}