using System;
using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public class FluentQuery
    {
        public Query RawQuery { get; set; }
        public string AssetTypeName { get; set; }
        public List<Tuple<string, object, FilterTerm.Operator>> WhereCriteria { get; set; }
        public List<object> SelectFields { get; set; }
        public Action<IEnumerable<AssetClassBase>> OnSuccess { get; set; }
        public Action<Exception> OnError { get; set; }

        public FluentQuery(
            string assetTypeName)
        {
            RawQuery = new Query(MetaModelProvider.Meta.GetAssetType(assetTypeName));
            AssetTypeName = assetTypeName;

            WhereCriteria = new List<Tuple<string, object, FilterTerm.Operator>>();
            SelectFields = new List<object>();
        }

        public FluentQuery Where(params Tuple<string, object, FilterTerm.Operator>[] criteria)
        {
            WhereCriteria.AddRange(criteria);

            return this;
        }

        public FluentQuery Select(params object[] fields)
        {
            SelectFields.AddRange(fields);

            return this;
        }

        public FluentQuery Success(Action<IEnumerable<AssetClassBase>> callback)
        {
            OnSuccess = callback;

            return this;
        }

        public FluentQuery Error(Action<Exception> callback)
        {
            OnError = callback;

            return this;
        }

        public FluentQuery Execute()
        {
            if (OnSuccess == null)
            {
                throw new NullReferenceException("Must specify the OnSuccess callback property before calling Execute");
            }

            if (OnError == null)
            {
                throw new NullReferenceException("Must specify the OnError callback property before calling Execute");
            }

            try
            {
                var attributes = new List<IAttributeDefinition>();

                if (SelectFields.Count > 0)
                {
                    attributes.AddRange(
                        SelectFields.Select(
                            m => MetaModelProvider.Meta.GetAttributeDefinition(AssetTypeName
                                + "." + m.ToString())));
                }
                RawQuery.Selection.AddRange(attributes);

                if (WhereCriteria.Count > 0)
                {
                    var andTerms = new List<FilterTerm>();

                    foreach (var tuple in WhereCriteria)
                    {
                        var attribute = MetaModelProvider.Meta.GetAttributeDefinition(AssetTypeName
                                                                                      + "." + tuple.Item1);
                        var item = tuple.Item2;
                        var term = new FilterTerm(attribute);
                        term.Operate(tuple.Item3, item);
                        andTerms.Add(term);
                    }

                    var andTerm = new AndFilterTerm(andTerms.ToArray());
                    RawQuery.Filter = andTerm;
                }

                var list = new List<AssetClassBase>();

                var result = ServicesProvider.Services.Retrieve(RawQuery);

                if (result.Assets.Count == 0)
                {
                    OnSuccess(list);
                }

                list.AddRange(result.Assets.Select(a => new AssetClassBase(a, AssetTypeName)));

                OnSuccess(list);
            }
            catch (Exception exception)
            {
                OnError(exception);
            }

            return this;
        }
    }
}