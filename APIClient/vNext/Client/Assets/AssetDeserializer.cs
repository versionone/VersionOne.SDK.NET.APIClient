using RestSharp.Deserializers;

namespace VersionOne.Assets
{
    public class AssetDeserializer : IDeserializer
    {
        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var translator = new TranslateAssetXmlOutputToHalJson();

            var result = translator.Execute<T>(response.Content);

            return result;
        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}
