using System;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient
{
    public class FluentQuery
    {
        private IMetaModel metaModel;
        private IServices services;
        public Query RawQuery { get; set; }
        public string AssetTypeName { get; set; }
        public List<Tuple<string, object, FilterTerm.Operator>> WhereCriteria { get; set; }
        public List<object> SelectFields { get; set; }
        public Action<IEnumerable<Asset>> OnSuccess { get; set; }
        public Action OnEmptyResults { get; set; }
        public Action<Exception> OnError { get; set; }

        public FluentQuery(
            string assetTypeName, IMetaModel metaModel, IServices services)
        {
            this.metaModel = metaModel;
            this.services = services;
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

        public FluentQuery Success(Action<IEnumerable<Asset>> callback)
        {
            OnSuccess = callback;

            return this;
        }

        public FluentQuery WhenEmpty(Action callback)
        {
            OnEmptyResults = callback;

            return this;
        }

        public FluentQuery Error(Action<Exception> callback)
        {
            OnError = callback;

            return this;
        }

        public FluentQuery Execute(Action<IEnumerable<Asset>> successCallback = null)
        {
            if (OnSuccess == null && successCallback == null)
            {
                throw new NullReferenceException("Must specify the OnSuccess callback before calling Execute or pass it directly to Execute as a parameter");
            }

            try
            {
                QueryResult result = RetrieveQueryResult();

                if (result.Assets.Count == 0)
                {
                    OnSuccess?.Invoke(result.Assets);
                }

                result.Assets.ForEach(a => a.Configure(AssetTypeName, metaModel, services));

                if (result.Assets.Count == 0)
                {
                    OnEmptyResults?.Invoke();
                }

                if (successCallback != null)
                {
                    successCallback(result.Assets);
                }
                else
                {
                    OnSuccess(result.Assets);
                }
            }
            catch (Exception exception)
            {
                if (OnError != null)
                {
                    OnError(exception);
                }
                else
                {
                    throw;
                }
            }

            return this;
        }

        private QueryResult RetrieveQueryResult()
        {
            RawQuery = new Query(metaModel.GetAssetType(AssetTypeName));

            var attributes = new List<IAttributeDefinition>();

            if (SelectFields.Count > 0)
            {
                attributes.AddRange(
                    SelectFields.Select(
                        m => metaModel.GetAttributeDefinition(AssetTypeName
                            + "." + m.ToString())));
            }
            RawQuery.Selection.AddRange(attributes);

            if (WhereCriteria.Count > 0)
            {
                var andTerms = new List<FilterTerm>();

                foreach (var tuple in WhereCriteria)
                {
                    var attribute = metaModel.GetAttributeDefinition(AssetTypeName
                        + "." + tuple.Item1);
                    var item = tuple.Item2;
                    var term = new FilterTerm(attribute);
                    term.Operate(tuple.Item3, item);
                    andTerms.Add(term);
                }

                var andTerm = new AndFilterTerm(andTerms.ToArray());
                RawQuery.Filter = andTerm;
            }

            var result = services.Retrieve(RawQuery);
            return result;
        }

        public QueryResult Retrieve()
        {
            QueryResult result = null;
            try
            {
                result = RetrieveQueryResult();
            }
            catch (Exception exception)
            {
                if (OnError != null)
                {
                    OnError(exception);
                }
                else
                {
                    throw;
                }
            }
            return result;
        }
    }
}