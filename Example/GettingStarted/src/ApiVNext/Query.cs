using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class Query<T> where T : AssetClassBase, new()
    {
        public T Execute(string token, object[] selectFields)
        {
            var oid = Oid.FromToken(token, MetaModelProvider.Meta);

            var emptyObj = new T();

            var query = new Query(oid);

            var attributes = new List<IAttributeDefinition>(selectFields.Length);
            attributes.AddRange(selectFields.Select(emptyObj.GetAttribute));
            query.Selection.AddRange(attributes);

            var result = ServicesProvider.Services.Retrieve(query);

            if (result.Assets.Count == 0)
            {
                return null; // or maybe return emptyObj or a new empty instance?
            }

            dynamic assetObject = emptyObj.Create(result.Assets[0]);

            return (T) assetObject;
        }
    }
}