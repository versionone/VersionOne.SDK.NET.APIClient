namespace VersionOne.SDK.APIClient {
    public abstract class QueryBuilder : IQueryBuilder {
        public BuildResult Build(Query query, BuildResult result) {
            DoBuild(query, result);
            return result;
        }

        protected abstract void DoBuild(Query query, BuildResult result);
    }
}