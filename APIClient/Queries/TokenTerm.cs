namespace VersionOne.SDK.APIClient.Queries {
    public class TokenTerm : IFilterTerm {
        private readonly string token;

        public TokenTerm(string token) {
            this.token = token;
        }

        public string Token {
            get { return token; }
        }

        public string ShortToken {
            get { return token; }
        }
    }
}