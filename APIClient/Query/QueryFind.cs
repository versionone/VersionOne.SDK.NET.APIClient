namespace VersionOne.SDK.APIClient {
    public class QueryFind {
        public readonly string Text;
        public readonly AttributeSelection Attributes;

        public QueryFind(string text) : this(text, new AttributeSelection()) {}

        public QueryFind(string text, AttributeSelection sel) {
            Text = text;
            Attributes = sel;
        }
    }
}