using System;

namespace VersionOne.SDK.APIClient
{

    public enum AssetState : byte
    {
        Future = 0,
        Active = 64,
        Closed = 128,
        Dead = 192,
        Deleted = 255,
    }

    public static class AssetStateManager
    {

        public static AssetState GetAssetStateFromString(string assetState)
        {
            if (string.IsNullOrEmpty(assetState)) throw new ArgumentNullException("assetState");
            byte assetStateRaw;
            byte.TryParse(assetState, out assetStateRaw);
            return (AssetState)assetStateRaw;
        }

    }

}