using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class FreeQuery
    {
        //public void Execute(
        public FreeQuery(
            string assetTypeName,
            object[] select = null,
            Dictionary<string, object> where = null, 
            Action<IEnumerable<AssetClassBase>> success = null,
            Action<Exception> error = null
            )
        {
            if (success == null)
            {
                throw new ArgumentNullException("success");
            }

            if (error == null)
            {
                throw new ArgumentNullException("error");
            }

            try
            {
                var query = new Query(MetaModelProvider.Meta.GetAssetType(assetTypeName));

                var attributes = new List<IAttributeDefinition>();
                if (select != null)
                {
                    attributes.AddRange(
                        select.Select(
                            m => MetaModelProvider.Meta.GetAttributeDefinition(assetTypeName 
                                + "." + m.ToString())));
                }
                query.Selection.AddRange(attributes);

                if (where != null)
                {
                    var andTerms = new List<FilterTerm>();

                    foreach (var key in where.Keys)
                    {
                        var attribute = MetaModelProvider.Meta.GetAttributeDefinition(assetTypeName
                                                                                      + "." + key);
                        var item = where[key];
                        var term = new FilterTerm(attribute);
                        term.Equal(item);
                        andTerms.Add(term);
                    }

                    var andTerm = new AndFilterTerm(andTerms.ToArray());
                    query.Filter = andTerm;
                }

                var list = new List<AssetClassBase>();

                var result = ServicesProvider.Services.Retrieve(query);

                if (result.Assets.Count == 0)
                {
                    success(list);
                }

                list.AddRange(result.Assets.Select(a => new AssetClass(a, assetTypeName)));

                success(list);
            } catch (Exception exception)
            {
                error(exception);
            }

            //var task = new TaskFactory<List<AssetClassBase>>().StartNew(() =>
            //    {
            //        var result = ServicesProvider.Services.Retrieve(query);

            //        if (result.Assets.Count == 0)
            //        {
            //            return list;
            //        }

            //        list.AddRange(
            //            result.Assets.Select(
            //                a => new AssetClass(a, assetTypeName)));

            //        return list;
            //    });
        }
    }
}