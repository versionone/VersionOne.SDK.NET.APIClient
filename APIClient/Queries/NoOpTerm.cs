namespace VersionOne.SDK.APIClient.Queries {
    public class NoOpTerm : IFilterTerm {
        public string Token {
            get { return null; }
        }

        public string ShortToken {
            get { return null; }
        }
    }
}