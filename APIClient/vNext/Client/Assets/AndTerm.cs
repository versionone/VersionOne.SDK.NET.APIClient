using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
	public class AndTerm : Term
	{
		private List<Term> _terms = new List<Term>();

		public AndTerm(params Term[] criteria)
		{
			_terms.AddRange(criteria);
		}

		public override string ToQueryStringParameter()
		{
			var encodedTerms = _terms.Select(c => c.ToQueryStringParameter());

			return $"({string.Join(";", encodedTerms)})";
		}
	}
}