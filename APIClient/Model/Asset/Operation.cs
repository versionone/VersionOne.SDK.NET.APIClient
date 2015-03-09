using System.Xml;
using VersionOne.SDK.APIClient.Meta;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Model.Asset {
    internal class Operation : IOperation {
        private readonly IMetaModel Meta;

        private readonly string assetTypeToken;
        private readonly string name;

        private readonly string validatorToken;
        private IAssetType assetType;
        private IAttributeDefinition validator;


        public Operation(IMetaModel meta, string assetTypeToken, XmlElement element) {
            Meta = meta;
            this.assetTypeToken = assetTypeToken;

            if (string.IsNullOrEmpty(assetTypeToken)) {
                var of = element.GetAttribute("of");
                var ofs = of.Split('/');
                this.assetTypeToken = ofs[ofs.Length - 1];
            }

            name = element.GetAttribute("name");

            var validators = element.GetElementsByTagName("Validator");
            
            if (validators != null && validators.Count > 0) {
                validatorToken = ((XmlElement) validators[0]).GetAttribute("tokenref");
            }

            ((AssetType) AssetType).SaveOperation(this);
        }

        public string Token {
            get { return assetTypeToken + "." + name; }
        }

        public string Name {
            get { return name; }
        }

        public IAssetType AssetType {
            get {
                if (assetType == null && assetTypeToken != null) {
                    assetType = Meta.GetAssetType(assetTypeToken);
                }
                
                return assetType;
            }
        }

        public IAttributeDefinition ValidatorAttribute {
            get {
                if (validator == null && validatorToken != null) {
                    validator = Meta.GetAttributeDefinition(validatorToken);
                }
                
                return validator;
            }
        }
    }
}