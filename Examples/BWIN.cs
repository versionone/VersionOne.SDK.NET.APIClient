using System;
using VersionOne.SDK.APIClient;

namespace Examples
{
	public class BWIN
	{
		public static void Main(string[] args)
		{
			// ProxyProvider proxyProvider = new ProxyProvider(new Uri("http://atvp1xipxy002.apz.unix:3128"), "", "");

			IServices services = new Services(V1Connector
				.WithInstanceUrl("https://www52.v1host.com/GVC-Sandbox/")
				.WithUserAgentHeader("MycloudApp", "1.0")
				.WithAccessToken("1.VStuIjHXBxJOTwc3h2k0qkoudng=")  // Sandbox admin accesstoken
				.UseOAuthEndpoints()
	//			.WithProxy(proxyProvider)
				.Build());

				var projectId = services.GetOid("Scope:4583919");   // here I’m getting exception
				//Oid projectId = services.GetOid("Scope:6699948");

				IAssetType storyType = services.Meta.GetAssetType("Story");
				Asset newStory = services.New(storyType, projectId);
				IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
				IAttributeDefinition BusinesssOwnerAttribute = storyType.GetAttributeDefinition("RequestedBy");//("RequestedBy");
				IAttributeDefinition StatusAttribute = storyType.GetAttributeDefinition("Status");//("Status");
				IAttributeDefinition PriorityAttribute = storyType.GetAttributeDefinition("Priority");//("Priority");
				IAttributeDefinition requestedbyAttribute = storyType.GetAttributeDefinition("Customer");//("Customer");

				newStory.SetAttributeValue(nameAttribute, "Test Story, pls Ignore");
				newStory.SetAttributeValue(StatusAttribute, "StoryStatus:133");
				newStory.SetAttributeValue(PriorityAttribute, "WorkitemPriority:138");
				newStory.SetAttributeValue(requestedbyAttribute, "Member:9563819");
				services.Save(newStory);

				var assetType = services.Meta.GetAssetType("Story");
				var assetOID = services.GetOid(newStory.Oid.Token);
				var query = new Query(assetOID);

				var numberAttribute = assetType.GetAttributeDefinition("Number");
				query.Selection.Add(numberAttribute);

				QueryResult result = services.Retrieve(query);
				var Result = result.Assets[0].GetAttribute(numberAttribute).Value + "|NEW|" + newStory.Oid.Token;
		}

	}
}
