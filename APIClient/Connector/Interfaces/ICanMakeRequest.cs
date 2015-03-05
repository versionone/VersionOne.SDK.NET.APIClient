using System.IO;

namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanMakeRequest
    {
        Stream GetData(string resource = null);

        Stream SendData(object data, string resource = null, RequestFormat requestFormat = RequestFormat.Xml);
    }
}