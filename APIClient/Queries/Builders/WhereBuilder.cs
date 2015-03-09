namespace VersionOne.SDK.APIClient.Queries.Builders {
    public class WhereBuilder : QueryBuilder {
        protected override void DoBuild(Query query, BuildResult result) {
            var filtertoken = query.Filter.Token;

            if (filtertoken != null) {
                result.QuerystringParts.Add("where=" + filtertoken);
            }
        }
    }
}