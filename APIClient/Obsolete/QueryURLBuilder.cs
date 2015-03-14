using System;

namespace VersionOne.SDK.APIClient
{
    [Obsolete]
    public class QueryURLBuilder : CompositeBuilder
    {
        private readonly Query query;

        public QueryURLBuilder(Query query)
        {
            this.query = query;

            Builders.Add(new HierarchicalPartBuilder());
            Builders.Add(new SelectionBuilder());
            Builders.Add(new WhereBuilder());
            Builders.Add(new SortBuilder());
            Builders.Add(new PagingBuilder());
            Builders.Add(new AsOfBuilder());
            Builders.Add(new FindBuilder());
            Builders.Add(new WithVariablesBuilder());
        }

        public override string ToString()
        {
            return Build(query, new BuildResult()).ToUrl();
        }
    }
}