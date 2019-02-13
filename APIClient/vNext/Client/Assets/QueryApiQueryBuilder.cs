using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
	public class QueryApiQueryBuilder
	{
		public readonly List<object> SelectFields = new List<object>();
		public readonly List<Term> WhereCriteria = new List<Term>();
		public readonly List<Criterion> FilterCriteria = new List<Criterion>();
		private readonly string _from = string.Empty;
		protected internal string From { get => _from; }
		public int? PageSize { get; set; }
		public int? PageStart { get; set; }

		public QueryApiQueryBuilder(string from)
		{
			if (string.IsNullOrWhiteSpace(from))
			{
				throw new ArgumentNullException(nameof(from));
			}
			_from = from;
		}

		public QueryApiQueryBuilder Select(params object[] fields)
		{
			SelectFields.AddRange(fields);

			return this;
		}

		public QueryApiQueryBuilder Where(string attributeName, string matchValue)
		{
			WhereCriteria.Add(new Criterion(attributeName, ComparisonOperator.Equal, matchValue));

			return this;
		}

		public QueryApiQueryBuilder Where(params Term[] criteria)
		{
			WhereCriteria.AddRange(criteria);

			return this;
		}

		public QueryApiQueryBuilder Filter(string attributeName, string op, object filterValue)
		{
			var oper = ComparisonOperator.GetOperator(op);

			return Filter(attributeName, oper, filterValue);
		}

		public QueryApiQueryBuilder Filter(string attributeName, ComparisonOperator op, object filterValue)
		{
			FilterCriteria.Add(new Criterion(attributeName, op, filterValue));

			return this;
		}

		public QueryApiQueryBuilder Filter(params Criterion[] criteria)
		{
			FilterCriteria.AddRange(criteria);

			return this;
		}

		public QueryApiQueryBuilder Filter(string attributeName, Func<string, object, Criterion> operatorFunc, object filterValue)
		{
			var result = operatorFunc(attributeName, filterValue);
			FilterCriteria.Add(result);

			return this;
		}

		public override string ToString() => Build().ToString();
	
		protected virtual JObject Build()
		{
			var root = new JObject
			{
				{ "from", _from }
			};

			if (SelectFields.Count > 0)
			{
				var select = new JArray();

				var attributes = SelectFields.Where(s => s is string);
				foreach (var attr in attributes)
				{
					var val = attr as string;
					select.Add(val);
				}

				var nestedBuilders = SelectFields.Where(s => s is QueryApiQueryBuilder);
				foreach (var item in nestedBuilders)
				{
					var nestedBuilder = item as QueryApiQueryBuilder;
					select.Add(nestedBuilder.Build());
				}
				
				if (select.Count > 0)
					root.Add("select", select);
			}

			var filterNodes = new JArray();

			if (WhereCriteria.Count > 0)
			{
				var whereNodes = new JObject();

				ProcessWhereCriteria(filterNodes, whereNodes);

				root.Add("where", whereNodes);
			}

			if (FilterCriteria.Count > 0)
			{
				foreach (var criterion in FilterCriteria)
				{
					filterNodes.Add($"{criterion.AttributeName}{criterion.Operator.Token}\"{criterion.MatchValue.ToString()}\"");
				}
			}

			if (filterNodes.Count > 0)
			{
				root.Add("filter", filterNodes);
			}

			if (!PageSize.HasValue || !PageStart.HasValue) return root;
			else
			{
				var page = new JObject
				{
					{ "size", PageSize.ToString() },
					{ "start", PageStart.ToString() }
				};
				root.Add("page", page);
			}

			return root;
		}

		private (JArray filterNodes, JObject whereNodes) ProcessWhereCriteria(List<Term> whereCriteria)
		{
			var filterNodes = new JArray();
			var whereNodes = new JObject();

			foreach (var term in WhereCriteria)
			{
				switch (term)
				{
					case Criterion criterion:
						switch (criterion.IsMultiMatch)
						{
							case true:
								var matchValues = String.Join(",", criterion.MatchValues.Select(m => $"\"{m}\""));
								filterNodes.Add($"{criterion.AttributeName}{criterion.Operator.Token}{matchValues}");
								break;
							case false:
								whereNodes.Add(criterion.AttributeName, criterion.MatchValue.ToString());
								break;
						}
						break;
					case OrTerm or: // VERY Stuck here... Maybe .Where should never support "Or" and "And" because of its 
									// simply nature, and only .Filter should.
									// If that's the case, then we could get by with stuffing everything into filterNodes, simply
									// mapping the false case above into its equavilent filter syntax.
//from: StoryStatus
//select:
//-Name
//filter:
//-Name = "In Progress","Future" | Name != "Future"
						var combined =
						foreach (var orTerm in or.Terms)
						{
							var result = ProcessWhereCriteria(new List<Term>() { orTerm });
							// TODO this seems really messed up...
							
						}

						break;
					default:
						break;

				}
				if (criterion a is Criterion and a.IsMultiMatch)
					{

				}
					else
					{
					whereNodes.Add(criterion.AttributeName, criterion.MatchValue.ToString());
				}
			}
		}
	}
}
