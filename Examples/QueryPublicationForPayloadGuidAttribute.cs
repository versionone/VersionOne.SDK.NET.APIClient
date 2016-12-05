using System;
using VersionOne.SDK.APIClient;

namespace Examples
{ 
	public class QueryPublicationForPayloadGuidAttribute
	{
		string instanceUrl = "https://www16.v1host.com/api-examples";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		public void Execute()
		{
			var connector = V1Connector
				  .WithInstanceUrl(instanceUrl)
				  .WithUserAgentHeader("Examples", "0.1")
				  .WithAccessToken(accessToken)
				  .Build();

			var services = new Services(connector, true);
			var memberType = services.Meta.GetAssetType("Publication");
			var query = new Query(memberType);
			var payloadAttrDef = memberType.GetAttributeDefinition("Payload");
			query.Selection.Add(payloadAttrDef);
			var filter = new FilterTerm(payloadAttrDef);
			const string payloadValue = "87e33977-0628-4269-ae6c-4b25af302e19";
			filter.Equal(payloadValue);
			query.Filter = filter;
			var result = services.Retrieve(query);

			Console.WriteLine("Expected Payload value: {0}; Actual Payload value: {1}", 
				payloadValue,
				result.Assets[0].GetAttribute(payloadAttrDef).Value);

			// Try to set the value to something different via string
			const string newPayloadValue = "962ab714-778c-4130-becb-fe71f56f2448";
			result.Assets[0].SetAttributeValue(payloadAttrDef, newPayloadValue);			
			// Now read it again:
			Console.WriteLine("Payload value after modifying with string value: {0}", result.Assets[0].GetAttribute(payloadAttrDef).Value);

			// Try to set the value to something different via an actual Guid
			result.Assets[0].SetAttributeValue(payloadAttrDef, Guid.Parse(newPayloadValue));
			// Now read it again:
			Console.WriteLine("Payload value after modifying with Guid value: {0}", result.Assets[0].GetAttribute(payloadAttrDef).Value);
		}

		static void Main(string[] args)
		{
			var example = new QueryPublicationForPayloadGuidAttribute();
			example.Execute();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}