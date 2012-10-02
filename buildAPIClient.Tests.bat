mkdir packages
cd APIClient.Tests
call ..\..\GetBuildTools\bin\NuGet\RestorePackagesOnly.bat VersionOne.SDK.APIClient.Tests.csproj
call ..\..\GetBuildTools\bin\NuGet\UpdatePackages.bat
cd ..\
buildAPIClient.Tests.MSBuild.bat