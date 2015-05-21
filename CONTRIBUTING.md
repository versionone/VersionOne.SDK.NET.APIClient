# Contributing to the VersionOne .NET SDK

 1. [Getting Involved](#getting-involved)
 2. [Reporting Bugs](#reporting-bugs)
 3. [Contributing Code](#contributing-code)

## Getting Involved

We need your help to make the VersionOne .NET SDK a useful tool for developing integrations and complementary applications! While third-party patches are absolutely essential, they are not the only way to get involved. You can help the project by discovering and [reporting bugs](#reporting-bugs), helping others on [StackOverflow](http://stackoverflow.com/questions/tagged/versionone), and reporting defects or enhancement requests as [GitHub issues](https://github.com/versionone/VersionOne.SDK.NET.APIClient/issues).

## Reporting Bugs

Before reporting a bug on the SDK's [issues page](https://github.com/versionone/VersionOne.SDK.NET.APIClient/issues), first make sure that your issue is caused by the SDK and not your application code (e.g. passing incorrect arguments to methods, etc.). Second, search the already reported issues for similar cases, and if it has been reported already, just add any additional details in the comments.

After you made sure that you have found a new bug, here are some tips for creating a helpful report that will make fixing it much easier and quicker:

 * Write a **descriptive, specific title**. Bad: *Problem with filtering*. Good: *Scope.Workitems always returns an empty list*.
 * Whenever possible, include **Function** info in the description.
 * Create a **simple test case** that demonstrates the bug.

## Contributing Code

### Making Changes to Source

If you are not yet familiar with the way GitHub works (forking, pull requests, etc.), be sure to read [the article about forking](https://help.github.com/articles/fork-a-repo) on the GitHub Help website &mdash; it will get you started quickly.

You should always write each batch of changes (feature, bugfix, etc.) in its own branch. Please do not commit to the `master` branch, or your unrelated changes will go into the same pull request.

You should also follow the code style and whitespace conventions of the original codebase.

### Considerations for Accepting Patches

Before sending a pull request with a new feature, first check if it has been discussed before already (either on [GitHub issues](https://github.com/versionone/VersionOne.SDK.NET.APIClient/issues). If your feature or improvement did get merged into master, please consider submitting another pull request.

### Open Source Licenses and Attribution
Regardless of whether attribution is required by included code or a dependency, we want to acknowledge the work that the VersionOne Java SDK depends on and make it easy for people to evaluate the legal implications of using this library. Therefore, all dependencies should be attributed in the [ACKNOWLEDGEMENTS.md](https://github.com/versionone/VersionOne.SDK.NET.APIClient/blob/master/ACKNOWLEDGEMENTS.md) file. This should include the persons or organizations who contributed the libraries, a link to the source code, and a link to the underlying license.
