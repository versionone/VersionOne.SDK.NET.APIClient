namespace VersionOne.Assets
{
    public class AcccessTokenAuthenticator : RestSharp.Authenticators.IAuthenticator
    {
        private string _accessToken { get; set; }

        public AcccessTokenAuthenticator(string accessToken)
        {
            _accessToken = accessToken;
        }

        public void Authenticate(RestSharp.IRestClient client, RestSharp.IRestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + _accessToken);
        }
    }
}
