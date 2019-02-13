using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace VersionOne.Assets
{
	[Serializable]
	public class Asset : DynamicObject, IAsset
	{
		private enum RelationItemCommand
		{
			original,
			add,
			remove
		}

		private dynamic _wrapped;
		private Dictionary<string, List<(string relationship, RelationItemCommand command)>>
			_relationshipAssetReferencesMap = new Dictionary<string, List<(string relationship, RelationItemCommand command)>>();
		private Dictionary<string, bool> _modifiedAttributes = new Dictionary<string, bool>();

		private bool _fromDynamic;
		private bool _fromQueryResult;

		public Asset(object wrapped, bool fromQueryResult = false)
		{
			if (wrapped == null) throw new ArgumentNullException(nameof(wrapped));

			if (wrapped is JObject == false) SetWrappedDynamic(JObject.FromObject(wrapped));
			else SetWrappedDynamic(wrapped);
			_fromDynamic = true;
			_fromQueryResult = fromQueryResult;
		}

		public Asset(string assetTypeName, object attributes = null)
		{
			if (string.IsNullOrWhiteSpace(assetTypeName)) throw new ArgumentNullException(nameof(assetTypeName));

			if (attributes != null)
			{
				if (attributes is JObject)
					SetWrappedDynamic(attributes);
				else
					SetWrappedDynamic(JObject.FromObject(attributes));
			}
			else SetWrappedDynamic(new JObject());

			SetDirect("AssetType", assetTypeName);
		}

		private void SetWrappedDynamic(dynamic wrapped) => _wrapped = wrapped;

		public Asset(string assetTypeName, string oid) : this(assetTypeName)
		{
			if (string.IsNullOrWhiteSpace(assetTypeName)) throw new ArgumentNullException(nameof(assetTypeName));
			if (string.IsNullOrWhiteSpace(oid)) throw new ArgumentNullException(nameof(oid));

			Oid = oid;
		}

		[JsonIgnore]
		public string AssetTypeName
		{
			get
			{
				var assetTypeName = GetDirect("AssetType");
				if (assetTypeName != null && !string.IsNullOrWhiteSpace(assetTypeName.ToString())) return assetTypeName.ToString();
				else if (!string.IsNullOrEmpty(Oid)) return Oid.Split(':')[0];
				else return string.Empty;
			}
		}

		private string _oid;

		[JsonIgnore]
		public string Oid
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(_oid)) return _oid;
				return GetDirect("Oid") != null ? GetDirect("Oid").ToString() : string.Empty;
			}
			set
			{
				_oid = value;
			}
		}

		public JObject GetChangesDto()
		{
			if (_fromDynamic && !_fromQueryResult) return _wrapped as JObject;

			var changesObj = new JObject();
			foreach (var key in _modifiedAttributes.Keys)
			{
				changesObj[key] = GetDirect(key) as JToken;
			}

			foreach (var list in _relationshipAssetReferencesMap)
			{
				var items = new List<object>();
				foreach (var oidTokenReference in list.Value)
				{
					var act = oidTokenReference.command.ToString();
					items.Add(new
					{
						idref = oidTokenReference.relationship,
						act = act
					});
				}
				changesObj[list.Key] = JArray.FromObject(items);
			}

			return changesObj;
		}

		// TODO this is pretty hacky
		public object Attributes => _wrapped;

		internal void ApplyOids(IEnumerable<string> assetOidTokens)
		{
			var oids = assetOidTokens.ToList();

			void applyOids(List<string> oidTokens, dynamic root)
			{
				var oid = oidTokens[0];
				oidTokens.RemoveAt(0);
				root.Oid = oid;
				foreach (var obj in GetObjects(root)) applyOids(oidTokens, obj);
			}
			applyOids(oids, _wrapped);
		}

		private IEnumerable<JObject> GetObjects(JObject root)
		{
			var objs = new List<JObject>();

			foreach (var prop in root.Properties())
			{
				if (prop.Value.Type == JTokenType.Object) yield return prop.Value<JObject>();
				else if (prop.Value.Type == JTokenType.Array)
				{
					var items = prop.Value as JArray;
					foreach (var item in items)
					{
						if (item.Type == JTokenType.Object)
						{
							var obj = item.Value<JObject>();
							yield return obj;
						}
					}
				}
			}
		}

		private T GetRelation<T>(string relationName) where T : class => _wrapped[relationName] as T;

		private List<(string relationship, RelationItemCommand command)> GetOrCreateRelationMap(string relationName)
		{
			if (!_relationshipAssetReferencesMap.ContainsKey(relationName))
			{
				var newMap = new List<(string relationship, RelationItemCommand command)>();
				_relationshipAssetReferencesMap[relationName] = newMap;
			}
			var map = _relationshipAssetReferencesMap[relationName];
			return map;
		}

		public void AddRelatedAsset(string relationName, IAsset asset)
		{
			var relation = GetDirect(relationName);
			if (relation == null || !(relation is JArray))
			{
				relation = new JArray();
			}
			var array = relation as JArray;
			// TODO maybe fix this?
			var assetBase = asset as Asset;
			dynamic wrapped = assetBase.GetWrappedDynamic();
			var token = JToken.FromObject(wrapped);
			array.Add(token);
			Set(relationName, relation);
		}

		private void RegisterRemovedRelationshipAssetReference(string relationName, string oidToken) =>
			RegisterRelationshipAssetReference(relationName, oidToken, RelationItemCommand.remove);

		private void RegisterAddedRelationshipAssetReference(string relationName, string oidToken) =>
			RegisterRelationshipAssetReference(relationName, oidToken, RelationItemCommand.add);

		private void RegisterRelationshipAssetReference(string relationName, string oidToken, RelationItemCommand direction)
		{
			var map = GetOrCreateRelationMap(relationName);
			var entry = map.FirstOrDefault(m => m.relationship == oidToken);
			if (entry.Equals(default(ValueTuple<string, RelationItemCommand>)))
			{
				entry = (oidToken, direction);
				map.Add(entry);
			}
			else
			{
				var newEntry = (entry.relationship, direction);
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

		public object Get(string attributeName)
		{
			var result = GetDirect(attributeName) as dynamic;
			if (result is JObject && result.Oid != null)
				return new Asset(result, true);
			else if (result is JArray)
			{
				var results = new List<object>();
				var array = result as JArray;
				foreach (dynamic i in array)
				{
					if (i.Oid != null) results.Add(new Asset(i, true));
					else results.Add(i);
				}
				return results;
			}
			return result is JObject && result.Oid != null ?
				new Asset(result, true) : result;
		}

		private dynamic GetDirect(string attributeName) => _wrapped[attributeName];

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			bool success;
			try
			{
				result = Get(binder.Name);
				success = true;
			}
			catch (Exception ex)
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
				SetDirect(atttributeName, JToken.FromObject(value));
			}
			catch (Exception ex)
			{
				SetDirect(atttributeName, JToken.FromObject(value.ToString()));
				// If we still blow up, then we're just out of luck
			}
			_modifiedAttributes[atttributeName] = true;
		}

		private void SetDirect(string attributeName, dynamic value) => _wrapped[attributeName] = value;

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			bool success;

			try
			{
				var originalValue = GetDirect(binder.Name);
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

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			//var names = base.GetDynamicMemberNames();
			var names = (_wrapped as JObject).Properties().Select(s => s.Name).Cast<string>().ToArray();
			return names;
		}

		internal dynamic GetWrappedDynamic() => _wrapped;

		public object this[string attributeName]
		{
			get
			{
				var result = Get(attributeName);
				return result;
			}
			set
			{
				Set(attributeName, value);
			}
		}

		public override string ToString() => GetWrappedDynamic().ToString();
	}
}