namespace VersionOne.SDK.APIClient
{
    public interface ICanGetConnector
    {
        /// <summary>
        /// Required terminating method that returns the V1Connector object.
        /// </summary>
        /// <returns></returns>
        V1Connector Build();
    }
}