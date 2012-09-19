namespace VersionOne.SDK.APIClient {
    public class SelectionBuilder : QueryBuilder {
        protected override void DoBuild(Query query, BuildResult result) {
            if(query.ParentRelation != null) {
                query.Selection.Add(query.ParentRelation);
            }

            if(query.Selection.Count == 1 && !query.Oid.IsNull) {
                result.PathParts.Add(query.Selection[0].Name);
            } else if(query.Selection.Count > 0) {
                result.QuerystringParts.Add("sel=" + query.Selection.Token);
            } else {
                result.QuerystringParts.Add("sel=");
            }
        }
    }
}