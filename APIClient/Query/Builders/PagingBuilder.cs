namespace VersionOne.SDK.APIClient
{
    public class PagingBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {
            if (query.Paging.Start != 0 || query.Paging.PageSize != int.MaxValue)
            {
                result.QuerystringParts.Add("page=" + query.Paging.Token);
            }
        }
    }
}