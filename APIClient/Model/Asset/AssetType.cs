using System.Collections;
using System.Xml;
using VersionOne.SDK.APIClient.Meta;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Model.Asset {
    internal class AssetType : IAssetType {
        private readonly IMetaModel meta;
        private readonly IDictionary map;
        private readonly string displayName;
        private readonly string token;
        private IAssetType @base = null;
        private readonly string baseToken = null;
        private IAttributeDefinition orderBy = null;
        private readonly string orderByToken = null;

        private IAttributeDefinition shortNameAttribute = null;
        private readonly string shortNameToken = null;

        private IAttributeDefinition nameAttribute = null;
        private readonly string nameToken = null;

        private IAttributeDefinition descriptionAttribute = null;
        private readonly string descriptionToken = null;

        public AssetType(IMetaModel meta, XmlElement element, IDictionary map) {
            this.meta = meta;
            this.map = map;
            displayName = element.GetAttribute("displayname");
            token = element.GetAttribute("token");

            var baseelement = element.SelectSingleNode("Base") as XmlElement;

            if(baseelement != null) {
                baseToken = baseelement.GetAttribute("nameref");
            }

            orderByToken = ReadAttribute(element, "DefaultOrderBy");
            nameToken = ReadAttribute(element, "Name");
            shortNameToken = ReadAttribute(element, "ShortName");
            descriptionToken = ReadAttribute(element, "Description");
        }

        private static string ReadAttribute(XmlNode element, string nodeName) {
            var subNode = element.SelectSingleNode(nodeName) as XmlElement;

            if(subNode != null) {
                return subNode.GetAttribute("tokenref");
            }

            return null;
        }

        public bool Is(IAssetType targettype) {
            for(IAssetType thistype = this; thistype != null; thistype = thistype.Base) {
                if (thistype == targettype) {
                    return true;
                }
            }

            return false;
        }

        public string Token {
            get { return token; }
        }

        public IAssetType Base {
            get {
                if(@base == null && baseToken != null) {
                    @base = meta.GetAssetType(baseToken);
                }

                return @base;
            }
        }

        public string DisplayName {
            get { return displayName; }
        }

        private IAttributeDefinition ResolveAttribute(string token, IAttributeDefinition result) {
            if(result == null && token != null) {
                result = meta.GetAttributeDefinition(token);
            }

            return result;
        }

        public IAttributeDefinition DefaultOrderBy {
            get { return orderBy = ResolveAttribute(orderByToken, orderBy); }
        }

        public IAttributeDefinition ShortNameAttribute {
            get { return shortNameAttribute = ResolveAttribute(shortNameToken, shortNameAttribute); }
        }

        public IAttributeDefinition NameAttribute {
            get { return nameAttribute = ResolveAttribute(nameToken, nameAttribute); }
        }

        public IAttributeDefinition DescriptionAttribute {
            get { return descriptionAttribute = ResolveAttribute(descriptionToken, descriptionAttribute); }
        }

        public bool TryGetAttributeDefinition(string name, out IAttributeDefinition def) {
            def = LookupAttributeDefinition(name);
            return def != null || meta.TryGetAttributeDefinition(Token + "." + name, out def);
        }

        public IAttributeDefinition GetAttributeDefinition(string name) {
            var attribdef = LookupAttributeDefinition(name);
            return attribdef ?? meta.GetAttributeDefinition(Token + "." + name);
        }

        private IAttributeDefinition LookupAttributeDefinition(string name) {
            var key = new Pair<IAssetType, string>(this, name);
            return map[key] as IAttributeDefinition;
        }

        internal void SaveAttributeDefinition(IAttributeDefinition attribdef) {
            var key = new Pair<IAssetType, string>(this, attribdef.Name);
            map[key] = attribdef;
        }

        public bool TryGetOperation(string name, out IOperation op) {
            op = LookupOperation(name);
            return op != null || meta.TryGetOperation(Token + "." + name, out op);
        }

        public IOperation GetOperation(string name) {
            var op = LookupOperation(name);
            return op ?? meta.GetOperation(Token + "." + name);
        }

        private IOperation LookupOperation(string name) {
            var key = new Pair<IAssetType, string>(this, name);
            return map[key] as IOperation;
        }

        internal void SaveOperation(IOperation op) {
            var key = new Pair<IAssetType, string>(this, op.Name);
            map[key] = op;
        }
    }
}