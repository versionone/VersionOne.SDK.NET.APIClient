namespace VersionOne.SDK.APIClient
{
    public class SortBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {
            if (query.OrderBy.Count > 0)
            {
                result.QuerystringParts.Add("sort=" + query.OrderBy.Token);
            }
        }
    }
}