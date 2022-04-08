namespace VersionOne.SDK.APIClient
{
    public class NeedTotalBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {
            if (query.NeedTotal)
            {
                result.QuerystringParts.Add("needTotal=true");
            }
        }
    }
}