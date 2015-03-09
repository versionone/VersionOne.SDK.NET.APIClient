namespace VersionOne.SDK.APIClient.Queries.Builders {
    public abstract class QueryBuilder : IQueryBuilder {
        public BuildResult Build(Query query, BuildResult result) {
            DoBuild(query, result);
            return result;
        }

        protected abstract void DoBuild(Query query, BuildResult result);
    }
}