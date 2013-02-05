# VersionOne SDK.NET APIClient

The APIClient provides access to the Core API without concern for the underlying RESTful API or the HTTP/XML plumbing. Through the APIClient, developers can query for simple or complex sets of information, update the information, and execute system-defined operations. The APIClient is best suited for course-grained and bulk access.

## System Requirements
These libraries have only been tested in a Windows environment with .NET Framework 4.5. They have not been tested under Mono.

## How to get the library as a precompiled package

_Do this if you only want to use the functionality, but are not interested in compiling from source or in contributing code to the project._

Use the NuGet package manager from Visual Studio or nuget.exe. Search for `VersionOne.SDK.NET.APIClient` to find the precompiled package. VersionOne tests packages distributed via NuGet against product releases as they become available. For details, see [the specific versions tested](https://github.com/versionone/VersionOne.SDK.NET.APIClient/wiki/Which-product-releases-has-the-APIClient-library-been-tested-against%3F). Learn more about NuGet from [the NuGet Overview](http://docs.nuget.org/docs/start-here/overview).

## How to get the library source code

_Do this if you want to compile, customize, investigate, debug, or contribute code to the project._

You can find the information necessary to clone the github repository here:  https://github.com/versionone/VersionOne.SDK.NET.APIClient.  

## Learn By Example: APIClient Setup

Using the APIClient is as simple as making a reference to the APIClient.dll in your .Net project, then providing connection information to the main service objects in an included app.config file for your EXECUTING assembly. There are three possible ways to connect to your VersionOne instance using the APIClient. Before you attempt to connect, find out whether your VersionOne instance uses VersionOne authentication or Windows Integrated Authentication. You can then configure your project using an app.config file similar to the one included with the unit test project.  Please take note of the "UseWindowsIntegratedAuth" setting so that it represents your particular environment.

```html
<appSettings>
    <add key="DebugFileName" value="C:\VersionOneAPIClientDebug.txt" />
    <add key="V1Url" value="https://www14.v1host.com/v1sdktesting/" />
    <add key="V1UserName" value="admin" />
    <add key="V1Password" value="admin" />
    <add key="ProxyUrl" value="https://myProxyServer:3128" />
    <add key="ConfigUrl" value="config.v1/" />
    <add key="ProxyUserName" value="Administrator" />
    <add key="ProxyPassword" value="12345678" />
    <add key="UseWindowsIntegratedAuth" value="false" />
</appSettings>
```

## Setup using Windows Integrated Authentication

If your VersionOne instance uses Windows Integrated Authentication, and you wish to connect to the API using the credentials of the user running your program, you can omit the username and password argument in the configuration.  Be sure to set the "UseWindowsIntegratedAuth" value to "true".

If you wish to impersonate another user, you must specify the windows domain account in the form "User@FullyQualifiedDomainName". If you are unsure what the fully qualified domain name is, see the Domain name shown on the 'Computer Name' tab in the My Computer...Properties dialog in Windows.

## Where to find sample code ##
Sample code is available in the github repository in the VersionOne.SDK.APIClient/APIClient/Examples folder.  There are associated unit tests in the VersionOne.SDK.APIClient.Tests/ExamplesTests folder that you can make use of in order to drive and step through these tests.  The tests are runable when you first clone the repository so that you can step through them immediately to see how they work.  The examples below are a reflection of these examples.  

There are also some experimental examples available from the root directory of the cloned repository in \Example\GettingStarted.  These examples have their own solution.

## Getting Started ##

To get started after you have setup your app.config file for your executing assembly/project, you first need to create an instanace of the EnvironmentContext class.  This class encapsulates the objects you will need to execute your code against an instance of VersionOne.
```csharp
var context = new EnvironmentContext();
```
Please note that the EnvironmentContext class optionally takes one parameter to afford flexiblity.  If needed, you can pass in your own implementation of the IModelsAndServices interface.  However, by default, you do not need to do this.

In the examples mentioned earlier, there are a few utility methods you should be aware of.  You will see these methods used in several places throughout the code samples.  Though it's not critical that you know what these methods do in order to understand how to best use the APIClient library, they may confuse you if you aren't aware of them.  These helper methods are:

```csharp
/// <summary>
/// Retrieves the next source id in a series of three.
/// </summary>
/// <param name="oldSource"></param>
/// <returns></returns>
private static string GetNextSourceId(string oldSource)
{
    if (oldSource == "StorySource:148") return "StorySource:149";
    if (oldSource == "StorySource:149") return "StorySource:150";
    return "StorySource:148";
}

/// <summary>
/// Null checks an object type value for the purpose of console output.
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
private static string GetValue(object value)
{
    return value == null ? "No Value Available" : value.ToString();
}

/// <summary>
/// Logs a result set to the debug view.
/// </summary>
/// <param name="results"></param>
private static void LogResult(params string[] results)
{
    foreach (var result in results)
    {
        Debug.WriteLine(result);
    }
}
```


## Learn By Example: Queries

This section is a series of examples, starting with simpler queries and moving to more advanced queries. You'll need to create an instance of both IMetaModel and IServices, as outlined above, to perform the queries.

### How to query a single asset

Retrieve the Member with ID 20 and list their name and email addresses:

```csharp
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

    /***** OUTPUT EXAMPLE *****
        Member:20
        Administrator
        admin@company.com
        ******************/

    return member;

}
```

### How to get a list of all Story assets

```csharp
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
                GetValue(story.GetAttribute(estimateAttribute).Value).ToString(CultureInfo.InvariantCulture)));  		//stories may not have an estimate assigned.

    /***** OUTPUT EXAMPLE *****
        Story:1083
        View Daily Call Count
        5

        Story:1554
        Multi-View Customer Calendar
        1 ...
        ******************/

    return result.Assets;
}
```

Depending on your security role, you may not be able to see all the Story assets in the entire system.

### How to filter a query

Use the Filter property of the Query object to filter the results that are returned. This query will retrieve only Story assets with a To Do of zero:

```csharp
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

    /***** OUTPUT EXAMPLE *****
        Task:1153
        Code Review
        0

        Task:1154
        Design Component
        0 ...
        ******************/

    return result.Assets;

}
```

### How to use find in a query

Use the Find property of the Query object to search for text. This query will retrieve only Request assets with the word "Urgent" in the name:

```csharp
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
```

### How to sort a query

Use the OrderBy property of the Query object to sort the results. This query will retrieve Story assets sorted by increasing Estimate:

```csharp
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

    /***** OUTPUT EXAMPLE *****
        Task:1153
        Code Review
        0

        Task:1154
        Design Component
        0 ...
        ******************/

    return result.Assets;
}
```

There are two methods you can call on the OrderBy class to sort your results: MinorSort and MajorSort. If you are sorting by only one field, it does not matter which one you use. If you want to sort by multiple fields, you need to call either MinorSort or MajorSort multiple times. The difference is: Each time you call MinorSort, the parameter will be added to the end of the OrderBy statement. Each time you call MajorSort, the parameter will be inserted at the beginning of the OrderBy statement.

### How to select a portion of query results

Retrieve a "page" of query results by using the Paging propery of the Query object. This query will retrieve the first 3 Story assets:

```csharp
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

    /***** OUTPUT EXAMPLE *****
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
```

The PageSize property shown asks for 3 items, and the Start property indicates to start at 0. The next 3 items can be retrieve with PageSize=3, Start=3.

###How to query the history of a single asset

This query will retrieve the history of the Member asset with ID 1000.

```csharp
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

    /***** OUTPUT EXAMPLE *****
        Member:1000:105
        4/2/2007 1:22:03 PM
        andre.agile@company.com

        Member:1000:101
        3/29/2007 4:10:29 PM
        andre@company.net
        ******************/

    return result.Assets;
}
```

To create a history query, provide a boolean "true" second argument to the Query constructor.

### How to query the history of many assets

This query will retrieve history for all Member assets:

```csharp
public List<Asset> HistoryListOfAssets()
{
    var memberType = _context.MetaModel.GetAssetType("Member");
    var query = new Query(memberType, true);
    var changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
    var emailAttribute = memberType.GetAttributeDefinition("Email");
    query.Selection.Add(changeDateAttribute);
    query.Selection.Add(emailAttribute);
    var result = _context.Services.Retrieve(query);
    var memberHistory = result.Assets;

    memberHistory.ForEach(member =>
        LogResult(member.Oid.Token,
            GetValue(member.GetAttribute(changeDateAttribute).Value),
            GetValue(member.GetAttribute(emailAttribute))));

    /***** OUTPUT EXAMPLE *****
        Member:20:0
        Thu Nov 30 19:00:00 EST 1899
        null

        Member:20:17183
        Fri Nov 09 09:46:25 EST 2012
        versionone@mailinator.com

        Member:20:17190
        Sun Nov 11 22:59:23 EST 2012
        versionone@mailinator.com

        Member:20:17191
        Sun Nov 11 22:59:47 EST 2012
        versionone@mailinator.com
        ******************/

    return memberHistory;
}
```

Again, the response is a list of historical assets. There will be multiple Asset objects returned for an asset that has changed previously.

All of the previously demonstrated query properties can be used with historical queries also.

### How to query an asset "as of" a specific time

Use the AsOf property of the Query object to retrieve data as it existed at some point in time. This query finds the version of each Story asset as it existed seven days ago:

```csharp
public List<Asset> HistoryAsOfTime()
{
    var storyType = _context.MetaModel.GetAssetType("Story");
    var query = new Query(storyType, true);
    var nameAttribute = storyType.GetAttributeDefinition("Name");
    var estimateAttribute = storyType.GetAttributeDefinition("Estimate");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(estimateAttribute);

    query.AsOf = DateTime.Now.AddDays(-7);
    QueryResult result = _context.Services.Retrieve(query);

    result.Assets.ForEach(asset =>
        LogResult(asset.Oid.Token,
            GetValue(asset.GetAttribute(nameAttribute).Value),
            GetValue(asset.GetAttribute(estimateAttribute).Value)));

    /***** OUTPUT EXAMPLE *****
    Story:5807:7830
    Investigate and fix priority update and data integrity issues.
    12
    Story:8440:13019
    OneHundredThousandAndOne1/7/2012 10:24:56 AM_i5

    Story:8564:13143
    OneHundredThousandAndOne1/7/2012 10:26:35 AM_i115

    Story:10194:14838
    Story Object Model Single Call Test 2/13/2012 3:12:18 PM

    Story:8424:13003
    OneHundredThousandAndOne1/7/2012 10:23:39 AM_i3

    Story:9228:13807
    OneHundredThousandAndOne1/7/2012 10:39:17 AM_i466

        ******************/

    return result.Assets;

}
```

## Learn By Example: Updates

Updating assets through the APIClient involves calling the Save method on the IServices object.

### How to update a scalar attribute on an asset

Updating a scalar attribute on an asset is accomplished by calling the SetAttribute method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the new scalar value. This code will update the Name attribute on the Story with ID 1094:

```csharp
public bool UpdateScalarAttribute()
{
    var storyId = Oid.FromToken("Story:1094", _context.MetaModel);
    var query = new Query(storyId);
    var storyType = _context.MetaModel.GetAssetType("Story");
    var nameAttribute = storyType.GetAttributeDefinition("Name");

    query.Selection.Add(nameAttribute);
    var result = _context.Services.Retrieve(query);
    var story = result.Assets[0];
    var oldName = GetValue(story.GetAttribute(nameAttribute).Value);
    story.SetAttributeValue(nameAttribute, Guid.NewGuid().ToString());
    _context.Services.Save(story);

    LogResult(story.Oid.Token, oldName, GetValue(story.GetAttribute(nameAttribute).Value));

    /***** OUTPUT EXAMPLE *****
        Story:1094:1446
        Logon
        F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4
        ******************/

    return true;
}
```

### How to update a single-value relation on an asset

Updating a single-value relation is accomplished by calling the SetAttribute method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the ID for the new relation. This code will change the source of the Story with ID 1094:

```csharp
public bool UpdateSingleValueRelation()
{

    var storyId = Oid.FromToken("Story:1094", _context.MetaModel);
    var query = new Query(storyId);
    var storyType = _context.MetaModel.GetAssetType("Story");
    var sourceAttribute = storyType.GetAttributeDefinition("Source");
    query.Selection.Add(sourceAttribute);
    var result = _context.Services.Retrieve(query);
    var story = result.Assets[0];
    var oldSource = GetValue(story.GetAttribute(sourceAttribute).Value);
    story.SetAttributeValue(sourceAttribute, GetNextSourceId(oldSource));
    _context.Services.Save(story);

    LogResult(story.Oid.Token, oldSource, GetValue(story.GetAttribute(sourceAttribute).Value));

    /***** OUTPUT EXAMPLE *****
    Story:1094:17726
    StorySource:148
    StorySource:149
    ******************/

    return true;

}
```

### How to add and remove values from a multi-value relation

Updating a multi-value relation is accomplished by calling either the RemoveAttributeValue or AddAttributeValue method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the ID of the relation you wish to add or remove. This code will add one Member and remove another Member from the Story with ID 1094:

```csharp
public bool UpdateMultiValueRelation()
{

    var storyId = Oid.FromToken("Story:1124", _context.MetaModel);
    var query = new Query(storyId);
    var storyType = _context.MetaModel.GetAssetType("Story");
    var ownersAttribute = storyType.GetAttributeDefinition("Owners");

    query.Selection.Add(ownersAttribute);

    var result = _context.Services.Retrieve(query);
    var story = result.Assets[0];
    var values = story.GetAttribute(ownersAttribute).Values;
    var owners = values.Cast<object>().ToList();

    if (owners.Count >= 1) story.RemoveAttributeValue(ownersAttribute, owners[0]);

    _context.Services.Save(story);

    return true;

}
```

## Learn By Example: New Asset

When you create a new asset in the APIClient you need to specify the "context" of another asset that will be the parent. For example, if you create a new Story asset you can specify which Scope it should be created in.

How to get a new Story asset template in the context of a Scope asset
This code will create a Story asset in the context of Scope with ID 1012:

```csharp
public Asset AddNewAsset()
{
    var projectId = Oid.FromToken("Scope:0", _context.MetaModel);
    var assetType = _context.MetaModel.GetAssetType("Story");
    var newStory = _context.Services.New(assetType, projectId);
    var nameAttribute = assetType.GetAttributeDefinition("Name");
    newStory.SetAttributeValue(nameAttribute, "My New Story");
    _context.Services.Save(newStory);

    LogResult(newStory.Oid.Token,
        GetValue(newStory.GetAttribute(assetType.GetAttributeDefinition("Scope")).Value),
        GetValue(newStory.GetAttribute(nameAttribute).Value));

    /***** OUTPUT *****
        Story:1094
        Scope:1012
        My New Story
        ******************/

    return newStory;
}
```

## Learn By Example: Operations

An operation is an action that is executed against a single asset. For example, to delete an asset you must execute the Delete operation on the asset. To close or inactivate a Workitem, you must use the Inactivate Operation. Available operations for each asset are listed at the bottom of the the meta data description for that asset, for instance:

```url
https://www1/VersionOne/meta.v1/Story?xsl=api.xsl
```

### How to delete a Story asset

Get the Delete operation from the IMetaModel, and use IServices to execute it against a story Oid.

***Important note:  it's standard operating procedure to inactivate or close an asset versus deleting it.

```csharp
public bool DeleteAnAsset()
{

    var story = AddNewAsset();
    var deleteOperation = _context.MetaModel.GetOperation("Story.Delete");
    var deletedId = _context.Services.ExecuteOperation(deleteOperation, story.Oid);
    var query = new Query(deletedId.Momentless);

    try
    {
        QueryResult result = _context.Services.Retrieve(query);
    }
    catch (ConnectionException e)
    {
        LogResult(string.Format("Story has been deleted: {0}.  Exception was:  {1}", story.Oid.Momentless, e.InnerException.Message));
    }

    /***** OUTPUT *****
        Story has been deleted: Story:1049
        ******************/

    return true;

}
```

The delete operation returns the Oid, with the new Moment, of the deleted asset. Future current info queries will automatically exclude deleted assets from results.

Currently, there is no support for undeleting a deleted asset.

### How to close a Story asset

Get the Inactivate operation from the IMetaModel, and use IServices to execute it against a story Oid.

```csharp
public Asset CloseAnAsset()
{

    var story = AddNewAsset();
    var closeOperation = _context.MetaModel.GetOperation("Story.Inactivate");
    var assetName = _context.MetaModel.GetAttributeDefinition("Story.Name");
    var assetState = _context.MetaModel.GetAttributeDefinition("Story.AssetState");
    var closeId = _context.Services.ExecuteOperation(closeOperation, story.Oid);

    var query = new Query(closeId.Momentless);

    query.Selection.Add(assetState);
    query.Selection.Add(assetName);

    var result = _context.Services.Retrieve(query);
    var closedStory = result.Assets[0];
    var state = AssetStateManager.GetAssetStateFromString(GetValue(closedStory.GetAttribute(assetState).Value));

    LogResult(closedStory.Oid.Token,
        closedStory.GetAttribute(assetName).Value.ToString(),
        state.ToString());

    /***** OUTPUT *****
        Story:12079
        My New Story
        Closed
        ******************/

    return closedStory;

}
```

The AssetState attribute is the internal state of an asset.

### How to reopen a Story asset

Get the Reactivate operation from the IMetaModel, and use IServices to execute it against a story Oid.

```csharp
public bool ReOpenAnAsset()
{

    var story = CloseAnAsset();
    var activateOperation = _context.MetaModel.GetOperation("Story.Reactivate");
    var activeId = _context.Services.ExecuteOperation(activateOperation, story.Oid);

    var query = new Query(activeId.Momentless);
    var assetState = _context.MetaModel.GetAttributeDefinition("Story.AssetState");
    query.Selection.Add(assetState);
    var result = _context.Services.Retrieve(query);
    var activeStory = result.Assets[0];
    var state = AssetStateManager.GetAssetStateFromString(GetValue(activeStory.GetAttribute(assetState)));

    LogResult(activeStory.Oid.ToString(), state.ToString());

    /***** OUTPUT EXAMPLE *****
        Story:1098
        Future
        ******************/

    return true;

}
```

## Learn By Example: System Settings

Some system settings are exposed (read-only) to the APIClient, to allow client-side data validation. Specifically, the system settings for Effort Tracking, Story Tracking Level and Defect Tracking Level are now available to the APIClient, so that entry of Effort, Detail Estimate, and ToDo can be done consistently with the way VersionOne Enterprise is configured. In previous versions, there was no way for the APIClient to check these settings, and the developer would have to code with knowledge of the system's configured state.  Using the V1Configuration component, you can get the system's configured state, and apply these settings appropriately in code.

### Getting VersionOne System Settings

To get the system settings, create an instance of the V1Configuration class, using a V1APIConnector (directed to the "config.v1" http address):

```csharp
public IV1Configuration GetV1Configuration()
{
    return _context.V1Configuration;
}
```

### Effort Tracking setting

The V1Configuration.EffortTracking property indicates whether or not Effort Tracking has been enabled in VersionOne Enterprise.  In this example, the VersionOne instance has Effort Tracking turned off:

```csharp
public bool EffortTrackingIsEnabled()
{

    LogResult(_context.V1Configuration.EffortTracking.ToString());

    return _context.V1Configuration.EffortTracking;

    /***** OUTPUT EXAMPLE *****
    False
    ******************/
}
```

### Tracking Level settings

Detail Estimate, ToDo and Effort can be entered for Stories and Defects, or for their child Tasks and Tests, depending on how the system is configured.  The V1Configuration.StoryTrackingLevel and V1Configuration.DefectTrackingLevel properties indicate where input of Detail Estimate, ToDo and Effort are taken.

In this example, the VersionOne instance is configured to take DetailEstimate, ToDo, and Effort at the Task/Test level for Stories (Off), and to take DetailEstimate, ToDo, and Effort at the Defect level for Defects (On):

```csharp
public void GetStoryAndDefectTrackingLevel()
{

    LogResult(string.Concat("Story tracking level:  ", _context.V1Configuration.StoryTrackingLevel));
    LogResult(string.Concat("Defect tracking level:  ", _context.V1Configuration.DefectTrackingLevel));

    /***** OUTPUT EXAMPLE *****
    Story tracking level:  Mix
    Defect tracking level:  On
    ******************/

}
```

A value of "On" indicates that Detail Estimate, ToDo, and Effort input is accepted at the PrimaryWorkitem level only. A value of "Off" indicates that Detail Estimate, ToDo, and Effort input is accepted at the Task/Test level only. A value of "Mix" indicates that Detail Estimate, ToDo, and Effort input is accepted at both the PrimaryWorkitem and Task/Test level.

## The VersionOne Information Model

Practically all data in VersionOne is stored in the form of assets, which have attributes. Each asset is classified by an asset type, which describes a number of attribute definitions, operations, rules, and possibly an inheritance from another asset type. A list of all the types within VersionOne can be obtained by accessing the meta data url of your VersionOne instance. Additionally, VersionOne comes with an xsl stylesheet, which can be referenced as a parameter to the meta data url and makes it easier to read the response:

```url
https://www14.v1host.com/v1sdktesting/meta.v1/?xsl=api.xsl
```

Individual types can also be viewed through the meta url:

```url
https://www14.v1host.com/v1sdktesting/meta.v1/Story?xsl=api.xsl
```

You must use the system name for the type you would like to retrieve. This is true whether using the API directly or the APIClient. For instance, in the example above the system name is "Story", which certain methodology templates display as "Backlog Item" or "Requirement". Here is a list of some of the most important system names and their corresponding default display names in the available methodology templates:

### System Names
<table summary="System Names" cellspacing="0" cellpadding="0" border="0">
<thead>
    <tr>
        <th>System Name</th>
        <th>XP Display Name</th>
        <th>Scrum Display Name</th>
        <th>AgileUP Display Name</th>
        <th>DSDM Display Name</th>
    </tr>
</thead>
<tbody>
    <tr>
        <td>Scope</td>
        <td>Project</td>
        <td>Project</td>
        <td>Project</td>
        <td>Project</td>
    </tr>
    <tr>
        <td>Timebox</td>
        <td>Iteration</td>
        <td>Sprint</td>
        <td>Iteration</td>
        <td>Iteration</td>
    </tr>
    <tr>
        <td>Theme</td>
        <td>Theme</td>
        <td>Feature Group</td>
        <td>Use Case</td>
        <td>Feature Group</td>
    </tr>
    <tr>
        <td>Story</td>
        <td>Story</td>
        <td>Backlog Item</td>
        <td>Requirement</td>
        <td>Requirement</td>
    </tr>
    <tr>
        <td>Defect</td>
        <td>Defect</td>
        <td>Defect</td>
        <td>Defect</td>
        <td>Defect</td>
    </tr>
    <tr>
        <td>Task</td>
        <td>Task</td>
        <td>Task</td>
        <td>Task</td>
        <td>Task</td>
    </tr>
    <tr>
        <td>Test</td>
        <td>Test</td>
        <td>Test</td>
        <td>Test</td>
        <td>Test</td>
    </tr>
    <tr>
        <td>RegressionTest</td>
        <td>RegressionTest</td>
        <td>RegressionTest</td>
        <td>RegressionTest</td>
        <td>RegressionTest</td>
    </tr>
    <tr>
        <td>RegressionPlan</td>
        <td>RegressionPlan</td>
        <td>RegressionPlan</td>
        <td>RegressionPlan</td>
        <td>RegressionPlan</td>
    </tr>
    <tr>
        <td>RegressionSuite</td>
        <td>RegressionSuite</td>
        <td>RegressionSuite</td>
        <td>RegressionSuite</td>
        <td>RegressionSuite</td>
    </tr>
    <tr>
        <td>TestSet</td>
        <td>TestSet</td>
        <td>TestSet</td>
        <td>TestSet</td>
        <td>TestSet</td>
    </tr>
    <tr>
        <td>Environment</td>
        <td>Environment</td>
        <td>Environment</td>
        <td>Environment</td>
        <td>Environment</td>
    </tr>
</tbody>
</table>

### Asset Type

Asset types describe the "classes" of business data available. Asset types form an inheritance hierarchy, such that each asset type inherits attribute definitions, operations, and rules from it's "parent" asset type. Those asset types at the leaves of this hierarchy are concrete, whereas asset types with "children" asset types are abstract. Assets are all instances of concrete asset types. Asset types are identified by unique names.

By way of example, Story and Defect are concrete asset types. On the other hand, Workitem is an abstract asset type, from which Story and Defect ultimately derive.

### Attribute Definition

Attribute definitions describe the properties that "make up" each asset type. An attribute definition defines the type of its value, whether it is required and/or read-only, and many other qualities. Attribute definitions are identified by a name that is unique within its asset type.

Attribute definitions are defined as either scalars or relations to other assets. Further, relation attribute definitions can be either single-value or multi-value. For example, the Estimate attribute definition on the Workitem asset type is a scalar (specifically, a floating-point number). On the other hand, the Workitem asset type's Scope attribute definition is a single-value relation (to a Scope asset). The reverse relation, Workitems on the Scope asset type, is a multi-value relation (to Workitem assets).

### Asset

Actual business objects in VersionOne are assets, which are instances of concrete asset types. Each asset is uniquely identified by it's asset type and ID (an integer). For example, Member:20 identifies the Member asset with ID of 20.

### Attribute

On every asset are a number of attributes, which attach specific values to the attribute definitions defined in the asset type. If the attribute's definition is a relation, then the value(s) of the attribute are references to an asset(s).

### Moment

As data changes in VersionOne, a history is maintained. Every change to every asset is journaled within the system, and assigned a chronologically-increasing integer called a moment. A past version of an asset is uniquely identified by it's asset type, ID, and Moment. A past version of a relation attribute will refer to the past version of it's target asset. For example, Member:20:563 identifies the Member asset with ID of 20, as it was at the time of moment 563.

## Other Resources

* [DEVELOPING.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/DEVELOPING.md) - Documentation on developing with VersionOne SDK.NET APIClient
* [LICENSE.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/LICENSE.md) - Source code and user license
* [ACKNOWLEDGEMENTS.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/ACKNOWLEDGEMENTS.md) - Acknowledgments of included software and associated licenses

### Getting Help
Need to bootstrap on VersionOne SDK.NET quickly? VersionOne services brings a wealth of development experience to training and mentoring on VersionOne SDK.NET:

http://www.versionone.com/training/product_training_services/

Have a question? Get help from the community of VersionOne developers:

http://groups.google.com/group/versionone-dev/
