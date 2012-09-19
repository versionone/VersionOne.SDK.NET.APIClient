namespace VersionOne.SDK.APIClient {
    public enum AssetState : byte {
        Future = 0,
        Active = 64,
        Closed = 128,
        Dead = 192,
        Deleted = 255,
    }
}