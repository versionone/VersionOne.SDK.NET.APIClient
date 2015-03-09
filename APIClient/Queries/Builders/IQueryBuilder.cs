namespace VersionOne.SDK.APIClient.Queries.Builders {
    public interface IQueryBuilder {
        BuildResult Build(Query query, BuildResult result);
    }
}