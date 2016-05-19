module When_preLoadMeta_is_false
open FSpec.Dsl
open FSpec.Matchers
open VersionOne.SDK.APIClient
open ServicesConstructorHelpers
open MetaSamplePayloads

let specs =
    describe "Services" [
        describe "Constructor" [
            context "When preLoadMeta is false" [
                subject <| fun ctx ->
                    configure(ctx)
                    configureRoute ctx "/meta.v1//AssetType" assetTypeType
                    configureRoute ctx "/meta.v1//PrimaryRelation" primaryRelationType

                    let connector = createConnector
                    Services(connector)
                
                before <| fun ctx ->
                    let subject = ctx.GetSubject<IServices>()
                    ctx?assetTypeType <- subject.Meta.GetAssetType "AssetType"
                    ctx?primaryRelationType <- subject.Meta.GetAssetType "PrimaryRelation"

                it "should not call the full meta.v1 route" <| fun ctx -> assertRouteNotCalled ctx "meta.v1//"
                
                it "should access the AssetType route" <| fun ctx -> assertRouteCalled ctx "/meta.v1//AssetType"
                it "should let me access the AssetType type" <| fun ctx -> ctx?assetTypeType |> shouldNot (equal null)

                it "should access the AssetType route" <| fun ctx -> assertRouteCalled ctx "/meta.v1//PrimaryRelation"
                it "should let me access the PrimaryRelation type" <| fun ctx -> ctx?primaryRelationType |> shouldNot (equal null)
            ]]]