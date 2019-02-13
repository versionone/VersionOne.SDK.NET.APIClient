using System;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VersionOne.Assets
{
	public class AssetClient : RestClient
	{
		public AssetClient(string baseUrl, string userName, string password) : base(baseUrl)
		{
			Require.Argument(nameof(baseUrl), baseUrl);

			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}
			if (string.IsNullOrWhiteSpace(password))
			{
				throw new ArgumentNullException(nameof(password));
			}

			Authenticator = new HttpBasicAuthenticator(userName, password);
		}

		public AssetClient(string baseUrl, string accessToken) : base(baseUrl)
		{
			Require.Argument(nameof(baseUrl), baseUrl);

			if (string.IsNullOrWhiteSpace(accessToken))
			{
				throw new ArgumentNullException(nameof(accessToken));
			}
			Authenticator = new AcccessTokenAuthenticator(accessToken);
		}

		public IAsset Create(object attributes)
		{
			dynamic payload = JObject.FromObject(attributes);
			if (payload.AssetType == null)
				throw new ArgumentNullException("Must provide an AssetType attribute in the supplied attributes parameter");
			return PostAsset(payload);
		}

		public IAsset Create(params (string name, object value)[] attributes) =>
			Create(ClientUtilities.Attributes(attributes));

		public IAsset Create(IAsset asset)
		{
			dynamic payload = JObject.FromObject(asset.Attributes);
			return PostAsset(payload);
		}

		private IAsset PostAsset(dynamic payload)
		{
			//var req = new RestRequest(string.Empty, Method.POST);
			var obj = DoPost(payload.ToString());
			var asset = new Asset(payload, true);
			asset.ApplyOids(obj.assetsCreated.oidTokens.Values<string>());
			return asset;
		}

		//public IRestResponse<dynamic> Update(string oidToken, object attributes)
		public IAsset Update(string oid, object changedAttributes)
		{
			if (UpdateInternal(oid, changedAttributes)) {
				var assetAttributes = JObject.FromObject(changedAttributes);
				var asset = new Asset(assetAttributes, false);
				asset.Oid = oid;
				return asset;
			}
			else throw new Exception("TODO the Update did not work, and this exception path needs to be handled more gracefully");
		}

		public IAsset Update(IAsset asset)
		{
			var oid = asset.Oid;
			var concreteAsset = asset as Asset;
			var changedAttributes = concreteAsset.GetChangesDto();
			if (UpdateInternal(oid, changedAttributes)) return asset;
			else throw new Exception("TODO the Update did not work, and this exception path needs to be handled more gracefully");			
		}

		public IEnumerable<string> Update(QueryApiQueryBuilder querySpec, object changedAttributes)
		{
			var updateBuilder = new UpdateApiBuilder(querySpec, changedAttributes);
			var payload = updateBuilder.ToString();
			dynamic obj = DoPost(payload);
			return obj.assetsModified.oidTokens.ToObject<string[]>();
		}

		public IEnumerable<string> ExecuteOperation(QueryApiQueryBuilder querySpec, string operation)
		{
			var executeOperationBuilder = new ExecuteOperationApiBuilder(querySpec, operation);
			var payload = executeOperationBuilder.ToString();
			dynamic obj = DoPost(payload);
			return obj.assetsOperatedOn.oidTokens.ToObject<string[]>();
		}

		private bool UpdateInternal(string oid, object changedAttributes)
		{
			var payload = AssetApiPayloadBuilder.Build(oid, changedAttributes);
			// TODO inspect for errors
			// TODO: this is only helpful in a one-update situation
			dynamic obj = DoPost(payload);
			var result = obj.assetsModified.oidTokens[0].Value;
			// TODO this is kind of weird, do we need to do this?
			return result == oid;
		}

		public IFluentQueryBuilder Query(string from)
		{
			Func<string, IList<IAsset>> execute = (string payload) =>
			{
				dynamic obj = DoPost(payload);
				var results = obj.queryResult.results[0];
				var assets = new List<IAsset>(results.Count);
				foreach (dynamic item in results)
				{
					assets.Add(new Asset(item, true));
				}
				return assets;
			};

			return new FluentQueryBuilder(from, execute);
		}

		private dynamic DoPost(string payload)
		{
			var req = new RestRequest();
			req.AddParameter("application/json", payload, ParameterType.RequestBody);
			var response = this.Post(req);
			return GetParsedResult(response);
		}
		private dynamic GetParsedResult(IRestResponse response)
		{
			var content = response.Content.Replace("\"_oid\"", "\"Oid\"");
			dynamic obj = JObject.Parse(content);
			return obj;
		}
	}
}