# VersionOne SDK.NET APIClient #

The APIClient provides access to the Core API without concern for the underlying RESTful API or the HTTP/XML plumbing. Through the APIClient, developers can query for simple or complex sets of information, update the information, and execute system-defined operations. The APIClient is best suited for course-grained and bulk access.

## Table of Contents ##

* auto-gen TOC:
{:toc}

Other resources:

* [DEVELOPING.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/DEVELOPING.md) - Documentation on developing with VersionOne SDK.NET APIClient
* [LICENSE.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/LICENSE.md) - Source code and user license
* [ACKNOWLEDGEMENTS.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/ACKNOWLEDGEMENTS.md) - Acknowledgments of included software and associated licenses

## System Requirements

### VersionOne SDK.NET Libraries
* .NET Framework 4.0
These libraries have only been tested in a Windows environment. They have not been tested under Mono.

## Learn By Example: APIClient Setup

Using the APIClient is as simple as making a reference to the APIClient.dll in your .Net project, then providing connection information to the main service objects within the APIClient. There are three possible ways to connect to your VersionOne instance using the APIClient. Before you attempt to connect, find out whether your VersionOne instance uses VersionOne authentication or Windows Integrated Authentication. You need to create an instance of IMetaModel and and instance of IServices and provide them with connection information via instances of the V1APIConnector.

### Setup using VersionOne Authentication

To use VersionOne authentication, specify the username and password:

```csharp
V1APIConnector dataConnector = new V1APIConnector("http://server/v1instance/rest-1.v1/", "username", "password");
V1APIConnector metaConnector = new V1APIConnector("http://server/v1instance/meta.v1/");
IMetaModel metaModel = new MetaModel(metaConnector);
IServices services = new Services(metaModel, dataConnector);
```
### Setup using Windows Integrated Authentication

If your VersionOne instance uses Windows Integrated Authentication, and you wish to connect to the API using the credentials of the user running your program, you can omit the username and password arguments to the V1APIConnector:

```csharp
V1APIConnector dataConnector = new V1APIConnector("http://server/v1instance/rest-1.v1/");
V1APIConnector metaConnector = new V1APIConnector("http://server/v1instance/meta.v1/");
IMetaModel metaModel = new MetaModel(metaConnector);
IServices services = new Services(metaModel, dataConnector);
```

### Setup using Windows Integrated Authentication, specifying credentials

You may also explicitly identify the domain user you wish to use to authenticate to VersionOne, and provide an extra boolean argument indicating that you wish to use Windows Integrated Authentication:

```csharp
V1APIConnector dataConnector = new V1APIConnector("http://server/v1instance/rest-1.v1/", @"username@FullyQualifiedDomainName", "password", true);
V1APIConnector metaConnector = new V1APIConnector("http://server/v1instance/meta.v1/");
IMetaModel metaModel = new MetaModel(metaConnector);
IServices services = new Services(metaModel, dataConnector);
```

Note that you must specify the windows domain account in the form "User@FullyQualifiedDomainName". If you are unsure what the fully qualified domain name is, see the Domain name shown on the 'Computer Name' tab in the My Computer...Properties dialog.

## Learn By Example: Queries

This section is a series of examples, starting with simpler queries and moving to more advanced queries. You'll need to create an instance of both IMetaModel and IServices, as outlined above, to perform the queries.

### How to query a single asset

Retrieve the Member with ID 20:

```csharp
public Asset SingleAsset()
{
    Oid memberId = Oid.FromToken("Member:20", metaModel);
    Query query = new Query(memberId);
    QueryResult result = services.Retrieve(query);
    Asset member = result.Assets[0];

    Console.WriteLine(member.Oid.Token);
    /***** OUTPUT *****
        Member:20
    ******************/

    return member;
}
```

In this example, the asset will have its Oid populated, but will not have any other attributes populated. This is to minimize the size of the data sets returned. The next example shows how to ask for an asset with specific attributes populated.

### How to query for specific attributes

Retrieve an asset with populated attributes by using the Selection property of the Query object.

```csharp
public Asset SingleAssetWithAttributes()
{
    Oid memberId = Oid.FromToken("Member:20", metaModel);
    Query query = new Query(memberId);
    IAttributeDefinition nameAttribute = metaModel.GetAttributeDefinition("Member.Name");
    IAttributeDefinition emailAttribute = metaModel.GetAttributeDefinition("Member.Email");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(emailAttribute);
    QueryResult result = services.Retrieve(query);
    Asset member = result.Assets[0];

    Console.WriteLine(member.Oid.Token);
    Console.WriteLine(member.GetAttribute(nameAttribute).Value);
    Console.WriteLine(member.GetAttribute(emailAttribute).Value);
    /***** OUTPUT *****
        Member:20
        Administrator
        admin@company.com
    ******************/

    return member;
}
```

### How to get a list of all Story assets

```csharp
public AssetList ListOfAssets()
{
    IAssetType storyType = metaModel.GetAssetType("Story");
    Query query = new Query(storyType);
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    IAttributeDefinition estimateAttribute = storyType.GetAttributeDefinition("Estimate");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(estimateAttribute);
    QueryResult result = services.Retrieve(query);

    foreach (Asset story in result.Assets)
    {
        Console.WriteLine(story.Oid.Token);
        Console.WriteLine(story.GetAttribute(nameAttribute).Value);
        Console.WriteLine(story.GetAttribute(estimateAttribute).Value);
        Console.WriteLine();
    }
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
```

Depending on your security role, you may not be able to see all the Story assets in the entire system.

### How to filter a query

Use the Filter property of the Query object to filter the results that are returned. This query will retrieve only Story assets with a To Do of zero:

```csharp
public AssetList FilterListOfAssets()
{
    IAssetType taskType = metaModel.GetAssetType("Task");
    Query query = new Query(taskType);
    IAttributeDefinition nameAttribute = taskType.GetAttributeDefinition("Name");
    IAttributeDefinition todoAttribute = taskType.GetAttributeDefinition("ToDo");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(todoAttribute);

    FilterTerm term = new FilterTerm(todoAttribute);
    term.Equal(0);
    query.Filter = term;

    QueryResult result = services.Retrieve(query);

    foreach (Asset task in result.Assets)
    {
        Console.WriteLine(task.Oid.Token);
        Console.WriteLine(task.GetAttribute(nameAttribute).Value);
        Console.WriteLine(task.GetAttribute(todoAttribute).Value);
        Console.WriteLine();
    }
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
```

### How to use find in a query

Use the Find property of the Query object to search for text. This query will retrieve only Request assets with the word "Urgent" in the name:

```csharp
public AssetList FilterListOfAssets()
{
    IAssetType requestType = metaModel.GetAssetType("Request");
    Query query = new Query(requestType);
    IAttributeDefinition nameAttribute = requestType.GetAttributeDefinition("Name");
    query.Selection.Add(nameAttribute);

    query.Find = new QueryFind("Urgent", new AttributeSelection(nameAttribute));

    QueryResult result = services.Retrieve(query);

    foreach (Asset request in result.Assets)
    {
        Console.WriteLine(request.Oid.Token);
        Console.WriteLine(request.GetAttribute(nameAttribute).Value);
        Console.WriteLine();
    }
    /***** OUTPUT *****
        Request:1195
        Urgent!  Filter by owner

        Task:1244
        Urgent: improve search performance ...
    ******************/

    return result.Assets;
}
```

### How to sort a query

Use the OrderBy property of the Query object to sort the results. This query will retrieve Story assets sorted by increasing Estimate:

```csharp
public AssetList SortListOfAssets()
{
    IAssetType storyType = metaModel.GetAssetType("Story");
    Query query = new Query(storyType);
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    IAttributeDefinition estimateAttribute = storyType.GetAttributeDefinition("Estimate");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(estimateAttribute);
    query.OrderBy.MinorSort(estimateAttribute, OrderBy.Order.Ascending);
    QueryResult result = services.Retrieve(query);

    foreach (Asset story in result.Assets)
    {
        Console.WriteLine(story.Oid.Token);
        Console.WriteLine(story.GetAttribute(nameAttribute).Value);
        Console.WriteLine(story.GetAttribute(estimateAttribute).Value);
        Console.WriteLine();
    }
    /***** OUTPUT *****
        Story:1073
        Add Order Line
        1

        Story:1068
        Update Member
        2 ...
    ******************/

    return result.Assets;
}
```

There are two methods you can call on the OrderBy class to sort your results: MinorSort and MajorSort. If you are sorting by only one field, it does not matter which one you use. If you want to sort by multiple fields, you need to call either MinorSort or MajorSort multiple times. The difference is: Each time you call MinorSort, the parameter will be added to the end of the OrderBy statement. Each time you call MajorSort, the parameter will be inserted at the beginning of the OrderBy statement.

### How to select a portion of query results

Retrieve a "page" of query results by using the Paging propery of the Query object. This query will retrieve the first 3 Story assets:

```csharp
public AssetList PageListOfAssets()
{
    IAssetType storyType = metaModel.GetAssetType("Story");
    Query query = new Query(storyType);
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    IAttributeDefinition estimateAttribute = storyType.GetAttributeDefinition("Estimate");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(estimateAttribute);
    query.Paging.PageSize = 3;
    query.Paging.Start = 0;
    QueryResult result = services.Retrieve(query);

    foreach (Asset story in result.Assets)
    {
        Console.WriteLine(story.Oid.Token);
        Console.WriteLine(story.GetAttribute(nameAttribute).Value);
        Console.WriteLine(story.GetAttribute(estimateAttribute).Value);
        Console.WriteLine();
    }
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
```

The PageSize property shown asks for 3 items, and the Start property indicates to start at 0. The next 3 items can be retrieve with PageSize=3, Start=3.

###How to query the history of a single asset

This query will retrieve the history of the Member asset with ID 1000.

```csharp
public AssetList HistorySingleAsset()
{
    IAssetType memberType = metaModel.GetAssetType("Member");
	Query query = new Query(Oid.FromToken("Member:1000", metamodel), true);

	IAttributeDefinition changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
	IAttributeDefinition emailAttribute = memberType.GetAttributeDefinition("Email");
	query.Selection.Add(changeDateAttribute);
	query.Selection.Add(emailAttribute);

	QueryResult result = services.Retrieve(query);
	AssetList memberHistory = result.Assets;

	foreach (Asset member in memberHistory)
	{
		Console.WriteLine(member.Oid.Token);
		Console.WriteLine(member.GetAttribute(changeDateAttribute).Value);
		Console.WriteLine(member.GetAttribute(emailAttribute).Value);
		Console.WriteLine();
	}
	/***** OUTPUT *****
		Member:1000:105
		4/2/2007 1:22:03 PM
		andre.agile@company.com

		Member:1000:101
		3/29/2007 4:10:29 PM
		andre@company.net
	******************/

	return memberHistory;
}
```

To create a history query, provide a boolean "true" second argument to the Query constructor.

### How to query the history of many assets

This query will retrieve history for all Member assets:

```csharp
public AssetList HistoryListOfAssets()
{
    IAssetType memberType = metaModel.GetAssetType("Member");
    Query query = new Query(memberType, true);
    IAttributeDefinition changeDateAttribute = memberType.GetAttributeDefinition("ChangeDate");
    IAttributeDefinition emailAttribute = memberType.GetAttributeDefinition("Email");
    query.Selection.Add(changeDateAttribute);
    query.Selection.Add(emailAttribute);
    QueryResult result = services.Retrieve(query);
    AssetList memberHistory = result.Assets;

    foreach (Asset member in memberHistory)
    {
        Console.WriteLine(member.Oid.Token);
        Console.WriteLine(member.GetAttribute(changeDateAttribute).Value);
        Console.WriteLine(member.GetAttribute(emailAttribute).Value);
        Console.WriteLine();
    }
    /***** OUTPUT *****
        Member:1010:106
        4/2/2007 3:27:23 PM
        tammy.coder@company.com

        Member:1000:105
        4/2/2007 1:22:03 PM
        andre.agile@company.com

        Member:1000:101
        3/29/2007 4:10:29 PM
        andre@company.net
    ******************/

    return memberHistory;
}
```

Again, the response is a list of historical assets. There will be multiple Asset objects returned for an asset that has changed previously.

All of the previously demonstrated query properties can be used with historical queries also.

### How to query an asset "as of" a specific time

Use the AsOf property of the Query object to retrieve data as it existed at some point in time. This query finds the version of each Story asset as it existed seven days ago:

```csharp
public AssetList HistoryAsOfTime()
{
    IAssetType storyType = metaModel.GetAssetType("Story");
    Query query = new Query(storyType, true);
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    IAttributeDefinition estimateAttribute = storyType.GetAttributeDefinition("Estimate");
    query.Selection.Add(nameAttribute);
    query.Selection.Add(estimateAttribute);
    query.AsOf = DateTime.Now.AddDays(-7); //7 days ago
    QueryResult result = services.Retrieve(query);

    foreach (Asset story in result.Assets)
    {
        Console.WriteLine(story.Oid.Token);
        Console.WriteLine(story.GetAttribute(nameAttribute).Value);
        Console.WriteLine(story.GetAttribute(estimateAttribute).Value);
        Console.WriteLine();
    }
    /***** OUTPUT *****
        Story:1063
        Logon
        3

        Story:1064
        Add Customer Details
        1

        Story:1065
        Add Customer Header
        3
    ******************/

    return result.Assets;
}
```

## Learn By Example: Updates

Updating assets through the APIClient involves calling the Save method on the IServices object.

### How to update a scalar attribute on an asset

Updating a scalar attribute on an asset is accomplished by calling the SetAttribute method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the new scalar value. This code will update the Name attribute on the Story with ID 1094:

```csharp
public Asset UpdateScalarAttribute()
{
    Oid storyId = Oid.FromToken("Story:1094", metaModel);
    Query query = new Query(storyId);
    IAssetType storyType = metaModel.GetAssetType("Story");
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    query.Selection.Add(nameAttribute);
    QueryResult result = services.Retrieve(query);
    Asset story = result.Assets[0];
    string oldName = story.GetAttribute(nameAttribute).Value.ToString();
    story.SetAttributeValue(nameAttribute, GetNewName());
    services.Save(story);

    Console.WriteLine(story.Oid.Token);
    Console.WriteLine(oldName);
    Console.WriteLine(story.GetAttribute(nameAttribute).Value);
    /***** OUTPUT *****
        Story:1094:1446
        Logon
        New Name
    ******************/

    return story;
}
```

### How to update a single-value relation on an asset

Updating a single-value relation is accomplished by calling the SetAttribute method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the ID for the new relation. This code will change the source of the Story with ID 1094:

```csharp
public Asset UpdateSingleValueRelation()
{
    Oid storyId = Oid.FromToken("Story:1094", metaModel);
    Query query = new Query(storyId);
    IAssetType storyType = metaModel.GetAssetType("Story");
    IAttributeDefinition sourceAttribute = storyType.GetAttributeDefinition("Source");
    query.Selection.Add(sourceAttribute);
    QueryResult result = services.Retrieve(query);
    Asset story = result.Assets[0];
    string oldSource = story.GetAttribute(sourceAttribute).Value.ToString();
    story.SetAttributeValue(sourceAttribute, GetNextSourceID(oldSource));
    services.Save(story);

    Console.WriteLine(story.Oid.Token);
    Console.WriteLine(oldSource);
    Console.WriteLine(story.GetAttribute(sourceAttribute).Value);
    /***** OUTPUT *****
        Story:1094:1446
        StorySource:148
        StorySource:149
    ******************/

    return story;
}
```

### How to add and remove values from a multi-value relation

Updating a multi-value relation is accomplished by calling either the RemoveAttributeValue or AddAttributeValue method on an asset, specifying the IAttributeDefinition of the attribute you wish to change and the ID of the relation you wish to add or remove. This code will add one Member and remove another Member from the Story with ID 1094:

```csharp
public Asset UpdateMultiValueRelation()
{
    Oid storyId = Oid.FromToken("Story:1094", metaModel);
    Query query = new Query(storyId);
    IAssetType storyType = metaModel.GetAssetType("Story");
    IAttributeDefinition ownersAttribute = storyType.GetAttributeDefinition("Owners");
    query.Selection.Add(ownersAttribute);
    QueryResult result = services.Retrieve(query);
    Asset story = result.Assets[0];
    ArrayList oldOwners = new ArrayList();
    oldOwners.AddRange(story.GetAttribute(ownersAttribute).Values);
    story.RemoveAttributeValue(ownersAttribute, GetOwnerToRemove(oldOwners));
    story.AddAttributeValue(ownersAttribute, GetOwnerToAdd(oldOwners));
    services.Save(story);

    Console.WriteLine(story.Oid.Token);
    foreach (Oid oid in oldOwners)
    {
        Console.WriteLine(oid.Token);
    }
    foreach (Oid oid in story.GetAttribute(ownersAttribute).Values)
    {
        Console.WriteLine(oid.Token);
    }
    /***** OUTPUT *****
        Story:1094:1446
        Member:1003
        Member:1000
    ******************/

    return story;
}
```

## Learn By Example: New Asset

When you create a new asset in the APIClient you need to specify the "context" of another asset that will be the parent. For example, if you create a new Story asset you can specify which Scope it should be created in.

How to get a new Story asset template in the context of a Scope asset
This code will create a Story asset in the context of Scope with ID 1012:

```csharp
public Asset AddNewAsset()
{
    Oid projectId = Oid.FromToken("Scope:1012", metaModel);
    IAssetType storyType = metaModel.GetAssetType("Story");
    Asset newStory = services.New(storyType, projectId);
    IAttributeDefinition nameAttribute = storyType.GetAttributeDefinition("Name");
    newStory.SetAttributeValue(nameAttribute, "My New Story");
    services.Save(newStory);

    Console.WriteLine(newStory.Oid.Token);
    Console.WriteLine(newStory.GetAttribute(storyType.GetAttributeDefinition("Scope")).Value);
    Console.WriteLine(newStory.GetAttribute(nameAttribute).Value);
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

```csharp
public Oid DeleteAsset()
{
    Asset story = AddNewAsset();
    IOperation deleteOperation = metaModel.GetOperation("Story.Delete");
    Oid deletedID = services.ExecuteOperation(deleteOperation, story.Oid);
    try
    {
        Query query = new Query(deletedID.Momentless);
        services.Retrieve(query);
    }
    catch(WebException)
    {
        Console.WriteLine("Story has been deleted: " + story.Oid.Momentless);
    }
    /***** OUTPUT *****
        Story has been deleted: Story:1049
    ******************/

    return deletedID;
}
```

The delete operation returns the Oid, with the new Moment, of the deleted asset. Future current info queries will automatically exclude deleted assets from results.

Currently, there is no support for undeleting a deleted asset.

### How to close a Story asset

Get the Inactivate operation from the IMetaModel, and use IServices to execute it against a story Oid.

```csharp
public Asset CloseAsset()
{
    Asset story = AddNewAsset();
    IOperation closeOperation = metaModel.GetOperation("Story.Inactivate");
    Oid closeID = services.ExecuteOperation(closeOperation, story.Oid);

    Query query = new Query(closeID.Momentless);
    IAttributeDefinition assetState = metaModel.GetAttributeDefinition("Story.AssetState");
    query.Selection.Add(assetState);
    QueryResult result = services.Retrieve(query);
    Asset closeStory = result.Assets[0];
    AssetState state = (AssetState) closeStory.GetAttribute(assetState).Value;

    Console.WriteLine(closeStory.Oid);
    Console.WriteLine(Enum.GetName(typeof(AssetState), state));
    /***** OUTPUT *****
        Story:1050
        Closed
    ******************/

    return closeStory;
}
```

The AssetState attribute is the internal state of an asset.

### How to reopen a Story asset

Get the Reactivate operation from the IMetaModel, and use IServices to execute it against a story Oid.

```csharp
public Asset ReOpenAsset()
{
    Asset story = CloseAsset();
    IOperation activateOperation = metaModel.GetOperation("Story.Reactivate");
    Oid activeID = services.ExecuteOperation(activateOperation, story.Oid);

    Query query = new Query(activeID.Momentless);
    IAttributeDefinition assetState = metaModel.GetAttributeDefinition("Story.AssetState");
    query.Selection.Add(assetState);
    QueryResult result = services.Retrieve(query);
    Asset activeStory = result.Assets[0];
    AssetState state = (AssetState)activeStory.GetAttribute(assetState).Value;

    Console.WriteLine(activeStory.Oid);
    Console.WriteLine(Enum.GetName(typeof(AssetState), state));
    /***** OUTPUT *****
        Story:1051
        Active
    ******************/

    return activeStory;
}
```

## Learn By Example: System Settings

Some system settings are exposed (read-only) to the APIClient, to allow client-side data validation. Specifically, the system settings for Effort Tracking, Story Tracking Level and Defect Tracking Level are now available to the APIClient, so that entry of Effort, Detail Estimate, and ToDo can be done consistently with the way VersionOne Enterprise is configured. In previous versions, there was no way for the APIClient to check these settings, and the developer would have to code with knowledge of the system's configured state.  Using the V1Configuration component, you can get the system's configured state, and apply these settings appropriately in code.

### Getting VersionOne System Settings

To get the system settings, create an instance of the V1Configuration class, using a V1APIConnector (directed to the "config.v1" http address):

```csharp
public void GetV1configuration()
{
    V1Configuration configuration = new V1Configuration(new V1APIConnector("http://server/v1instance/config.v1/"));
}
```

### Effort Tracking setting

The V1Configuration.EffortTracking property indicates whether or not Effort Tracking has been enabled in VersionOne Enterprise.  In this example, the VersionOne instance has Effort Tracking turned off:

```csharp
public void IsEffortTrackingEnabled()
{
    V1Configuration configuration = new V1Configuration(new V1APIConnector("http://server/v1instance/config.v1/"));

    if(configuration.EffortTracking)
    	Console.WriteLine("Effort Tracking is enabled");
    else
    	Console.WriteLine("Effort Tracking is disabled");

    /***** OUTPUT *****
        Effort Tracking is disabled
    ******************/
}
```

### Tracking Level settings

Detail Estimate, ToDo and Effort can be entered for Stories and Defects, or for their child Tasks and Tests, depending on how the system is configured.  The V1Configuration.StoryTrackingLevel and V1Configuration.DefectTrackingLevel properties indicate where input of Detail Estimate, ToDo and Effort are taken.

In this example, the VersionOne instance is configured to take DetailEstimate, ToDo, and Effort at the Task/Test level for Stories (Off), and to take DetailEstimate, ToDo, and Effort at the Defect level for Defects (On):

```csharp
public void StoryAndDefectTrackingLevel()
{
    V1Configuration configuration = new V1Configuration(new V1APIConnector("http://server/v1instance/config.v1/"));

    Console.Writeline(configuration.StoryTrackingLevel);
    Console.Writeline(configuration.DefectTrackingLevel);

    /***** OUTPUT *****
        Off
    	On
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
