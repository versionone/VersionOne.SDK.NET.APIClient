namespace VersionOne.SDK.APIClient
{
    public class AndFilterTerm : GroupFilterTerm
    {
        public AndFilterTerm(params IFilterTerm[] terms) : base(terms) { }

        protected override string TokenSeperator
        {
            get { return ";"; }
        }
    }
}