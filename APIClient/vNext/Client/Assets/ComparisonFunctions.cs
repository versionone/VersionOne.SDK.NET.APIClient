namespace VersionOne.Assets
{
	public static class ComparisonFunctions
	{
		public static WhereCriterion Equal(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.Equal, MatchValue = matchValue };
		public static WhereCriterion NotEqual(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.NotEqual, MatchValue = matchValue };
		public static WhereCriterion LessThan(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.LessThan, MatchValue = matchValue };
		public static WhereCriterion LessThanOrEqual(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.LessThanOrEqual, MatchValue = matchValue };
		public static WhereCriterion GreaterThan(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.GreaterThan, MatchValue = matchValue };
		public static WhereCriterion GreaterThanOrEqual(string expression, object matchValue) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.GreaterThanOrEqual, MatchValue = matchValue };
		public static WhereCriterion Exists(string expression) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.Exists, MatchValue = WhereCriterion.MatchNotApplicable };
		public static WhereCriterion NotExists(string expression) => new WhereCriterion { AttributeName = expression, Operator = ComparisonOperator.NotExists, MatchValue = WhereCriterion.MatchNotApplicable };
		// TEMP HACK
		public static WhereCriterion Or(params WhereCriterion[] criteria) => new OrCriterion(criteria);
	}
}
