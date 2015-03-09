namespace VersionOne.SDK.APIClient.Queries {
    public class OrFilterTerm : GroupFilterTerm {
        public OrFilterTerm(params IFilterTerm[] terms) : base(terms) {}

        protected override string TokenSeperator {
            get { return "|"; }
        }
    }
}