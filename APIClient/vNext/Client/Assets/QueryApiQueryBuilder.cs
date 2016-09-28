using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace VersionOne.Assets
{
    public class QueryApiQueryBuilder
    {
        public readonly List<object> SelectFields = new List<object>();
        public readonly List<WhereCriterion> WhereCriteria = new List<WhereCriterion>();
        public readonly List<WhereCriterion> FilterCriteria = new List<WhereCriterion>();
        private readonly string _assetType = string.Empty;

        public QueryApiQueryBuilder(string assetType)
        {
            if (string.IsNullOrWhiteSpace(assetType))
            {
                throw new ArgumentNullException("assetType");
            }
            _assetType = assetType;
        }

        public QueryApiQueryBuilder Select(params object[] fields)
        {
            SelectFields.AddRange(fields);

            return this;
        }

        public QueryApiQueryBuilder Where(string attributeName, string matchValue)
        {
            WhereCriteria.Add(new WhereCriterion
            {
                AttributeName = attributeName,
                Operator = ComparisonOperator.Equal,
                MatchValue = matchValue
            });

            return this;
        }

        public QueryApiQueryBuilder Where(params WhereCriterion[] criteria) { 
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
            FilterCriteria.Add(new WhereCriterion
            {
                AttributeName = attributeName,
                Operator = op,
                MatchValue = filterValue
            });

            return this;
        }

        public QueryApiQueryBuilder Filter(params WhereCriterion[] criteria)
        {
            FilterCriteria.AddRange(criteria);

            return this;
        }

        public QueryApiQueryBuilder Filter(string attributeName, Func<string, object, WhereCriterion> operatorFunc, object filterValue)
        {
            var result = operatorFunc(attributeName, filterValue);
            FilterCriteria.Add(result);

            return this;
        }

        public override string ToString()
        {
            var nodes = Build();

            var doc = new YamlDocument(nodes);
            var stream = new YamlStream(doc);

            String output = string.Empty;
            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                stream.Save(writer, false);
                output = sb.ToString();
            }

            return output;
        }

        private YamlNode Build()
        {
            var root = new YamlMappingNode();

            root.Add("from", _assetType);

            if (SelectFields.Count > 0)
            {
                var select = new YamlSequenceNode();

                var attributes = SelectFields.Where(s => s is string);
                foreach(var attr in attributes)
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

                root.Add("select", select);
            }

            if (WhereCriteria.Count > 0)
            {
                var whereNodes = new YamlMappingNode();

                foreach (var criterion in WhereCriteria)
                {
                    whereNodes.Add(criterion.AttributeName, criterion.MatchValue.ToString());
                }

                root.Add("where", whereNodes);
            }

            if (FilterCriteria.Count > 0)
            {
                var filterNodes = new YamlSequenceNode();

                foreach (var criterion in FilterCriteria)
                {
                    filterNodes.Add($"{criterion.AttributeName}{criterion.Operator.Token}\"{criterion.MatchValue.ToString()}\"");
                }

                root.Add("filter", filterNodes);
            }

            return root;
        }
    }
}
