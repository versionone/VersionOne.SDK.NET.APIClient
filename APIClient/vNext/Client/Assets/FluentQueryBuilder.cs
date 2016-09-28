using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.Assets
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		public readonly List<object> SelectFields = new List<object>();
		public readonly List<WhereCriterion> WhereCriteria = new List<WhereCriterion>();
		public readonly List<string> FilterTokens = new List<string>();
		public int PageSize = -1;
		public int PageStart = -1;
		private readonly string _assetTypeName = string.Empty;
		private string _id = string.Empty;
		private Func<string, IList<IAssetBase>> _executor = null;

		public FluentQueryBuilder(string assetTypeName, Func<string, IList<IAssetBase>> executor)
		{
			if (string.IsNullOrWhiteSpace(assetTypeName))
			{
				throw new ArgumentNullException("assetTypeName");
			}
			if (executor == null)
			{
				throw new ArgumentNullException("executor");
			}
			_executor = executor;
			_assetTypeName = assetTypeName;
		}

		public IFluentQueryBuilder Id(object id)
		{
			if (id == null) throw new ArgumentNullException("id");
			var val = id.ToString();

			if (string.IsNullOrWhiteSpace(val))
			{
				throw new ArgumentNullException("id", "id.ToString() must return a non-empty string");
			}
			_id = val;

			return this;
		}

		public IFluentQueryBuilder Select(params object[] fields)
		{
			SelectFields.AddRange(fields);

			return this;
		}

		public IFluentQueryBuilder Where(string attributeName, string matchValue)
		{
			WhereCriteria.Add(new WhereCriterion
			{
				AttributeName = attributeName,
				Operator = ComparisonOperator.Equal,
				MatchValue = matchValue
			});

			return this;
		}

		public IFluentQueryBuilder Where(params WhereCriterion[] criteria)
		{
			WhereCriteria.AddRange(criteria);

			return this;
		}

		public IFluentQueryBuilder Filter(string attributeName, string op, object filterValue)
		{
			var oper = ComparisonOperator.GetOperator(op);

			return Filter(attributeName, oper, filterValue);
		}

		public IFluentQueryBuilder Filter(string attributeName, ComparisonOperator op, object filterValue)
		{
			WhereCriteria.Add(new WhereCriterion
			{
				AttributeName = attributeName,
				Operator = op,
				MatchValue = filterValue
			});

			return this;
		}

		// Alias for a Where, basically...
		// TODO jg: maybe this is just confusing
		public IFluentQueryBuilder Filter(params WhereCriterion[] criteria) => Where(criteria);

		public IFluentQueryBuilder Filter(params string[] filterTokens)
		{
			FilterTokens.AddRange(filterTokens);
			return this;
		}

		public IFluentQueryBuilder Paging(int pageSize, int pageStart = 0)
		{
			PageSize = pageSize;
			PageStart = pageStart;

			return this;
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			var query = new StringBuilder();

			if (SelectFields.Count > 0)
			{
				var selectFragment = String.Join(",", SelectFields);
				query.Append("sel=" + Uri.EscapeDataString(selectFragment));
			}

			if (WhereCriteria.Count > 0)
			{
				var encodedCriteria = WhereCriteria.Select(w => w.ToQueryStringParameter());

				var whereFragment = String.Join(";", encodedCriteria);

				if (query.Length > 0)
				{
					query.Append("&");
				}
				query.Append("where=" + whereFragment);
			}

			if (PageSize != -1 && PageStart != -1)
			{
				if (query.Length > 0)
				{
					query.Append("&");
				}
				query.Append(string.Format("page={0},{1}", PageSize, PageStart));
			}

			builder.Append("/" + _assetTypeName);

			if (!string.IsNullOrWhiteSpace(_id))
			{
				builder.Append("/" + _id);
			}

			if (query.Length > 0)
			{
				builder.Append("?" + query);
			}

			return builder.ToString();
		}

		public IList<IAssetBase> Retrieve()
		{
			var uri = this.ToString();
			return _executor(uri);
		}

		public IAssetBase RetrieveFirst()
		{
			var uri = this.ToString();
			var results = _executor(uri);
			if (results.Count > 0) return results[0];
			return null;
		}
	}
}