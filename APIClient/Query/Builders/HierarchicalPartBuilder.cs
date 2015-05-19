namespace VersionOne.SDK.APIClient
{
    public class HierarchicalPartBuilder : QueryBuilder
    {
        private readonly bool _queryForV1Connector = false;

        public HierarchicalPartBuilder(bool queryForV1Connector = false)
        {
            _queryForV1Connector = queryForV1Connector;
        }

        protected override void DoBuild(Query query, BuildResult result)
        {
            if (!_queryForV1Connector)
                result.PathParts.Add(query.IsHistorical ? "Hist" : "Data");

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