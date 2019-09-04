using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.Assets
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private Func<string, IList<IAsset>> _executor = null;
		private readonly QuerySpec _querySpec;

		public FluentQueryBuilder(string from, Func<string, IList<IAsset>> executor)
		{
			_querySpec = new QuerySpec();
			if (string.IsNullOrWhiteSpace(from))
			{
				throw new ArgumentNullException(nameof(from));
			}
			if (executor == null)
			{
				throw new ArgumentNullException(nameof(executor));
			}
			_executor = executor;
			_querySpec.From = from;
		}

		public IFluentQueryBuilder Select(params object[] fields)
		{
			_querySpec.Select.AddRange(fields);

			return this;
		}

		public IFluentQueryBuilder Where(string attributeName, string matchValue)
		{
			_querySpec.Where.Add(new Criterion(attributeName, ComparisonOperator.Equal, matchValue));

			return this;
		}

		public IFluentQueryBuilder Where(params Term[] criteria)
		{
			_querySpec.Where.AddRange(criteria);

			return this;
		}

		public IFluentQueryBuilder Filter(string attributeName, string op, object filterValue)
		{
			var oper = ComparisonOperator.GetOperator(op);

			return Filter(attributeName, oper, filterValue);
		}

		public IFluentQueryBuilder Filter(string attributeName, ComparisonOperator op, object filterValue)
		{
			_querySpec.Where.Add(new Criterion(attributeName, op, filterValue));

			return this;
		}

		// Alias for a Where, basically...
		// TODO jg: maybe this is just confusing
		public IFluentQueryBuilder Filter(params Term[] criteria) => Where(criteria);

		public IFluentQueryBuilder Paging(int pageSize, int pageStart = 0)
		{
			_querySpec.PageSize = pageSize;
			_querySpec.PageStart = pageStart;

			return this;
		}

		public override string ToString() => _querySpec.ToString();

		public IList<IAsset> Retrieve()
		{
			var payload = ToString();
			return _executor(payload);
		}

		public IAsset RetrieveFirst()
		{
			var uri = ToString();
			var results = _executor(uri);
			if (results.Count > 0) return results[0];
			return null;
		}
	}
}