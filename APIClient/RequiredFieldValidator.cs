using System;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
    // TODO create AssetValidationResult and AssetCollectionValidationResult so users could operate results with more convenience. At least calculated field IsValid is reasonable. These classes would inherit corresponding collections to contain less redundancy.
    public class RequiredFieldValidator
    {
        private readonly IDictionary<IAssetType, ICollection<IAttributeDefinition>> requiredFields;
        private readonly IMetaModel metaModel;
        private readonly IServices services;

        public RequiredFieldValidator(IMetaModel metaModel, IServices services)
        {
            requiredFields = new Dictionary<IAssetType, ICollection<IAttributeDefinition>>();
            this.metaModel = metaModel;
            this.services = services;
        }

        /// <summary>
        /// Validate single Asset attribute. If attribute is not loaded, it is just considered invalid.
        /// </summary>
        /// <param name="asset">Asset to validate</param>
        /// <param name="attributeDefinition">Attribute definition of validated attribute</param>
        /// <returns>Validation result</returns>
        // TODO create separate private method to avoid excessive GetRequiredFields() calls
        public bool Validate(Asset asset, IAttributeDefinition attributeDefinition)
        {
            GetRequiredFields(asset.AssetType);
            asset.EnsureAttribute(attributeDefinition);
            Attribute attribute = asset.GetAttribute(attributeDefinition);
            bool result = attribute != null && !(IsMultiValueAndUnfilled(attribute) || IsSingleValueAndUnfilled(attribute));

            if (!result && attribute != null)
            {
                result = !attribute.HasChanged && !isAttributeUnfilledOnServer(asset, attributeDefinition);
            }

            return result;
        }

        /// <summary>
        /// Validate all available Asset attributes. 
        /// If there are required attributes that haven't been loaded, these are considered failures.
        /// In some cases, attributes could exist on server and have valid values, but it's up to user to retrieve them or ignore corresponding validation errors.
        /// </summary>
        /// <param name="asset">Asset to validate</param>
        /// <returns>Collection of attribute definitions for attributes which values do not pass validation</returns>
        public ICollection<IAttributeDefinition> Validate(Asset asset)
        {
            GetRequiredFields(asset.AssetType);
            ICollection<IAttributeDefinition> results = new List<IAttributeDefinition>();
            ICollection<IAttributeDefinition> requiredAttributes = requiredFields[asset.AssetType];

            foreach (IAttributeDefinition attributeDefinition in requiredAttributes)
            {
                asset.EnsureAttribute(attributeDefinition);
                Attribute attribute = asset.GetAttribute(attributeDefinition);
                
                if(attribute == null || !Validate(asset, attributeDefinition)) 
                {
                    results.Add(attributeDefinition);
                }
            }

            return results;
        }

        /// <summary>
        /// Validate collection of Assets.
        /// </summary>
        /// <param name="assets">Asset collection to check</param>
        /// <returns>Validation results dictionary, each entry value key is Asset, and value is output of <see cref="Validate(Asset)"/></returns>
        public IDictionary<Asset, ICollection<IAttributeDefinition>> Validate(IEnumerable<Asset> assets)
        {
            IDictionary<Asset, ICollection<IAttributeDefinition>> results = new Dictionary<Asset, ICollection<IAttributeDefinition>>();

            foreach (Asset asset in assets)
            {
                results.Add(asset, Validate(asset));
            }

            return results;
        }

        /// <summary>
        /// Check whether the attribute corresponding to the attributeName is required in current VersionOne server setup.
        /// </summary>
        /// <param name="assetType">Asset type</param>
        /// <param name="attributeName">Attribute name</param>
        /// <returns></returns>
        public bool IsRequired(IAssetType assetType, string attributeName)
        {
            return IsRequired(assetType.GetAttributeDefinition(attributeName));
        }

        /// <summary>
        /// Check whether the provided attribute is required in current VersionOne server setup.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool IsRequired(IAttributeDefinition definition)
        {
            GetRequiredFields(definition.AssetType);
            return IsRequiredField(definition.AssetType, definition.Name);
        }

        /// <summary>
        /// Get required fields for asset type.
        /// </summary>
        /// <param name="assetType">Asset type</param>
        private void GetRequiredFields(IAssetType assetType)
        {
            if (!requiredFields.ContainsKey(assetType))
            {
                ICollection<IAttributeDefinition> requiredFieldsForType = LoadRequiredFields(assetType);
                requiredFields.Add(assetType, requiredFieldsForType);
            }
        }

        /// <summary>
        /// Load required fields attribute definitions for provided Asset type.
        /// </summary>
        /// <returns>Collection of attribute definitions for required fields</returns>
        private ICollection<IAttributeDefinition> LoadRequiredFields(IAssetType assetType)
        {
            ICollection<IAttributeDefinition> requiredFieldsForType = new List<IAttributeDefinition>();

            IAssetType attributeDefinitionAssetType = metaModel.GetAssetType("AttributeDefinition");
            IAttributeDefinition nameAttributeDef = attributeDefinitionAssetType.GetAttributeDefinition("Name");
            IAttributeDefinition assetNameAttributeDef =
                attributeDefinitionAssetType.GetAttributeDefinition("Asset.AssetTypesMeAndDown.Name");

            Query query = new Query(attributeDefinitionAssetType);
            query.Selection.Add(nameAttributeDef);
            FilterTerm assetTypeTerm = new FilterTerm(assetNameAttributeDef);
            assetTypeTerm.Equal(assetType.Token);
            query.Filter = new AndFilterTerm(new IFilterTerm[] { assetTypeTerm });

            QueryResult result = services.Retrieve(query);

            foreach (Asset asset in result.Assets)
            {
                string name = asset.GetAttribute(nameAttributeDef).Value.ToString();
                if (IsRequiredField(assetType, name))
                {
                    IAttributeDefinition definition = assetType.GetAttributeDefinition(name);
                    requiredFieldsForType.Add(definition);
                }
            }

            return requiredFieldsForType;
        }

        private static bool IsRequiredField(IAssetType assetType, string name)
        {
            IAttributeDefinition def = assetType.GetAttributeDefinition(name);
            return def.IsRequired && !def.IsReadOnly;
        }

        private bool IsSingleValueAndUnfilled(Attribute attribute)
        {
            return !attribute.Definition.IsMultiValue &&
                    ((attribute.Value is Oid && ((Oid)attribute.Value).IsNull) || attribute.Value == null);
        }

        private bool IsMultiValueAndUnfilled(Attribute attribute)
        {
            return (attribute.Definition.IsMultiValue && attribute.ValuesList.Count < 1);
        }

        private bool isAttributeUnfilledOnServer(Asset asset, IAttributeDefinition attributeDefinition)
        {
            if (asset.Oid == Oid.Null)
            {
                return true;
            }
            Query query = new Query(asset.Oid);
            query.Selection.Add(attributeDefinition);
            QueryResult result = null;
            try
            {
                result = services.Retrieve(query);
            }
            catch (Exception)
            {
                //do nothing
            }

            if (result != null)
            {
                Attribute attr = result.Assets[0].GetAttribute(attributeDefinition);
                try
                {
                    return IsSingleValueAndUnfilled(attr) && IsMultiValueAndUnfilled(attr);
                }
                catch (APIException)
                {
                    // do nothing
                }
            }

            return true; // there is no data on the server.
        }
    }
}