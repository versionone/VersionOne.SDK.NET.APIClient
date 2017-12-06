using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.Assets
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private Func<string, IList<IAssetBase>> _executor = null;
		private readonly QuerySpec _querySpec;

		public FluentQueryBuilder(string assetSource, Func<string, IList<IAssetBase>> executor)
		{
			// TODO this is a little weird the way the split occurs again in the ToString()
			string assetTypeName;
			_querySpec = new QuerySpec();
			if (assetSource.IndexOf(':') > -1)
			{
				var oidTokenParts = assetSource.Split(':');
				assetTypeName = oidTokenParts[0];
				_querySpec.Id = assetSource;
			}
			else
			{
				assetTypeName = assetSource;
			}
			if (string.IsNullOrWhiteSpace(assetTypeName))
			{
				throw new ArgumentNullException("assetTypeName");
			}
			if (executor == null)
			{
				throw new ArgumentNullException("executor");
			}
			_executor = executor;
			_querySpec.AssetTypeName = assetTypeName;
		}

		public IFluentQueryBuilder Id(object id)
		{
			if (id == null) throw new ArgumentNullException("id");
			var val = id.ToString();

			if (string.IsNullOrWhiteSpace(val))
			{
				throw new ArgumentNullException("id", "id.ToString() must return a non-empty string");
			}
			_querySpec.Id = val;

			return this;
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

		public override string ToString() => $"/{_querySpec}";

		public IList<IAssetBase> Retrieve()
		{
			var uri = ToString();
			return _executor(uri);
		}

		public IAssetBase RetrieveFirst()
		{
			var uri = ToString();
			var results = _executor(uri);
			if (results.Count > 0) return results[0];
			return null;
		}
	}
}