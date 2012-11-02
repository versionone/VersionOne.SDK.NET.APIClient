using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class AssetClass : AssetClassBase
    {
        public AssetClass(Asset wrapped, string basePrefix) : base(wrapped)
        {
            AssetBasePrefix = basePrefix;
        }
    }
}