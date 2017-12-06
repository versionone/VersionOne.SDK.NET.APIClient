using System;

namespace VersionOne.Assets
{
	public class Criterion : Term
	{
		public string AttributeName { get; set; }
		public ComparisonOperator Operator { get; set; }
		public object MatchValue { get; set; }

		public Criterion(string attributeName, ComparisonOperator op, object matchValue)
		{
			AttributeName = attributeName;
			Operator = op;
			MatchValue = matchValue;
		}

		public Criterion(string attributeName, ComparisonOperator op) : this(attributeName, op, MatchNotApplicable)
		{
		}

		public class MatchNotApplicableMatch
		{
			// Marker class to indicate that this is a unary criterion
		}

		public static MatchNotApplicableMatch MatchNotApplicable = new MatchNotApplicableMatch();

		public bool IsUnary => MatchValue == MatchNotApplicable;

		public override string ToQueryStringParameter()
		{
			string encoded;

			if (IsUnary)
			{
				encoded = Operator.Token + AttributeName;
			}
			else
			{
				encoded = $"{AttributeName}{Operator.Token}\'{Uri.EscapeDataString(MatchValue.ToString())}\'";
			}

			return encoded;
		}
}
}