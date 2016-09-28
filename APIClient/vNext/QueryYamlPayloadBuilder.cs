using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace VersionOne.Assets
{
    public static class QueryYamlPayloadBuilder
    {
        public static string Build(IAssetBase source)
        {
            var nodes = GetNodes(source);

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

        private static Tuple<string, YamlNode> GetUpdateAttribute(JProperty prop)
        {
            var propValueType = prop.Value.Type;
            var value = string.Empty;

            if (propValueType == JTokenType.Object || propValueType == JTokenType.Array)
            {
                if (propValueType == JTokenType.Array)
                {
                    var nodes = new YamlSequenceNode();
                    foreach(var item in prop.Value as JArray)
                    {
                        var asset = new AssetBase(item as dynamic);
                        var yamlNode = GetNodes(asset);
                        nodes.Add(yamlNode);
                    }
                    return new Tuple<string, YamlNode>(prop.Name, nodes);
                }                

                return new Tuple<string, YamlNode>(prop.Name, new YamlScalarNode(string.Empty));
            }
            else
            {
                value = (prop.Value as JValue).Value.ToString();
                return new Tuple<string, YamlNode>(prop.Name, new YamlScalarNode(value));
            }
        }

        public static YamlNode GetNodes(IAssetBase sourceAsset)
        {
			var source = sourceAsset as AssetBase; // TODO fix this up
            var root = new YamlMappingNode();
            var assetType = source.AssetTypeName;
            root.Add("asset", assetType);
            JObject obj = JObject.FromObject(source.GetChangesDto());
            obj.Remove("AssetType");

            YamlMappingNode attributes = new YamlMappingNode();

            var tuples = (from prop in
                            (
                                from token in JToken.FromObject(obj)
                                where token.Type == JTokenType.Property
                                select token as JProperty
                             )
                          select GetUpdateAttribute(prop)
                        );
            foreach (var tuple in tuples)
            {
                attributes.Add(tuple.Item1, tuple.Item2);
            }

            root.Add("attributes", attributes);

            return root;
        }

        //    if (SelectFields.Count > 0)
        //    {
        //        var select = new YamlSequenceNode();

        //        var attributes = SelectFields.Where(s => s is string);
        //        foreach (var attr in attributes)
        //        {
        //            var val = attr as string;
        //            select.Add(val);
        //        }

        //        var nestedBuilders = SelectFields.Where(s => s is QueryApiQueryBuilder);
        //        foreach (var item in nestedBuilders)
        //        {
        //            var nestedBuilder = item as QueryApiQueryBuilder;
        //            select.Add(nestedBuilder.Build());
        //        }

        //        root.Add("select", select);
        //    }

        //    if (WhereCriteria.Count > 0)
        //    {
        //        var whereNodes = new YamlMappingNode();

        //        foreach (var criterion in WhereCriteria)
        //        {
        //            whereNodes.Add(criterion.AttributeName, criterion.MatchValue.ToString());
        //        }

        //        root.Add("where", whereNodes);
        //    }

        //    if (FilterCriteria.Count > 0)
        //    {
        //        var filterNodes = new YamlSequenceNode();

        //        foreach (var criterion in FilterCriteria)
        //        {
        //            filterNodes.Add($"{criterion.AttributeName}{criterion.Operator.Token}\"{criterion.MatchValue.ToString()}\"");
        //        }

        //        root.Add("filter", filterNodes);
        //    }

        //    return root;
        //}
    }
}

