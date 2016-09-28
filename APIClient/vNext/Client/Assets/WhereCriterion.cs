using System;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
	public class WhereCriterion
	{
		public string AttributeName { get; set; }
		public ComparisonOperator Operator { get; set; }
		public object MatchValue { get; set; }

		public class MatchNotApplicableMatch
		{
			// Marker class to indicate that this is a unary criterion
		}

		public static MatchNotApplicableMatch MatchNotApplicable = new WhereCriterion.MatchNotApplicableMatch();

		public bool IsUnary
		{
			get
			{
				return MatchValue == MatchNotApplicable;
			}
		}

		public virtual string ToQueryStringParameter()
		{
			var encoded = string.Empty;

			if (IsUnary)
			{
				encoded = Operator.Token + AttributeName;
			}
			else
			{
				encoded = AttributeName + Operator.Token + "'" + Uri.EscapeDataString(MatchValue.ToString()) + "'";
			}

			return encoded;
		}
}

	public class CompoundCriterion : WhereCriterion
	{
	}

	public class OrCriterion : CompoundCriterion
	{
		private List<WhereCriterion> _criteria = new List<WhereCriterion>();

		public OrCriterion(params WhereCriterion[] criteria)
		{
			_criteria.AddRange(criteria);
		}

		public override string ToQueryStringParameter()
		{
			var encodedCriteria = _criteria.Select(c => c.ToQueryStringParameter());

			return string.Join("|", encodedCriteria);
		}
	}

}