using Newtonsoft.Json.Linq;

namespace VersionOne.Assets
{
	public class ExecuteOperationApiBuilder : QueryApiQueryBuilder
	{
		private string Operation { get; set; }

		public ExecuteOperationApiBuilder(QueryApiQueryBuilder querySpec, string operation)
			: base(querySpec.From)
		{
			Operation = operation;
			Where(querySpec.WhereCriteria.ToArray());
			Filter(querySpec.FilterCriteria.ToArray());
		}

		protected override JObject Build()
		{
			var rootNode = base.Build();
			rootNode.Add("execute", Operation);

			return rootNode;
		}
	}

}
