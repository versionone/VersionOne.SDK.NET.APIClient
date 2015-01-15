namespace VersionOne.SDK.APIClient.Tests
{
    public class LocalizerTesterBase
    {
        private ILocalizer _loc;
        protected ILocalizer Loc
        {
            get
            {
                if (_loc == null)
                    _loc = new Localizer(new TextResponseConnector("TestData.xml", "loc.v1/", LocTestKeys));
                return _loc;
            }
        }

        protected virtual string LocTestKeys { get { return null; } }
    }
}
