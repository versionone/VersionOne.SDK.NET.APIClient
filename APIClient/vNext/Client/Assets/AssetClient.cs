using System;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace VersionOne.Assets
{
	public class AssetClient : RestClient
	{
		public AssetClient(string baseUrl, string userName, string password) : base(baseUrl)
		{
			Require.Argument("baseUrl", baseUrl);

			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("userName");
			}
			if (string.IsNullOrWhiteSpace(password))
			{
				throw new ArgumentNullException("password");
			}

			Authenticator = new HttpBasicAuthenticator(userName, password);
			ClearHandlers();
			AddHandler("text/xml", new AssetDeserializer());
		}

		public AssetClient(string baseUrl, string accessToken) : base(baseUrl)
		{
			Require.Argument("baseUrl", baseUrl);

			if (string.IsNullOrWhiteSpace(accessToken))
			{
				throw new ArgumentNullException("accessToken");
			}
			Authenticator = new AcccessTokenAuthenticator(accessToken);
			ClearHandlers();
			AddHandler("text/xml", new AssetDeserializer());
		}

		//public IRestResponse<dynamic> Create(string assetType, object attributes)
		public IAssetBase Create(string assetTypeName, object attributes)
		{
			var payload = RestApiPayloadBuilder.Build(attributes);
			var req = new RestRequest(assetTypeName, Method.POST);
			req.AddParameter("application/json", payload, ParameterType.RequestBody);
			var res = this.Post<dynamic>(req);
			return new AssetBase(res.Data[0], true);
		}

		//public IRestResponse<dynamic> Update(string oidToken, object attributes)
		public IAssetBase Update(string oidToken, object attributes)
		{
			var payload = RestApiPayloadBuilder.Build(attributes);
			var asset = oidToken.Replace(":", "/");
			var req = new RestRequest(asset, Method.POST);
			req.AddParameter("application/json", payload, ParameterType.RequestBody);
			var res = this.Post<dynamic>(req);
			return new AssetBase(res.Data[0], true);
		}

		public IAssetBase Update(IAssetBase asset)
		{
			var oidToken = asset.OidToken;
			// TODO: the only kind of IAssetBase. Should there be others?
			var concreteAsset = asset as AssetBase;
			var changes = concreteAsset.GetChangesDto();
			return Update(oidToken, changes);
		}


		public IFluentQueryBuilder Query(string assetSource)
		{
			Func<string, IList<IAssetBase>> execute = (string query) =>
			{
				var req = new RestRequest(query);
				var response = this.Get<List<dynamic>>(req);
				var results = response.Data as IList<dynamic>;
				var assets = new List<IAssetBase>(results.Count);
				foreach (dynamic item in results)
				{
					assets.Add(new AssetBase(item, true));
				}
				return assets;
			};
			return new FluentQueryBuilder(assetSource, execute);
		}
	}
}


