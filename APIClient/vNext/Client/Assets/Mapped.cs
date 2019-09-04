using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace VersionOne.Assets
{
    public class MapAttribute : Attribute
    {
        public String Name { get; set; }

        public MapAttribute(string path)
        {
            Name = path;
        }

        public static string GetMappedPathForProperty<T>(string propertyName)
        {
            // TODO cache the mappings per type
            var mappings = GetMappings<T>();

            if (mappings.ContainsValue(propertyName))
            {
                foreach (var mapping in mappings)
                {
                    if (mapping.Value.Equals(propertyName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return mapping.Key;
                    }
                }
            }

            return propertyName;
        }

        public static Dictionary<string, string> GetMappings<T>()
        {
            var mappings = new Dictionary<string, string>();

            var type = typeof (T);

            // For when you are fetching a list of results:
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                var genericTypes = type.GetGenericArguments();
                if (genericTypes.Length > 0)
                {
                    type = genericTypes[0];
                }
            }

            foreach (var prop in type.GetProperties())
            {
                foreach (MapAttribute attr in
                    prop.GetCustomAttributes(typeof(MapAttribute), false))
                {
                    if (!mappings.ContainsKey(attr.Name))
                    {
                        mappings.Add(attr.Name, prop.Name);
                    }
                    else
                    {
                        throw new DuplicateNameException(string.Format(
                            "Cannot map attribute name {0} to property name {1} because it is already mapped to a property named {2} on type {3}", 
                            attr.Name, 
                            prop.Name,
                            mappings[attr.Name],
                            type.FullName));
                    }
                }
            }

            return mappings;
        }
    }
}
