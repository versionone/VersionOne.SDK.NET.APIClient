/*


            var baseUrl = "http://localhost/VersionOne.Web";
            // http://localhost/VersionOne.Web/oauth.v1/auth?response_type=code&client_id=client_uo4z9tdx&redirect_uri=urn:ietf:wg:oauth:2.0:oob&scope=query-api-1.0
            // http://localhost/VersionOne.Web/oauth.v1/auth?response_type=code&client_id=client_uo4z9tdx&redirect_uri=urn:ietf:wg:oauth:2.0:oob&scope=apiv1
            const string authorizationCode =
                "E5yQ!IAAAAM-COgXYe5PCkQ5zJtod7jhpGXYGNpa4kL5ZZlXeLSmWAQEAAAF9KsVYrxgiVxVTlANYWNI1gBp4GPR9CQxSvEeCLFtw27rCp5DkrUrkxk9plQ20si33XnfwqOFygV0gQcMWzeTpijRq4IfwA44v5ZvVwiOwEPX8QM4TJTIdLCU1W4fqADLK9Zchce_0UCl80hCCbXEZlYWmlzrvlxPKKLePPIltTJIJ4Pmt1Pq9C93oSCX_IWPbdvEmube9pqPQ0HntE6jAszAM8kjlzhOl9QVwSgXzADoKSKFv027OHlAjCAgOgXIcU1LgJ1bYmgTHT4uM5sD6rMhIfNyaBQq-_eXk72Y6f9Q1E0aY7fkv94rFG3uIWaRzpHHxJZ7209gXZtqLXgd-";

            var client = new RestClient(baseUrl);
            var request = new RestRequest("/oauth.v1/token", Method.POST);

            request.AddParameter("code", authorizationCode);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("redirect_uri", "urn:ietf:wg:oauth:2.0:oob");
            request.AddParameter("client_id", "client_uo4z9tdx");
            //request.AddParameter("scope", "apiv1");
            request.AddParameter("scope", "query-api-1.0");
            request.AddParameter("client_secret", "twaoty4e36cdsuf6q3ns");

            var response = client.Execute<AccessToken>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Error.WriteLine("Failed!!!");
            }

            // Extract the Access Token
            var accessToken = response.Data.access_token;


            client = new RestClient("http://localhost/VersionOne.Web");
            var oauthAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator();
            var query =
                @"from: Member
select:
    - Description
    - Name
    - Nickname
where:
    Name: Administrator";
            //client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken);
            request = new RestRequest("/query.v1");
            request.AddHeader(
                "Authorization",
                string.Format("Bearer {0}", accessToken));
            request.AddBody(query);
            var memberResponse = client.Post<List<Member>>(request);
            Console.WriteLine(memberResponse.Data[0].Name);
            Console.WriteLine(memberResponse.Data[0].Description);
            Console.WriteLine(memberResponse.Data[0].Nickname);
        }
    }

    public class AccessToken
    {
        public string access_token { get; set; }
    }
*/


/*
var client = new RestClient("http://eval.versionone.net/platformtest");
client.Authenticator = new HttpBasicAuthenticator("admin", "admin");
client.AddHandler("text/xml", new JsonDeserializer()); // hack for now

var request = new RestRequest("rest-1.v1/Data/Member/20?sel=Name,Description,Nickname");
request.AddHeader("Accept", "haljson");
var memberResponse = client.Get<Member>(request);

Console.WriteLine(memberResponse.Data.Name);
Console.WriteLine(memberResponse.Data.Description);
Console.WriteLine(memberResponse.Data.Nickname);
*/
