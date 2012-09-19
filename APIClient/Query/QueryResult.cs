namespace VersionOne.SDK.APIClient {
    public class QueryResult {
        private readonly AssetList assets;
        private readonly int total;
        private readonly Query query;

        public AssetList Assets {
            get { return assets; }
        }

        public int TotalAvaliable {
            get { return total; }
        }

        public Query Query {
            get { return query; }
        }

        public QueryResult(AssetList assets, int total, Query query) {
            this.assets = assets;
            this.total = total;
            this.query = query;
        }
    }
}