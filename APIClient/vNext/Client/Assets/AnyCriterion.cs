using System;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
	public class AnyCriterion : Term
	{
		private List<object> _matchValues = new List<object>();
		private string _attributeName;
		private ComparisonOperator _op;

		public AnyCriterion(string  attributeName, ComparisonOperator op, params object[] matchValues)
		{
			_attributeName = attributeName;
			_op = op;
			_matchValues.AddRange(matchValues);
		}

		public override string ToQueryStringParameter()
		{
			var encodedList = _matchValues.Select(s => $"'{Uri.EscapeDataString(s.ToString())}'");
			var encodedCriteria = string.Join(",", encodedList);

			return $"{_attributeName}{_op.Token}{encodedCriteria}";
		}
	}
}