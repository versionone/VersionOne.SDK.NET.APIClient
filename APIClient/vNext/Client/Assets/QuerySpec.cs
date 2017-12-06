using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionOne.Assets
{
	public class QuerySpec
	{
		public string AssetTypeName { get; set; } = string.Empty;
		public string Id { get; set; } = string.Empty;
		public readonly List<object> Select = new List<object>();
		public readonly List<Term> Where = new List<Term>();
		public readonly List<string> Filter = new List<string>();
		public int PageSize { get; set; } = -1;
		public int PageStart { get; set; } = -1;

		public override string ToString()
		{
			var builder = new StringBuilder();
			var query = new StringBuilder();

			ApplyAssetTypeName(builder);
			MaybeApplyOidToken(builder);

			MaybeApplySelections(query);
			MaybeApplyWhere(query);
			MaybeApplyPaging(query);

			MaybeApplyQuery(query, builder);

			return builder.ToString();
		}

		private void ApplyAssetTypeName(StringBuilder builder)
		{
			builder.Append($"{AssetTypeName}");
		}

		private void MaybeApplyOidToken(StringBuilder builder)
		{
			if (string.IsNullOrWhiteSpace(Id)) return;

			var oidParts = Id.Split(':');
			if (oidParts.Length < 2)
				throw new InvalidOperationException(
					$"Id must contain an oidToken in the correct format, for example Story:12345, but contained: {Id}");
			builder.Append($"/{oidParts[1]}");
		}

		private void MaybeApplySelections(StringBuilder query)
		{
			if (Select.Count <= 0) return;
			var selectFragment = string.Join(",", Select);
			query.Append($"sel={Uri.EscapeDataString(selectFragment)}");
		}

		private void MaybeApplyWhere(StringBuilder query)
		{
			if (Where.Count <= 0) return;

			var encodedTerms = Where.Select(w => w.ToQueryStringParameter());

			var whereFragment = string.Join(";", encodedTerms);

			if (query.Length > 0)
			{
				query.Append("&");
			}

			query.Append($"where={whereFragment}");
		}

		private void MaybeApplyPaging(StringBuilder query)
		{
			if (PageSize == -1 || PageStart == -1) return;
			if (query.Length > 0)
			{
				query.Append("&");
			}
			query.Append($"page={PageSize},{PageStart}");
		}

		private static void MaybeApplyQuery(StringBuilder query, StringBuilder builder)
		{
			if (query.Length <= 0) return;
			builder.Append("?" + query);
		}
	}
}