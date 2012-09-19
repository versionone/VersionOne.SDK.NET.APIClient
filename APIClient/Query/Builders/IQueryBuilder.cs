namespace VersionOne.SDK.APIClient {
    public interface IQueryBuilder {
        BuildResult Build(Query query, BuildResult result);
    }
}