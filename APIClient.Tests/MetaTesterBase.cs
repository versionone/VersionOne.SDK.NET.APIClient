namespace VersionOne.SDK.APIClient.Tests
{
    public class MetaTesterBase
    {
        protected virtual string MetaTestKeys { get { return null; } }
        protected virtual bool Preload { get { return false; } }

        private IMetaModel _meta;
        protected IMetaModel Meta
        {
            get
            {
                if (_meta == null)
                    _meta = new MetaModel(new XmlResponseConnector("TestData.xml", "meta.v1/", MetaTestKeys), Preload);
                return _meta;
            }
        }

        protected IAssetType AssetType(string token)
        {
            return Meta.GetAssetType(token);
        }

        protected IAttributeDefinition AttributeDefinition(string token)
        {
            return Meta.GetAttributeDefinition(token);
        }

        protected IOperation Operation(string token)
        {
            return Meta.GetOperation(token);
        }

        protected IAssetType ScopeType { get { return AssetType("Scope"); } }
        protected IAssetType ThemeType { get { return AssetType("Theme"); } }

        protected IAttributeDefinition WorkitemScope { get { return AttributeDefinition("Workitem.Scope"); } }
        protected IAttributeDefinition WorkitemParent { get { return AttributeDefinition("Workitem.Parent"); } }
        protected IAttributeDefinition WorkitemToDo { get { return AttributeDefinition("Workitem.ToDo"); } }

        protected Oid ScopeOid(int id) { return new Oid(ScopeType, id, null); }
        protected Oid ThemeOid(int id) { return new Oid(ThemeType, id, null); }	
    }
}
