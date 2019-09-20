using System;
using System.Collections.Generic;

namespace VersionOne.Assets
{
	public class ComparisonOperator
	{
		public string Token { get; set; }
		public string Name { get; set; }

		public ComparisonOperator(string name, string token)
		{
			Name = name;
			Token = token;
		}

		private static ComparisonOperator Create(string left, string right) => new ComparisonOperator(left, right);

		public static readonly ComparisonOperator Equal = Create(ComparisonOperatorConstants.Equal, ComparisonOperatorConstants.EqualToken);
		public static readonly ComparisonOperator NotEqual = Create(ComparisonOperatorConstants.NotEqual, ComparisonOperatorConstants.NotEqualToken);
		public static readonly ComparisonOperator LessThan = Create(ComparisonOperatorConstants.LessThan, ComparisonOperatorConstants.LessThanToken);
		public static readonly ComparisonOperator LessThanOrEqual = Create(ComparisonOperatorConstants.LessThanOrEqual, ComparisonOperatorConstants.LessThanOrEqualToken);
		public static readonly ComparisonOperator GreaterThan = Create(ComparisonOperatorConstants.GreaterThan, ComparisonOperatorConstants.GreaterThanToken);
		public static readonly ComparisonOperator GreaterThanOrEqual = Create(ComparisonOperatorConstants.GreaterThanOrEqual, ComparisonOperatorConstants.GreaterThanOrEqualToken);
		public static readonly ComparisonOperator Exists = Create(ComparisonOperatorConstants.Exists, ComparisonOperatorConstants.ExistsToken);
		public static readonly ComparisonOperator NotExists = Create(ComparisonOperatorConstants.NotExists, ComparisonOperatorConstants.NotExistsToken);

		private static Dictionary<string, ComparisonOperator> _operatorsMap =
			new Dictionary<string, ComparisonOperator>()
				{
					{ComparisonOperatorConstants.Equal, Equal},
					{ComparisonOperatorConstants.EqualToken, Equal},
					{ComparisonOperatorConstants.NotEqual, NotEqual},
					{ComparisonOperatorConstants.NotEqualToken, NotEqual},
					{ComparisonOperatorConstants.LessThan, LessThan},
					{ComparisonOperatorConstants.LessThanToken, LessThan},
					{ComparisonOperatorConstants.LessThanOrEqual, LessThanOrEqual},
					{ComparisonOperatorConstants.LessThanOrEqualToken, LessThanOrEqual},
					{ComparisonOperatorConstants.GreaterThan, GreaterThan},
					{ComparisonOperatorConstants.GreaterThanToken, GreaterThan},
					{ComparisonOperatorConstants.GreaterThanOrEqual, GreaterThanOrEqual},
					{ComparisonOperatorConstants.GreaterThanOrEqualToken, GreaterThanOrEqual},
					{ComparisonOperatorConstants.Exists, Exists},
					{ComparisonOperatorConstants.ExistsToken, Exists},
					{ComparisonOperatorConstants.NotExists, NotExists},
					{ComparisonOperatorConstants.NotExistsToken, NotExists},
				};

		public static ComparisonOperator GetOperator(string op)
		{
			if (_operatorsMap.ContainsKey(op))
			{
				return _operatorsMap[op];
			}

			throw new ArgumentException(string.Format("Could not find an operator by name or token for the supplied parameter: {0}", op));
		}
	}
}