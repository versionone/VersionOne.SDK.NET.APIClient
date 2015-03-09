using VersionOne.SDK.APIClient.Utils;

namespace VersionOne.SDK.APIClient.Queries.Builders {
    public class WithVariablesBuilder : QueryBuilder {
        protected override void DoBuild(Query query, BuildResult result) {
            if(query.Variables != null && query.Variables.Count > 0) {
                result.QuerystringParts.Add("with=" + TextBuilder.Join(query.Variables, ";", v => v.ToString()));
            }
        }
    }
}