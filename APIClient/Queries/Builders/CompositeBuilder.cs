using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.Queries.Builders {
    public abstract class CompositeBuilder : IQueryBuilder {
        public readonly IList<IQueryBuilder> Builders = new List<IQueryBuilder>();

        public BuildResult Build(Query query, BuildResult result) {
            foreach (var builder in Builders) {
                builder.Build(query, result);
            }

            return result;
        }
    }
}