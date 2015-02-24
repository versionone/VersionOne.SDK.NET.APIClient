namespace VersionOne.SDK.APIClient
{
    public class V1QueryURLBuilder: CompositeBuilder {
        private readonly Query query;

        public V1QueryURLBuilder(Query query)
        {
            this.query = query;

            Builders.Add(new V1HierarchicalPartBuilder());
            Builders.Add(new SelectionBuilder());
            Builders.Add(new WhereBuilder());
            Builders.Add(new SortBuilder());
            Builders.Add(new PagingBuilder());
            Builders.Add(new AsOfBuilder());
            Builders.Add(new FindBuilder());
            Builders.Add(new WithVariablesBuilder());
        }

        public override string ToString() {
            return Build(query, new BuildResult()).ToUrl();
        }
    }
}
