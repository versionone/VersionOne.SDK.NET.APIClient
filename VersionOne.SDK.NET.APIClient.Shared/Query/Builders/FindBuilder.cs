using System;
using System.Web;

namespace VersionOne.SDK.APIClient
{
    public class FindBuilder : QueryBuilder
    {
        protected override void DoBuild(Query query, BuildResult result)
        {

            if (query == null || query.Find == null || string.IsNullOrEmpty(query.Find.Text)) return;

            var part = string.Concat("find=", HttpUtility.UrlEncode(query.Find.Text));
            result.QuerystringParts.Add(part);

            if (query.Find.Attributes == null || query.Find.Attributes.Count == 0 || string.IsNullOrEmpty(query.Find.Attributes.Token)) return;
            part = string.Concat("findin=", HttpUtility.UrlEncode(query.Find.Attributes.Token));
            result.QuerystringParts.Add(part);

        }
    }
}