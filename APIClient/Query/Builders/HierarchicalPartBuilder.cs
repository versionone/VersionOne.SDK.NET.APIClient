namespace VersionOne.SDK.APIClient.Evolved
{
    public class HierarchicalPartBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {
            result.PathParts.Add(query.AssetType.Token);

            if (!query.Oid.IsNull)
            {
                result.PathParts.Add(query.Oid.Key.ToString());
            }

            if (query.Oid.HasMoment)
            {
                result.PathParts.Add(query.Oid.Moment.ToString());
            }
        }
    }
}
