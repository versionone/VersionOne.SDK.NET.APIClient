namespace VersionOne.SDK.APIClient
{
    public class OrFilterTerm : GroupFilterTerm
    {
        public OrFilterTerm(params IFilterTerm[] terms) : base(terms) { }

        protected override string TokenSeperator
        {
            get { return "|"; }
        }
    }
}