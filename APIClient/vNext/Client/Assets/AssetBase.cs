using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace VersionOne.Assets
{
	public class AssetBase : DynamicObject, IAssetBase
	{
		private enum AddOrRemove
		{
			original,
			add,
			remove
		}

		private dynamic _wrapped;
		private Dictionary<string, List<Tuple<string, AddOrRemove>>> _relationshipAssetReferencesMap =
			new Dictionary<string, List<Tuple<string, AddOrRemove>>>();
		private Dictionary<string, bool> _modifiedAttributes = new Dictionary<string, bool>();

		private bool _fromDynamic = false;

		public AssetBase(dynamic wrapped)
		{
			_wrapped = wrapped;
			_fromDynamic = true;
		}

		public AssetBase(string assetTypeName, object attributes = null)
		{
			if (attributes != null) _wrapped = JObject.FromObject(attributes);
			else _wrapped = new JObject();
			_wrapped["AssetTypeName"] = assetTypeName;
		}

		public AssetBase(string assetTypeName, string oidToken) : this(assetTypeName)
		{
			if (string.IsNullOrWhiteSpace(oidToken))
			{
				throw new ArgumentNullException("oidToken");
			}

			OidToken = oidToken;
		}

		[JsonIgnore]
		public string AssetTypeName
		{
			get
			{
				var assetTypeName = _wrapped["AssetTypeName"];
				if (assetTypeName != null && !string.IsNullOrWhiteSpace(assetTypeName.ToString())) return assetTypeName.ToString();
				else return string.Empty;
			}
		}

		private string _oidToken;

		[JsonIgnore]
		public string OidToken
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(_oidToken)) return _oidToken;
				var relation = GetRelation<JObject>("self");
				if (relation != null) return relation["oidToken"].ToString();
				return string.Empty;
			}
			set
			{
				_oidToken = value;
			}
		}

		public JObject GetChangesDto()
		{
			if (_fromDynamic) return _wrapped as JObject;

			var changesObj = new JObject();
			foreach (var key in _modifiedAttributes.Keys)
			{
				changesObj[key] = _wrapped[key];
			}

			foreach (var list in _relationshipAssetReferencesMap)
			{
				var items = new List<object>();
				foreach (var oidTokenReference in list.Value)
				{
					var act = oidTokenReference.Item2.ToString();
					items.Add(new
					{
						idref = oidTokenReference.Item1,
						act = act
					});
				}
				changesObj[list.Key] = JArray.FromObject(items);
			}

			return changesObj;
		}

		// TODO this is pretty hacky
		public object Attributes
		{
			get
			{
				return GetChangesDto();
			}
		}

		public string GetYamlPayload()
		{
			return string.Empty;
			//return QueryYamlPayloadBuilder.Build(this);
		}

		// TODO: We might not need this _link thing anymore. It's a holdover from a HAL-style approach
		private T GetRelation<T>(string relationName) where T : class => _wrapped["_links"][relationName] as T;

		private List<Tuple<string, AddOrRemove>> GetOrCreateRelationMap(string relationName)
		{
			if (!_relationshipAssetReferencesMap.ContainsKey(relationName))
			{
				var newMap = new List<Tuple<string, AddOrRemove>>();
				_relationshipAssetReferencesMap[relationName] = newMap;
			}
			var map = _relationshipAssetReferencesMap[relationName];
			return map;
		}

		public void AddRelatedAsset(string relationName, IAssetBase asset)
		{
			var relation = _wrapped[relationName];
			if (relation == null || !(relation is JArray))
			{
				relation = new JArray();
			}
			var array = relation as JArray;
			// TODO maybe fix this?
			var assetBase = asset as AssetBase;
			dynamic wrapped = assetBase.GetWrappedDynamic();
			var token = JToken.FromObject(wrapped);
			array.Add(token);
			Set(relationName, relation);
		}

		private void RegisterRemovedRelationshipAssetReference(string relationName, string oidToken) =>
			RegisterRelationshipAssetReference(relationName, oidToken, AddOrRemove.remove);

		private void RegisterAddedRelationshipAssetReference(string relationName, string oidToken) =>
			RegisterRelationshipAssetReference(relationName, oidToken, AddOrRemove.add);

		private void RegisterRelationshipAssetReference(string relationName, string oidToken, AddOrRemove direction)
		{
			var map = GetOrCreateRelationMap(relationName);
			var entry = map.FirstOrDefault(m => m.Item1 == oidToken);
			if (entry == null)
			{
				entry = new Tuple<string, AddOrRemove>(oidToken, direction);
				map.Add(entry);
			}
			else
			{
				var newEntry = new Tuple<string, AddOrRemove>(entry.Item1, direction);
				map.Remove(entry);
				map.Add(newEntry);
			}
		}

		public int RemoveRelatedAssets(string relationName, params object[] oidTokens)
		{
			int removed = 0;
			try
			{
				foreach (var oidToken in oidTokens)
				{
					var oid = oidToken.ToString();
					var relation = GetRelation<JArray>(relationName);

					foreach (dynamic item in relation)
					{
						if (item.idref == oid)
						{
							relation.Remove(item);
							RegisterRemovedRelationshipAssetReference(relationName, oid);
							removed++;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
			}
			return removed;
		}

		public void AddRelatedAssets(string relationName, params object[] oidTokens)
		{
			// TODO check for duplicates first
			foreach (var oidToken in oidTokens)
			{
				var oid = oidToken.ToString();
				var relation = GetRelation<JArray>(relationName);
				RegisterAddedRelationshipAssetReference(relationName, oid);
				relation.Add(JObject.FromObject(new
				{
					idref = oidToken
				}));
			}
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			if (binder.Name == "RemoveRelatedAssets")
			{
				result = this.RemoveRelatedAssets(args[0] as string, args[1] as object);
				return true;
			}
			else if (binder.Name == "AddRelatedAssets")
			{
				this.AddRelatedAssets(args[0] as string, args[1] as object);
				result = null;
				return true;
			}
			else if (binder.Name == "GetChangesDto")
			{
				result = this.GetChangesDto();
				return true;
			}

			return base.TryInvokeMember(binder, args, out result);
		}

		public object Get(string attributeName) => _wrapped[attributeName];

		public override bool TryGetMember(GetMemberBinder binder,
												 out object result)
		{
			bool success;
			try
			{
				result = _wrapped[binder.Name];
				success = true;
			}
			catch (Exception)
			{
				result = null;
				success = false;
			}
			return success;
		}

		public void Set(string atttributeName, object value)
		{
			try
			{
				_wrapped[atttributeName] = JToken.FromObject(value);
			}
			catch (Exception ex)
			{
				_wrapped[atttributeName] = JToken.FromObject(value.ToString());
				// If we still blow up, then we're just out of luck
			}
			_modifiedAttributes[atttributeName] = true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			bool success;

			try
			{
				var originalValue = _wrapped[binder.Name];
				if (originalValue != value)
				{
					Set(binder.Name, value);
				}
				success = true;
			}
			catch (Exception ex)
			{
				// TODO...
				success = false;
			}

			return success;
		}

		internal dynamic GetWrappedDynamic() => _wrapped;

		public object this[string attributeName]
		{
			get
			{
				return Get(attributeName);
			}
			set
			{
				Set(attributeName, value);
			}
		}
	}
}