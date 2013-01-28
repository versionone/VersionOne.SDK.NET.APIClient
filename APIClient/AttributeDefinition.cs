using System;
using System.Xml;

namespace VersionOne.SDK.APIClient {
    internal class AttributeDefinition : IAttributeDefinition {
        private readonly IMetaModel metaModel;
        private IAssetType assetType;
        private readonly string assetTypeToken;
        private readonly string name;
        private readonly string token;
        private readonly AttributeType attributeType;
        private IAttributeDefinition @base = null;
        private readonly string baseToken = null;
        private readonly bool isReadonly;
        private readonly bool isRequired;
        private readonly bool isMultivalue;
        private IAssetType relatedAsset = null;
        private readonly string relatedAssetToken = null;
        private readonly string displayName;

        public AttributeDefinition(IMetaModel metaModel, XmlElement element) {
            this.metaModel = metaModel;

            token = element.GetAttribute("token");

            TextBuilder.SplitPrefix(token, '.', out assetTypeToken, out name);

            displayName = element.GetAttribute("displayname");
            attributeType = (AttributeType) Enum.Parse(typeof (AttributeType), element.GetAttribute("attributetype"));

            isReadonly = bool.Parse(element.GetAttribute("isreadonly"));
            isRequired = bool.Parse(element.GetAttribute("isrequired"));
            isMultivalue = bool.Parse(element.GetAttribute("ismultivalue"));

            var baseelement = element.SelectSingleNode("Base") as XmlElement;

            if(baseelement != null) {
                baseToken = baseelement.GetAttribute("tokenref");
            }

            var relatedelement = element.SelectSingleNode("RelatedAsset") as XmlElement;

            if(relatedelement != null) {
                relatedAssetToken = relatedelement.GetAttribute("nameref");
            }

            ((AssetType) AssetType).SaveAttributeDefinition(this);
        }


        public IAssetType AssetType {
            get { return assetType ?? (assetType = metaModel.GetAssetType(assetTypeToken)); }
        }

        public string Name {
            get { return name; }
        }

        public string Token {
            get { return token; }
        }

        public AttributeType AttributeType {
            get { return attributeType; }
        }

        public IAttributeDefinition Base {
            get {
                if(@base == null && baseToken != null) {
                    @base = metaModel.GetAttributeDefinition(baseToken);
                }

                return @base;
            }
        }

        public bool IsReadOnly {
            get { return isReadonly; }
        }

        public bool IsRequired {
            get { return isRequired; }
        }

        public bool IsMultiValue {
            get { return isMultivalue; }
        }

        public IAssetType RelatedAsset {
            get {
                if(relatedAsset == null && relatedAssetToken != null) {
                    relatedAsset = metaModel.GetAssetType(relatedAssetToken);
                }

                return relatedAsset;
            }
        }

        public string DisplayName {
            get { return displayName; }
        }

        public object Coerce(object value) {
            switch (AttributeType) {
                case AttributeType.Boolean:
                    return DB.Bit(value);
                case AttributeType.Numeric:
                    return DB.Real(value);
                case AttributeType.Date:
                    return DB.DateTime(value);
                case AttributeType.Duration:
                    if(value == null || value is Duration) {
                        return value;
                    }

                    if(value is int) {
                        return new Duration((int) value, Duration.Unit.Days);
                    }

                    if(value is TimeSpan) {
                        return new Duration((TimeSpan) value);
                    }

                    return Duration.Parse((string) value);
                case AttributeType.Text:
                case AttributeType.LongText:
                case AttributeType.LocalizerTag:
                case AttributeType.Password:
                    return DB.Str(value);
                case AttributeType.Relation:
                    var oid = CoerceOid(value);

                    if(RelatedAsset != null && !oid.IsNull && !(oid.AssetType).Is(RelatedAsset)) {
                        throw new OidException("Wrong OID AssetType", oid.Token);
                    }

                    return oid;
                case AttributeType.AssetType:
                    return CoerceAssetType(value);
                case AttributeType.Opaque:
                    return value;
                case AttributeType.State:
                    return CoerceState(value);
                case AttributeType.Rank:
                    return new Rank(value);
                case AttributeType.LongInt:
                    return DB.BigInt(value);
                case AttributeType.Blob:
                    return value;
                default:
                    throw new MetaException("Unsupported AttributeType ", AttributeType.ToString());
            }
        }

        private static object CoerceState(object value) {
            if (value == null) {
                return null;
            }

            if(value is AssetStateManager.AssetState) {
                return (AssetStateManager.AssetState) value;
            }

            if(value is Enum) {
                return (byte) value;
            }

            var statetype = typeof (AssetStateManager.AssetState);
            
            if (value is byte) {
                var byteval = (byte) value;

                if(Enum.IsDefined(statetype, byteval)) {
                    return Enum.ToObject(statetype, byteval);
                }

                return byteval;
            }

            var stringval = value.ToString();

            try {
                return Enum.Parse(statetype, stringval, true);
            } catch { }

            return byte.Parse(stringval);
        }

        private Oid CoerceOid(object value) {
            if(value is Oid) {
                return (Oid) value;
            }

            if(value == null) {
                return Oid.Null;
            }

            if(value is string) {
                return Oid.FromToken((string) value, metaModel);
            }

            if(value is int) {
                return new Oid(RelatedAsset, (int) value, null);
            }

            throw new OidException("Object is not convertible to an OID", value.ToString());
        }

        private IAssetType CoerceAssetType(object value) {
            if (value == null) {
                return null;
            }

            if(value is IAssetType) {
                return (IAssetType) value;
            }

            if(value is string) {
                return metaModel.GetAssetType((string) value);
            }

            throw new MetaException("Object is not convertible to an AssetType", value.ToString());
        }

        public IAttributeDefinition Downcast(IAssetType assetType) {
            if (AttributeType == AttributeType.Relation) {
                if(assetType.Is(RelatedAsset)) {
                    return metaModel.GetAttributeDefinition(Token + ":" + assetType.Token);
                }

                throw new MetaException("Cannot downcast to unrelated type");
            }

            throw new MetaException("Cannot downcast non-relation attributes");
        }

        public IAttributeDefinition Filter(IFilterTerm filter) {
            if(AttributeType == AttributeType.Relation) {
                return metaModel.GetAttributeDefinition(Token + "[" + filter.ShortToken + "]");
            }

            throw new MetaException("Cannot filter non-relation attributes");
        }

        public IAttributeDefinition Join(IAttributeDefinition joined) {
            if (AttributeType == AttributeType.Relation) {
                if(RelatedAsset.Is(joined.AssetType)) {
                    return metaModel.GetAttributeDefinition(Token + "." + joined.Name);
                }

                throw new MetaException("Cannot join unrelated attributes");
            }

            throw new MetaException("Cannot join non-relation attributes");
        }

        public IAttributeDefinition Aggregate(Aggregate aggregate) {
            if (IsMultiValue) {
                switch (aggregate) {
                    case APIClient.Aggregate.Min:
                        switch (AttributeType) {
                            case AttributeType.Numeric:
                                return metaModel.GetAttributeDefinition(Token + ".@Min");
                            case AttributeType.Date:
                                return metaModel.GetAttributeDefinition(Token + ".@MinDate");
                        }

                        throw new MetaException("Must aggregate MIN of numerics and dates");
                    case APIClient.Aggregate.Max:
                        switch (AttributeType) {
                            case AttributeType.Numeric:
                                return metaModel.GetAttributeDefinition(Token + ".@Max");
                            case AttributeType.Date:
                                return metaModel.GetAttributeDefinition(Token + ".@MaxDate");
                        }

                        throw new MetaException("Must aggregate MAX of numerics and dates");
                    case APIClient.Aggregate.Count:
                        if(AttributeType == AttributeType.Relation) {
                            return metaModel.GetAttributeDefinition(Token + ".@Count");
                        }

                        throw new MetaException("Must aggregate COUNT of relations");
                    case APIClient.Aggregate.Sum:
                        if(AttributeType == AttributeType.Numeric) {
                            return metaModel.GetAttributeDefinition(Token + ".@Sum");
                        }

                        throw new MetaException("Must aggregate SUM of numerics");
                    case APIClient.Aggregate.And:
                        if(AttributeType == AttributeType.Boolean) {
                            return metaModel.GetAttributeDefinition(Token + ".@And");
                        }

                        throw new MetaException("Must aggregate AND of booleans");
                    case APIClient.Aggregate.Or:
                        if(AttributeType == AttributeType.Boolean) {
                            return metaModel.GetAttributeDefinition(Token + ".@Or");
                        }

                        throw new MetaException("Must aggregate OR of booleans");
                }
            }

            throw new MetaException("Must aggregate multi-value attributes");
        }
    }
}