namespace VersionOne.SDK.APIClient {
    public class NoOpTerm : IFilterTerm {
        public string Token {
            get { return null; }
        }

        public string ShortToken {
            get { return null; }
        }
    }
}