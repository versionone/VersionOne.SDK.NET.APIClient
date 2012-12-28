namespace VersionOne.SDK.APIClient
{

    public interface ICredentials
    {
        string V1UserName { get; }
        string V1Password { get; }
    }

    public sealed class Credentials : ICredentials
    {

        public Credentials()
        {
            V1UserName = "admin";
            V1Password = "admin";
        }

        public string V1UserName { get; private set; }
        public string V1Password { get; private set; }
    }
}
