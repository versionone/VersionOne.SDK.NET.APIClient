using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class Member : TypedAssetClass
    {
        public enum Fields
        {
            Name,
            Email
        }

        public Member()
        {
            AssetBasePrefix = "Member";
        }

        public Member(Asset wrapped)
            : base(wrapped)
        {
            AssetBasePrefix = "Member";
        }

        public override AssetClassBase Create(Asset wrapped)
        {
            return new Member(wrapped);
        }
    }
}