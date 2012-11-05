using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public abstract class TypedAssetClass : AssetClassBase
    {
        public TypedAssetClass()
        {
        }

        public TypedAssetClass(Asset wrapped) : base(wrapped)
        {
        }

        public abstract AssetClassBase Create(Asset wrapped);
    }
}