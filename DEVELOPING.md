# Developing with VersionOne SDK.NET #

## Getting Libraries ##
VersionOne SDK.NET consists of two DLLs:

* VersionOne.SDK.APIClient
* VersionOne.SDK.ObjectModel

Both libraries are available via:

* NuGet from within Visual Studio.
* Download binares in a zip file.

### APIClient ###
The APIClient provides access to the Core API without concern for the 
underlying RESTful API or the HTTP/XML plumbing. Through the APIClient, 
developers can query for simple or complex sets of information, update the 
information, and execute system-defined operations. The APIClient is best 
suited for course-grained and bulk access.

### ObjectModel ###
The ObjectModel libraries provide a strongly-typed model on top of APIClient. 
This allows developers to easily and quickly develop VersionOne integrations 
and complementary applications/utilities using domain objects (Project, Story, 
Iteration, etc) instead of more abstract objects (Asset, Attribute). The 
ObjectModel is suitable for fine-grained access, such as creating new 
VersionOne assets.


## Building from Source ##
The solution uses NuGet to resolve external dependencies. Since the test 
projects depend on NUnit, NuGet will install the correct version of NUnit when 
Visual Studio builds the test projects. Use Visual Studio or MS Build to create 
the DLLs.

## Testing ##
Different testing strategies have been employed for each layer of 
VersionOne SDK.NET.

### APIClient ###
VersionOne.SDK.APIClient.Tests run without a VersionOne installation. In order 
to ease execution of the unit tests, the project file has a reference to:
`$(SolutionDir)\packages\NUnit.Runners.<version>\tools\nunit.exe`

1. Build the VersionOne.SDK.APIClient.Tests project.
2. Right-click on the VersionOne.SDK.APIClient.Tests project and select 
   `Debug > Start new instance` or `Debug > Step Into new instance`.

By default Visual Studio's debugger will not stop on breakpoints when executing 
the tests in the external NUnit tool. To enable breakpoints, modify the 
`packages\NUnit.Runners.<verion>\tools\nunit.exe.config` file under 
`Startup > supportedRuntime` as follows:

```xml
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <!-- Comment out the next line to force use of .NET 4.0 -->
    <!-- <supportedRuntime version="v2.0.50727" /> -->
    <supportedRuntime version="v4.0.30319" />
  </startup>
```

This forces the NUnit runner to execute under .NET 4.0, and allows Visual 
Studio to thus load the debug symbols. Otherwise, NUnit executes under 2.0, but 
spawns a separate process to execute the tests under version 4.0.

### ObjectModel ###
VersionOne.SDK.ObjectModel.Tests require a VersionOne instance. The 
`InstallV1.cmd` script installs the VersionOne application with options 
necessary for testing. It requires some modifications for local environments.

#### Database Restore ####
By default, the script will restore the database backup to the default SQL 
Server intance on the local machine. To override the defaults:

* Change the `RESTORE_DB` variable to `false`.
* Change the `DB_SERVER` to the DB server and instance. 
  Example: `(local)\SQL2008` or `dbserver\MyInstance`
* Copy the `V1SDKTests.exe` file to the target server if it is not the local 
  machine. Run `V1SDKTests.exe` to extract the `V1SDKTests.bak` file. It should 
  end up about 15 megabytes.
* Edit the `RestoreV1SDKTestsDB.sql` file to configure the paths needed to 
  restoree DB from disk on the target SQL Server instance. 

*Note:* The DB name `V1SDKTests` is hard-coded into other files; hence, the DB 
name should not be changed.

#### Application Installer ####

* Copy the VersionOne installer exe file into the TestSetup directory.
* Edit `InstallV1.cmd` and modify the `V1_SETUP` variable to point to the name 
  of the installer. By default it is `VersionOne.Setup-Ultimate-latest.exe`.
* Type `InstallV1.cmd` from the command line.

*Note:* A SQL script attempts to determine the exact location for the DB files. 
If it fails, replace the `CALL SET_SQL_VARS.bat` with 
`SET SQL_DATA_DIR=<Path to SQL DataDir>`. Example: 
`C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\`

After the `InstallV1.cmd` script completes, the success message should read:

```
Thank you, you can browse to http://localhost/V1SDKTests and login with 
admin / admin, and you should be able to execute the integration tests now...
```

*Note:* Run `UnInstallV1.cmd` to uninstall the VersionOne application and 
database.

#### Running the Tests ####
In order to ease execution of the unit tests, the 
VersionOne.SDK.ObjectModel.Tests project file has a reference to:
`$(SolutionDir)\packages\NUnit.Runners.<version>\tools\nunit.exe`

1. Build the VersionOne.SDK.ObjectModel.Tests project.
2. Right-click on the VersionOne.SDK.ObjectModel.Tests project and select 
   `Debug > Start new instance` or `Debug > Step Into new instance`.

By default Visual Studio's debugger will not stop on breakpoints when executing 
the tests in the external NUnit tool. To enable breakpoints, modify the 
`packages\NUnit.Runners.<verion>\tools\nunit.exe.config` file under 
`Startup > supportedRuntime` as follows:

```xml
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <!-- Comment out the next line to force use of .NET 4.0 -->
    <!-- <supportedRuntime version="v2.0.50727" /> -->
    <supportedRuntime version="v4.0.30319" />
  </startup>
```

This forces the NUnit runner to execute under .NET 4.0, and allows Visual 
Studio to thus load the debug symbols. Otherwise, NUnit executes under 2.0, but 
spawns a separate process to execute the tests under version 4.0.


## Getting Help ##
Need to bootstrap on VersionOne SDK.NET quickly? VersionOne services brings a 
wealth of development experience to training and mentoring on VersionOne 
SDK.NET:

http://www.versionone.com/training/product_training_services/

Have a question? Get help from the community of VersionOne developers:

http://groups.google.com/group/versionone-dev/
