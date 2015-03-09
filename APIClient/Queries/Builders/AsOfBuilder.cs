using System;

namespace VersionOne.SDK.APIClient.Queries.Builders {
    public class AsOfBuilder : QueryBuilder {
        protected override void DoBuild(Query query, BuildResult result) {
            if (query.AsOf.CompareTo(DateTime.MinValue) > 0) {
                result.QuerystringParts.Add("asof=" + query.AsOf.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
        }
    }
}