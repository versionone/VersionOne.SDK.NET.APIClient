using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

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
                member.GetAttribute(nameAttribute).Value.ToString(),
                member.GetAttribute(emailAttribute).Value.ToString());

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
                        story.GetAttribute(nameAttribute).Value.ToString(),
                        GetIntegerValue(story.GetAttribute(estimateAttribute).Value).ToString(CultureInfo.InvariantCulture)));  //stories may not have an estimate assigned.

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

            result.Assets.ForEach(asset => LogResult(asset.Oid.Token, asset.GetAttribute(nameAttribute).Value.ToString()));

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
                    taskAsset.GetAttribute(nameAttribute).Value.ToString(),
                    taskAsset.GetAttribute(todoAttribute).Value.ToString()));

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
                    asset.GetAttribute(nameAttribute).Value.ToString(),
                    asset.GetAttribute(estimateAttribute).Value.ToString()));

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


        private static int GetIntegerValue(object value)
        {
            var returnValue = 0;
            if (value == null) return returnValue;
            int.TryParse(value.ToString(), out returnValue);
            return returnValue;
        }
    }
}
