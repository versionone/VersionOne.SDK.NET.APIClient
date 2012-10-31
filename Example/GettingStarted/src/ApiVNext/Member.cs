using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class Member : AssetClassBase
    {
        public enum Fields
        {
            Name,
            Email
        }

        public static string GetAssetBasePrefixName()
        {
            return "Member";
        }
        protected override string GetAssetBasePrefix()
        {
            return Member.GetAssetBasePrefixName();
        }

        public Member()
        {
        }

        public Member(Asset wrapped)
            : base(wrapped)
        {
        }

        public override AssetClassBase Create(Asset wrapped)
        {
            return new Member(wrapped);
        }
    }
}