namespace VersionOne.SDK.APIClient.Tests.ServicesTests
{
    public class MetaSamplePayloads
    {
        #region AssetTypeType
        public static readonly string AssetTypeType = @"<AssetType name=""AssetType""  version=""16.1.1.225"" token=""AssetType"" displayname=""AssetType'AssetType"" abstract=""False"">
    <DefaultOrderBy href=""/v1sdktesting/meta.v1/AssetType/Order"" tokenref=""AssetType.Order"" />
    <DefaultDisplayBy href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
    <ShortName href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
    <Name href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
    <AttributeDefinition name=""ID"" token=""AssetType.ID"" displayname=""AttributeDefinition'ID'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Now"" token=""AssetType.Now"" displayname=""AttributeDefinition'Now'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Now"" tokenref=""AssetType.Now"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""History"" token=""AssetType.History"" displayname=""AttributeDefinition'History'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Now"" tokenref=""AssetType.Now"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetType"" token=""AssetType.AssetType"" displayname=""AttributeDefinition'AssetType'AssetType"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/AssetType"" tokenref=""AssetType.AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Key"" token=""AssetType.Key"" displayname=""AttributeDefinition'Key'AssetType"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Key"" tokenref=""AssetType.Key"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Moment"" token=""AssetType.Moment"" displayname=""AttributeDefinition'Moment'AssetType"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Moment"" tokenref=""AssetType.Moment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Is"" token=""AssetType.Is"" displayname=""AttributeDefinition'Is'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
    <AttributeDefinition name=""ChangeDate"" token=""AssetType.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeDate"" tokenref=""AssetType.ChangeDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireDate"" token=""AssetType.RetireDate"" displayname=""AttributeDefinition'RetireDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireDate"" tokenref=""AssetType.RetireDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateDate"" token=""AssetType.CreateDate"" displayname=""AttributeDefinition'CreateDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateDate"" tokenref=""AssetType.CreateDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeDateUTC"" token=""AssetType.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeDateUTC"" tokenref=""AssetType.ChangeDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireDateUTC"" token=""AssetType.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireDateUTC"" tokenref=""AssetType.RetireDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Days"" token=""AssetType.Days"" displayname=""AttributeDefinition'Days'AssetType"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Days"" tokenref=""AssetType.Days"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateDateUTC"" token=""AssetType.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateDateUTC"" tokenref=""AssetType.CreateDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeReason"" token=""AssetType.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeReason"" tokenref=""AssetType.ChangeReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireReason"" token=""AssetType.RetireReason"" displayname=""AttributeDefinition'RetireReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireReason"" tokenref=""AssetType.RetireReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateReason"" token=""AssetType.CreateReason"" displayname=""AttributeDefinition'CreateReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateReason"" tokenref=""AssetType.CreateReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeComment"" token=""AssetType.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeComment"" tokenref=""AssetType.ChangeComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireComment"" token=""AssetType.RetireComment"" displayname=""AttributeDefinition'RetireComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireComment"" tokenref=""AssetType.RetireComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateComment"" token=""AssetType.CreateComment"" displayname=""AttributeDefinition'CreateComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateComment"" tokenref=""AssetType.CreateComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangedBy"" token=""AssetType.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangedBy.Name"" tokenref=""AssetType.ChangedBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangedBy.Name"" tokenref=""AssetType.ChangedBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetiredBy"" token=""AssetType.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetiredBy.Name"" tokenref=""AssetType.RetiredBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetiredBy.Name"" tokenref=""AssetType.RetiredBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreatedBy"" token=""AssetType.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreatedBy.Name"" tokenref=""AssetType.CreatedBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreatedBy.Name"" tokenref=""AssetType.CreatedBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Viewers"" token=""AssetType.Viewers"" displayname=""AttributeDefinition'Viewers'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Prior"" token=""AssetType.Prior"" displayname=""AttributeDefinition'Prior'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Prior.Order"" tokenref=""AssetType.Prior.Order"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Prior.Name"" tokenref=""AssetType.Prior.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""VisibleToCollaborator"" token=""AssetType.VisibleToCollaborator"" displayname=""AttributeDefinition'VisibleToCollaborator'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/VisibleToCollaborator"" tokenref=""AssetType.VisibleToCollaborator"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ListValidValuesFilter"" token=""AssetType.ListValidValuesFilter"" displayname=""AttributeDefinition'ListValidValuesFilter'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ListValidValuesFilter"" tokenref=""AssetType.ListValidValuesFilter"" />
    </AttributeDefinition>
    <AttributeDefinition name=""EventDefinitions"" token=""AssetType.EventDefinitions"" displayname=""AttributeDefinition'EventDefinitions'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/EventDefinition/Asset"" tokenref=""EventDefinition.Asset"" />
        <RelatedAsset nameref=""EventDefinition"" href=""/v1sdktesting/meta.v1/EventDefinition"" />
    </AttributeDefinition>
    <AttributeDefinition name=""UseViewRightsForUpdate"" token=""AssetType.UseViewRightsForUpdate"" displayname=""AttributeDefinition'UseViewRightsForUpdate'AssetType"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UseViewRightsForUpdate"" tokenref=""AssetType.UseViewRightsForUpdate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""SecureViaRelation"" token=""AssetType.SecureViaRelation"" displayname=""AttributeDefinition'SecureViaRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/SecureViaRelation"" tokenref=""AssetType.SecureViaRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""VisibleToInstigator"" token=""AssetType.VisibleToInstigator"" displayname=""AttributeDefinition'VisibleToInstigator'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/VisibleToInstigator"" tokenref=""AssetType.VisibleToInstigator"" />
    </AttributeDefinition>
    <AttributeDefinition name=""IsCustom"" token=""AssetType.IsCustom"" displayname=""AttributeDefinition'IsCustom'AssetType"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsCustom"" tokenref=""AssetType.IsCustom"" />
    </AttributeDefinition>
    <AttributeDefinition name=""DefaultHierarchyAttribute"" token=""AssetType.DefaultHierarchyAttribute"" displayname=""AttributeDefinition'DefaultHierarchyAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/DefaultHierarchyAttribute"" tokenref=""AssetType.DefaultHierarchyAttribute"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Base"" token=""AssetType.Base"" displayname=""AttributeDefinition'Base'AssetType"" attributetype=""Relation"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypes"" tokenref=""AssetType.AssetTypes"" />
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Base.Order"" tokenref=""AssetType.Base.Order"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Base.Name"" tokenref=""AssetType.Base.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetTypes"" token=""AssetType.AssetTypes"" displayname=""AttributeDefinition'AssetTypes'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Base"" tokenref=""AssetType.Base"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""BaseMeAndUp"" token=""AssetType.BaseMeAndUp"" displayname=""AttributeDefinition'BaseMeAndUp'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesMeAndDown"" tokenref=""AssetType.AssetTypesMeAndDown"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""BaseAndUp"" token=""AssetType.BaseAndUp"" displayname=""AttributeDefinition'BaseAndUp'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesAndDown"" tokenref=""AssetType.AssetTypesAndDown"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""BaseAndMe"" token=""AssetType.BaseAndMe"" displayname=""AttributeDefinition'BaseAndMe'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesAndMe"" tokenref=""AssetType.AssetTypesAndMe"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetTypesMeAndDown"" token=""AssetType.AssetTypesMeAndDown"" displayname=""AttributeDefinition'AssetTypesMeAndDown'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseMeAndUp"" tokenref=""AssetType.BaseMeAndUp"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetTypesAndDown"" token=""AssetType.AssetTypesAndDown"" displayname=""AttributeDefinition'AssetTypesAndDown'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseAndUp"" tokenref=""AssetType.BaseAndUp"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetTypesAndMe"" token=""AssetType.AssetTypesAndMe"" displayname=""AttributeDefinition'AssetTypesAndMe'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseAndMe"" tokenref=""AssetType.BaseAndMe"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Operations"" token=""AssetType.Operations"" displayname=""AttributeDefinition'Operations'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/Operation/Asset"" tokenref=""Operation.Asset"" />
        <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Overrides"" token=""AssetType.Overrides"" displayname=""AttributeDefinition'Overrides'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/Override/Asset"" tokenref=""Override.Asset"" />
        <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AttributeDefinitions"" token=""AssetType.AttributeDefinitions"" displayname=""AttributeDefinition'AttributeDefinitions'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
        <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Order"" token=""AssetType.Order"" displayname=""AttributeDefinition'Order'AssetType"" attributetype=""Rank"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Order"" tokenref=""AssetType.Order"" />
    </AttributeDefinition>
    <AttributeDefinition name=""NumberPattern"" token=""AssetType.NumberPattern"" displayname=""AttributeDefinition'NumberPattern'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NumberPattern"" tokenref=""AssetType.NumberPattern"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Resolver"" token=""AssetType.Resolver"" displayname=""AttributeDefinition'Resolver'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Resolver"" tokenref=""AssetType.Resolver"" />
    </AttributeDefinition>
    <AttributeDefinition name=""NameResolutionAttributes"" token=""AssetType.NameResolutionAttributes"" displayname=""AttributeDefinition'NameResolutionAttributes'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NameResolutionAttributes"" tokenref=""AssetType.NameResolutionAttributes"" />
    </AttributeDefinition>
    <AttributeDefinition name=""DefaultOrderByAttribute"" token=""AssetType.DefaultOrderByAttribute"" displayname=""AttributeDefinition'DefaultOrderByAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/DefaultOrderByAttribute"" tokenref=""AssetType.DefaultOrderByAttribute"" />
    </AttributeDefinition>
    <AttributeDefinition name=""UpdatePrivileges"" token=""AssetType.UpdatePrivileges"" displayname=""AttributeDefinition'UpdatePrivileges'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UpdatePrivileges"" tokenref=""AssetType.UpdatePrivileges"" />
    </AttributeDefinition>
    <AttributeDefinition name=""NewSecurityScopeRelation"" token=""AssetType.NewSecurityScopeRelation"" displayname=""AttributeDefinition'NewSecurityScopeRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NewSecurityScopeRelation"" tokenref=""AssetType.NewSecurityScopeRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""SecurityScopeRelation"" token=""AssetType.SecurityScopeRelation"" displayname=""AttributeDefinition'SecurityScopeRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/SecurityScopeRelation"" tokenref=""AssetType.SecurityScopeRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""UpdateRights"" token=""AssetType.UpdateRights"" displayname=""AttributeDefinition'UpdateRights'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UpdateRights"" tokenref=""AssetType.UpdateRights"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ViewRights"" token=""AssetType.ViewRights"" displayname=""AttributeDefinition'ViewRights'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ViewRights"" tokenref=""AssetType.ViewRights"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Initializer"" token=""AssetType.Initializer"" displayname=""AttributeDefinition'Initializer'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Initializer"" tokenref=""AssetType.Initializer"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ShortNameAttribute"" token=""AssetType.ShortNameAttribute"" displayname=""AttributeDefinition'ShortNameAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ShortNameAttribute"" tokenref=""AssetType.ShortNameAttribute"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Name"" token=""AssetType.Name"" displayname=""AttributeDefinition'Name'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
    </AttributeDefinition>
    <AttributeDefinition name=""IsReadOnly"" token=""AssetType.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsReadOnly"" tokenref=""AssetType.IsReadOnly"" />
    </AttributeDefinition>
    <AttributeDefinition name=""IsDeletable"" token=""AssetType.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsDeletable"" tokenref=""AssetType.IsDeletable"" />
    </AttributeDefinition>
    <AttributeDefinition name=""IsCanned"" token=""AssetType.IsCanned"" displayname=""AttributeDefinition'IsCanned'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsCanned"" tokenref=""AssetType.IsCanned"" />
    </AttributeDefinition>
</AssetType>";
            #endregion

        #region PrimaryRelationType
        public static readonly string PrimaryRelationType = @"<AssetType version=""16.1.1.225"" name=""PrimaryRelation"" token=""PrimaryRelation"" displayname=""AssetType'PrimaryRelation"" abstract=""False"">
    <DefaultOrderBy href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
    <AttributeDefinition name=""ID"" token=""PrimaryRelation.ID"" displayname=""AttributeDefinition'ID'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
        <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Now"" token=""PrimaryRelation.Now"" displayname=""AttributeDefinition'Now'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
        <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""History"" token=""PrimaryRelation.History"" displayname=""AttributeDefinition'History'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
        <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""AssetType"" token=""PrimaryRelation.AssetType"" displayname=""AttributeDefinition'AssetType'PrimaryRelation"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/AssetType"" tokenref=""PrimaryRelation.AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Key"" token=""PrimaryRelation.Key"" displayname=""AttributeDefinition'Key'PrimaryRelation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Key"" tokenref=""PrimaryRelation.Key"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Moment"" token=""PrimaryRelation.Moment"" displayname=""AttributeDefinition'Moment'PrimaryRelation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Moment"" tokenref=""PrimaryRelation.Moment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Is"" token=""PrimaryRelation.Is"" displayname=""AttributeDefinition'Is'PrimaryRelation"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
    <AttributeDefinition name=""ChangeDate"" token=""PrimaryRelation.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeDate"" tokenref=""PrimaryRelation.ChangeDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireDate"" token=""PrimaryRelation.RetireDate"" displayname=""AttributeDefinition'RetireDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireDate"" tokenref=""PrimaryRelation.RetireDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateDate"" token=""PrimaryRelation.CreateDate"" displayname=""AttributeDefinition'CreateDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateDate"" tokenref=""PrimaryRelation.CreateDate"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeDateUTC"" token=""PrimaryRelation.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeDateUTC"" tokenref=""PrimaryRelation.ChangeDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireDateUTC"" token=""PrimaryRelation.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireDateUTC"" tokenref=""PrimaryRelation.RetireDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Days"" token=""PrimaryRelation.Days"" displayname=""AttributeDefinition'Days'PrimaryRelation"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Days"" tokenref=""PrimaryRelation.Days"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateDateUTC"" token=""PrimaryRelation.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateDateUTC"" tokenref=""PrimaryRelation.CreateDateUTC"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeReason"" token=""PrimaryRelation.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeReason"" tokenref=""PrimaryRelation.ChangeReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireReason"" token=""PrimaryRelation.RetireReason"" displayname=""AttributeDefinition'RetireReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireReason"" tokenref=""PrimaryRelation.RetireReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateReason"" token=""PrimaryRelation.CreateReason"" displayname=""AttributeDefinition'CreateReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateReason"" tokenref=""PrimaryRelation.CreateReason"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangeComment"" token=""PrimaryRelation.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeComment"" tokenref=""PrimaryRelation.ChangeComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetireComment"" token=""PrimaryRelation.RetireComment"" displayname=""AttributeDefinition'RetireComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireComment"" tokenref=""PrimaryRelation.RetireComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreateComment"" token=""PrimaryRelation.CreateComment"" displayname=""AttributeDefinition'CreateComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateComment"" tokenref=""PrimaryRelation.CreateComment"" />
    </AttributeDefinition>
    <AttributeDefinition name=""ChangedBy"" token=""PrimaryRelation.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangedBy.Name"" tokenref=""PrimaryRelation.ChangedBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangedBy.Name"" tokenref=""PrimaryRelation.ChangedBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""RetiredBy"" token=""PrimaryRelation.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetiredBy.Name"" tokenref=""PrimaryRelation.RetiredBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetiredBy.Name"" tokenref=""PrimaryRelation.RetiredBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""CreatedBy"" token=""PrimaryRelation.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreatedBy.Name"" tokenref=""PrimaryRelation.CreatedBy.Name"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreatedBy.Name"" tokenref=""PrimaryRelation.CreatedBy.Name"" />
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Viewers"" token=""PrimaryRelation.Viewers"" displayname=""AttributeDefinition'Viewers'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
        <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Prior"" token=""PrimaryRelation.Prior"" displayname=""AttributeDefinition'Prior'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Prior.ID"" tokenref=""PrimaryRelation.Prior.ID"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Prior"" tokenref=""PrimaryRelation.Prior"" />
        <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
    </AttributeDefinition>
    <AttributeDefinition name=""To"" token=""PrimaryRelation.To"" displayname=""AttributeDefinition'To'PrimaryRelation"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/To.Order"" tokenref=""PrimaryRelation.To.Order"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/To.Name"" tokenref=""PrimaryRelation.To.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""From"" token=""PrimaryRelation.From"" displayname=""AttributeDefinition'From'PrimaryRelation"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/From.Order"" tokenref=""PrimaryRelation.From.Order"" />
        <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/From.Name"" tokenref=""PrimaryRelation.From.Name"" />
        <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
    </AttributeDefinition>
    <AttributeDefinition name=""Relation"" token=""PrimaryRelation.Relation"" displayname=""AttributeDefinition'Relation'PrimaryRelation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
        <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Relation"" tokenref=""PrimaryRelation.Relation"" />
    </AttributeDefinition>
</AssetType>
";
        #endregion

        public static readonly string FullSubset = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Meta href=""/v1sdktesting/meta.v1/"" version=""16.1.1.225"">
    <AssetType name=""AssetType"" token=""AssetType"" displayname=""AssetType'AssetType"" abstract=""False"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/AssetType/Order"" tokenref=""AssetType.Order"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        <Name href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        <AttributeDefinition name=""ID"" token=""AssetType.ID"" displayname=""AttributeDefinition'ID'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""AssetType.Now"" displayname=""AttributeDefinition'Now'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/ID"" tokenref=""AssetType.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Now"" tokenref=""AssetType.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""AssetType.History"" displayname=""AttributeDefinition'History'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Now"" tokenref=""AssetType.Now"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""AssetType.AssetType"" displayname=""AttributeDefinition'AssetType'AssetType"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/AssetType"" tokenref=""AssetType.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""AssetType.Key"" displayname=""AttributeDefinition'Key'AssetType"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Key"" tokenref=""AssetType.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""AssetType.Moment"" displayname=""AttributeDefinition'Moment'AssetType"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Moment"" tokenref=""AssetType.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""AssetType.Is"" displayname=""AttributeDefinition'Is'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""AssetType.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeDate"" tokenref=""AssetType.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""AssetType.RetireDate"" displayname=""AttributeDefinition'RetireDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireDate"" tokenref=""AssetType.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""AssetType.CreateDate"" displayname=""AttributeDefinition'CreateDate'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateDate"" tokenref=""AssetType.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""AssetType.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeDateUTC"" tokenref=""AssetType.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""AssetType.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireDateUTC"" tokenref=""AssetType.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""AssetType.Days"" displayname=""AttributeDefinition'Days'AssetType"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Days"" tokenref=""AssetType.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""AssetType.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'AssetType"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateDateUTC"" tokenref=""AssetType.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""AssetType.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeReason"" tokenref=""AssetType.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""AssetType.RetireReason"" displayname=""AttributeDefinition'RetireReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireReason"" tokenref=""AssetType.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""AssetType.CreateReason"" displayname=""AttributeDefinition'CreateReason'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateReason"" tokenref=""AssetType.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""AssetType.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangeComment"" tokenref=""AssetType.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""AssetType.RetireComment"" displayname=""AttributeDefinition'RetireComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetireComment"" tokenref=""AssetType.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""AssetType.CreateComment"" displayname=""AttributeDefinition'CreateComment'AssetType"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreateComment"" tokenref=""AssetType.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""AssetType.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangedBy.Name"" tokenref=""AssetType.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/ChangedBy.Name"" tokenref=""AssetType.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""AssetType.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetiredBy.Name"" tokenref=""AssetType.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/RetiredBy.Name"" tokenref=""AssetType.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""AssetType.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreatedBy.Name"" tokenref=""AssetType.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/CreatedBy.Name"" tokenref=""AssetType.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""AssetType.Viewers"" displayname=""AttributeDefinition'Viewers'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""AssetType.Prior"" displayname=""AttributeDefinition'Prior'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Prior.Order"" tokenref=""AssetType.Prior.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Prior.Name"" tokenref=""AssetType.Prior.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""VisibleToCollaborator"" token=""AssetType.VisibleToCollaborator"" displayname=""AttributeDefinition'VisibleToCollaborator'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/VisibleToCollaborator"" tokenref=""AssetType.VisibleToCollaborator"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ListValidValuesFilter"" token=""AssetType.ListValidValuesFilter"" displayname=""AttributeDefinition'ListValidValuesFilter'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ListValidValuesFilter"" tokenref=""AssetType.ListValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""EventDefinitions"" token=""AssetType.EventDefinitions"" displayname=""AttributeDefinition'EventDefinitions'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/EventDefinition/Asset"" tokenref=""EventDefinition.Asset"" />
            <RelatedAsset nameref=""EventDefinition"" href=""/v1sdktesting/meta.v1/EventDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""UseViewRightsForUpdate"" token=""AssetType.UseViewRightsForUpdate"" displayname=""AttributeDefinition'UseViewRightsForUpdate'AssetType"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UseViewRightsForUpdate"" tokenref=""AssetType.UseViewRightsForUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""SecureViaRelation"" token=""AssetType.SecureViaRelation"" displayname=""AttributeDefinition'SecureViaRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/SecureViaRelation"" tokenref=""AssetType.SecureViaRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""VisibleToInstigator"" token=""AssetType.VisibleToInstigator"" displayname=""AttributeDefinition'VisibleToInstigator'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/VisibleToInstigator"" tokenref=""AssetType.VisibleToInstigator"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""AssetType.IsCustom"" displayname=""AttributeDefinition'IsCustom'AssetType"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsCustom"" tokenref=""AssetType.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""DefaultHierarchyAttribute"" token=""AssetType.DefaultHierarchyAttribute"" displayname=""AttributeDefinition'DefaultHierarchyAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/DefaultHierarchyAttribute"" tokenref=""AssetType.DefaultHierarchyAttribute"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Base"" token=""AssetType.Base"" displayname=""AttributeDefinition'Base'AssetType"" attributetype=""Relation"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypes"" tokenref=""AssetType.AssetTypes"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Base.Order"" tokenref=""AssetType.Base.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetType/Base.Name"" tokenref=""AssetType.Base.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetTypes"" token=""AssetType.AssetTypes"" displayname=""AttributeDefinition'AssetTypes'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Base"" tokenref=""AssetType.Base"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""BaseMeAndUp"" token=""AssetType.BaseMeAndUp"" displayname=""AttributeDefinition'BaseMeAndUp'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesMeAndDown"" tokenref=""AssetType.AssetTypesMeAndDown"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""BaseAndUp"" token=""AssetType.BaseAndUp"" displayname=""AttributeDefinition'BaseAndUp'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesAndDown"" tokenref=""AssetType.AssetTypesAndDown"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""BaseAndMe"" token=""AssetType.BaseAndMe"" displayname=""AttributeDefinition'BaseAndMe'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AssetTypesAndMe"" tokenref=""AssetType.AssetTypesAndMe"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetTypesMeAndDown"" token=""AssetType.AssetTypesMeAndDown"" displayname=""AttributeDefinition'AssetTypesMeAndDown'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseMeAndUp"" tokenref=""AssetType.BaseMeAndUp"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetTypesAndDown"" token=""AssetType.AssetTypesAndDown"" displayname=""AttributeDefinition'AssetTypesAndDown'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseAndUp"" tokenref=""AssetType.BaseAndUp"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetTypesAndMe"" token=""AssetType.AssetTypesAndMe"" displayname=""AttributeDefinition'AssetTypesAndMe'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/BaseAndMe"" tokenref=""AssetType.BaseAndMe"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Operations"" token=""AssetType.Operations"" displayname=""AttributeDefinition'Operations'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Operation/Asset"" tokenref=""Operation.Asset"" />
            <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Overrides"" token=""AssetType.Overrides"" displayname=""AttributeDefinition'Overrides'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Override/Asset"" tokenref=""Override.Asset"" />
            <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeDefinitions"" token=""AssetType.AttributeDefinitions"" displayname=""AttributeDefinition'AttributeDefinitions'AssetType"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Order"" token=""AssetType.Order"" displayname=""AttributeDefinition'Order'AssetType"" attributetype=""Rank"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Order"" tokenref=""AssetType.Order"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NumberPattern"" token=""AssetType.NumberPattern"" displayname=""AttributeDefinition'NumberPattern'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NumberPattern"" tokenref=""AssetType.NumberPattern"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Resolver"" token=""AssetType.Resolver"" displayname=""AttributeDefinition'Resolver'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Resolver"" tokenref=""AssetType.Resolver"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NameResolutionAttributes"" token=""AssetType.NameResolutionAttributes"" displayname=""AttributeDefinition'NameResolutionAttributes'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NameResolutionAttributes"" tokenref=""AssetType.NameResolutionAttributes"" />
        </AttributeDefinition>
        <AttributeDefinition name=""DefaultOrderByAttribute"" token=""AssetType.DefaultOrderByAttribute"" displayname=""AttributeDefinition'DefaultOrderByAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/DefaultOrderByAttribute"" tokenref=""AssetType.DefaultOrderByAttribute"" />
        </AttributeDefinition>
        <AttributeDefinition name=""UpdatePrivileges"" token=""AssetType.UpdatePrivileges"" displayname=""AttributeDefinition'UpdatePrivileges'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UpdatePrivileges"" tokenref=""AssetType.UpdatePrivileges"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewSecurityScopeRelation"" token=""AssetType.NewSecurityScopeRelation"" displayname=""AttributeDefinition'NewSecurityScopeRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/NewSecurityScopeRelation"" tokenref=""AssetType.NewSecurityScopeRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""SecurityScopeRelation"" token=""AssetType.SecurityScopeRelation"" displayname=""AttributeDefinition'SecurityScopeRelation'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/SecurityScopeRelation"" tokenref=""AssetType.SecurityScopeRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""UpdateRights"" token=""AssetType.UpdateRights"" displayname=""AttributeDefinition'UpdateRights'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/UpdateRights"" tokenref=""AssetType.UpdateRights"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ViewRights"" token=""AssetType.ViewRights"" displayname=""AttributeDefinition'ViewRights'AssetType"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ViewRights"" tokenref=""AssetType.ViewRights"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Initializer"" token=""AssetType.Initializer"" displayname=""AttributeDefinition'Initializer'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Initializer"" tokenref=""AssetType.Initializer"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ShortNameAttribute"" token=""AssetType.ShortNameAttribute"" displayname=""AttributeDefinition'ShortNameAttribute'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/ShortNameAttribute"" tokenref=""AssetType.ShortNameAttribute"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""AssetType.Name"" displayname=""AttributeDefinition'Name'AssetType"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/Name"" tokenref=""AssetType.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""AssetType.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsReadOnly"" tokenref=""AssetType.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""AssetType.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsDeletable"" tokenref=""AssetType.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""AssetType.IsCanned"" displayname=""AttributeDefinition'IsCanned'AssetType"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetType/IsCanned"" tokenref=""AssetType.IsCanned"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""AttributeDefinition"" token=""AttributeDefinition"" displayname=""AssetType'AttributeDefinition"" abstract=""True"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
        <AttributeDefinition name=""ID"" token=""AttributeDefinition.ID"" displayname=""AttributeDefinition'ID'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AttributeDefinition/ID"" tokenref=""AttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ID"" tokenref=""AttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""AttributeDefinition.Now"" displayname=""AttributeDefinition'Now'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AttributeDefinition/ID"" tokenref=""AttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Now"" tokenref=""AttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""AttributeDefinition.History"" displayname=""AttributeDefinition'History'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AttributeDefinition/Now"" tokenref=""AttributeDefinition.Now"" />
            <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""AttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'AttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetType"" tokenref=""AttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""AttributeDefinition.Key"" displayname=""AttributeDefinition'Key'AttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Key"" tokenref=""AttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""AttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'AttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Moment"" tokenref=""AttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""AttributeDefinition.Is"" displayname=""AttributeDefinition'Is'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""AttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""AttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""AttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""AttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""AttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""AttributeDefinition.Days"" displayname=""AttributeDefinition'Days'AttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""AttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'AttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""AttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""AttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""AttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""AttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""AttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""AttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'AttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""AttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy.Name"" tokenref=""AttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy.Name"" tokenref=""AttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""AttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy.Name"" tokenref=""AttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy.Name"" tokenref=""AttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""AttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy.Name"" tokenref=""AttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy.Name"" tokenref=""AttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""AttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""AttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'AttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior.Name"" tokenref=""AttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior.Name"" tokenref=""AttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetState"" token=""AttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'AttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""AttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'AttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset.Order"" tokenref=""AttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset.Name"" tokenref=""AttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""AttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""AttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""AttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""AttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""AttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""AttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'AttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""AttributeDefinition.Name"" displayname=""AttributeDefinition'Name'AttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""AttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/CanUpdate"" tokenref=""AttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""AttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""AttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""AttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'AttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""RelationDefinition"" token=""RelationDefinition"" displayname=""AssetType'RelationDefinition"" abstract=""True"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""RelationDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangeDate"" tokenref=""RelationDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""RelationDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetireDate"" tokenref=""RelationDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""RelationDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreateDate"" tokenref=""RelationDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""RelationDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangeDateUTC"" tokenref=""RelationDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""RelationDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetireDateUTC"" tokenref=""RelationDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""RelationDefinition.Days"" displayname=""AttributeDefinition'Days'RelationDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Days"" tokenref=""RelationDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""RelationDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'RelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreateDateUTC"" tokenref=""RelationDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""RelationDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangeReason"" tokenref=""RelationDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""RelationDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetireReason"" tokenref=""RelationDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""RelationDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreateReason"" tokenref=""RelationDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""RelationDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangeComment"" tokenref=""RelationDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""RelationDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetireComment"" tokenref=""RelationDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""RelationDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'RelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreateComment"" tokenref=""RelationDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""RelationDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangedBy.Name"" tokenref=""RelationDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ChangedBy.Name"" tokenref=""RelationDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""RelationDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetiredBy.Name"" tokenref=""RelationDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RetiredBy.Name"" tokenref=""RelationDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""RelationDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreatedBy.Name"" tokenref=""RelationDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CreatedBy.Name"" tokenref=""RelationDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""RelationDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""RelationDefinition.Prior"" displayname=""AttributeDefinition'Prior'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Prior.Name"" tokenref=""RelationDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Prior.Name"" tokenref=""RelationDefinition.Prior.Name"" />
            <RelatedAsset nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""RelationDefinition.ID"" displayname=""AttributeDefinition'ID'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/RelationDefinition/ID"" tokenref=""RelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ID"" tokenref=""RelationDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
            <RelatedAsset nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""RelationDefinition.Now"" displayname=""AttributeDefinition'Now'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/RelationDefinition/ID"" tokenref=""RelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Now"" tokenref=""RelationDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
            <RelatedAsset nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""RelationDefinition.History"" displayname=""AttributeDefinition'History'RelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/RelationDefinition/Now"" tokenref=""RelationDefinition.Now"" />
            <RelatedAsset nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""RelationDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'RelationDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/AssetType"" tokenref=""RelationDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""RelationDefinition.Key"" displayname=""AttributeDefinition'Key'RelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Key"" tokenref=""RelationDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""RelationDefinition.Moment"" displayname=""AttributeDefinition'Moment'RelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Moment"" tokenref=""RelationDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""RelationDefinition.Is"" displayname=""AttributeDefinition'Is'RelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ReverseNewQuickValuesFilter"" token=""RelationDefinition.ReverseNewQuickValuesFilter"" displayname=""AttributeDefinition'ReverseNewQuickValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""RelationDefinition.ReverseNewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewQuickValuesFilter"" token=""RelationDefinition.NewQuickValuesFilter"" displayname=""AttributeDefinition'NewQuickValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/NewQuickValuesFilter"" tokenref=""RelationDefinition.NewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseQuickValuesFilter"" token=""RelationDefinition.ReverseQuickValuesFilter"" displayname=""AttributeDefinition'ReverseQuickValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseQuickValuesFilter"" tokenref=""RelationDefinition.ReverseQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""QuickValuesFilter"" token=""RelationDefinition.QuickValuesFilter"" displayname=""AttributeDefinition'QuickValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/QuickValuesFilter"" tokenref=""RelationDefinition.QuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetState"" token=""RelationDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'RelationDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/AssetState"" tokenref=""RelationDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RelatedAssetType"" token=""RelationDefinition.RelatedAssetType"" displayname=""AttributeDefinition'RelatedAssetType'RelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RelatedAssetType.Order"" tokenref=""RelationDefinition.RelatedAssetType.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/RelatedAssetType.Name"" tokenref=""RelationDefinition.RelatedAssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""RelationDefinition.Asset"" displayname=""AttributeDefinition'Asset'RelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Asset.Order"" tokenref=""RelationDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Asset.Name"" tokenref=""RelationDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseIsBasic"" token=""RelationDefinition.ReverseIsBasic"" displayname=""AttributeDefinition'ReverseIsBasic'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseIsBasic"" tokenref=""RelationDefinition.ReverseIsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseNewValidValuesFilter"" token=""RelationDefinition.ReverseNewValidValuesFilter"" displayname=""AttributeDefinition'ReverseNewValidValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewValidValuesFilter"" tokenref=""RelationDefinition.ReverseNewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseValidValuesFilter"" token=""RelationDefinition.ReverseValidValuesFilter"" displayname=""AttributeDefinition'ReverseValidValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseValidValuesFilter"" tokenref=""RelationDefinition.ReverseValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewValidValuesFilter"" token=""RelationDefinition.NewValidValuesFilter"" displayname=""AttributeDefinition'NewValidValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/NewValidValuesFilter"" tokenref=""RelationDefinition.NewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ValidValuesFilter"" token=""RelationDefinition.ValidValuesFilter"" displayname=""AttributeDefinition'ValidValuesFilter'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ValidValuesFilter"" tokenref=""RelationDefinition.ValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseName"" token=""RelationDefinition.ReverseName"" displayname=""AttributeDefinition'ReverseName'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseName"" tokenref=""RelationDefinition.ReverseName"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""RelationDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsBasic"" tokenref=""RelationDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""RelationDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/NativeValue"" tokenref=""RelationDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""RelationDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsCustom"" tokenref=""RelationDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""RelationDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsReadOnly"" tokenref=""RelationDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""RelationDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'RelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsRequired"" tokenref=""RelationDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""RelationDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/AttributeType"" tokenref=""RelationDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""RelationDefinition.Name"" displayname=""AttributeDefinition'Name'RelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/Name"" tokenref=""RelationDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""RelationDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'RelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/CanUpdate"" tokenref=""RelationDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""RelationDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'RelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsCanned"" tokenref=""RelationDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""RelationDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'RelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsDeletable"" tokenref=""RelationDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""RelationDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'RelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/RelationDefinition/IsDeleted"" tokenref=""RelationDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/RelationDefinition/IsDeletable"" tokenref=""RelationDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""BaseSyntheticAttributeDefinition"" token=""BaseSyntheticAttributeDefinition"" displayname=""AssetType'BaseSyntheticAttributeDefinition"" abstract=""True"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""BaseSyntheticAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangeDate"" tokenref=""BaseSyntheticAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""BaseSyntheticAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetireDate"" tokenref=""BaseSyntheticAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""BaseSyntheticAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreateDate"" tokenref=""BaseSyntheticAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""BaseSyntheticAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangeDateUTC"" tokenref=""BaseSyntheticAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""BaseSyntheticAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetireDateUTC"" tokenref=""BaseSyntheticAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""BaseSyntheticAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'BaseSyntheticAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Days"" tokenref=""BaseSyntheticAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""BaseSyntheticAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'BaseSyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreateDateUTC"" tokenref=""BaseSyntheticAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""BaseSyntheticAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangeReason"" tokenref=""BaseSyntheticAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""BaseSyntheticAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetireReason"" tokenref=""BaseSyntheticAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""BaseSyntheticAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreateReason"" tokenref=""BaseSyntheticAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""BaseSyntheticAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangeComment"" tokenref=""BaseSyntheticAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""BaseSyntheticAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetireComment"" tokenref=""BaseSyntheticAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""BaseSyntheticAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreateComment"" tokenref=""BaseSyntheticAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""BaseSyntheticAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangedBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ChangedBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""BaseSyntheticAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetiredBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/RetiredBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""BaseSyntheticAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreatedBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CreatedBy.Name"" tokenref=""BaseSyntheticAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""BaseSyntheticAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""BaseSyntheticAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Prior.Name"" tokenref=""BaseSyntheticAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Prior.Name"" tokenref=""BaseSyntheticAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""BaseSyntheticAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ID"" tokenref=""BaseSyntheticAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ID"" tokenref=""BaseSyntheticAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
            <RelatedAsset nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""BaseSyntheticAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/ID"" tokenref=""BaseSyntheticAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Now"" tokenref=""BaseSyntheticAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
            <RelatedAsset nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""BaseSyntheticAttributeDefinition.History"" displayname=""AttributeDefinition'History'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Now"" tokenref=""BaseSyntheticAttributeDefinition.Now"" />
            <RelatedAsset nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""BaseSyntheticAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'BaseSyntheticAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/AssetType"" tokenref=""BaseSyntheticAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""BaseSyntheticAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'BaseSyntheticAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Key"" tokenref=""BaseSyntheticAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""BaseSyntheticAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'BaseSyntheticAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Moment"" tokenref=""BaseSyntheticAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""BaseSyntheticAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""BaseSyntheticAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'BaseSyntheticAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/AssetState"" tokenref=""BaseSyntheticAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""BaseSyntheticAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'BaseSyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Asset.Order"" tokenref=""BaseSyntheticAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Asset.Name"" tokenref=""BaseSyntheticAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Parameter"" token=""BaseSyntheticAttributeDefinition.Parameter"" displayname=""AttributeDefinition'Parameter'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Parameter"" tokenref=""BaseSyntheticAttributeDefinition.Parameter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Calculation"" token=""BaseSyntheticAttributeDefinition.Calculation"" displayname=""AttributeDefinition'Calculation'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Calculation"" tokenref=""BaseSyntheticAttributeDefinition.Calculation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""BaseSyntheticAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsBasic"" tokenref=""BaseSyntheticAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""BaseSyntheticAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/NativeValue"" tokenref=""BaseSyntheticAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""BaseSyntheticAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsCustom"" tokenref=""BaseSyntheticAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""BaseSyntheticAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsReadOnly"" tokenref=""BaseSyntheticAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""BaseSyntheticAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsRequired"" tokenref=""BaseSyntheticAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""BaseSyntheticAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/AttributeType"" tokenref=""BaseSyntheticAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""BaseSyntheticAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'BaseSyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Name"" tokenref=""BaseSyntheticAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""BaseSyntheticAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/CanUpdate"" tokenref=""BaseSyntheticAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""BaseSyntheticAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsCanned"" tokenref=""BaseSyntheticAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""BaseSyntheticAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsDeletable"" tokenref=""BaseSyntheticAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""BaseSyntheticAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'BaseSyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsDeleted"" tokenref=""BaseSyntheticAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/IsDeletable"" tokenref=""BaseSyntheticAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""SimpleAttributeDefinition"" token=""SimpleAttributeDefinition"" displayname=""AssetType'SimpleAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""SimpleAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangeDate"" tokenref=""SimpleAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""SimpleAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetireDate"" tokenref=""SimpleAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""SimpleAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreateDate"" tokenref=""SimpleAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""SimpleAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangeDateUTC"" tokenref=""SimpleAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""SimpleAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetireDateUTC"" tokenref=""SimpleAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""SimpleAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'SimpleAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Days"" tokenref=""SimpleAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""SimpleAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'SimpleAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreateDateUTC"" tokenref=""SimpleAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""SimpleAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangeReason"" tokenref=""SimpleAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""SimpleAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetireReason"" tokenref=""SimpleAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""SimpleAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreateReason"" tokenref=""SimpleAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""SimpleAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangeComment"" tokenref=""SimpleAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""SimpleAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetireComment"" tokenref=""SimpleAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""SimpleAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreateComment"" tokenref=""SimpleAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""SimpleAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangedBy.Name"" tokenref=""SimpleAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ChangedBy.Name"" tokenref=""SimpleAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""SimpleAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetiredBy.Name"" tokenref=""SimpleAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/RetiredBy.Name"" tokenref=""SimpleAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""SimpleAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreatedBy.Name"" tokenref=""SimpleAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CreatedBy.Name"" tokenref=""SimpleAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""SimpleAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""SimpleAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Prior.Name"" tokenref=""SimpleAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Prior.Name"" tokenref=""SimpleAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""SimpleAttributeDefinition"" href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""SimpleAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ID"" tokenref=""SimpleAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ID"" tokenref=""SimpleAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
            <RelatedAsset nameref=""SimpleAttributeDefinition"" href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""SimpleAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/ID"" tokenref=""SimpleAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Now"" tokenref=""SimpleAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
            <RelatedAsset nameref=""SimpleAttributeDefinition"" href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""SimpleAttributeDefinition.History"" displayname=""AttributeDefinition'History'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Now"" tokenref=""SimpleAttributeDefinition.Now"" />
            <RelatedAsset nameref=""SimpleAttributeDefinition"" href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""SimpleAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'SimpleAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/AssetType"" tokenref=""SimpleAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""SimpleAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'SimpleAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Key"" tokenref=""SimpleAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""SimpleAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'SimpleAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Moment"" tokenref=""SimpleAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""SimpleAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""SimpleAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'SimpleAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/AssetState"" tokenref=""SimpleAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""SimpleAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'SimpleAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Asset.Order"" tokenref=""SimpleAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Asset.Name"" tokenref=""SimpleAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""SimpleAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsBasic"" tokenref=""SimpleAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""SimpleAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/NativeValue"" tokenref=""SimpleAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""SimpleAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsCustom"" tokenref=""SimpleAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""SimpleAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsReadOnly"" tokenref=""SimpleAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""SimpleAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsRequired"" tokenref=""SimpleAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""SimpleAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/AttributeType"" tokenref=""SimpleAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""SimpleAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'SimpleAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/Name"" tokenref=""SimpleAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""SimpleAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/CanUpdate"" tokenref=""SimpleAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""SimpleAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsCanned"" tokenref=""SimpleAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""SimpleAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsDeletable"" tokenref=""SimpleAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""SimpleAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'SimpleAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsDeleted"" tokenref=""SimpleAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/SimpleAttributeDefinition/IsDeletable"" tokenref=""SimpleAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""CredentialsAttributeDefinition"" token=""CredentialsAttributeDefinition"" displayname=""AssetType'CredentialsAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""CredentialsAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangeDate"" tokenref=""CredentialsAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""CredentialsAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetireDate"" tokenref=""CredentialsAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""CredentialsAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreateDate"" tokenref=""CredentialsAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""CredentialsAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangeDateUTC"" tokenref=""CredentialsAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""CredentialsAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetireDateUTC"" tokenref=""CredentialsAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""CredentialsAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'CredentialsAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Days"" tokenref=""CredentialsAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""CredentialsAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'CredentialsAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreateDateUTC"" tokenref=""CredentialsAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""CredentialsAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangeReason"" tokenref=""CredentialsAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""CredentialsAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetireReason"" tokenref=""CredentialsAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""CredentialsAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreateReason"" tokenref=""CredentialsAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""CredentialsAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangeComment"" tokenref=""CredentialsAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""CredentialsAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetireComment"" tokenref=""CredentialsAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""CredentialsAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreateComment"" tokenref=""CredentialsAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""CredentialsAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangedBy.Name"" tokenref=""CredentialsAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ChangedBy.Name"" tokenref=""CredentialsAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""CredentialsAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetiredBy.Name"" tokenref=""CredentialsAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/RetiredBy.Name"" tokenref=""CredentialsAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""CredentialsAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreatedBy.Name"" tokenref=""CredentialsAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CreatedBy.Name"" tokenref=""CredentialsAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""CredentialsAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""CredentialsAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Prior.Name"" tokenref=""CredentialsAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Prior.Name"" tokenref=""CredentialsAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""CredentialsAttributeDefinition"" href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""CredentialsAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ID"" tokenref=""CredentialsAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ID"" tokenref=""CredentialsAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
            <RelatedAsset nameref=""CredentialsAttributeDefinition"" href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""CredentialsAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/ID"" tokenref=""CredentialsAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Now"" tokenref=""CredentialsAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
            <RelatedAsset nameref=""CredentialsAttributeDefinition"" href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""CredentialsAttributeDefinition.History"" displayname=""AttributeDefinition'History'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Now"" tokenref=""CredentialsAttributeDefinition.Now"" />
            <RelatedAsset nameref=""CredentialsAttributeDefinition"" href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""CredentialsAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'CredentialsAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/AssetType"" tokenref=""CredentialsAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""CredentialsAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'CredentialsAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Key"" tokenref=""CredentialsAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""CredentialsAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'CredentialsAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Moment"" tokenref=""CredentialsAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""CredentialsAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""CredentialsAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'CredentialsAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/AssetState"" tokenref=""CredentialsAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""CredentialsAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'CredentialsAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Asset.Order"" tokenref=""CredentialsAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Asset.Name"" tokenref=""CredentialsAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""CredentialsAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsBasic"" tokenref=""CredentialsAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""CredentialsAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/NativeValue"" tokenref=""CredentialsAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""CredentialsAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsCustom"" tokenref=""CredentialsAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""CredentialsAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsReadOnly"" tokenref=""CredentialsAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""CredentialsAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsRequired"" tokenref=""CredentialsAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""CredentialsAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/AttributeType"" tokenref=""CredentialsAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""CredentialsAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'CredentialsAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/Name"" tokenref=""CredentialsAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""CredentialsAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/CanUpdate"" tokenref=""CredentialsAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""CredentialsAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsCanned"" tokenref=""CredentialsAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""CredentialsAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsDeletable"" tokenref=""CredentialsAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""CredentialsAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'CredentialsAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsDeleted"" tokenref=""CredentialsAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/CredentialsAttributeDefinition/IsDeletable"" tokenref=""CredentialsAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""PrincipalAttributeDefinition"" token=""PrincipalAttributeDefinition"" displayname=""AssetType'PrincipalAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""PrincipalAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangeDate"" tokenref=""PrincipalAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""PrincipalAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetireDate"" tokenref=""PrincipalAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""PrincipalAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreateDate"" tokenref=""PrincipalAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""PrincipalAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangeDateUTC"" tokenref=""PrincipalAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""PrincipalAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetireDateUTC"" tokenref=""PrincipalAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""PrincipalAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'PrincipalAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Days"" tokenref=""PrincipalAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""PrincipalAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'PrincipalAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreateDateUTC"" tokenref=""PrincipalAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""PrincipalAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangeReason"" tokenref=""PrincipalAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""PrincipalAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetireReason"" tokenref=""PrincipalAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""PrincipalAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreateReason"" tokenref=""PrincipalAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""PrincipalAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangeComment"" tokenref=""PrincipalAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""PrincipalAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetireComment"" tokenref=""PrincipalAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""PrincipalAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreateComment"" tokenref=""PrincipalAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""PrincipalAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangedBy.Name"" tokenref=""PrincipalAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ChangedBy.Name"" tokenref=""PrincipalAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""PrincipalAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetiredBy.Name"" tokenref=""PrincipalAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/RetiredBy.Name"" tokenref=""PrincipalAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""PrincipalAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreatedBy.Name"" tokenref=""PrincipalAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CreatedBy.Name"" tokenref=""PrincipalAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""PrincipalAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""PrincipalAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Prior.Name"" tokenref=""PrincipalAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Prior.Name"" tokenref=""PrincipalAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""PrincipalAttributeDefinition"" href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""PrincipalAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ID"" tokenref=""PrincipalAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ID"" tokenref=""PrincipalAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
            <RelatedAsset nameref=""PrincipalAttributeDefinition"" href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""PrincipalAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/ID"" tokenref=""PrincipalAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Now"" tokenref=""PrincipalAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
            <RelatedAsset nameref=""PrincipalAttributeDefinition"" href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""PrincipalAttributeDefinition.History"" displayname=""AttributeDefinition'History'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Now"" tokenref=""PrincipalAttributeDefinition.Now"" />
            <RelatedAsset nameref=""PrincipalAttributeDefinition"" href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""PrincipalAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'PrincipalAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/AssetType"" tokenref=""PrincipalAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""PrincipalAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'PrincipalAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Key"" tokenref=""PrincipalAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""PrincipalAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'PrincipalAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Moment"" tokenref=""PrincipalAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""PrincipalAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""PrincipalAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'PrincipalAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/AssetState"" tokenref=""PrincipalAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""PrincipalAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'PrincipalAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Asset.Order"" tokenref=""PrincipalAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Asset.Name"" tokenref=""PrincipalAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""PrincipalAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsBasic"" tokenref=""PrincipalAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""PrincipalAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/NativeValue"" tokenref=""PrincipalAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""PrincipalAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsCustom"" tokenref=""PrincipalAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""PrincipalAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsReadOnly"" tokenref=""PrincipalAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""PrincipalAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsRequired"" tokenref=""PrincipalAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""PrincipalAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/AttributeType"" tokenref=""PrincipalAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""PrincipalAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'PrincipalAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/Name"" tokenref=""PrincipalAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""PrincipalAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/CanUpdate"" tokenref=""PrincipalAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""PrincipalAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsCanned"" tokenref=""PrincipalAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""PrincipalAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsDeletable"" tokenref=""PrincipalAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""PrincipalAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'PrincipalAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsDeleted"" tokenref=""PrincipalAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/PrincipalAttributeDefinition/IsDeletable"" tokenref=""PrincipalAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""PasswordAttributeDefinition"" token=""PasswordAttributeDefinition"" displayname=""AssetType'PasswordAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""PasswordAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangeDate"" tokenref=""PasswordAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""PasswordAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetireDate"" tokenref=""PasswordAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""PasswordAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreateDate"" tokenref=""PasswordAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""PasswordAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangeDateUTC"" tokenref=""PasswordAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""PasswordAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetireDateUTC"" tokenref=""PasswordAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""PasswordAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'PasswordAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Days"" tokenref=""PasswordAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""PasswordAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'PasswordAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreateDateUTC"" tokenref=""PasswordAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""PasswordAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangeReason"" tokenref=""PasswordAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""PasswordAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetireReason"" tokenref=""PasswordAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""PasswordAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreateReason"" tokenref=""PasswordAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""PasswordAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangeComment"" tokenref=""PasswordAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""PasswordAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetireComment"" tokenref=""PasswordAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""PasswordAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreateComment"" tokenref=""PasswordAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""PasswordAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangedBy.Name"" tokenref=""PasswordAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ChangedBy.Name"" tokenref=""PasswordAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""PasswordAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetiredBy.Name"" tokenref=""PasswordAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/RetiredBy.Name"" tokenref=""PasswordAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""PasswordAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreatedBy.Name"" tokenref=""PasswordAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CreatedBy.Name"" tokenref=""PasswordAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""PasswordAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""PasswordAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Prior.Name"" tokenref=""PasswordAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Prior.Name"" tokenref=""PasswordAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""PasswordAttributeDefinition"" href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""PasswordAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ID"" tokenref=""PasswordAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ID"" tokenref=""PasswordAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
            <RelatedAsset nameref=""PasswordAttributeDefinition"" href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""PasswordAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/ID"" tokenref=""PasswordAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Now"" tokenref=""PasswordAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
            <RelatedAsset nameref=""PasswordAttributeDefinition"" href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""PasswordAttributeDefinition.History"" displayname=""AttributeDefinition'History'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Now"" tokenref=""PasswordAttributeDefinition.Now"" />
            <RelatedAsset nameref=""PasswordAttributeDefinition"" href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""PasswordAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'PasswordAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/AssetType"" tokenref=""PasswordAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""PasswordAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'PasswordAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Key"" tokenref=""PasswordAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""PasswordAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'PasswordAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Moment"" tokenref=""PasswordAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""PasswordAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""PasswordAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'PasswordAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/AssetState"" tokenref=""PasswordAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""PasswordAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'PasswordAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Asset.Order"" tokenref=""PasswordAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Asset.Name"" tokenref=""PasswordAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""PasswordAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsBasic"" tokenref=""PasswordAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""PasswordAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/NativeValue"" tokenref=""PasswordAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""PasswordAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsCustom"" tokenref=""PasswordAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""PasswordAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsReadOnly"" tokenref=""PasswordAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""PasswordAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsRequired"" tokenref=""PasswordAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""PasswordAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/AttributeType"" tokenref=""PasswordAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""PasswordAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'PasswordAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/Name"" tokenref=""PasswordAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""PasswordAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/CanUpdate"" tokenref=""PasswordAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""PasswordAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsCanned"" tokenref=""PasswordAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""PasswordAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsDeletable"" tokenref=""PasswordAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""PasswordAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'PasswordAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsDeleted"" tokenref=""PasswordAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/PasswordAttributeDefinition/IsDeletable"" tokenref=""PasswordAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""AssetNumberAttributeDefinition"" token=""AssetNumberAttributeDefinition"" displayname=""AssetType'AssetNumberAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""AssetNumberAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangeDate"" tokenref=""AssetNumberAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""AssetNumberAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetireDate"" tokenref=""AssetNumberAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""AssetNumberAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreateDate"" tokenref=""AssetNumberAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""AssetNumberAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangeDateUTC"" tokenref=""AssetNumberAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""AssetNumberAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetireDateUTC"" tokenref=""AssetNumberAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""AssetNumberAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'AssetNumberAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Days"" tokenref=""AssetNumberAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""AssetNumberAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'AssetNumberAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreateDateUTC"" tokenref=""AssetNumberAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""AssetNumberAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangeReason"" tokenref=""AssetNumberAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""AssetNumberAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetireReason"" tokenref=""AssetNumberAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""AssetNumberAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreateReason"" tokenref=""AssetNumberAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""AssetNumberAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangeComment"" tokenref=""AssetNumberAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""AssetNumberAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetireComment"" tokenref=""AssetNumberAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""AssetNumberAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreateComment"" tokenref=""AssetNumberAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""AssetNumberAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangedBy.Name"" tokenref=""AssetNumberAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ChangedBy.Name"" tokenref=""AssetNumberAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""AssetNumberAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetiredBy.Name"" tokenref=""AssetNumberAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/RetiredBy.Name"" tokenref=""AssetNumberAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""AssetNumberAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreatedBy.Name"" tokenref=""AssetNumberAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CreatedBy.Name"" tokenref=""AssetNumberAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""AssetNumberAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""AssetNumberAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Prior.Name"" tokenref=""AssetNumberAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Prior.Name"" tokenref=""AssetNumberAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""AssetNumberAttributeDefinition"" href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""AssetNumberAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ID"" tokenref=""AssetNumberAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ID"" tokenref=""AssetNumberAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
            <RelatedAsset nameref=""AssetNumberAttributeDefinition"" href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""AssetNumberAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/ID"" tokenref=""AssetNumberAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Now"" tokenref=""AssetNumberAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
            <RelatedAsset nameref=""AssetNumberAttributeDefinition"" href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""AssetNumberAttributeDefinition.History"" displayname=""AttributeDefinition'History'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Now"" tokenref=""AssetNumberAttributeDefinition.Now"" />
            <RelatedAsset nameref=""AssetNumberAttributeDefinition"" href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""AssetNumberAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'AssetNumberAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/AssetType"" tokenref=""AssetNumberAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""AssetNumberAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'AssetNumberAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Key"" tokenref=""AssetNumberAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""AssetNumberAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'AssetNumberAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Moment"" tokenref=""AssetNumberAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""AssetNumberAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""AssetNumberAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'AssetNumberAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/AssetState"" tokenref=""AssetNumberAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""AssetNumberAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'AssetNumberAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Asset.Order"" tokenref=""AssetNumberAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Asset.Name"" tokenref=""AssetNumberAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""AssetNumberAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsBasic"" tokenref=""AssetNumberAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""AssetNumberAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/NativeValue"" tokenref=""AssetNumberAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""AssetNumberAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsCustom"" tokenref=""AssetNumberAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""AssetNumberAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsReadOnly"" tokenref=""AssetNumberAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""AssetNumberAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsRequired"" tokenref=""AssetNumberAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""AssetNumberAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/AttributeType"" tokenref=""AssetNumberAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""AssetNumberAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'AssetNumberAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/Name"" tokenref=""AssetNumberAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""AssetNumberAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/CanUpdate"" tokenref=""AssetNumberAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""AssetNumberAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsCanned"" tokenref=""AssetNumberAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""AssetNumberAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsDeletable"" tokenref=""AssetNumberAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""AssetNumberAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'AssetNumberAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsDeleted"" tokenref=""AssetNumberAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/AssetNumberAttributeDefinition/IsDeletable"" tokenref=""AssetNumberAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""UpdateSecurityCheckAttributeDefinition"" token=""UpdateSecurityCheckAttributeDefinition"" displayname=""AssetType'UpdateSecurityCheckAttributeDefinition"" abstract=""False"">
        <Base nameref=""AttributeDefinition"" href=""/v1sdktesting/meta.v1/AttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""UpdateSecurityCheckAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangeDate"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""UpdateSecurityCheckAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetireDate"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""UpdateSecurityCheckAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreateDate"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""UpdateSecurityCheckAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangeDateUTC"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""UpdateSecurityCheckAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetireDateUTC"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""UpdateSecurityCheckAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'UpdateSecurityCheckAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Days"" tokenref=""UpdateSecurityCheckAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""UpdateSecurityCheckAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'UpdateSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreateDateUTC"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""UpdateSecurityCheckAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangeReason"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""UpdateSecurityCheckAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetireReason"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""UpdateSecurityCheckAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreateReason"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""UpdateSecurityCheckAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangeComment"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""UpdateSecurityCheckAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetireComment"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""UpdateSecurityCheckAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreateComment"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""UpdateSecurityCheckAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangedBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ChangedBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""UpdateSecurityCheckAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetiredBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/RetiredBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""UpdateSecurityCheckAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreatedBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CreatedBy.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""UpdateSecurityCheckAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""UpdateSecurityCheckAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Prior.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Prior.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""UpdateSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""UpdateSecurityCheckAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ID"" tokenref=""UpdateSecurityCheckAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ID"" tokenref=""UpdateSecurityCheckAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
            <RelatedAsset nameref=""UpdateSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""UpdateSecurityCheckAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/ID"" tokenref=""UpdateSecurityCheckAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Now"" tokenref=""UpdateSecurityCheckAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
            <RelatedAsset nameref=""UpdateSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""UpdateSecurityCheckAttributeDefinition.History"" displayname=""AttributeDefinition'History'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Now"" tokenref=""UpdateSecurityCheckAttributeDefinition.Now"" />
            <RelatedAsset nameref=""UpdateSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""UpdateSecurityCheckAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'UpdateSecurityCheckAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/AssetType"" tokenref=""UpdateSecurityCheckAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""UpdateSecurityCheckAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'UpdateSecurityCheckAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Key"" tokenref=""UpdateSecurityCheckAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""UpdateSecurityCheckAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'UpdateSecurityCheckAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Moment"" tokenref=""UpdateSecurityCheckAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""UpdateSecurityCheckAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""UpdateSecurityCheckAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'UpdateSecurityCheckAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/AssetState"" tokenref=""UpdateSecurityCheckAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""UpdateSecurityCheckAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'UpdateSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Asset.Order"" tokenref=""UpdateSecurityCheckAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Asset.Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""UpdateSecurityCheckAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsBasic"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""UpdateSecurityCheckAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/NativeValue"" tokenref=""UpdateSecurityCheckAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""UpdateSecurityCheckAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsCustom"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""UpdateSecurityCheckAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsReadOnly"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""UpdateSecurityCheckAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsRequired"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""UpdateSecurityCheckAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/AttributeType"" tokenref=""UpdateSecurityCheckAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""UpdateSecurityCheckAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'UpdateSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/Name"" tokenref=""UpdateSecurityCheckAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""UpdateSecurityCheckAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/CanUpdate"" tokenref=""UpdateSecurityCheckAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""UpdateSecurityCheckAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsCanned"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""UpdateSecurityCheckAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsDeletable"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""UpdateSecurityCheckAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'UpdateSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsDeleted"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/UpdateSecurityCheckAttributeDefinition/IsDeletable"" tokenref=""UpdateSecurityCheckAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""OneToManyRelationDefinition"" token=""OneToManyRelationDefinition"" displayname=""AssetType'OneToManyRelationDefinition"" abstract=""False"">
        <Base nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""OneToManyRelationDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangeDate"" tokenref=""OneToManyRelationDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""OneToManyRelationDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetireDate"" tokenref=""OneToManyRelationDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""OneToManyRelationDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreateDate"" tokenref=""OneToManyRelationDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""OneToManyRelationDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangeDateUTC"" tokenref=""OneToManyRelationDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""OneToManyRelationDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetireDateUTC"" tokenref=""OneToManyRelationDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""OneToManyRelationDefinition.Days"" displayname=""AttributeDefinition'Days'OneToManyRelationDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Days"" tokenref=""OneToManyRelationDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""OneToManyRelationDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'OneToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreateDateUTC"" tokenref=""OneToManyRelationDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""OneToManyRelationDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangeReason"" tokenref=""OneToManyRelationDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""OneToManyRelationDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetireReason"" tokenref=""OneToManyRelationDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""OneToManyRelationDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreateReason"" tokenref=""OneToManyRelationDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""OneToManyRelationDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangeComment"" tokenref=""OneToManyRelationDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""OneToManyRelationDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetireComment"" tokenref=""OneToManyRelationDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""OneToManyRelationDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreateComment"" tokenref=""OneToManyRelationDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""OneToManyRelationDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangedBy.Name"" tokenref=""OneToManyRelationDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ChangedBy.Name"" tokenref=""OneToManyRelationDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""OneToManyRelationDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetiredBy.Name"" tokenref=""OneToManyRelationDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RetiredBy.Name"" tokenref=""OneToManyRelationDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""OneToManyRelationDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreatedBy.Name"" tokenref=""OneToManyRelationDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CreatedBy.Name"" tokenref=""OneToManyRelationDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""OneToManyRelationDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""OneToManyRelationDefinition.Prior"" displayname=""AttributeDefinition'Prior'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Prior.Name"" tokenref=""OneToManyRelationDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Prior.Name"" tokenref=""OneToManyRelationDefinition.Prior.Name"" />
            <RelatedAsset nameref=""OneToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""OneToManyRelationDefinition.ID"" displayname=""AttributeDefinition'ID'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ID"" tokenref=""OneToManyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ID"" tokenref=""OneToManyRelationDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
            <RelatedAsset nameref=""OneToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""OneToManyRelationDefinition.Now"" displayname=""AttributeDefinition'Now'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ID"" tokenref=""OneToManyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Now"" tokenref=""OneToManyRelationDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
            <RelatedAsset nameref=""OneToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""OneToManyRelationDefinition.History"" displayname=""AttributeDefinition'History'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Now"" tokenref=""OneToManyRelationDefinition.Now"" />
            <RelatedAsset nameref=""OneToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""OneToManyRelationDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'OneToManyRelationDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/AssetType"" tokenref=""OneToManyRelationDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""OneToManyRelationDefinition.Key"" displayname=""AttributeDefinition'Key'OneToManyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Key"" tokenref=""OneToManyRelationDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""OneToManyRelationDefinition.Moment"" displayname=""AttributeDefinition'Moment'OneToManyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Moment"" tokenref=""OneToManyRelationDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""OneToManyRelationDefinition.Is"" displayname=""AttributeDefinition'Is'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ReverseNewQuickValuesFilter"" token=""OneToManyRelationDefinition.ReverseNewQuickValuesFilter"" displayname=""AttributeDefinition'ReverseNewQuickValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""RelationDefinition.ReverseNewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""OneToManyRelationDefinition.ReverseNewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewQuickValuesFilter"" token=""OneToManyRelationDefinition.NewQuickValuesFilter"" displayname=""AttributeDefinition'NewQuickValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewQuickValuesFilter"" tokenref=""RelationDefinition.NewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/NewQuickValuesFilter"" tokenref=""OneToManyRelationDefinition.NewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseQuickValuesFilter"" token=""OneToManyRelationDefinition.ReverseQuickValuesFilter"" displayname=""AttributeDefinition'ReverseQuickValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseQuickValuesFilter"" tokenref=""RelationDefinition.ReverseQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseQuickValuesFilter"" tokenref=""OneToManyRelationDefinition.ReverseQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""QuickValuesFilter"" token=""OneToManyRelationDefinition.QuickValuesFilter"" displayname=""AttributeDefinition'QuickValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/QuickValuesFilter"" tokenref=""RelationDefinition.QuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/QuickValuesFilter"" tokenref=""OneToManyRelationDefinition.QuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetState"" token=""OneToManyRelationDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'OneToManyRelationDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/AssetState"" tokenref=""OneToManyRelationDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RelatedAssetType"" token=""OneToManyRelationDefinition.RelatedAssetType"" displayname=""AttributeDefinition'RelatedAssetType'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/RelatedAssetType"" tokenref=""RelationDefinition.RelatedAssetType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RelatedAssetType.Order"" tokenref=""OneToManyRelationDefinition.RelatedAssetType.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/RelatedAssetType.Name"" tokenref=""OneToManyRelationDefinition.RelatedAssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""OneToManyRelationDefinition.Asset"" displayname=""AttributeDefinition'Asset'OneToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Asset.Order"" tokenref=""OneToManyRelationDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Asset.Name"" tokenref=""OneToManyRelationDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseIsBasic"" token=""OneToManyRelationDefinition.ReverseIsBasic"" displayname=""AttributeDefinition'ReverseIsBasic'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseIsBasic"" tokenref=""RelationDefinition.ReverseIsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseIsBasic"" tokenref=""OneToManyRelationDefinition.ReverseIsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseNewValidValuesFilter"" token=""OneToManyRelationDefinition.ReverseNewValidValuesFilter"" displayname=""AttributeDefinition'ReverseNewValidValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewValidValuesFilter"" tokenref=""RelationDefinition.ReverseNewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseNewValidValuesFilter"" tokenref=""OneToManyRelationDefinition.ReverseNewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseValidValuesFilter"" token=""OneToManyRelationDefinition.ReverseValidValuesFilter"" displayname=""AttributeDefinition'ReverseValidValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseValidValuesFilter"" tokenref=""RelationDefinition.ReverseValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseValidValuesFilter"" tokenref=""OneToManyRelationDefinition.ReverseValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewValidValuesFilter"" token=""OneToManyRelationDefinition.NewValidValuesFilter"" displayname=""AttributeDefinition'NewValidValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewValidValuesFilter"" tokenref=""RelationDefinition.NewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/NewValidValuesFilter"" tokenref=""OneToManyRelationDefinition.NewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ValidValuesFilter"" token=""OneToManyRelationDefinition.ValidValuesFilter"" displayname=""AttributeDefinition'ValidValuesFilter'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ValidValuesFilter"" tokenref=""RelationDefinition.ValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ValidValuesFilter"" tokenref=""OneToManyRelationDefinition.ValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseName"" token=""OneToManyRelationDefinition.ReverseName"" displayname=""AttributeDefinition'ReverseName'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseName"" tokenref=""RelationDefinition.ReverseName"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/ReverseName"" tokenref=""OneToManyRelationDefinition.ReverseName"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""OneToManyRelationDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsBasic"" tokenref=""OneToManyRelationDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""OneToManyRelationDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/NativeValue"" tokenref=""OneToManyRelationDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""OneToManyRelationDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsCustom"" tokenref=""OneToManyRelationDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""OneToManyRelationDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsReadOnly"" tokenref=""OneToManyRelationDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""OneToManyRelationDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsRequired"" tokenref=""OneToManyRelationDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""OneToManyRelationDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/AttributeType"" tokenref=""OneToManyRelationDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""OneToManyRelationDefinition.Name"" displayname=""AttributeDefinition'Name'OneToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/Name"" tokenref=""OneToManyRelationDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""OneToManyRelationDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/CanUpdate"" tokenref=""OneToManyRelationDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""OneToManyRelationDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsCanned"" tokenref=""OneToManyRelationDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""OneToManyRelationDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsDeletable"" tokenref=""OneToManyRelationDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""OneToManyRelationDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'OneToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsDeleted"" tokenref=""OneToManyRelationDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/OneToManyRelationDefinition/IsDeletable"" tokenref=""OneToManyRelationDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""HierarchyRelationDefinition"" token=""HierarchyRelationDefinition"" displayname=""AssetType'HierarchyRelationDefinition"" abstract=""False"">
        <Base nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""HierarchyRelationDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangeDate"" tokenref=""HierarchyRelationDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""HierarchyRelationDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetireDate"" tokenref=""HierarchyRelationDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""HierarchyRelationDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreateDate"" tokenref=""HierarchyRelationDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""HierarchyRelationDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangeDateUTC"" tokenref=""HierarchyRelationDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""HierarchyRelationDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetireDateUTC"" tokenref=""HierarchyRelationDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""HierarchyRelationDefinition.Days"" displayname=""AttributeDefinition'Days'HierarchyRelationDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Days"" tokenref=""HierarchyRelationDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""HierarchyRelationDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'HierarchyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreateDateUTC"" tokenref=""HierarchyRelationDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""HierarchyRelationDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangeReason"" tokenref=""HierarchyRelationDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""HierarchyRelationDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetireReason"" tokenref=""HierarchyRelationDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""HierarchyRelationDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreateReason"" tokenref=""HierarchyRelationDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""HierarchyRelationDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangeComment"" tokenref=""HierarchyRelationDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""HierarchyRelationDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetireComment"" tokenref=""HierarchyRelationDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""HierarchyRelationDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreateComment"" tokenref=""HierarchyRelationDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""HierarchyRelationDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangedBy.Name"" tokenref=""HierarchyRelationDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ChangedBy.Name"" tokenref=""HierarchyRelationDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""HierarchyRelationDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetiredBy.Name"" tokenref=""HierarchyRelationDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RetiredBy.Name"" tokenref=""HierarchyRelationDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""HierarchyRelationDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreatedBy.Name"" tokenref=""HierarchyRelationDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CreatedBy.Name"" tokenref=""HierarchyRelationDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""HierarchyRelationDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""HierarchyRelationDefinition.Prior"" displayname=""AttributeDefinition'Prior'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Prior.Name"" tokenref=""HierarchyRelationDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Prior.Name"" tokenref=""HierarchyRelationDefinition.Prior.Name"" />
            <RelatedAsset nameref=""HierarchyRelationDefinition"" href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""HierarchyRelationDefinition.ID"" displayname=""AttributeDefinition'ID'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ID"" tokenref=""HierarchyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ID"" tokenref=""HierarchyRelationDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
            <RelatedAsset nameref=""HierarchyRelationDefinition"" href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""HierarchyRelationDefinition.Now"" displayname=""AttributeDefinition'Now'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ID"" tokenref=""HierarchyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Now"" tokenref=""HierarchyRelationDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
            <RelatedAsset nameref=""HierarchyRelationDefinition"" href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""HierarchyRelationDefinition.History"" displayname=""AttributeDefinition'History'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Now"" tokenref=""HierarchyRelationDefinition.Now"" />
            <RelatedAsset nameref=""HierarchyRelationDefinition"" href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""HierarchyRelationDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'HierarchyRelationDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/AssetType"" tokenref=""HierarchyRelationDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""HierarchyRelationDefinition.Key"" displayname=""AttributeDefinition'Key'HierarchyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Key"" tokenref=""HierarchyRelationDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""HierarchyRelationDefinition.Moment"" displayname=""AttributeDefinition'Moment'HierarchyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Moment"" tokenref=""HierarchyRelationDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""HierarchyRelationDefinition.Is"" displayname=""AttributeDefinition'Is'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ReverseNewQuickValuesFilter"" token=""HierarchyRelationDefinition.ReverseNewQuickValuesFilter"" displayname=""AttributeDefinition'ReverseNewQuickValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""RelationDefinition.ReverseNewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""HierarchyRelationDefinition.ReverseNewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewQuickValuesFilter"" token=""HierarchyRelationDefinition.NewQuickValuesFilter"" displayname=""AttributeDefinition'NewQuickValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewQuickValuesFilter"" tokenref=""RelationDefinition.NewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/NewQuickValuesFilter"" tokenref=""HierarchyRelationDefinition.NewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseQuickValuesFilter"" token=""HierarchyRelationDefinition.ReverseQuickValuesFilter"" displayname=""AttributeDefinition'ReverseQuickValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseQuickValuesFilter"" tokenref=""RelationDefinition.ReverseQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseQuickValuesFilter"" tokenref=""HierarchyRelationDefinition.ReverseQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""QuickValuesFilter"" token=""HierarchyRelationDefinition.QuickValuesFilter"" displayname=""AttributeDefinition'QuickValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/QuickValuesFilter"" tokenref=""RelationDefinition.QuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/QuickValuesFilter"" tokenref=""HierarchyRelationDefinition.QuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetState"" token=""HierarchyRelationDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'HierarchyRelationDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/AssetState"" tokenref=""HierarchyRelationDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RelatedAssetType"" token=""HierarchyRelationDefinition.RelatedAssetType"" displayname=""AttributeDefinition'RelatedAssetType'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/RelatedAssetType"" tokenref=""RelationDefinition.RelatedAssetType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RelatedAssetType.Order"" tokenref=""HierarchyRelationDefinition.RelatedAssetType.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/RelatedAssetType.Name"" tokenref=""HierarchyRelationDefinition.RelatedAssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""HierarchyRelationDefinition.Asset"" displayname=""AttributeDefinition'Asset'HierarchyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Asset.Order"" tokenref=""HierarchyRelationDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Asset.Name"" tokenref=""HierarchyRelationDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseIsBasic"" token=""HierarchyRelationDefinition.ReverseIsBasic"" displayname=""AttributeDefinition'ReverseIsBasic'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseIsBasic"" tokenref=""RelationDefinition.ReverseIsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseIsBasic"" tokenref=""HierarchyRelationDefinition.ReverseIsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseNewValidValuesFilter"" token=""HierarchyRelationDefinition.ReverseNewValidValuesFilter"" displayname=""AttributeDefinition'ReverseNewValidValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewValidValuesFilter"" tokenref=""RelationDefinition.ReverseNewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseNewValidValuesFilter"" tokenref=""HierarchyRelationDefinition.ReverseNewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseValidValuesFilter"" token=""HierarchyRelationDefinition.ReverseValidValuesFilter"" displayname=""AttributeDefinition'ReverseValidValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseValidValuesFilter"" tokenref=""RelationDefinition.ReverseValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseValidValuesFilter"" tokenref=""HierarchyRelationDefinition.ReverseValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewValidValuesFilter"" token=""HierarchyRelationDefinition.NewValidValuesFilter"" displayname=""AttributeDefinition'NewValidValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewValidValuesFilter"" tokenref=""RelationDefinition.NewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/NewValidValuesFilter"" tokenref=""HierarchyRelationDefinition.NewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ValidValuesFilter"" token=""HierarchyRelationDefinition.ValidValuesFilter"" displayname=""AttributeDefinition'ValidValuesFilter'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ValidValuesFilter"" tokenref=""RelationDefinition.ValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ValidValuesFilter"" tokenref=""HierarchyRelationDefinition.ValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseName"" token=""HierarchyRelationDefinition.ReverseName"" displayname=""AttributeDefinition'ReverseName'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseName"" tokenref=""RelationDefinition.ReverseName"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/ReverseName"" tokenref=""HierarchyRelationDefinition.ReverseName"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""HierarchyRelationDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsBasic"" tokenref=""HierarchyRelationDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""HierarchyRelationDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/NativeValue"" tokenref=""HierarchyRelationDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""HierarchyRelationDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsCustom"" tokenref=""HierarchyRelationDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""HierarchyRelationDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsReadOnly"" tokenref=""HierarchyRelationDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""HierarchyRelationDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsRequired"" tokenref=""HierarchyRelationDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""HierarchyRelationDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/AttributeType"" tokenref=""HierarchyRelationDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""HierarchyRelationDefinition.Name"" displayname=""AttributeDefinition'Name'HierarchyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/Name"" tokenref=""HierarchyRelationDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""HierarchyRelationDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/CanUpdate"" tokenref=""HierarchyRelationDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""HierarchyRelationDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsCanned"" tokenref=""HierarchyRelationDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""HierarchyRelationDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsDeletable"" tokenref=""HierarchyRelationDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""HierarchyRelationDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'HierarchyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsDeleted"" tokenref=""HierarchyRelationDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/HierarchyRelationDefinition/IsDeletable"" tokenref=""HierarchyRelationDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""ManyToManyRelationDefinition"" token=""ManyToManyRelationDefinition"" displayname=""AssetType'ManyToManyRelationDefinition"" abstract=""False"">
        <Base nameref=""RelationDefinition"" href=""/v1sdktesting/meta.v1/RelationDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""ManyToManyRelationDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangeDate"" tokenref=""ManyToManyRelationDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""ManyToManyRelationDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetireDate"" tokenref=""ManyToManyRelationDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""ManyToManyRelationDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreateDate"" tokenref=""ManyToManyRelationDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""ManyToManyRelationDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangeDateUTC"" tokenref=""ManyToManyRelationDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""ManyToManyRelationDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetireDateUTC"" tokenref=""ManyToManyRelationDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""ManyToManyRelationDefinition.Days"" displayname=""AttributeDefinition'Days'ManyToManyRelationDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Days"" tokenref=""ManyToManyRelationDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""ManyToManyRelationDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'ManyToManyRelationDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreateDateUTC"" tokenref=""ManyToManyRelationDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""ManyToManyRelationDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangeReason"" tokenref=""ManyToManyRelationDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""ManyToManyRelationDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetireReason"" tokenref=""ManyToManyRelationDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""ManyToManyRelationDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreateReason"" tokenref=""ManyToManyRelationDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""ManyToManyRelationDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangeComment"" tokenref=""ManyToManyRelationDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""ManyToManyRelationDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetireComment"" tokenref=""ManyToManyRelationDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""ManyToManyRelationDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreateComment"" tokenref=""ManyToManyRelationDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""ManyToManyRelationDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangedBy.Name"" tokenref=""ManyToManyRelationDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ChangedBy.Name"" tokenref=""ManyToManyRelationDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""ManyToManyRelationDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetiredBy.Name"" tokenref=""ManyToManyRelationDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RetiredBy.Name"" tokenref=""ManyToManyRelationDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""ManyToManyRelationDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreatedBy.Name"" tokenref=""ManyToManyRelationDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CreatedBy.Name"" tokenref=""ManyToManyRelationDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""ManyToManyRelationDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""ManyToManyRelationDefinition.Prior"" displayname=""AttributeDefinition'Prior'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Prior.Name"" tokenref=""ManyToManyRelationDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Prior.Name"" tokenref=""ManyToManyRelationDefinition.Prior.Name"" />
            <RelatedAsset nameref=""ManyToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""ManyToManyRelationDefinition.ID"" displayname=""AttributeDefinition'ID'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ID"" tokenref=""ManyToManyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ID"" tokenref=""ManyToManyRelationDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
            <RelatedAsset nameref=""ManyToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""ManyToManyRelationDefinition.Now"" displayname=""AttributeDefinition'Now'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ID"" tokenref=""ManyToManyRelationDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Now"" tokenref=""ManyToManyRelationDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
            <RelatedAsset nameref=""ManyToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""ManyToManyRelationDefinition.History"" displayname=""AttributeDefinition'History'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Now"" tokenref=""ManyToManyRelationDefinition.Now"" />
            <RelatedAsset nameref=""ManyToManyRelationDefinition"" href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""ManyToManyRelationDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'ManyToManyRelationDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/AssetType"" tokenref=""ManyToManyRelationDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""ManyToManyRelationDefinition.Key"" displayname=""AttributeDefinition'Key'ManyToManyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Key"" tokenref=""ManyToManyRelationDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""ManyToManyRelationDefinition.Moment"" displayname=""AttributeDefinition'Moment'ManyToManyRelationDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Moment"" tokenref=""ManyToManyRelationDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""ManyToManyRelationDefinition.Is"" displayname=""AttributeDefinition'Is'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ReverseNewQuickValuesFilter"" token=""ManyToManyRelationDefinition.ReverseNewQuickValuesFilter"" displayname=""AttributeDefinition'ReverseNewQuickValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""RelationDefinition.ReverseNewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseNewQuickValuesFilter"" tokenref=""ManyToManyRelationDefinition.ReverseNewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewQuickValuesFilter"" token=""ManyToManyRelationDefinition.NewQuickValuesFilter"" displayname=""AttributeDefinition'NewQuickValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewQuickValuesFilter"" tokenref=""RelationDefinition.NewQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/NewQuickValuesFilter"" tokenref=""ManyToManyRelationDefinition.NewQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseQuickValuesFilter"" token=""ManyToManyRelationDefinition.ReverseQuickValuesFilter"" displayname=""AttributeDefinition'ReverseQuickValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseQuickValuesFilter"" tokenref=""RelationDefinition.ReverseQuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseQuickValuesFilter"" tokenref=""ManyToManyRelationDefinition.ReverseQuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""QuickValuesFilter"" token=""ManyToManyRelationDefinition.QuickValuesFilter"" displayname=""AttributeDefinition'QuickValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/QuickValuesFilter"" tokenref=""RelationDefinition.QuickValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/QuickValuesFilter"" tokenref=""ManyToManyRelationDefinition.QuickValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetState"" token=""ManyToManyRelationDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'ManyToManyRelationDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/AssetState"" tokenref=""ManyToManyRelationDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RelatedAssetType"" token=""ManyToManyRelationDefinition.RelatedAssetType"" displayname=""AttributeDefinition'RelatedAssetType'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/RelatedAssetType"" tokenref=""RelationDefinition.RelatedAssetType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RelatedAssetType.Order"" tokenref=""ManyToManyRelationDefinition.RelatedAssetType.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/RelatedAssetType.Name"" tokenref=""ManyToManyRelationDefinition.RelatedAssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""ManyToManyRelationDefinition.Asset"" displayname=""AttributeDefinition'Asset'ManyToManyRelationDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Asset.Order"" tokenref=""ManyToManyRelationDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Asset.Name"" tokenref=""ManyToManyRelationDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ACLMask"" token=""ManyToManyRelationDefinition.ACLMask"" displayname=""AttributeDefinition'ACLMask'ManyToManyRelationDefinition"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ACLMask"" tokenref=""ManyToManyRelationDefinition.ACLMask"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseIsAssetHistory"" token=""ManyToManyRelationDefinition.ReverseIsAssetHistory"" displayname=""AttributeDefinition'ReverseIsAssetHistory'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseIsAssetHistory"" tokenref=""ManyToManyRelationDefinition.ReverseIsAssetHistory"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsAssetHistory"" token=""ManyToManyRelationDefinition.IsAssetHistory"" displayname=""AttributeDefinition'IsAssetHistory'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsAssetHistory"" tokenref=""ManyToManyRelationDefinition.IsAssetHistory"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseIsBasic"" token=""ManyToManyRelationDefinition.ReverseIsBasic"" displayname=""AttributeDefinition'ReverseIsBasic'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseIsBasic"" tokenref=""RelationDefinition.ReverseIsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseIsBasic"" tokenref=""ManyToManyRelationDefinition.ReverseIsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseNewValidValuesFilter"" token=""ManyToManyRelationDefinition.ReverseNewValidValuesFilter"" displayname=""AttributeDefinition'ReverseNewValidValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseNewValidValuesFilter"" tokenref=""RelationDefinition.ReverseNewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseNewValidValuesFilter"" tokenref=""ManyToManyRelationDefinition.ReverseNewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseValidValuesFilter"" token=""ManyToManyRelationDefinition.ReverseValidValuesFilter"" displayname=""AttributeDefinition'ReverseValidValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseValidValuesFilter"" tokenref=""RelationDefinition.ReverseValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseValidValuesFilter"" tokenref=""ManyToManyRelationDefinition.ReverseValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NewValidValuesFilter"" token=""ManyToManyRelationDefinition.NewValidValuesFilter"" displayname=""AttributeDefinition'NewValidValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/NewValidValuesFilter"" tokenref=""RelationDefinition.NewValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/NewValidValuesFilter"" tokenref=""ManyToManyRelationDefinition.NewValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ValidValuesFilter"" token=""ManyToManyRelationDefinition.ValidValuesFilter"" displayname=""AttributeDefinition'ValidValuesFilter'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ValidValuesFilter"" tokenref=""RelationDefinition.ValidValuesFilter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ValidValuesFilter"" tokenref=""ManyToManyRelationDefinition.ValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ReverseName"" token=""ManyToManyRelationDefinition.ReverseName"" displayname=""AttributeDefinition'ReverseName'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/RelationDefinition/ReverseName"" tokenref=""RelationDefinition.ReverseName"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/ReverseName"" tokenref=""ManyToManyRelationDefinition.ReverseName"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""ManyToManyRelationDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsBasic"" tokenref=""ManyToManyRelationDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""ManyToManyRelationDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/NativeValue"" tokenref=""ManyToManyRelationDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""ManyToManyRelationDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsCustom"" tokenref=""ManyToManyRelationDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""ManyToManyRelationDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsReadOnly"" tokenref=""ManyToManyRelationDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""ManyToManyRelationDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsRequired"" tokenref=""ManyToManyRelationDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""ManyToManyRelationDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/AttributeType"" tokenref=""ManyToManyRelationDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""ManyToManyRelationDefinition.Name"" displayname=""AttributeDefinition'Name'ManyToManyRelationDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/Name"" tokenref=""ManyToManyRelationDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""ManyToManyRelationDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/CanUpdate"" tokenref=""ManyToManyRelationDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""ManyToManyRelationDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsCanned"" tokenref=""ManyToManyRelationDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""ManyToManyRelationDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsDeletable"" tokenref=""ManyToManyRelationDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""ManyToManyRelationDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'ManyToManyRelationDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsDeleted"" tokenref=""ManyToManyRelationDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/ManyToManyRelationDefinition/IsDeletable"" tokenref=""ManyToManyRelationDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""SyntheticAttributeDefinition"" token=""SyntheticAttributeDefinition"" displayname=""AssetType'SyntheticAttributeDefinition"" abstract=""False"">
        <Base nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Order"" tokenref=""SyntheticAttributeDefinition.Order"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""SyntheticAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangeDate"" tokenref=""SyntheticAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""SyntheticAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetireDate"" tokenref=""SyntheticAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""SyntheticAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreateDate"" tokenref=""SyntheticAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""SyntheticAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangeDateUTC"" tokenref=""SyntheticAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""SyntheticAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetireDateUTC"" tokenref=""SyntheticAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""SyntheticAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'SyntheticAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Days"" tokenref=""SyntheticAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""SyntheticAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'SyntheticAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreateDateUTC"" tokenref=""SyntheticAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""SyntheticAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangeReason"" tokenref=""SyntheticAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""SyntheticAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetireReason"" tokenref=""SyntheticAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""SyntheticAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreateReason"" tokenref=""SyntheticAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""SyntheticAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangeComment"" tokenref=""SyntheticAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""SyntheticAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetireComment"" tokenref=""SyntheticAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""SyntheticAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreateComment"" tokenref=""SyntheticAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""SyntheticAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangedBy.Name"" tokenref=""SyntheticAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ChangedBy.Name"" tokenref=""SyntheticAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""SyntheticAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetiredBy.Name"" tokenref=""SyntheticAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/RetiredBy.Name"" tokenref=""SyntheticAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""SyntheticAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreatedBy.Name"" tokenref=""SyntheticAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CreatedBy.Name"" tokenref=""SyntheticAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""SyntheticAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""SyntheticAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Prior.Order"" tokenref=""SyntheticAttributeDefinition.Prior.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Prior.Name"" tokenref=""SyntheticAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""SyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""SyntheticAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ID"" tokenref=""SyntheticAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ID"" tokenref=""SyntheticAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
            <RelatedAsset nameref=""SyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""SyntheticAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/ID"" tokenref=""SyntheticAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Now"" tokenref=""SyntheticAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
            <RelatedAsset nameref=""SyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""SyntheticAttributeDefinition.History"" displayname=""AttributeDefinition'History'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Now"" tokenref=""SyntheticAttributeDefinition.Now"" />
            <RelatedAsset nameref=""SyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""SyntheticAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'SyntheticAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/AssetType"" tokenref=""SyntheticAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""SyntheticAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'SyntheticAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Key"" tokenref=""SyntheticAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""SyntheticAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'SyntheticAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Moment"" tokenref=""SyntheticAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""SyntheticAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""SyntheticAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'SyntheticAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/AssetState"" tokenref=""SyntheticAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Order"" token=""SyntheticAttributeDefinition.Order"" displayname=""AttributeDefinition'Order'SyntheticAttributeDefinition"" attributetype=""Rank"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Order"" tokenref=""SyntheticAttributeDefinition.Order"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""SyntheticAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'SyntheticAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Asset.Order"" tokenref=""SyntheticAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Asset.Name"" tokenref=""SyntheticAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Parameter"" token=""SyntheticAttributeDefinition.Parameter"" displayname=""AttributeDefinition'Parameter'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Parameter"" tokenref=""BaseSyntheticAttributeDefinition.Parameter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Parameter"" tokenref=""SyntheticAttributeDefinition.Parameter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Calculation"" token=""SyntheticAttributeDefinition.Calculation"" displayname=""AttributeDefinition'Calculation'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Calculation"" tokenref=""BaseSyntheticAttributeDefinition.Calculation"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Calculation"" tokenref=""SyntheticAttributeDefinition.Calculation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""SyntheticAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsBasic"" tokenref=""SyntheticAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""SyntheticAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/NativeValue"" tokenref=""SyntheticAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""SyntheticAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsCustom"" tokenref=""SyntheticAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""SyntheticAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsReadOnly"" tokenref=""SyntheticAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""SyntheticAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsRequired"" tokenref=""SyntheticAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""SyntheticAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/AttributeType"" tokenref=""SyntheticAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""SyntheticAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'SyntheticAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/Name"" tokenref=""SyntheticAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""SyntheticAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/CanUpdate"" tokenref=""SyntheticAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""SyntheticAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsCanned"" tokenref=""SyntheticAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""SyntheticAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsDeletable"" tokenref=""SyntheticAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""SyntheticAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'SyntheticAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsDeleted"" tokenref=""SyntheticAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/SyntheticAttributeDefinition/IsDeletable"" tokenref=""SyntheticAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""ExecuteSecurityCheckAttributeDefinition"" token=""ExecuteSecurityCheckAttributeDefinition"" displayname=""AssetType'ExecuteSecurityCheckAttributeDefinition"" abstract=""False"">
        <Base nameref=""BaseSyntheticAttributeDefinition"" href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
        <Name href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""ExecuteSecurityCheckAttributeDefinition.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDate"" tokenref=""AttributeDefinition.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangeDate"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""ExecuteSecurityCheckAttributeDefinition.RetireDate"" displayname=""AttributeDefinition'RetireDate'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDate"" tokenref=""AttributeDefinition.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetireDate"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""ExecuteSecurityCheckAttributeDefinition.CreateDate"" displayname=""AttributeDefinition'CreateDate'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDate"" tokenref=""AttributeDefinition.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreateDate"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""ExecuteSecurityCheckAttributeDefinition.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeDateUTC"" tokenref=""AttributeDefinition.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangeDateUTC"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""ExecuteSecurityCheckAttributeDefinition.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireDateUTC"" tokenref=""AttributeDefinition.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetireDateUTC"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""ExecuteSecurityCheckAttributeDefinition.Days"" displayname=""AttributeDefinition'Days'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Days"" tokenref=""AttributeDefinition.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Days"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""ExecuteSecurityCheckAttributeDefinition.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateDateUTC"" tokenref=""AttributeDefinition.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreateDateUTC"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""ExecuteSecurityCheckAttributeDefinition.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeReason"" tokenref=""AttributeDefinition.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangeReason"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""ExecuteSecurityCheckAttributeDefinition.RetireReason"" displayname=""AttributeDefinition'RetireReason'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireReason"" tokenref=""AttributeDefinition.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetireReason"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""ExecuteSecurityCheckAttributeDefinition.CreateReason"" displayname=""AttributeDefinition'CreateReason'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateReason"" tokenref=""AttributeDefinition.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreateReason"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""ExecuteSecurityCheckAttributeDefinition.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangeComment"" tokenref=""AttributeDefinition.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangeComment"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""ExecuteSecurityCheckAttributeDefinition.RetireComment"" displayname=""AttributeDefinition'RetireComment'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetireComment"" tokenref=""AttributeDefinition.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetireComment"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""ExecuteSecurityCheckAttributeDefinition.CreateComment"" displayname=""AttributeDefinition'CreateComment'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreateComment"" tokenref=""AttributeDefinition.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreateComment"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""ExecuteSecurityCheckAttributeDefinition.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/ChangedBy"" tokenref=""AttributeDefinition.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangedBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ChangedBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""ExecuteSecurityCheckAttributeDefinition.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/RetiredBy"" tokenref=""AttributeDefinition.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetiredBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/RetiredBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""ExecuteSecurityCheckAttributeDefinition.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/CreatedBy"" tokenref=""AttributeDefinition.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreatedBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CreatedBy.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""ExecuteSecurityCheckAttributeDefinition.Viewers"" displayname=""AttributeDefinition'Viewers'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Viewers"" tokenref=""AttributeDefinition.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""ExecuteSecurityCheckAttributeDefinition.Prior"" displayname=""AttributeDefinition'Prior'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Prior"" tokenref=""AttributeDefinition.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Prior.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Prior.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Prior.Name"" />
            <RelatedAsset nameref=""ExecuteSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""ExecuteSecurityCheckAttributeDefinition.ID"" displayname=""AttributeDefinition'ID'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ID"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ID"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
            <RelatedAsset nameref=""ExecuteSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""ExecuteSecurityCheckAttributeDefinition.Now"" displayname=""AttributeDefinition'Now'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/ID"" tokenref=""ExecuteSecurityCheckAttributeDefinition.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Now"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
            <RelatedAsset nameref=""ExecuteSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""ExecuteSecurityCheckAttributeDefinition.History"" displayname=""AttributeDefinition'History'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Now"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Now"" />
            <RelatedAsset nameref=""ExecuteSecurityCheckAttributeDefinition"" href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""ExecuteSecurityCheckAttributeDefinition.AssetType"" displayname=""AttributeDefinition'AssetType'ExecuteSecurityCheckAttributeDefinition"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/AssetType"" tokenref=""ExecuteSecurityCheckAttributeDefinition.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""ExecuteSecurityCheckAttributeDefinition.Key"" displayname=""AttributeDefinition'Key'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Key"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""ExecuteSecurityCheckAttributeDefinition.Moment"" displayname=""AttributeDefinition'Moment'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Moment"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""ExecuteSecurityCheckAttributeDefinition.Is"" displayname=""AttributeDefinition'Is'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AssetState"" token=""ExecuteSecurityCheckAttributeDefinition.AssetState"" displayname=""AttributeDefinition'AssetState'ExecuteSecurityCheckAttributeDefinition"" attributetype=""State"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AssetState"" tokenref=""AttributeDefinition.AssetState"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/AssetState"" tokenref=""ExecuteSecurityCheckAttributeDefinition.AssetState"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""ExecuteSecurityCheckAttributeDefinition.Asset"" displayname=""AttributeDefinition'Asset'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Asset"" tokenref=""AttributeDefinition.Asset"" />
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/AttributeDefinitions"" tokenref=""AssetType.AttributeDefinitions"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Asset.Order"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Asset.Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Operation"" token=""ExecuteSecurityCheckAttributeDefinition.Operation"" displayname=""AttributeDefinition'Operation'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Operation"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Parameter"" token=""ExecuteSecurityCheckAttributeDefinition.Parameter"" displayname=""AttributeDefinition'Parameter'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Parameter"" tokenref=""BaseSyntheticAttributeDefinition.Parameter"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Parameter"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Parameter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Calculation"" token=""ExecuteSecurityCheckAttributeDefinition.Calculation"" displayname=""AttributeDefinition'Calculation'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseSyntheticAttributeDefinition/Calculation"" tokenref=""BaseSyntheticAttributeDefinition.Calculation"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Calculation"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Calculation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""ExecuteSecurityCheckAttributeDefinition.IsBasic"" displayname=""AttributeDefinition'IsBasic'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsBasic"" tokenref=""AttributeDefinition.IsBasic"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsBasic"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""NativeValue"" token=""ExecuteSecurityCheckAttributeDefinition.NativeValue"" displayname=""AttributeDefinition'NativeValue'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/NativeValue"" tokenref=""AttributeDefinition.NativeValue"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/NativeValue"" tokenref=""ExecuteSecurityCheckAttributeDefinition.NativeValue"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCustom"" token=""ExecuteSecurityCheckAttributeDefinition.IsCustom"" displayname=""AttributeDefinition'IsCustom'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCustom"" tokenref=""AttributeDefinition.IsCustom"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsCustom"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsCustom"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""ExecuteSecurityCheckAttributeDefinition.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsReadOnly"" tokenref=""AttributeDefinition.IsReadOnly"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsReadOnly"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""ExecuteSecurityCheckAttributeDefinition.IsRequired"" displayname=""AttributeDefinition'IsRequired'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsRequired"" tokenref=""AttributeDefinition.IsRequired"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsRequired"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AttributeType"" token=""ExecuteSecurityCheckAttributeDefinition.AttributeType"" displayname=""AttributeDefinition'AttributeType'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/AttributeType"" tokenref=""AttributeDefinition.AttributeType"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/AttributeType"" tokenref=""ExecuteSecurityCheckAttributeDefinition.AttributeType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""ExecuteSecurityCheckAttributeDefinition.Name"" displayname=""AttributeDefinition'Name'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/Name"" tokenref=""AttributeDefinition.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/Name"" tokenref=""ExecuteSecurityCheckAttributeDefinition.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CanUpdate"" token=""ExecuteSecurityCheckAttributeDefinition.CanUpdate"" displayname=""AttributeDefinition'CanUpdate'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/CanUpdate"" tokenref=""ExecuteSecurityCheckAttributeDefinition.CanUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsCanned"" token=""ExecuteSecurityCheckAttributeDefinition.IsCanned"" displayname=""AttributeDefinition'IsCanned'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsCanned"" tokenref=""AttributeDefinition.IsCanned"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsCanned"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsCanned"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeletable"" token=""ExecuteSecurityCheckAttributeDefinition.IsDeletable"" displayname=""AttributeDefinition'IsDeletable'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeletable"" tokenref=""AttributeDefinition.IsDeletable"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsDeletable"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsDeletable"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsDeleted"" token=""ExecuteSecurityCheckAttributeDefinition.IsDeleted"" displayname=""AttributeDefinition'IsDeleted'ExecuteSecurityCheckAttributeDefinition"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/AttributeDefinition/IsDeleted"" tokenref=""AttributeDefinition.IsDeleted"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsDeleted"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsDeleted"" />
        </AttributeDefinition>
        <Operation name=""Delete"">
            <Validator href=""/v1sdktesting/meta.v1/ExecuteSecurityCheckAttributeDefinition/IsDeletable"" tokenref=""ExecuteSecurityCheckAttributeDefinition.IsDeletable"" />
        </Operation>
    </AssetType>
    <AssetType name=""Override"" token=""Override"" displayname=""AssetType'Override"" abstract=""False"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
        <Name href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
        <AttributeDefinition name=""ID"" token=""Override.ID"" displayname=""AttributeDefinition'ID'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Override/ID"" tokenref=""Override.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ID"" tokenref=""Override.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
            <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""Override.Now"" displayname=""AttributeDefinition'Now'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Override/ID"" tokenref=""Override.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Now"" tokenref=""Override.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
            <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""Override.History"" displayname=""AttributeDefinition'History'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Override/Now"" tokenref=""Override.Now"" />
            <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""Override.AssetType"" displayname=""AttributeDefinition'AssetType'Override"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/AssetType"" tokenref=""Override.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""Override.Key"" displayname=""AttributeDefinition'Key'Override"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Key"" tokenref=""Override.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""Override.Moment"" displayname=""AttributeDefinition'Moment'Override"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Moment"" tokenref=""Override.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""Override.Is"" displayname=""AttributeDefinition'Is'Override"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""Override.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ChangeDate"" tokenref=""Override.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""Override.RetireDate"" displayname=""AttributeDefinition'RetireDate'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RetireDate"" tokenref=""Override.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""Override.CreateDate"" displayname=""AttributeDefinition'CreateDate'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/CreateDate"" tokenref=""Override.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""Override.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ChangeDateUTC"" tokenref=""Override.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""Override.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RetireDateUTC"" tokenref=""Override.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""Override.Days"" displayname=""AttributeDefinition'Days'Override"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Days"" tokenref=""Override.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""Override.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'Override"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/CreateDateUTC"" tokenref=""Override.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""Override.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ChangeReason"" tokenref=""Override.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""Override.RetireReason"" displayname=""AttributeDefinition'RetireReason'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RetireReason"" tokenref=""Override.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""Override.CreateReason"" displayname=""AttributeDefinition'CreateReason'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/CreateReason"" tokenref=""Override.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""Override.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ChangeComment"" tokenref=""Override.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""Override.RetireComment"" displayname=""AttributeDefinition'RetireComment'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RetireComment"" tokenref=""Override.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""Override.CreateComment"" displayname=""AttributeDefinition'CreateComment'Override"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/CreateComment"" tokenref=""Override.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""Override.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ChangedBy.Name"" tokenref=""Override.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/ChangedBy.Name"" tokenref=""Override.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""Override.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RetiredBy.Name"" tokenref=""Override.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/RetiredBy.Name"" tokenref=""Override.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""Override.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/CreatedBy.Name"" tokenref=""Override.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/CreatedBy.Name"" tokenref=""Override.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""Override.Viewers"" displayname=""AttributeDefinition'Viewers'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""Override.Prior"" displayname=""AttributeDefinition'Prior'Override"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Prior.Name"" tokenref=""Override.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/Prior.Name"" tokenref=""Override.Prior.Name"" />
            <RelatedAsset nameref=""Override"" href=""/v1sdktesting/meta.v1/Override"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RelatedAssetType"" token=""Override.RelatedAssetType"" displayname=""AttributeDefinition'RelatedAssetType'Override"" attributetype=""Relation"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/RelatedAssetType.Order"" tokenref=""Override.RelatedAssetType.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/RelatedAssetType.Name"" tokenref=""Override.RelatedAssetType.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""Override.Asset"" displayname=""AttributeDefinition'Asset'Override"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Overrides"" tokenref=""AssetType.Overrides"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Asset.Order"" tokenref=""Override.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Override/Asset.Name"" tokenref=""Override.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsBasic"" token=""Override.IsBasic"" displayname=""AttributeDefinition'IsBasic'Override"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/IsBasic"" tokenref=""Override.IsBasic"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ValidValuesFilter"" token=""Override.ValidValuesFilter"" displayname=""AttributeDefinition'ValidValuesFilter'Override"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/ValidValuesFilter"" tokenref=""Override.ValidValuesFilter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsReadOnly"" token=""Override.IsReadOnly"" displayname=""AttributeDefinition'IsReadOnly'Override"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/IsReadOnly"" tokenref=""Override.IsReadOnly"" />
        </AttributeDefinition>
        <AttributeDefinition name=""IsRequired"" token=""Override.IsRequired"" displayname=""AttributeDefinition'IsRequired'Override"" attributetype=""Boolean"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/IsRequired"" tokenref=""Override.IsRequired"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Parameter"" token=""Override.Parameter"" displayname=""AttributeDefinition'Parameter'Override"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Parameter"" tokenref=""Override.Parameter"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Calculation"" token=""Override.Calculation"" displayname=""AttributeDefinition'Calculation'Override"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Calculation"" tokenref=""Override.Calculation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""Override.Name"" displayname=""AttributeDefinition'Name'Override"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Override/Name"" tokenref=""Override.Name"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""BaseRule"" token=""BaseRule"" displayname=""AssetType'BaseRule"" abstract=""True"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
        <Name href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
        <AttributeDefinition name=""ID"" token=""BaseRule.ID"" displayname=""AttributeDefinition'ID'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseRule/ID"" tokenref=""BaseRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ID"" tokenref=""BaseRule.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
            <RelatedAsset nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""BaseRule.Now"" displayname=""AttributeDefinition'Now'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseRule/ID"" tokenref=""BaseRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Now"" tokenref=""BaseRule.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
            <RelatedAsset nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""BaseRule.History"" displayname=""AttributeDefinition'History'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BaseRule/Now"" tokenref=""BaseRule.Now"" />
            <RelatedAsset nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""BaseRule.AssetType"" displayname=""AttributeDefinition'AssetType'BaseRule"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/AssetType"" tokenref=""BaseRule.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""BaseRule.Key"" displayname=""AttributeDefinition'Key'BaseRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Key"" tokenref=""BaseRule.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""BaseRule.Moment"" displayname=""AttributeDefinition'Moment'BaseRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Moment"" tokenref=""BaseRule.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""BaseRule.Is"" displayname=""AttributeDefinition'Is'BaseRule"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""BaseRule.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangeDate"" tokenref=""BaseRule.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""BaseRule.RetireDate"" displayname=""AttributeDefinition'RetireDate'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetireDate"" tokenref=""BaseRule.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""BaseRule.CreateDate"" displayname=""AttributeDefinition'CreateDate'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreateDate"" tokenref=""BaseRule.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""BaseRule.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangeDateUTC"" tokenref=""BaseRule.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""BaseRule.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetireDateUTC"" tokenref=""BaseRule.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""BaseRule.Days"" displayname=""AttributeDefinition'Days'BaseRule"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Days"" tokenref=""BaseRule.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""BaseRule.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'BaseRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreateDateUTC"" tokenref=""BaseRule.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""BaseRule.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangeReason"" tokenref=""BaseRule.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""BaseRule.RetireReason"" displayname=""AttributeDefinition'RetireReason'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetireReason"" tokenref=""BaseRule.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""BaseRule.CreateReason"" displayname=""AttributeDefinition'CreateReason'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreateReason"" tokenref=""BaseRule.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""BaseRule.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangeComment"" tokenref=""BaseRule.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""BaseRule.RetireComment"" displayname=""AttributeDefinition'RetireComment'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetireComment"" tokenref=""BaseRule.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""BaseRule.CreateComment"" displayname=""AttributeDefinition'CreateComment'BaseRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreateComment"" tokenref=""BaseRule.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""BaseRule.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangedBy.Name"" tokenref=""BaseRule.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/ChangedBy.Name"" tokenref=""BaseRule.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""BaseRule.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetiredBy.Name"" tokenref=""BaseRule.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/RetiredBy.Name"" tokenref=""BaseRule.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""BaseRule.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreatedBy.Name"" tokenref=""BaseRule.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/CreatedBy.Name"" tokenref=""BaseRule.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""BaseRule.Viewers"" displayname=""AttributeDefinition'Viewers'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""BaseRule.Prior"" displayname=""AttributeDefinition'Prior'BaseRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Prior.Name"" tokenref=""BaseRule.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Prior.Name"" tokenref=""BaseRule.Prior.Name"" />
            <RelatedAsset nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""BaseRule.Name"" displayname=""AttributeDefinition'Name'BaseRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Initializer"" token=""BaseRule.Initializer"" displayname=""AttributeDefinition'Initializer'BaseRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Initializer"" tokenref=""BaseRule.Initializer"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Class"" token=""BaseRule.Class"" displayname=""AttributeDefinition'Class'BaseRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BaseRule/Class"" tokenref=""BaseRule.Class"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""DefaultRule"" token=""DefaultRule"" displayname=""AssetType'DefaultRule"" abstract=""False"">
        <Base nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
        <Name href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""DefaultRule.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDate"" tokenref=""BaseRule.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangeDate"" tokenref=""DefaultRule.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""DefaultRule.RetireDate"" displayname=""AttributeDefinition'RetireDate'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDate"" tokenref=""BaseRule.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetireDate"" tokenref=""DefaultRule.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""DefaultRule.CreateDate"" displayname=""AttributeDefinition'CreateDate'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDate"" tokenref=""BaseRule.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreateDate"" tokenref=""DefaultRule.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""DefaultRule.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDateUTC"" tokenref=""BaseRule.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangeDateUTC"" tokenref=""DefaultRule.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""DefaultRule.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDateUTC"" tokenref=""BaseRule.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetireDateUTC"" tokenref=""DefaultRule.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""DefaultRule.Days"" displayname=""AttributeDefinition'Days'DefaultRule"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Days"" tokenref=""BaseRule.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Days"" tokenref=""DefaultRule.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""DefaultRule.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'DefaultRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDateUTC"" tokenref=""BaseRule.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreateDateUTC"" tokenref=""DefaultRule.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""DefaultRule.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeReason"" tokenref=""BaseRule.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangeReason"" tokenref=""DefaultRule.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""DefaultRule.RetireReason"" displayname=""AttributeDefinition'RetireReason'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireReason"" tokenref=""BaseRule.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetireReason"" tokenref=""DefaultRule.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""DefaultRule.CreateReason"" displayname=""AttributeDefinition'CreateReason'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateReason"" tokenref=""BaseRule.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreateReason"" tokenref=""DefaultRule.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""DefaultRule.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeComment"" tokenref=""BaseRule.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangeComment"" tokenref=""DefaultRule.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""DefaultRule.RetireComment"" displayname=""AttributeDefinition'RetireComment'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireComment"" tokenref=""BaseRule.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetireComment"" tokenref=""DefaultRule.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""DefaultRule.CreateComment"" displayname=""AttributeDefinition'CreateComment'DefaultRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateComment"" tokenref=""BaseRule.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreateComment"" tokenref=""DefaultRule.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""DefaultRule.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangedBy"" tokenref=""BaseRule.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangedBy.Name"" tokenref=""DefaultRule.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ChangedBy.Name"" tokenref=""DefaultRule.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""DefaultRule.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetiredBy"" tokenref=""BaseRule.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetiredBy.Name"" tokenref=""DefaultRule.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/RetiredBy.Name"" tokenref=""DefaultRule.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""DefaultRule.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreatedBy"" tokenref=""BaseRule.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreatedBy.Name"" tokenref=""DefaultRule.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/CreatedBy.Name"" tokenref=""DefaultRule.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""DefaultRule.Viewers"" displayname=""AttributeDefinition'Viewers'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Viewers"" tokenref=""BaseRule.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""DefaultRule.Prior"" displayname=""AttributeDefinition'Prior'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Prior"" tokenref=""BaseRule.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Prior.Name"" tokenref=""DefaultRule.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Prior.Name"" tokenref=""DefaultRule.Prior.Name"" />
            <RelatedAsset nameref=""DefaultRule"" href=""/v1sdktesting/meta.v1/DefaultRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""DefaultRule.ID"" displayname=""AttributeDefinition'ID'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/DefaultRule/ID"" tokenref=""DefaultRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/ID"" tokenref=""DefaultRule.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
            <RelatedAsset nameref=""DefaultRule"" href=""/v1sdktesting/meta.v1/DefaultRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""DefaultRule.Now"" displayname=""AttributeDefinition'Now'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/DefaultRule/ID"" tokenref=""DefaultRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Now"" tokenref=""DefaultRule.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
            <RelatedAsset nameref=""DefaultRule"" href=""/v1sdktesting/meta.v1/DefaultRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""DefaultRule.History"" displayname=""AttributeDefinition'History'DefaultRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/DefaultRule/Now"" tokenref=""DefaultRule.Now"" />
            <RelatedAsset nameref=""DefaultRule"" href=""/v1sdktesting/meta.v1/DefaultRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""DefaultRule.AssetType"" displayname=""AttributeDefinition'AssetType'DefaultRule"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/AssetType"" tokenref=""DefaultRule.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""DefaultRule.Key"" displayname=""AttributeDefinition'Key'DefaultRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Key"" tokenref=""DefaultRule.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""DefaultRule.Moment"" displayname=""AttributeDefinition'Moment'DefaultRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Moment"" tokenref=""DefaultRule.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""DefaultRule.Is"" displayname=""AttributeDefinition'Is'DefaultRule"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""AttributeDefinition"" token=""DefaultRule.AttributeDefinition"" displayname=""AttributeDefinition'AttributeDefinition'DefaultRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/AttributeDefinition"" tokenref=""DefaultRule.AttributeDefinition"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""DefaultRule.Name"" displayname=""AttributeDefinition'Name'DefaultRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Name"" tokenref=""DefaultRule.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Initializer"" token=""DefaultRule.Initializer"" displayname=""AttributeDefinition'Initializer'DefaultRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Initializer"" tokenref=""BaseRule.Initializer"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Initializer"" tokenref=""DefaultRule.Initializer"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Class"" token=""DefaultRule.Class"" displayname=""AttributeDefinition'Class'DefaultRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Class"" tokenref=""BaseRule.Class"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/DefaultRule/Class"" tokenref=""DefaultRule.Class"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""InsertUpdateRule"" token=""InsertUpdateRule"" displayname=""AssetType'InsertUpdateRule"" abstract=""True"">
        <Base nameref=""BaseRule"" href=""/v1sdktesting/meta.v1/BaseRule"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
        <Name href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""InsertUpdateRule.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDate"" tokenref=""BaseRule.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangeDate"" tokenref=""InsertUpdateRule.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""InsertUpdateRule.RetireDate"" displayname=""AttributeDefinition'RetireDate'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDate"" tokenref=""BaseRule.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetireDate"" tokenref=""InsertUpdateRule.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""InsertUpdateRule.CreateDate"" displayname=""AttributeDefinition'CreateDate'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDate"" tokenref=""BaseRule.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreateDate"" tokenref=""InsertUpdateRule.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""InsertUpdateRule.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDateUTC"" tokenref=""BaseRule.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangeDateUTC"" tokenref=""InsertUpdateRule.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""InsertUpdateRule.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDateUTC"" tokenref=""BaseRule.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetireDateUTC"" tokenref=""InsertUpdateRule.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""InsertUpdateRule.Days"" displayname=""AttributeDefinition'Days'InsertUpdateRule"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Days"" tokenref=""BaseRule.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Days"" tokenref=""InsertUpdateRule.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""InsertUpdateRule.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'InsertUpdateRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDateUTC"" tokenref=""BaseRule.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreateDateUTC"" tokenref=""InsertUpdateRule.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""InsertUpdateRule.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeReason"" tokenref=""BaseRule.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangeReason"" tokenref=""InsertUpdateRule.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""InsertUpdateRule.RetireReason"" displayname=""AttributeDefinition'RetireReason'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireReason"" tokenref=""BaseRule.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetireReason"" tokenref=""InsertUpdateRule.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""InsertUpdateRule.CreateReason"" displayname=""AttributeDefinition'CreateReason'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateReason"" tokenref=""BaseRule.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreateReason"" tokenref=""InsertUpdateRule.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""InsertUpdateRule.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeComment"" tokenref=""BaseRule.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangeComment"" tokenref=""InsertUpdateRule.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""InsertUpdateRule.RetireComment"" displayname=""AttributeDefinition'RetireComment'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireComment"" tokenref=""BaseRule.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetireComment"" tokenref=""InsertUpdateRule.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""InsertUpdateRule.CreateComment"" displayname=""AttributeDefinition'CreateComment'InsertUpdateRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateComment"" tokenref=""BaseRule.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreateComment"" tokenref=""InsertUpdateRule.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""InsertUpdateRule.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangedBy"" tokenref=""BaseRule.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangedBy.Name"" tokenref=""InsertUpdateRule.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ChangedBy.Name"" tokenref=""InsertUpdateRule.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""InsertUpdateRule.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetiredBy"" tokenref=""BaseRule.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetiredBy.Name"" tokenref=""InsertUpdateRule.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/RetiredBy.Name"" tokenref=""InsertUpdateRule.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""InsertUpdateRule.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreatedBy"" tokenref=""BaseRule.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreatedBy.Name"" tokenref=""InsertUpdateRule.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/CreatedBy.Name"" tokenref=""InsertUpdateRule.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""InsertUpdateRule.Viewers"" displayname=""AttributeDefinition'Viewers'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Viewers"" tokenref=""BaseRule.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""InsertUpdateRule.Prior"" displayname=""AttributeDefinition'Prior'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Prior"" tokenref=""BaseRule.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Prior.Name"" tokenref=""InsertUpdateRule.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Prior.Name"" tokenref=""InsertUpdateRule.Prior.Name"" />
            <RelatedAsset nameref=""InsertUpdateRule"" href=""/v1sdktesting/meta.v1/InsertUpdateRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""InsertUpdateRule.ID"" displayname=""AttributeDefinition'ID'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/InsertUpdateRule/ID"" tokenref=""InsertUpdateRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/ID"" tokenref=""InsertUpdateRule.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
            <RelatedAsset nameref=""InsertUpdateRule"" href=""/v1sdktesting/meta.v1/InsertUpdateRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""InsertUpdateRule.Now"" displayname=""AttributeDefinition'Now'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/InsertUpdateRule/ID"" tokenref=""InsertUpdateRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Now"" tokenref=""InsertUpdateRule.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
            <RelatedAsset nameref=""InsertUpdateRule"" href=""/v1sdktesting/meta.v1/InsertUpdateRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""InsertUpdateRule.History"" displayname=""AttributeDefinition'History'InsertUpdateRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/InsertUpdateRule/Now"" tokenref=""InsertUpdateRule.Now"" />
            <RelatedAsset nameref=""InsertUpdateRule"" href=""/v1sdktesting/meta.v1/InsertUpdateRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""InsertUpdateRule.AssetType"" displayname=""AttributeDefinition'AssetType'InsertUpdateRule"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/AssetType"" tokenref=""InsertUpdateRule.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""InsertUpdateRule.Key"" displayname=""AttributeDefinition'Key'InsertUpdateRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Key"" tokenref=""InsertUpdateRule.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""InsertUpdateRule.Moment"" displayname=""AttributeDefinition'Moment'InsertUpdateRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Moment"" tokenref=""InsertUpdateRule.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""InsertUpdateRule.Is"" displayname=""AttributeDefinition'Is'InsertUpdateRule"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""OnUpdate"" token=""InsertUpdateRule.OnUpdate"" displayname=""AttributeDefinition'OnUpdate'InsertUpdateRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/OnUpdate"" tokenref=""InsertUpdateRule.OnUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""OnInsert"" token=""InsertUpdateRule.OnInsert"" displayname=""AttributeDefinition'OnInsert'InsertUpdateRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/OnInsert"" tokenref=""InsertUpdateRule.OnInsert"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""InsertUpdateRule.Name"" displayname=""AttributeDefinition'Name'InsertUpdateRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Name"" tokenref=""InsertUpdateRule.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Initializer"" token=""InsertUpdateRule.Initializer"" displayname=""AttributeDefinition'Initializer'InsertUpdateRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Initializer"" tokenref=""BaseRule.Initializer"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Initializer"" tokenref=""InsertUpdateRule.Initializer"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Class"" token=""InsertUpdateRule.Class"" displayname=""AttributeDefinition'Class'InsertUpdateRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Class"" tokenref=""BaseRule.Class"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/InsertUpdateRule/Class"" tokenref=""InsertUpdateRule.Class"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""BusinessRule"" token=""BusinessRule"" displayname=""AssetType'BusinessRule"" abstract=""False"">
        <Base nameref=""InsertUpdateRule"" href=""/v1sdktesting/meta.v1/InsertUpdateRule"" />
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/BusinessRule/Order"" tokenref=""BusinessRule.Order"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/BusinessRule/Name"" tokenref=""BusinessRule.Name"" />
        <Name href=""/v1sdktesting/meta.v1/BusinessRule/Name"" tokenref=""BusinessRule.Name"" />
        <AttributeDefinition name=""ChangeDate"" token=""BusinessRule.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDate"" tokenref=""BaseRule.ChangeDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangeDate"" tokenref=""BusinessRule.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""BusinessRule.RetireDate"" displayname=""AttributeDefinition'RetireDate'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDate"" tokenref=""BaseRule.RetireDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetireDate"" tokenref=""BusinessRule.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""BusinessRule.CreateDate"" displayname=""AttributeDefinition'CreateDate'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDate"" tokenref=""BaseRule.CreateDate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreateDate"" tokenref=""BusinessRule.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""BusinessRule.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeDateUTC"" tokenref=""BaseRule.ChangeDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangeDateUTC"" tokenref=""BusinessRule.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""BusinessRule.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireDateUTC"" tokenref=""BaseRule.RetireDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetireDateUTC"" tokenref=""BusinessRule.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""BusinessRule.Days"" displayname=""AttributeDefinition'Days'BusinessRule"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Days"" tokenref=""BaseRule.Days"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Days"" tokenref=""BusinessRule.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""BusinessRule.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'BusinessRule"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateDateUTC"" tokenref=""BaseRule.CreateDateUTC"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreateDateUTC"" tokenref=""BusinessRule.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""BusinessRule.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeReason"" tokenref=""BaseRule.ChangeReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangeReason"" tokenref=""BusinessRule.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""BusinessRule.RetireReason"" displayname=""AttributeDefinition'RetireReason'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireReason"" tokenref=""BaseRule.RetireReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetireReason"" tokenref=""BusinessRule.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""BusinessRule.CreateReason"" displayname=""AttributeDefinition'CreateReason'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateReason"" tokenref=""BaseRule.CreateReason"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreateReason"" tokenref=""BusinessRule.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""BusinessRule.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangeComment"" tokenref=""BaseRule.ChangeComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangeComment"" tokenref=""BusinessRule.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""BusinessRule.RetireComment"" displayname=""AttributeDefinition'RetireComment'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetireComment"" tokenref=""BaseRule.RetireComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetireComment"" tokenref=""BusinessRule.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""BusinessRule.CreateComment"" displayname=""AttributeDefinition'CreateComment'BusinessRule"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreateComment"" tokenref=""BaseRule.CreateComment"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreateComment"" tokenref=""BusinessRule.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""BusinessRule.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/ChangedBy"" tokenref=""BaseRule.ChangedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangedBy.Name"" tokenref=""BusinessRule.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ChangedBy.Name"" tokenref=""BusinessRule.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""BusinessRule.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/RetiredBy"" tokenref=""BaseRule.RetiredBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetiredBy.Name"" tokenref=""BusinessRule.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/RetiredBy.Name"" tokenref=""BusinessRule.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""BusinessRule.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/CreatedBy"" tokenref=""BaseRule.CreatedBy"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreatedBy.Name"" tokenref=""BusinessRule.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/CreatedBy.Name"" tokenref=""BusinessRule.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""BusinessRule.Viewers"" displayname=""AttributeDefinition'Viewers'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Viewers"" tokenref=""BaseRule.Viewers"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""BusinessRule.Prior"" displayname=""AttributeDefinition'Prior'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Prior"" tokenref=""BaseRule.Prior"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Prior.Order"" tokenref=""BusinessRule.Prior.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Prior.Name"" tokenref=""BusinessRule.Prior.Name"" />
            <RelatedAsset nameref=""BusinessRule"" href=""/v1sdktesting/meta.v1/BusinessRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ID"" token=""BusinessRule.ID"" displayname=""AttributeDefinition'ID'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BusinessRule/ID"" tokenref=""BusinessRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/ID"" tokenref=""BusinessRule.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Name"" tokenref=""BusinessRule.Name"" />
            <RelatedAsset nameref=""BusinessRule"" href=""/v1sdktesting/meta.v1/BusinessRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""BusinessRule.Now"" displayname=""AttributeDefinition'Now'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BusinessRule/ID"" tokenref=""BusinessRule.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Now"" tokenref=""BusinessRule.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Name"" tokenref=""BusinessRule.Name"" />
            <RelatedAsset nameref=""BusinessRule"" href=""/v1sdktesting/meta.v1/BusinessRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""BusinessRule.History"" displayname=""AttributeDefinition'History'BusinessRule"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/BusinessRule/Now"" tokenref=""BusinessRule.Now"" />
            <RelatedAsset nameref=""BusinessRule"" href=""/v1sdktesting/meta.v1/BusinessRule"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""BusinessRule.AssetType"" displayname=""AttributeDefinition'AssetType'BusinessRule"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/AssetType"" tokenref=""BusinessRule.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""BusinessRule.Key"" displayname=""AttributeDefinition'Key'BusinessRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Key"" tokenref=""BusinessRule.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""BusinessRule.Moment"" displayname=""AttributeDefinition'Moment'BusinessRule"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Moment"" tokenref=""BusinessRule.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""BusinessRule.Is"" displayname=""AttributeDefinition'Is'BusinessRule"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""Order"" token=""BusinessRule.Order"" displayname=""AttributeDefinition'Order'BusinessRule"" attributetype=""Rank"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Order"" tokenref=""BusinessRule.Order"" />
        </AttributeDefinition>
        <AttributeDefinition name=""OnUpdate"" token=""BusinessRule.OnUpdate"" displayname=""AttributeDefinition'OnUpdate'BusinessRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/InsertUpdateRule/OnUpdate"" tokenref=""InsertUpdateRule.OnUpdate"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/OnUpdate"" tokenref=""BusinessRule.OnUpdate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""OnInsert"" token=""BusinessRule.OnInsert"" displayname=""AttributeDefinition'OnInsert'BusinessRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/InsertUpdateRule/OnInsert"" tokenref=""InsertUpdateRule.OnInsert"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/OnInsert"" tokenref=""BusinessRule.OnInsert"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""BusinessRule.Name"" displayname=""AttributeDefinition'Name'BusinessRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Name"" tokenref=""BaseRule.Name"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Name"" tokenref=""BusinessRule.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Initializer"" token=""BusinessRule.Initializer"" displayname=""AttributeDefinition'Initializer'BusinessRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Initializer"" tokenref=""BaseRule.Initializer"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Initializer"" tokenref=""BusinessRule.Initializer"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Class"" token=""BusinessRule.Class"" displayname=""AttributeDefinition'Class'BusinessRule"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <Base href=""/v1sdktesting/meta.v1/BaseRule/Class"" tokenref=""BaseRule.Class"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/BusinessRule/Class"" tokenref=""BusinessRule.Class"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""Operation"" token=""Operation"" displayname=""AssetType'Operation"" abstract=""False"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
        <DefaultDisplayBy href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
        <ShortName href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
        <Name href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
        <AttributeDefinition name=""ID"" token=""Operation.ID"" displayname=""AttributeDefinition'ID'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Operation/ID"" tokenref=""Operation.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ID"" tokenref=""Operation.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
            <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""Operation.Now"" displayname=""AttributeDefinition'Now'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Operation/ID"" tokenref=""Operation.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Now"" tokenref=""Operation.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
            <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""Operation.History"" displayname=""AttributeDefinition'History'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/Operation/Now"" tokenref=""Operation.Now"" />
            <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""Operation.AssetType"" displayname=""AttributeDefinition'AssetType'Operation"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/AssetType"" tokenref=""Operation.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""Operation.Key"" displayname=""AttributeDefinition'Key'Operation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Key"" tokenref=""Operation.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""Operation.Moment"" displayname=""AttributeDefinition'Moment'Operation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Moment"" tokenref=""Operation.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""Operation.Is"" displayname=""AttributeDefinition'Is'Operation"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""Operation.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangeDate"" tokenref=""Operation.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""Operation.RetireDate"" displayname=""AttributeDefinition'RetireDate'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/RetireDate"" tokenref=""Operation.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""Operation.CreateDate"" displayname=""AttributeDefinition'CreateDate'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/CreateDate"" tokenref=""Operation.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""Operation.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangeDateUTC"" tokenref=""Operation.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""Operation.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/RetireDateUTC"" tokenref=""Operation.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""Operation.Days"" displayname=""AttributeDefinition'Days'Operation"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Days"" tokenref=""Operation.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""Operation.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'Operation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/CreateDateUTC"" tokenref=""Operation.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""Operation.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangeReason"" tokenref=""Operation.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""Operation.RetireReason"" displayname=""AttributeDefinition'RetireReason'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/RetireReason"" tokenref=""Operation.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""Operation.CreateReason"" displayname=""AttributeDefinition'CreateReason'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/CreateReason"" tokenref=""Operation.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""Operation.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangeComment"" tokenref=""Operation.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""Operation.RetireComment"" displayname=""AttributeDefinition'RetireComment'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/RetireComment"" tokenref=""Operation.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""Operation.CreateComment"" displayname=""AttributeDefinition'CreateComment'Operation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/CreateComment"" tokenref=""Operation.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""Operation.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangedBy.Name"" tokenref=""Operation.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/ChangedBy.Name"" tokenref=""Operation.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""Operation.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/RetiredBy.Name"" tokenref=""Operation.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/RetiredBy.Name"" tokenref=""Operation.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""Operation.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/CreatedBy.Name"" tokenref=""Operation.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/CreatedBy.Name"" tokenref=""Operation.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""Operation.Viewers"" displayname=""AttributeDefinition'Viewers'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""Operation.Prior"" displayname=""AttributeDefinition'Prior'Operation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Prior.Name"" tokenref=""Operation.Prior.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/Prior.Name"" tokenref=""Operation.Prior.Name"" />
            <RelatedAsset nameref=""Operation"" href=""/v1sdktesting/meta.v1/Operation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Asset"" token=""Operation.Asset"" displayname=""AttributeDefinition'Asset'Operation"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/AssetType/Operations"" tokenref=""AssetType.Operations"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Asset.Order"" tokenref=""Operation.Asset.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/Operation/Asset.Name"" tokenref=""Operation.Asset.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ExecutePrivileges"" token=""Operation.ExecutePrivileges"" displayname=""AttributeDefinition'ExecutePrivileges'Operation"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ExecutePrivileges"" tokenref=""Operation.ExecutePrivileges"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ExecuteRights"" token=""Operation.ExecuteRights"" displayname=""AttributeDefinition'ExecuteRights'Operation"" attributetype=""LongInt"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/ExecuteRights"" tokenref=""Operation.ExecuteRights"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Validator"" token=""Operation.Validator"" displayname=""AttributeDefinition'Validator'Operation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Validator"" tokenref=""Operation.Validator"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Implementation"" token=""Operation.Implementation"" displayname=""AttributeDefinition'Implementation'Operation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Implementation"" tokenref=""Operation.Implementation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Name"" token=""Operation.Name"" displayname=""AttributeDefinition'Name'Operation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/Name"" tokenref=""Operation.Name"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetTypeName"" token=""Operation.AssetTypeName"" displayname=""AttributeDefinition'AssetTypeName'Operation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/Operation/AssetTypeName"" tokenref=""Operation.AssetTypeName"" />
        </AttributeDefinition>
    </AssetType>
    <AssetType name=""PrimaryRelation"" token=""PrimaryRelation"" displayname=""AssetType'PrimaryRelation"" abstract=""False"">
        <DefaultOrderBy href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
        <AttributeDefinition name=""ID"" token=""PrimaryRelation.ID"" displayname=""AttributeDefinition'ID'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
            <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Now"" token=""PrimaryRelation.Now"" displayname=""AttributeDefinition'Now'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/ID"" tokenref=""PrimaryRelation.ID"" />
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
            <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""History"" token=""PrimaryRelation.History"" displayname=""AttributeDefinition'History'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <ReciprocalRelation href=""/v1sdktesting/meta.v1/PrimaryRelation/Now"" tokenref=""PrimaryRelation.Now"" />
            <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""AssetType"" token=""PrimaryRelation.AssetType"" displayname=""AttributeDefinition'AssetType'PrimaryRelation"" attributetype=""AssetType"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/AssetType"" tokenref=""PrimaryRelation.AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Key"" token=""PrimaryRelation.Key"" displayname=""AttributeDefinition'Key'PrimaryRelation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Key"" tokenref=""PrimaryRelation.Key"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Moment"" token=""PrimaryRelation.Moment"" displayname=""AttributeDefinition'Moment'PrimaryRelation"" attributetype=""Opaque"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Moment"" tokenref=""PrimaryRelation.Moment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Is"" token=""PrimaryRelation.Is"" displayname=""AttributeDefinition'Is'PrimaryRelation"" attributetype=""Boolean"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"" />
        <AttributeDefinition name=""ChangeDate"" token=""PrimaryRelation.ChangeDate"" displayname=""AttributeDefinition'ChangeDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeDate"" tokenref=""PrimaryRelation.ChangeDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDate"" token=""PrimaryRelation.RetireDate"" displayname=""AttributeDefinition'RetireDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireDate"" tokenref=""PrimaryRelation.RetireDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDate"" token=""PrimaryRelation.CreateDate"" displayname=""AttributeDefinition'CreateDate'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateDate"" tokenref=""PrimaryRelation.CreateDate"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeDateUTC"" token=""PrimaryRelation.ChangeDateUTC"" displayname=""AttributeDefinition'ChangeDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeDateUTC"" tokenref=""PrimaryRelation.ChangeDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireDateUTC"" token=""PrimaryRelation.RetireDateUTC"" displayname=""AttributeDefinition'RetireDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireDateUTC"" tokenref=""PrimaryRelation.RetireDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Days"" token=""PrimaryRelation.Days"" displayname=""AttributeDefinition'Days'PrimaryRelation"" attributetype=""Numeric"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Days"" tokenref=""PrimaryRelation.Days"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateDateUTC"" token=""PrimaryRelation.CreateDateUTC"" displayname=""AttributeDefinition'CreateDateUTC'PrimaryRelation"" attributetype=""Date"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateDateUTC"" tokenref=""PrimaryRelation.CreateDateUTC"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeReason"" token=""PrimaryRelation.ChangeReason"" displayname=""AttributeDefinition'ChangeReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeReason"" tokenref=""PrimaryRelation.ChangeReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireReason"" token=""PrimaryRelation.RetireReason"" displayname=""AttributeDefinition'RetireReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireReason"" tokenref=""PrimaryRelation.RetireReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateReason"" token=""PrimaryRelation.CreateReason"" displayname=""AttributeDefinition'CreateReason'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateReason"" tokenref=""PrimaryRelation.CreateReason"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangeComment"" token=""PrimaryRelation.ChangeComment"" displayname=""AttributeDefinition'ChangeComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangeComment"" tokenref=""PrimaryRelation.ChangeComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetireComment"" token=""PrimaryRelation.RetireComment"" displayname=""AttributeDefinition'RetireComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetireComment"" tokenref=""PrimaryRelation.RetireComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreateComment"" token=""PrimaryRelation.CreateComment"" displayname=""AttributeDefinition'CreateComment'PrimaryRelation"" attributetype=""Text"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreateComment"" tokenref=""PrimaryRelation.CreateComment"" />
        </AttributeDefinition>
        <AttributeDefinition name=""ChangedBy"" token=""PrimaryRelation.ChangedBy"" displayname=""AttributeDefinition'ChangedBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangedBy.Name"" tokenref=""PrimaryRelation.ChangedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/ChangedBy.Name"" tokenref=""PrimaryRelation.ChangedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""RetiredBy"" token=""PrimaryRelation.RetiredBy"" displayname=""AttributeDefinition'RetiredBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetiredBy.Name"" tokenref=""PrimaryRelation.RetiredBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/RetiredBy.Name"" tokenref=""PrimaryRelation.RetiredBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""CreatedBy"" token=""PrimaryRelation.CreatedBy"" displayname=""AttributeDefinition'CreatedBy'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreatedBy.Name"" tokenref=""PrimaryRelation.CreatedBy.Name"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/CreatedBy.Name"" tokenref=""PrimaryRelation.CreatedBy.Name"" />
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Viewers"" token=""PrimaryRelation.Viewers"" displayname=""AttributeDefinition'Viewers'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""True"" iscanned=""True"" iscustom=""False"">
            <RelatedAsset nameref=""Member"" href=""/v1sdktesting/meta.v1/Member"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Prior"" token=""PrimaryRelation.Prior"" displayname=""AttributeDefinition'Prior'PrimaryRelation"" attributetype=""Relation"" isreadonly=""True"" isrequired=""False"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Prior.ID"" tokenref=""PrimaryRelation.Prior.ID"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Prior"" tokenref=""PrimaryRelation.Prior"" />
            <RelatedAsset nameref=""PrimaryRelation"" href=""/v1sdktesting/meta.v1/PrimaryRelation"" />
        </AttributeDefinition>
        <AttributeDefinition name=""To"" token=""PrimaryRelation.To"" displayname=""AttributeDefinition'To'PrimaryRelation"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/To.Order"" tokenref=""PrimaryRelation.To.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/To.Name"" tokenref=""PrimaryRelation.To.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""From"" token=""PrimaryRelation.From"" displayname=""AttributeDefinition'From'PrimaryRelation"" attributetype=""Relation"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/From.Order"" tokenref=""PrimaryRelation.From.Order"" />
            <DisplayByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/From.Name"" tokenref=""PrimaryRelation.From.Name"" />
            <RelatedAsset nameref=""AssetType"" href=""/v1sdktesting/meta.v1/AssetType"" />
        </AttributeDefinition>
        <AttributeDefinition name=""Relation"" token=""PrimaryRelation.Relation"" displayname=""AttributeDefinition'Relation'PrimaryRelation"" attributetype=""Text"" isreadonly=""False"" isrequired=""True"" ismultivalue=""False"" iscanned=""True"" iscustom=""False"">
            <OrderByAttribute href=""/v1sdktesting/meta.v1/PrimaryRelation/Relation"" tokenref=""PrimaryRelation.Relation"" />
        </AttributeDefinition>
    </AssetType>
</Meta>";
    }
}
