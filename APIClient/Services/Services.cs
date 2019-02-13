﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;
using VersionOne.Assets;

namespace VersionOne.SDK.APIClient
{
	public class Services : IServices
	{
		private readonly IMetaModel _meta;
		private readonly IAPIConnector _connector;
		private readonly V1Connector _v1Connector;
		private Oid _loggedIn;

		public Oid LoggedIn
		{
			get
			{
				if (_loggedIn == null)
				{
					var q = new Query(_meta.GetAssetType("Member"));
					var term = new FilterTerm(_meta.GetAttributeDefinition("Member.IsSelf"));
					term.Equal(true);
					q.Filter = term;
					var list = Retrieve(q).Assets;

					if (list.Count != 1)
					{
						_loggedIn = Oid.Null;
					}
					else
					{
						_loggedIn = list[0].Oid;
					}
				}

				return _loggedIn;
			}
		}

		public Services(IMetaModel meta, IAPIConnector connector)
		{
			if (meta == null)
				throw new ArgumentNullException("meta");
			if (connector == null)
				throw new ArgumentNullException("connector");

			_meta = meta;
			_connector = connector;
		}

		public Services(V1Connector v1Connector)
		{
			if (v1Connector == null)
				throw new ArgumentNullException("v1Connector");

			_v1Connector = v1Connector;
			_meta = new MetaModel(_v1Connector);
		}

		public IMetaModel Meta
		{
			get { return _meta; }
		}

		public void SetUpstreamUserAgent(string userAgent)
		{
			if (_connector != null)
			{
				_connector.SetUpstreamUserAgent(userAgent);
			}
			else
			{
				_v1Connector.SetUpstreamUserAgent(userAgent);
			}
		}

		public QueryResult Retrieve(Query query)
		{
			var doc = new XmlDocument();

			try
			{
				Stream stream;
				if (_connector != null)
				{
					stream = _connector.GetData(new QueryURLBuilder(query).ToString());
				}
				else
				{
					if (query.IsHistorical)
					{
						_v1Connector.UseHistoryApi();
					}
					else
					{
						_v1Connector.UseDataApi();
					}
					stream = _v1Connector.GetData(new QueryURLBuilder(query, true).ToString());
				}
				doc.Load(stream);
				stream.Dispose();
			}
			catch (WebException ex)
			{
				//if we get a 404, return an empty query result otherwise throw the exception
				if ((ex.Response is HttpWebResponse && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound) || ex.Status.ToString() == "404")
				{
					return GetEmptyQueryResult(query);
				}

				throw;
			}

			return ParseQueryResult(doc.DocumentElement, query);
		}

		public Oid GetOid(string token)
		{
			return Oid.FromToken(token, _meta);
		}

		public Oid ExecuteOperation(IOperation op, Oid oid)
		{
			var doc = new XmlDocument();

			try
			{
				var path = oid.AssetType.Token + "/" + oid.Key + "?op=" + op.Name;
				Stream stream;
				if (_connector != null)
				{
					path = "Data/" + path;
					stream = _connector.SendData(path, string.Empty);
				}
				else
				{
					_v1Connector.UseDataApi();
					stream = _v1Connector.SendData(path);
				}
				doc.Load(stream);
				stream.Dispose();

				var asset = ParseAssetNode(doc.DocumentElement);

				return asset.Oid;
			}
			catch (WebException ex)
			{
				using (var stream = ex.Response.GetResponseStream())
				{
					doc.Load(stream);
				}

				var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
				throw new APIException(message, oid.Token, ex);
			}
			catch (Exception ex)
			{
				throw new APIException("Failed to execute", oid.Token, ex);
			}
		}

		public void Save(Asset asset)
		{
			Save(asset, string.Empty);
		}

		public void Save(Asset asset, string comment)
		{
			if (asset.HasChanged || asset.Oid.IsNull)
			{
				var doc = new XmlDocument();

				var s = new StringWriter();
				var writer = new XmlApiWriter(s, true);
				writer.WriteAsset(asset);
				var data = s.ToString();

				var path = asset.AssetType.Token;

				if (!asset.Oid.IsNull)
				{
					path += "/" + asset.Oid.Key;
				}

				if (comment != null & comment != string.Empty)
				{
					path += string.Format("?Comment='{0}'", System.Web.HttpUtility.UrlEncode(comment));
				}

				try
				{
					Stream stream;
					if (_connector != null)
					{
						path = "Data/" + path;
						stream = _connector.SendData(path, data);
					}
					else
					{
						_v1Connector.UseDataApi();
						stream = _v1Connector.SendData(path, data);
					}
					doc.Load(stream);
					stream.Dispose();

					ParseSaveAssetNode(doc.DocumentElement, asset);
				}
				catch (WebException ex)
				{
					if (ex.Response == null)
					{
						throw new ConnectionException("Error writing to output stream", ex);
					}

					using (var stream = ex.Response.GetResponseStream())
					{
						doc.Load(stream);
					}

					var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
					throw new APIException(message, asset.Oid.Token, ex);
				}
				catch (Exception ex)
				{
					throw new APIException("Failed to save", asset.Oid.Token, ex);
				}
			}
		}

		public void Save(AssetList assetList)
		{
			foreach (var asset in assetList)
			{
				Save(asset);
			}
		}

		public Asset New(IAssetType assetType, Oid context)
		{
			var doc = new XmlDocument();

			var path = assetType.Token;

			if (context != null && !context.IsNull)
			{
				path += "?ctx=" + context.Token;
			}

			try
			{
				Stream stream;
				if (_connector != null)
				{
					path = "New/" + path;
					stream = _connector.GetData(path);
				}
				else
				{
					_v1Connector.UseNewApi();
					stream = _v1Connector.GetData(path);
				}
				doc.Load(stream);
				stream.Dispose();

				return ParseNewAssetNode(doc.DocumentElement, assetType);
			}
			catch (Exception ex)
			{
				throw new APIException("Failed to get new asset!", assetType.Token, ex);
			}
		}

		public string Localization(string key)
		{
			var path = string.Format("?{0}", key);
			Stream stream;
			if (_connector != null)
			{
				path = "loc.v1/" + path;
				stream = _connector.GetData(path);
			}
			else
			{
				_v1Connector.UseLocApi();
				stream = _v1Connector.GetData(path);
			}

			string result;
			using (StreamReader reader = new StreamReader(stream))
			{
				result = reader.ReadToEnd();
			}

			return result;
		}

		public string Localization(IAttributeDefinition attribute)
		{
			var urlParam = string.Format("AttributeDefinition'{0}'{1}", attribute.Name, attribute.AssetType.Token);

			var path = string.Format("?{0}", string.Join(",", urlParam));

			Stream stream;
			if (_connector != null)
			{
				path = "loc.v1/" + path;
				stream = _connector.GetData(path);
			}
			else
			{
				_v1Connector.UseLocApi();
				stream = _v1Connector.GetData(path);
			}

			string result;
			using (StreamReader reader = new StreamReader(stream))
			{
				result = reader.ReadToEnd();
			}

			return result;
		}

		public Dictionary<string, string> Localization(params IAttributeDefinition[] attributes)
		{
			var locs = new Dictionary<string, string>();
			var urlParams =
				attributes.Select(
					attributeDefinition =>
						string.Format("AttributeDefinition'{0}'{1}", attributeDefinition.Name,
							attributeDefinition.AssetType.Token)).ToList();

			var path = string.Format("?[{0}]", string.Join(",", urlParams));

			Stream stream;
			if (_connector != null)
			{
				path = "loc-2.v1/" + path;
				stream = _connector.GetData(path);
			}
			else
			{
				_v1Connector.UseLoc2Api();
				stream = _v1Connector.GetData(path);
			}

			string result;
			using (StreamReader reader = new StreamReader(stream))
			{
				result = reader.ReadToEnd();
			}

			var jsonResult = JObject.Parse(result);
			foreach (var attributeDefinition in attributes)
			{
				var param = string.Format("AttributeDefinition'{0}'{1}", attributeDefinition.Name,
					attributeDefinition.AssetType.Token);
				locs.Add(attributeDefinition.Token, jsonResult[param].Value<string>());
			}

			return locs;
		}

		public string ExecutePassThroughQuery(string query)
		{
			_v1Connector.UseQueryApi();

			return _v1Connector.StringSendData(data: query, contentType: "application/json");
		}

		public Oid SaveAttachment(string filePath, Asset asset, string attachmentName)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentNullException("filePath");
			if (!File.Exists(filePath))
				throw new APIException(string.Format("File \"{0}\" does not exist.", filePath));

			var mimeType = MimeType.Resolve(filePath);
			IAssetType attachmentType = Meta.GetAssetType("Attachment");
			IAttributeDefinition attachmentAssetDef = attachmentType.GetAttributeDefinition("Asset");
			IAttributeDefinition attachmentContent = attachmentType.GetAttributeDefinition("Content");
			IAttributeDefinition attachmentContentType = attachmentType.GetAttributeDefinition("ContentType");
			IAttributeDefinition attachmentFileName = attachmentType.GetAttributeDefinition("Filename");
			IAttributeDefinition attachmentNameAttr = attachmentType.GetAttributeDefinition("Name");
			Asset attachment = New(attachmentType, Oid.Null);
			attachment.SetAttributeValue(attachmentNameAttr, attachmentName);
			attachment.SetAttributeValue(attachmentFileName, filePath);
			attachment.SetAttributeValue(attachmentContentType, mimeType);
			attachment.SetAttributeValue(attachmentContent, string.Empty);
			attachment.SetAttributeValue(attachmentAssetDef, asset.Oid);
			Save(attachment);

			string key = attachment.Oid.Key.ToString();

			using (Stream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				using (Stream output = _connector != null ? _connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1)) : _v1Connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1)))
				{
					byte[] buffer = new byte[input.Length + 1];
					while (true)
					{
						int read = input.Read(buffer, 0, buffer.Length);
						if (read <= 0)
							break;

						output.Write(buffer, 0, read);
					}
				}
			}
			if (_connector != null)
			{
				_connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), mimeType);
			}
			else
			{
				_v1Connector.UseAttachmentApi();
				_v1Connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), mimeType);
			}

			return attachment.Oid;
		}

		public Stream GetAttachment(Oid attachmentOid)
		{
			Stream result = null;
			if (_connector != null)
			{
				result = _connector.GetData(attachmentOid.Key.ToString());
			}
			else if (_v1Connector != null)
			{
				_v1Connector.UseAttachmentApi();
				result = _v1Connector.GetData(attachmentOid.Key.ToString());
			}

			return result;
		}

		public Oid SaveEmbeddedImage(string filePath, Asset asset)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentNullException("filePath");
			if (!File.Exists(filePath))
				throw new APIException(string.Format("File \"{0}\" does not exist.", filePath));

			var mimeType = MimeType.Resolve(filePath);
			var embeddedImageType = Meta.GetAssetType("EmbeddedImage");
			var newEmbeddedImage = New(embeddedImageType, Oid.Null);
			var assetAttribute = embeddedImageType.GetAttributeDefinition("Asset");
			var contentAttribute = embeddedImageType.GetAttributeDefinition("Content");
			var contentTypeAttribute = embeddedImageType.GetAttributeDefinition("ContentType");
			newEmbeddedImage.SetAttributeValue(assetAttribute, asset.Oid);
			newEmbeddedImage.SetAttributeValue(contentTypeAttribute, mimeType);
			newEmbeddedImage.SetAttributeValue(contentAttribute, string.Empty);
			Save(newEmbeddedImage);

			string key = newEmbeddedImage.Oid.Key.ToString();

			using (Stream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				using (Stream output = _connector != null ? _connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1)) : _v1Connector.BeginRequest(key.Substring(key.LastIndexOf('/') + 1)))
				{
					byte[] buffer = new byte[input.Length + 1];
					while (true)
					{
						int read = input.Read(buffer, 0, buffer.Length);
						if (read <= 0)
							break;

						output.Write(buffer, 0, read);
					}
				}
			}
			if (_connector != null)
			{
				_connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), mimeType);
			}
			else
			{
				_v1Connector.UseEmbeddedApi();
				_v1Connector.EndRequest(key.Substring(key.LastIndexOf('/') + 1), mimeType);
			}

			return newEmbeddedImage.Oid;
		}

		public Stream GetEmbeddedImage(Oid embeddedImageOid)
		{
			Stream result = null;
			if (_connector != null)
			{
				result = _connector.GetData(embeddedImageOid.Key.ToString());
			}
			else if (_v1Connector != null)
			{
				_v1Connector.UseEmbeddedApi();
				result = _v1Connector.GetData(embeddedImageOid.Key.ToString());
			}

			return result;
		}

		private QueryResult ParseQueryResult(XmlElement element, Query query)
		{
			switch (element.LocalName)
			{
				case "History":
					return ParseHistoryQueryResult(element, query);
				case "Assets":
					return ParseAssetListQueryResult(element, query);
				case "Asset":
					return ParseAssetQueryResult(element, query);
				case "Attribute":
					return ParseAttributeQueryResult(element, query);
				case "Relation":
					return ParseAttributeQueryResult(element, query);
				default:
					return GetEmptyQueryResult(query);
			}
		}

		private static QueryResult GetEmptyQueryResult(Query query)
		{
			return new QueryResult(new AssetList(), 0, query);
		}

		private QueryResult ParseHistoryQueryResult(XmlElement element, Query query)
		{
			if (!element.HasChildNodes)
			{
				return new QueryResult(new AssetList(), 0, query);
			}

			if (element.FirstChild.Name == "Asset")
			{
				return ParseAssetListQueryResult(element, query);
			}

			throw new NotImplementedException();
		}

		private QueryResult ParseAssetListQueryResult(XmlElement element, Query query)
		{
			var list = new AssetList();
			var total = int.Parse(element.GetAttribute("total"));

			var assetnodes = element.SelectNodes("Asset");

			list.AddRange(from XmlElement assetnode in assetnodes select ParseAssetNode(assetnode));

			if (query.ParentRelation != null)
			{
				list = TreeAssetListByAttribute(list, query.ParentRelation);
			}

			return new QueryResult(list, total, query);
		}

		private static AssetList TreeAssetListByAttribute(IEnumerable<Asset> input, IAttributeDefinition def)
		{
			var h = new Hashtable();

			foreach (var asset in input)
			{
				h.Add(asset.Oid.Token, asset);
			}

			var r = new AssetList();

			foreach (var asset in input)
			{
				var parent = (Asset)h[((Oid)asset.GetAttribute(def).Value).Token];
				var t = parent != null ? parent.Children : r;
				t.Add(asset);
			}

			return r;
		}

		private QueryResult ParseAssetQueryResult(XmlElement element, Query query)
		{
			var list = new AssetList();
			list.Add(ParseAssetNode(element));
			return new QueryResult(list, 1, query);
		}

		private QueryResult ParseAttributeQueryResult(XmlElement element, Query query)
		{
			var list = new AssetList();

			var asset = new Asset(query.Oid);
			list.Add(asset);

			var attribdef = _meta.GetAttributeDefinition(query.AssetType.Token + "." + element.GetAttribute("name"));

			ParseAttributeNode(asset, attribdef, element);

			return new QueryResult(list, 1, query);
		}

		private Asset ParseAssetNode(XmlElement element)
		{
			var asset = new Asset(GetOid(element.GetAttribute("id")));

			foreach (XmlElement child in element.ChildNodes)
			{
				ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
			}

			return asset;
		}

		private static Asset ParseNewAssetNode(XmlNode element, IAssetType assetType)
		{
			var asset = new Asset(assetType);

			foreach (XmlElement child in element.ChildNodes)
			{
				ParseAttributeNode(asset, asset.AssetType.GetAttributeDefinition(child.GetAttribute("name")), child);
			}

			return asset;
		}

		private void ParseSaveAssetNode(XmlElement element, Asset asset)
		{
			asset.Oid = GetOid(element.GetAttribute("id"));
			asset.AcceptChanges();
		}

		private static void ParseAttributeNode(Asset asset, IAttributeDefinition attribdef, XmlElement element)
		{
			var type = element.LocalName;

			asset.EnsureAttribute(attribdef);

			if (type == "Relation")
			{
				if (attribdef.IsMultiValue)
				{
					foreach (XmlElement child in element.ChildNodes)
					{
						var add = child.HasAttribute("act") && child.GetAttribute("act") == "add";

						var token = child.GetAttribute("idref");

						if (add)
						{
							asset.AddAttributeValue(attribdef, token);
						}
						else
						{
							asset.LoadAttributeValue(attribdef, token);
						}
					}
				}
				else
				{
					var token = Oid.Null.Token;

					if (element.HasChildNodes)
					{
						token = ((XmlElement)element.ChildNodes.Item(0)).GetAttribute("idref");
					}

					var force = element.HasAttribute("act") && element.GetAttribute("act") == "set";

					if (force)
					{
						asset.ForceAttributeValue(attribdef, token);
					}
					else
					{
						asset.LoadAttributeValue(attribdef, token);
					}
				}
			}
			else
			{
				if (attribdef.IsMultiValue)
				{
					foreach (XmlElement child in element.ChildNodes)
					{
						var add = child.HasAttribute("act") && child.GetAttribute("act") == "add";

						if (add)
						{
							asset.AddAttributeValue(attribdef, child.InnerText);
						}
						else
						{
							asset.LoadAttributeValue(attribdef, child.InnerText);
						}
					}
				}
				else
				{
					object v = null;

					if (!string.IsNullOrEmpty(element.InnerText))
					{
						v = element.InnerText;
					}

					var force = element.HasAttribute("act") && element.GetAttribute("act") == "set";

					if (force)
					{
						asset.ForceAttributeValue(attribdef, v);
					}
					else
					{
						asset.LoadAttributeValue(attribdef, v);
					}
				}
			}
		}

		public IFluentQueryBuilder Query(string assetTypeName) =>
			CreateAssetClient().Query(assetTypeName);

		public IAsset Create(params (string name, object value)[] attributes) =>
			CreateAssetClient().Create(attributes);

		public IAsset Create(object attributes) =>
			CreateAssetClient().Create(attributes);

		public IAsset Create(IAsset asset) =>
			CreateAssetClient().Create(asset);

		public IAsset Update(string oidToken, object attributes) => 
			CreateAssetClient().Update(oidToken, attributes);

		public IAsset Update(IAsset asset) =>
			CreateAssetClient().Update(asset);

		public IEnumerable<string> Update(QueryApiQueryBuilder querySpec, object attributes) =>
			CreateAssetClient().Update(querySpec, attributes);

		public IEnumerable<string> ExecuteOperation(QueryApiQueryBuilder querySpece, string operation) =>
			CreateAssetClient().ExecuteOperation(querySpece, operation);

		private AssetClient CreateAssetClient()
		{
			AssetClient client;
			if (!string.IsNullOrWhiteSpace(_v1Connector.Username))
			{
				client = new AssetClient(_v1Connector.AssetApiUrl,
					_v1Connector.Username, _v1Connector.Password);
			}
			else if (!string.IsNullOrWhiteSpace(_v1Connector.AccessToken))
			{
				client = new AssetClient(_v1Connector.AssetApiUrl, _v1Connector.AccessToken);
			}
			else
			{
				throw new InvalidOperationException("Could not find any credentials to use. Please call either WithUsernameAndPassword or WithAccessToken before attempting to call Query.");
			}
			client.UserAgent = _v1Connector.UserAgent;
			return client;
		}
	}
}
