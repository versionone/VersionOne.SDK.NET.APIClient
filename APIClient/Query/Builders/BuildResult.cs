using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient {
    public class BuildResult {
        public readonly ICollection<string> QuerystringParts = new List<string>();
        public readonly ICollection<string> PathParts = new List<string>();

        public string ToUrl() {
            var path = TextBuilder.Join(PathParts.ToArray(), "/");
            var querystring = TextBuilder.Join(QuerystringParts.ToArray(), "&");

            return string.Concat(path, querystring != null ? "?" + querystring : string.Empty);
        }
    }
}