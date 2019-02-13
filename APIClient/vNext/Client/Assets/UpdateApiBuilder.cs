using Newtonsoft.Json.Linq;

namespace VersionOne.Assets
{
	public class UpdateApiBuilder : QueryApiQueryBuilder
	{
		private object UpdateAttributes { get; set; }

		public UpdateApiBuilder(QueryApiQueryBuilder querySpec, object updateAttributes)
			: base(querySpec.From)
		{
			UpdateAttributes = updateAttributes;
			Where(querySpec.WhereCriteria.ToArray());
			Filter(querySpec.FilterCriteria.ToArray());
		}

		protected override JObject Build()
		{
			var rootNode = base.Build();

			var updateAttributes = JObject.FromObject(UpdateAttributes);
			rootNode.Add("update", updateAttributes);

			return rootNode;
		}
	}

}
