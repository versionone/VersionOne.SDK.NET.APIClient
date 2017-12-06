using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
	public class OrTerm : Term
	{
		private List<Term> _terms = new List<Term>();

		public OrTerm(params Term[] terms)
		{
			_terms.AddRange(terms);
		}

		public override string ToQueryStringParameter()
		{
			var encodedTerms = _terms.Select(c => c.ToQueryStringParameter());

			return $"({string.Join("|", encodedTerms)})";
		}
	}
}