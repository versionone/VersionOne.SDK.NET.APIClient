namespace VersionOne.SDK.APIClient {
    public class FindBuilder : QueryBuilder {
        protected override void DoBuild(Query query, BuildResult result) {
            if (query.Find != null && !string.IsNullOrEmpty(query.Find.Text)) {
                result.QuerystringParts.Add("find=\"" + query.Find.Text + "\"");

                if (query.Find.Attributes.Count > 0) {
                    result.QuerystringParts.Add("findin=" + query.Find.Attributes.Token);
                }
            }
        }
    }
}