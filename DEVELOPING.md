# VersionOne SDK.NET APIClient Library
The APIClient provides access to the Core API without concern for the underlying RESTful API or the HTTP/XML plumbing. Through the APIClient, developers can query for simple or complex sets of information, update the information, and execute system-defined operations. The APIClient is best suited for course-grained and bulk access.

## How to get the library as a precompiled package

_Do this if you only want to use the functionality, but are not interested in compiling from source or in contributing code to the project._

Use the NuGet package manager from Visual Studio or nuget.exe. Search for `VersionOne.SDK.APIClient` to find the precompiled package. Packages installed via NuGet have been tested by VersionOne against the product release version specified in the description of the package. Learn more about NuGet here: http://docs.nuget.org/docs/start-here/overview

## How to obtain the source code

_You should obtain the source code if you:_

1. Want to compile it yourself, perhaps to the better understand it or debug it.
2. Would like to contribute code to the project to improve it.

You can obtain it in two ways:

### How to download the source code as a zip file from GitHub

_Do this if you are not planning to contribute code back to the project._

1. Navigate to http://github.com/versionone/VersionOne.SDK.NET.APIClient
2. Click the ZIP button near the top. This downloads all the code as a single zip file.

### How to clone the source code repository from GitHub

_Do this if you want to contribute code to the project._

1. Install _Git for Windows_ from http://msysgit.github.com/
2. Run Git Bash from the start menu
3. Type `git clone git@github.com:versionone/VersionOne.SDK.NET.APIClient.git`

## How to build the library from source

_Once you have the code, you want to build it, right? Not so fast. First, enable NuGet package restore support in the solution:_

1. Open the `VersionOne.SDK.NET.APIClient.sln` solution in Visual Studio.
2. Right click on the solution node and click `Enable NuGet Package Restore`.
3. From the program menu, click `Tools > Library Package Manager > Package Manager Console`
4. From the Package Manager Console, you should see the message `Some NuGet packages are missing from this solution. Click to restore.` Click the `Restore` button next to it. _If you don't see this message_, then simply try to build the tests project. The output should contain messages like:

Like this:

    Successfully installed 'NUnit 2.6.1'.
    Successfully installed 'NUnit.Runners 2.6.1'.
    
## How to upgrade NuGet packages to their latest versions

NuGet can also update the installed packages to the most recent compatible versions. The APIClient does not depend on external packages, but the tests project depends upon NUnit.

To check for and install updated packages:

1. From the program menu, click `Tools > Library Package Manager > Package Manager Console`
2. From the `Default Project` list, select `VersionOne.SDK.APIClient.Tests`
2. From the Package Manager Console, type: `Update-Package`

If no packages updates are available, you should see output like:

    Applying constraint 'NUnit.Runners (≥ 2.6 && < 2.7)' defined in packages.config.
    No updates available for 'NUnit.Runners' in project 'VersionOne.SDK.APIClient.Tests'.
    Applying constraint 'NUnit (≥ 2.6 && < 2.7)' defined in packages.config.
    No updates available for 'NUnit' in project 'VersionOne.SDK.APIClient.Tests'.

If package updates are available, you'll messages showing how NuGet upgraded the project and packages.

## How to run the unit tests

VersionOne.SDK.APIClient.Tests run without a VersionOne installation. In order to ease execution of the unit tests, the project file has a reference to: `$(SolutionDir)\packages\NUnit.Runners.<version>\tools\nunit.exe`

1. Build the VersionOne.SDK.APIClient.Tests project.
2. Right-click on the VersionOne.SDK.APIClient.Tests project and select `Debug > Start new instance` or `Debug > Step Into new instance`.

### Notes on running the unit tests from Visual Studio for debugging

Only do this if you are testing specific methods and do not wish to re-run the entire suite like you can do above.

In order to ease execution of the unit tests, the VersionOne.SDK.APIClient.Tests project file has a reference to: `$(SolutionDir)\packages\NUnit.Runners.<version>\tools\nunit.exe`

_Note: If the NUnit runner version changes, you'll need to modify that path slightly._

1. Build the VersionOne.SDK.ObjectModel.Tests project.
2. Right-click on the VersionOne.SDK.ObjectModel.Tests project and select 
   `Debug > Start new instance` or `Debug > Step Into new instance`

By default Visual Studio's debugger will not stop on breakpoints when executing the tests in the external NUnit tool. To enable breakpoints, modify the `packages\NUnit.Runners.<verion>\tools\nunit.exe.config` file under `startup > supportedRuntime` as follows:

    <startup useLegacyV2RuntimeActivationPolicy="true">
        <!-- Comment out the next line to force use of .NET 4.0 -->
        <!-- <supportedRuntime version="v2.0.50727" /> -->
        <supportedRuntime version="v4.0.30319" />
    </startup>

This forces the NUnit runner to execute under .NET 4.0, and allows Visual Studio to thus load the debug symbols. Otherwise, NUnit executes under 2.0, but spawns a separate process to execute the tests under version 4.0.

## Getting Help
Need to bootstrap on VersionOne SDK.NET quickly? VersionOne services brings a wealth of development experience to training and mentoring on VersionOne SDK.NET:

http://www.versionone.com/training/product_training_services/

Have a question? Get help from the community of VersionOne developers:

http://groups.google.com/group/versionone-dev/