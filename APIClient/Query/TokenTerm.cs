namespace VersionOne.SDK.APIClient
{
    public class TokenTerm : IFilterTerm
    {
        private readonly string token;

        public TokenTerm(string token)
        {
            this.token = token;
        }

        public string Token
        {
            get { return token; }
        }

        public string ShortToken
        {
            get { return token; }
        }
    }
}