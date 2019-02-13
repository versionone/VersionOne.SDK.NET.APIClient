namespace VersionOne.Assets
{
	public static class ComparisonFunctions
	{
		public static Criterion Equal(string expression, params object[] matchValues) => new Criterion(expression, ComparisonOperator.Equal, matchValues);
		public static Term NotEqual(string expression, object matchValue) => new Criterion(expression, ComparisonOperator.NotEqual, matchValue);
		public static Term LessThan(string expression, object matchValue) => new Criterion(expression, ComparisonOperator.LessThan, matchValue);
		public static Term LessThanOrEqual(string expression, object matchValue) => new Criterion(expression, ComparisonOperator.LessThanOrEqual, matchValue);
		public static Term GreaterThan(string expression, object matchValue) => new Criterion(expression, ComparisonOperator.GreaterThan, matchValue);
		public static Term GreaterThanOrEqual(string expression, object matchValue) => new Criterion(expression, ComparisonOperator.GreaterThanOrEqual, matchValue);
		public static Term Exists(string expression) => new Criterion(expression, ComparisonOperator.Exists);
		public static Term NotExists(string expression) => new Criterion(expression, ComparisonOperator.NotExists);
		// TEMP HACK
		public static Term Or(params Term[] criteria) => new OrTerm(criteria);
		public static Term And(params Term[] criteria) => new AndTerm(criteria);
	}
}
