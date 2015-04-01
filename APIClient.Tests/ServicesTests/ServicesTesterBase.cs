namespace VersionOne.SDK.APIClient.Tests.ServicesTests
{
    public abstract class ServicesTesterBase
    {
        protected ServicesTesterBase()
        {
            DataConnector.BeforeGetData += DataConnector_BeforeGetData;
            DataConnector.BeforeSendData += DataConnector_BeforeSendData;
        }

        protected virtual string ServicesTestKeys
        {
            get { return null; }
        }

        protected virtual bool Preload
        {
            get { return false; }
        }

        private IMetaModel meta;

        protected IMetaModel Meta
        {
            get
            {
                if (meta == null)
                {
                    meta = new MetaModel(new XmlResponseConnector("TestData.xml", "meta.v1/", ServicesTestKeys), Preload);
                }

                return meta;
            }
        }

        private XmlResponseConnector dataConnector;

        internal XmlResponseConnector DataConnector
        {
            get
            {
                if (dataConnector == null)
                {
                    dataConnector = new XmlResponseConnector("TestData.xml", "rest-1.v1/", ServicesTestKeys);
                }

                return dataConnector;
            }

        }

        protected IAssetType AssetType(string token)
        {
            return Meta.GetAssetType(token);
        }

        private DataRequestEventArgs lastBeforeGetDataArgs;

        private void DataConnector_BeforeGetData(object sender, DataRequestEventArgs e)
        {
            lastBeforeGetDataArgs = e;
        }

        internal void GetLastGetDataRequest(ref DataRequestEventArgs e)
        {
            e = lastBeforeGetDataArgs;
        }

        private DataRequestEventArgs lastBeforeSendDataArgs;

        private void DataConnector_BeforeSendData(object sender, DataRequestEventArgs e)
        {
            lastBeforeSendDataArgs = e;
        }

        internal void GetLastSendDataRequest(ref DataRequestEventArgs e)
        {
            e = lastBeforeSendDataArgs;
        }
    }
}
