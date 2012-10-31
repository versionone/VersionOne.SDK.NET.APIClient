using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class Query<T> where T : AssetClassBase, new()
    {
        public IEnumerable<T> Execute(string token, object[] selectFields)
        {
            var oid = Oid.FromToken(token, MetaModelProvider.Meta);

            var emptyObj = new T();

            var query = new Query(oid);

            var attributes = new List<IAttributeDefinition>(selectFields.Length);
            attributes.AddRange(selectFields.Select(emptyObj.GetAttribute));
            query.Selection.AddRange(attributes);

            var list = new List<T>();

            var result = ServicesProvider.Services.Retrieve(query);

            if (result.Assets.Count == 0)
            {
                return list;
            }

            list.AddRange(result.Assets.Select(emptyObj.Create).Select(asssetObject => asssetObject).Cast<dynamic>().Cast<T>());

            return list;
        }
    }
}