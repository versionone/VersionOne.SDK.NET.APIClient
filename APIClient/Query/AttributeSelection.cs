using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient {
    public class AttributeSelection : List<IAttributeDefinition> {
        public AttributeSelection() {}

        public AttributeSelection(params IAttributeDefinition[] defs) : this() {
            foreach(var attribdef in defs.Where(attribdef => !Contains(attribdef))) {
                Add(attribdef);
            }
        }

        public AttributeSelection(IEnumerable<IAttributeDefinition> list) : this() {
            foreach(var attribdef in list.Where(attribdef => !Contains(attribdef))) {
                Add(attribdef);
            }
        }

        public AttributeSelection(string token, IMetaModel meta) : this() {
            var parts = token.Split(',');

            foreach(var part in parts) {
                Add(meta.GetAttributeDefinition(part));
            }
        }

        public AttributeSelection(string names, IAssetType meta) : this() {
            var parts = names.Split(',');

            foreach(var part in parts) {
                Add(meta.GetAttributeDefinition(part));
            }
        }

        public static AttributeSelection Merge(params IEnumerable<IAttributeDefinition>[] lists) {
            var result = new AttributeSelection();

            foreach(var def in lists.SelectMany(list => list.Where(def => !result.Contains(def)))) {
                result.Add(def);
            }

            return result;
        }

        public string Token {
            get { return TextBuilder.Join(this, ",", TokenOf); }
        }

        private static string TokenOf(IAttributeDefinition def) {
            return def.Token;
        }
    }
}