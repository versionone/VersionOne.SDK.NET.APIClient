using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace VersionOne.Assets
{
	public class TranslateAssetXmlOutputToHalJson
	{
		private Dictionary<string, string> _attributeNameToDtoPropertyMappings = new Dictionary<string, string>();

		public T Execute<T>(string input)
		{
			_attributeNameToDtoPropertyMappings = MapAttribute.GetMappings<T>();

			using (var reader = new StringReader(input))
			{
				var doc = new XPathDocument(reader);
				var nav = doc.CreateNavigator();

				var assetList = AddAssets(nav);
				if (assetList.Count > 0)
				{
					return assetList.ToObject<T>();
				}
				var rootObject = new JObject();
				rootObject.AddingNew += PropertyContainer_AddingNew;
				var relations = new JObject();
				relations.AddingNew += PropertyContainer_AddingNew;

				AddAttributes(nav, "//Attribute", rootObject);
				AddIdentityRelation(nav, "//Asset", relations);
				AddRelationships(nav, "//Relation", rootObject, relations);

				// Coerce into an array
				var arrayResult = new JArray { rootObject };
				return arrayResult.ToObject<T>();
			}
		}

		private JArray AddAssets(XPathNavigator nav)
		{
			var assetList = new JArray();

			var assetsNodes = nav.Select("//Assets");
			var hasRootNode = assetsNodes.MoveNext();
			if (!hasRootNode)
			{
				return assetList;
			}
			var nodeNav = assetsNodes.Current;
			var assetNodes = nodeNav.SelectChildren("Asset", string.Empty);
			while (assetNodes.MoveNext())
			{
				var assetNode = assetNodes.Current;
				var asset = new JObject();
				asset.AddingNew += PropertyContainer_AddingNew;
				var assetRelations = new JObject();
				assetRelations.AddingNew += PropertyContainer_AddingNew;

				AddIdentityRelation(assetNode, ".", assetRelations);
				AddAttributes(assetNode, "./Attribute", asset);
				AddRelationships(assetNode, "./Relation", asset, assetRelations);
				assetList.Add(asset);
			}

			return assetList;
		}

		private void AddAttributes(XPathNavigator nav, string selectPath, JObject propertyContainer)
		{
			var attributeNodes = nav.Select(selectPath);
			while (attributeNodes.MoveNext())
			{
				var nodeNav = attributeNodes.Current;
				var attrName = nodeNav.GetAttribute("name", string.Empty);
				if (_attributeNameToDtoPropertyMappings.ContainsKey(attrName))
				{
					attrName = _attributeNameToDtoPropertyMappings[attrName];
				}
				var valueAttributes = nodeNav.SelectChildren("Value", string.Empty);
				if (valueAttributes.Count > 0)
				{
					var values = new JArray();
					while (valueAttributes.MoveNext())
					{
						var value = valueAttributes.Current.Value;
						values.Add(value);
					}
					propertyContainer.Add(attrName, values);
				}
				else
				{
					var attrValue = nodeNav.Value;
					if (_attributeNameToDtoPropertyMappings.ContainsValue(attrName) &&
						string.IsNullOrWhiteSpace(attrValue))
					{
						var values = new JArray();
						propertyContainer.Add(attrName, values);
					}
					else
					{
						propertyContainer.Add(attrName, attrValue);

					}
				}
			}
		}

		private void PropertyContainer_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
		{
			var x = e.NewObject;
		}

		private static void AddIdentityRelation(XPathNavigator nav, string selectPath, JObject relations)
		{
			// Add the identity relation
			var assetNode = nav.SelectSingleNode(selectPath);
			if (assetNode == null) return;
			var href = assetNode.GetAttribute("href", string.Empty);
			var oidTokenFull = assetNode.GetAttribute("id", string.Empty);

			var self = new JObject {
				{ "href", new JValue(href) },
				{ "oidTokenFull", new JValue(oidTokenFull) },
				{ "oidToken", new JValue(GetMomentlessOidToken(oidTokenFull)) },
				{ "assetType", new JValue(GetAssetTypeFromOidToken(oidTokenFull)) },
				{ "id", new JValue(GetIdFromOidToken(oidTokenFull)) }
			};
			relations.Add("self", self);
		}

		private static string GetMomentlessOidToken(string oidTokenFull)
		{
			var parts = oidTokenFull.Split(':').Take(2).ToArray();
			return parts[0] + ":" + parts[1];
		}

		private static string GetAssetTypeFromOidToken(string oidTokenFull)
		{
			var parts = oidTokenFull.Split(':').Take(2).ToArray();
			return parts[0];
		}

		private static int GetIdFromOidToken(string oidTokenFull)
		{
			var parts = oidTokenFull.Split(':').Take(2).ToArray();
			return int.Parse(parts[1]);
		}

		private static void AddRelationships(XPathNavigator nav, string selectPath, JObject propertyContainer, JObject relations)
		{
			var relationNodes = nav.Select(selectPath);

			while (relationNodes.MoveNext())
			{
				var nodeNav = relationNodes.Current;
				var relationName = nodeNav.GetAttribute("name", string.Empty);
				var relatedAssets = new JArray();
				var assets = nodeNav.SelectDescendants("Asset", string.Empty, false);
				while (assets.MoveNext())
				{
					var assetNav = assets.Current;
					var asset = new JObject();
					var hrefVal = assetNav.GetAttribute("href", string.Empty);
					var idref = assetNav.GetAttribute("idref", string.Empty);
					asset.Add("href", hrefVal);
					asset.Add("idref", idref);
					relatedAssets.Add(asset);
				}
				AddRelationItems(relatedAssets, relations, relationName);
			}

			propertyContainer.Add("_links", relations);
		}

		private static void AddRelationItems(JArray relatedAssets, JObject relations, string relationName)
		{
			if (relatedAssets.Count > 0)
			{
				relations.Add(relationName, relatedAssets);
			}
			else
			{
				relations.Add(relationName, new JArray());
			}
		}
	}
}