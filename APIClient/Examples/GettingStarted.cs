using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace VersionOne.SDK.APIClient.Examples
{
    public sealed class GettingStarted
    {

        private readonly EnvironmentContext _context;

        public GettingStarted()
        {
            _context = new EnvironmentContext();
        }

        public IV1Configuration GetV1Configuration()
        {
            return _context.V1Configuration;
        }

        private static void LogResult(params string[] results)
        {
            foreach (var result in results)
            {
                Debug.WriteLine(result);
            }
        }

        public Asset GetSingleAsset()
        {

            var memberId = Oid.FromToken("Member:20", _context.MetaModel);
            var query = new Query(memberId);
            var nameAttribute = _context.MetaModel.GetAttributeDefinition("Member.Name");
            var emailAttribute = _context.MetaModel.GetAttributeDefinition("Member.Email");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(emailAttribute);

            var result = _context.Services.Retrieve(query);
            var member = result.Assets[0];

            LogResult(member.Oid.Token,
                GetValue(member.GetAttribute(nameAttribute).Value),
                GetValue(member.GetAttribute(emailAttribute).Value));

            /***** OUTPUT *****
             Member:20
             Administrator
             admin@company.com
             ******************/

            return member;

        }

        public bool EffortTrackingIsEnabled()
        {

            LogResult(_context.V1Configuration.EffortTracking.ToString());

            return _context.V1Configuration.EffortTracking;

            /***** OUTPUT *****
            False
            ******************/
        }

        public List<Asset> GetMultipleAssets()
        {
            var assetType = _context.MetaModel.GetAssetType("Story");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var estimateAttribute = assetType.GetAttributeDefinition("Estimate");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(estimateAttribute);

            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(story =>
                    LogResult(story.Oid.Token,
                        GetValue(story.GetAttribute(nameAttribute).Value),
                        GetValue(story.GetAttribute(estimateAttribute).Value).ToString(CultureInfo.InvariantCulture)));  //stories may not have an estimate assigned.

            /***** OUTPUT *****
             Story:1083
             View Daily Call Count
             5

             Story:1554
             Multi-View Customer Calendar
             1 ...
             ******************/

            return result.Assets;
        }

        public List<Asset> FindListOfAssets()
        {
            var assetType = _context.MetaModel.GetAssetType("Story");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            query.Selection.Add(nameAttribute);
            query.Find = new QueryFind("High");  //retrieve only stories marked as high priority
            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(asset => LogResult(GetValue(asset.Oid.Token), GetValue(asset.GetAttribute(nameAttribute).Value)));

            return result.Assets;

        }

        public List<Asset> FilterListOfAssets()
        {
            var assetType = _context.MetaModel.GetAssetType("Task");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var todoAttribute = assetType.GetAttributeDefinition("ToDo");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(todoAttribute);

            var toDoTerm = new FilterTerm(todoAttribute);
            toDoTerm.Equal(0);
            query.Filter = toDoTerm;
            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(taskAsset =>
                LogResult(taskAsset.Oid.Token,
                    GetValue(taskAsset.GetAttribute(nameAttribute).Value),
                    GetValue(taskAsset.GetAttribute(todoAttribute).Value.ToString())));

            /***** OUTPUT *****
             Task:1153
             Code Review
             0

             Task:1154
             Design Component
             0 ...
             ******************/

            return result.Assets;

        }

        public List<Asset> SortListOfAssets()
        {
            var assetType = _context.MetaModel.GetAssetType("Story");
            var query = new Query(assetType);
            var nameAttribute = assetType.GetAttributeDefinition("Name");
            var estimateAttribute = assetType.GetAttributeDefinition("Estimate");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(estimateAttribute);
            query.OrderBy.MinorSort(estimateAttribute, OrderBy.Order.Ascending);

            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(asset =>
                LogResult(asset.Oid.Token,
                    GetValue(asset.GetAttribute(nameAttribute).Value),
                    GetValue(asset.GetAttribute(estimateAttribute).Value)));

            /***** OUTPUT *****
             Task:1153
             Code Review
             0

             Task:1154
             Design Component
             0 ...
             ******************/

            return result.Assets;

        }

        public List<Asset> PageListOfAssets()
        {

            var storyType = _context.MetaModel.GetAssetType("Story");
            var query = new Query(storyType);
            var nameAttribute = storyType.GetAttributeDefinition("Name");
            var estimateAttribute = storyType.GetAttributeDefinition("Estimate");
            query.Selection.Add(nameAttribute);
            query.Selection.Add(estimateAttribute);
            query.Paging.PageSize = 3;
            query.Paging.Start = 0;
            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(asset =>
                LogResult(asset.Oid.Token,
                    GetValue(asset.GetAttribute(nameAttribute).Value),
                    GetValue(asset.GetAttribute(estimateAttribute).Value)));

            /***** OUTPUT *****
             Story:1063
             Logon
             2

             Story:1064
             Add Customer Details
             2

             Story:1065
             Add Customer Header
             3
             ******************/

            return result.Assets;
        }

        public List<Asset> HistorySingleAsset()
        {
            var memberType = _context.MetaModel.GetAssetType("Member");
            var query = new Query(memberType, true);
            var idAttribute = memberType.GetAttributeDefinition("ID");
            var changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
            var emailAttribute = memberType.GetAttributeDefinition("Email");
            query.Selection.Add(changeDateAttribute);
            query.Selection.Add(emailAttribute);
            var idTerm = new FilterTerm(idAttribute);
            idTerm.Equal("Member:20");
            query.Filter = idTerm;
            var result = _context.Services.Retrieve(query);

            result.Assets.ForEach(asset =>
                LogResult(asset.Oid.Token,
                    GetValue(asset.GetAttribute(changeDateAttribute).Value),
                    GetValue(asset.GetAttribute(emailAttribute).Value)));

            /***** OUTPUT *****
             Member:1000:105
             4/2/2007 1:22:03 PM
             andre.agile@company.com

             Member:1000:101
             3/29/2007 4:10:29 PM
             andre@company.net
             ******************/

            return result.Assets;

        }

        private static string GetValue(object value)
        {
            var returnValue = string.Empty;
            return value == null ? returnValue : value.ToString();
        }

    }
}
