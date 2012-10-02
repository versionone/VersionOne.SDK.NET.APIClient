mkdir packages
cd APIClient
call ..\..\GetBuildTools\bin\NuGet\RestorePackagesOnly.bat VersionOne.SDK.APIClient.csproj
call ..\..\GetBuildTools\bin\NuGet\UpdatePackages.bat
cd ..\
buildAPIClient.MSBuild.bat