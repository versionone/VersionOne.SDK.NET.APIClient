namespace VersionOne.SDK.APIClient
{
    public class WhereBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {
            var filtertoken = query.Filter.Token;

            if (filtertoken != null)
            {
                result.QuerystringParts.Add("where=" + filtertoken);
            }
        }
    }
}