using System.IO;

namespace VersionOne.SDK.APIClient.Connector.Interfaces
{
    public interface ICanMakeRequest
    {
        /// <summary>
        /// Gets the server data after sending a GET request.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        Stream GetData(string resource = null);

        /// <summary>
        /// Gets the server data after a POST request.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resource"></param>
        /// <param name="requestFormat"></param>
        /// <returns></returns>
        Stream SendData(object data, string resource = null, RequestFormat requestFormat = RequestFormat.Xml);
    }
}