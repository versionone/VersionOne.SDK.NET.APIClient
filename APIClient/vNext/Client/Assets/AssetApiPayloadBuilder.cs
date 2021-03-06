﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.Assets
{
    public static class AssetApiPayloadBuilder
    {
		public static string Build(string oid, object attributes)
		{
			return JObject.FromObject(new
			{
				from = oid,
				update = attributes
			}).ToString();
		}

        private static Update GetUpdateAttribute(JProperty prop)
        {
            var propValueType = prop.Value.Type;
            if (propValueType == JTokenType.Object || propValueType == JTokenType.Array)
            {
                return CreateRelationUpdate(prop);
            }
            else
            {
                return CreateSetScalarUpdateAttribute(prop);
            }
        }

        private static Update CreateRelationUpdate(JProperty prop)
        {
            var value = prop.Value;
            var propValueType = value.Type;

            var items = new List<object>();
                        
            if (propValueType == JTokenType.Array)
            {
                foreach (var item in value)
                {
                    if (item.Type == JTokenType.String)
                    {
                        items.Add(new AssetReference
                        {
                            idref = item.Value<string>(),
                            act = "add"
                        });
                    }
                    else
                    {
                        items.Add(item);
                    }
                }
            }
            else
            {
                items.Add(value);
            }

            value = JArray.FromObject(items);

            return new Update
            {
                name = prop.Name,
                value = value
            };
        }

        private static UpdateAttribute CreateSetScalarUpdateAttribute(JProperty prop) => new UpdateAttribute
        {
            act = "set",
            name = prop.Name,
            value = prop.Value
        };
    }
}
