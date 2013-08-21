using System;
using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient;
using ApiVNext;
using MoreLinq;

namespace GettingStarted
{
    public class Program
    {
        // Modify to have your own url and credentials here:
        private const string BaseUrl = "http://localhost/VersionOne.Web";
        private const string UserName = "admin";
        private const string Password = "admin";

        public void Run()
        {
            var runStaticExamples = ReadString("VersionOne API Client Example Runner: Type i for interactive mode or s to run the static examples: ");

            if (runStaticExamples.Equals("i", StringComparison.OrdinalIgnoreCase))
            {
                var keepGoing = "y";

                while (keepGoing.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    RunExample(ShowInteractiveFluentQuery, pauseBeforeContinue: false);

                    keepGoing = ReadString("Continue? y for yes, n to exit");
                }
            }
            else
            {
                // Static Examples

                RunExample(ShowAdminMemberToken,
                           "Showing the admin member oid value...",
                           "Press any key to show admin member oid token");

                RunExample(ShowMultipleAttributes,
                           "Showing multiple attributes from the admin member...",
                           "Press any key to continue");

                RunExample(ShowMultipleAttributesVNextTypedQuery,
                           "TypedQuery Approach Showing multiple attributes from the admin member...",
                           "Press any key to continue");

                RunExample(ShowMultipleAttributesVNextFreeQuery,
                           "FreeQuery Approach Showing multiple attributes from the admin member...",
                           "Press any key to continue");

                RunExample(ShowMultipleAttributesVNextFluentQuery,
                           "FluentQuery Approach Showing multiple attributes from the admin member...",
                           "Press any key to continue");

                RunExample(ShowProjectNameWithVNextFreeQuery,
                           "FreeQuery Approach Showing project name...",
                           "Press any key to continue");

                RunExample(UpdateAdminMemberNameFluentQuery,
                           "Updating the admin member's name with a FluentQuery result",
                           "Press any key to continue...");

                RunExample(UpdateAdminMemberName,
                           "Updating the admin member's name...",
                           "Press any key to exit...");
            }
        }

        #region Examples

        public void ShowAdminMemberToken()
        {
            var query = new Query(Oid.FromToken("Member:20", _metaModel));
            var result = _services.Retrieve(query);
            var member = result.Assets[0];

            Console.WriteLine(member.Oid.Token);
        }

        public void ShowMultipleAttributesVNextTypedQuery()
        {
            dynamic member = new TypedQuery<Member>().Execute(
                "Member:20",
                new[] { "Name", "Email" }
                // Can also use:
                // new object[] { Member.Fields.Name, Member.Fields.Email }
                ).FirstOrDefault();

            if (member != null)
            {
                Console.WriteLine("Name: " + member.Name);
                Console.WriteLine("Email: " + member.Email);
            }
        }

        public void ShowMultipleAttributesVNextFreeQuery()
        {
            new FreeQuery(
                "Member",

                where: new[]
                           {
                                                     // The term is optional, it's the default
                               Op.Get("Email", "admin@company.com", FilterTerm.Operator.Equal),
                           },

                select: new[] { "Name", "Email", "Username", "OwnedWorkitems.@Count" },

                success: (assets) =>
                {
                    dynamic member = assets.FirstOrDefault();

                    if (member != null)
                    {
                        Console.WriteLine("Name: " + member.Name);
                        Console.WriteLine("Email: " + member.Email);
                        Console.WriteLine("Username: " + member.Username);
                    }
                },

                error: (exception) => Console.WriteLine("Exception! " + exception.Message));
        }

        public void ShowMultipleAttributesVNextFluentQuery()
        {
            new
                FluentQuery("Member")
                .Where(
                    Op.Get("Email", "admin@company.com", FilterTerm.Operator.Equal) // default is Equal
                )
                .Select(
                    "Name", "Email", "Username", "OwnedWorkitems.@Count"
                )
                .Success(assets =>
                             {
                                 dynamic member = assets.FirstOrDefault();
                                 if (member != null)
                                 {
                                     Console.WriteLine("Fluent Name: " + member.Name);
                                     Console.WriteLine("Email: " + member.Email);
                                     Console.WriteLine("Username: " + member.Username);
                                 }
                             }
                )
                .WhenEmpty(() => Console.WriteLine("No results found..."))
                .Error(exception => Console.WriteLine("Exception! " + exception.Message))
                .Execute();
        }

        public void ShowInteractiveFluentQuery()
        {
            var assetTypeName = ReadString("What asset type do you want to query? (ex: Story, Member)");
            var query = new FluentQuery(assetTypeName);

            Console.WriteLine();
            var criteria = ReadValues(
                "Enter one or more comma-separated filter terms ins the form of Field=value (ex: ID=Story:1083, Name=My Story). Hit enter to continue.",
                ParseCommaDelimItems, ParseFilterTerm);

            query.Where(criteria.ToArray());

            Console.WriteLine();
            var selectTerms = ReadValues("Enter one or more comma-separated field names to select. (ex: Name, CreatedBy). Hit enter to continue.)",
                ParseCommaDelimItems);

            query.Select(selectTerms.ToArray());

            query.OnSuccess = assets =>
            {
                assets.ForEach(asset =>
                    selectTerms.ForEach(fieldName =>
                        Console.WriteLine(fieldName + ": " + asset.GetValueByName(fieldName))
                    )
                );
                // Above is the same thing as:
                //foreach (AssetClassBase asset in assets)
                //{
                //    foreach (var fieldName in selectTerms)
                //    {
                //        Console.WriteLine(fieldName + ": " + asset.GetValueByName(fieldName));
                //    }
                //}
            };
            query.OnEmptyResults = () => Console.WriteLine("No results found...");
            query.OnError = PrintError;

            query.Execute();
        }


        private void PrintError(Exception exception)
        {
            Console.WriteLine("Exception! " + exception.Message);
        }

        public void ShowProjectNameWithVNextFreeQuery()
        {
            new FreeQuery(
                "Scope",

                where: new[] 
                           {
                                Op.Get("Name", "Call Center")  
                           },

                select: new[] { "Name" },

                success: (assets) =>
                             {
                                 foreach (dynamic asset in assets)
                                     Console.WriteLine(asset.Name);
                             },

                error: (exception) => Console.WriteLine("Exception! " + exception.Message));
        }

        public void ShowMultipleAttributes()
        {
            var query = new Query(Oid.FromToken("Member:20", _metaModel));
            var nameAttribute = _metaModel.GetAttributeDefinition("Member.Name");
            var emailAttribute = _metaModel.GetAttributeDefinition("Member.Email");
            query.Selection.Add(nameAttribute);
            query.Selection.Add(emailAttribute);

            var result = _services.Retrieve(query);
            var member = result.Assets[0];

            Console.WriteLine("Oid Token: " + member.Oid.Token);
            Console.WriteLine("Name: " + member.GetAttribute(nameAttribute).Value);
            Console.WriteLine("Email: " + member.GetAttribute(emailAttribute).Value);
        }

        public void UpdateAdminMemberNameFluentQuery()
        {
            FluentQuery query = null;
            query = new FluentQuery("Member")
                .Where(
                    Op.Get("ID", "Member:20")
                )
                .Select(
                    "Name"
                )
                .Success(assets =>
                             {
                                 dynamic member = assets.FirstOrDefault();
                                 if (member != null)
                                 {
                                     Console.WriteLine("Name is currently: " + member.Name);

                                     var newName = string.Empty;
                                     while (newName == string.Empty)
                                     {
                                         newName = ReadString("Please enter a new name and hit enter");
                                     }

                                     member.Name = newName;

                                     var asset = (AssetClassBase)member;
                                     asset.SaveChanges();
                                 }
                             }
                )
                .WhenEmpty(() => Console.WriteLine("No results found..."))
                .Execute();

            Console.WriteLine();
            Console.WriteLine("Saved member, now requerying...");
            Console.WriteLine();

            query.Execute(assets => {
                dynamic memberNow = assets.FirstOrDefault();
                if (memberNow != null)
                {
                    Console.WriteLine("Name is now: " + memberNow.Name);
                }
            });
        }

        public void UpdateAdminMemberName()
        {
            var query = new Query(Oid.FromToken("Member:20", _metaModel));
            var nameAttribute = _metaModel.GetAttributeDefinition("Member.Name");
            query.Selection.Add(nameAttribute);
            var result = _services.Retrieve(query);
            var member = result.Assets[0];
            var nameValue = member.GetAttribute(nameAttribute).Value as string;
            Console.WriteLine("Name is currently: " + nameValue);

            var newName = string.Empty;
            while (newName == string.Empty)
            {
                newName = ReadString("Please enter a new name and hit enter");
            }

            member.SetAttributeValue(nameAttribute, newName);
            _services.Save(member);

            Console.WriteLine();
            Console.WriteLine("Saved member, now requerying...");
            Console.WriteLine();

            result = _services.Retrieve(query);
            member = result.Assets[0];
            nameValue = member.GetAttribute(nameAttribute).Value as string;
            Console.WriteLine("Name is now: " + nameValue);
        }

        #endregion

        #region Execution

        private static void RunExample(Action exampleMethod, string exampleMessage = null, string nextMessage = null,
            bool pauseBeforeContinue = true)
        {
            if (exampleMessage != null)
            {
                Console.WriteLine(exampleMessage);
            }
            Console.WriteLine();
            exampleMethod();
            Console.WriteLine();
            if (nextMessage != null)
            {
                Console.WriteLine(nextMessage);
            }
            Console.WriteLine();
            if (pauseBeforeContinue)
            {
                Console.ReadKey();
            }
        }

        private string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private IEnumerable<string> ReadValues(string lineMessage, Func<string, IEnumerable<string>> parseLine, string terminationPattern = "")
        {
            var lines = new List<string>();
            string newLine = null;
            while (newLine != terminationPattern)
            {
                newLine = ReadString(lineMessage);
                if (newLine != terminationPattern)
                {
                    if (parseLine != null)
                    {
                        var items = parseLine(newLine);
                        lines.AddRange(items);
                    }
                    else
                    {
                        lines.Add(newLine);
                    }
                }
            }
            return lines;
        }

        private IEnumerable<T> ReadValues<T>(string lineMessage,
            Func<string, IEnumerable<string>> parseLine,
            Func<string, T> converter,
            string terminationPattern = "") where T : class
        {
            var results = new List<T>();
            string newLine = null;
            while (newLine != terminationPattern)
            {
                newLine = ReadString(lineMessage);
                if (newLine != terminationPattern)
                {
                    var items = parseLine(newLine);
                    items.ForEach(part =>
                        {
                            var item = converter(part);
                            if (item != null)
                            {
                                results.Add(item);
                            }
                        }
                    );
                }
            }
            return results;
        }

        private IEnumerable<string> ParseCommaDelimItems(string line)
        {
            if (line.Contains(','))
            {
                var items = line.Split(',');

                var trimmedItems = items.Select(x => x.Trim());

                return trimmedItems;
            }

            return new[] { line };
        }

        private Tuple<string, object, FilterTerm.Operator> ParseFilterTerm(string item)
        {
            if (!item.Contains("="))
            {
                Console.WriteLine("Must enter terms in the form Field=value (ex: Email=admin@company.com).");
                return null;
            }

            var items = item.Split('=');
            var trimmedItems = items.Select(x => x.Trim()).ToList();

            return Op.Get(trimmedItems[0], trimmedItems[1]);
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private readonly IServices _services;
        private readonly IMetaModel _metaModel;

        public Program()
        {
			var servicesFactory = new V1ServicesFactory();
			System.IO.Directory.SetCurrentDirectory(@"C:\Users\JKoberg\src\VersionOne.SDK.NET.APIClient\Example\GettingStarted\src\bin\Debug");
			_services = servicesFactory.CreateServices(BaseUrl, OAuth2Client.Storage.JsonFileStorage.Default);
            _metaModel = servicesFactory.GetMetaModel();

            ServicesProvider.Services = _services;
            MetaModelProvider.Meta = _metaModel;
        }

        #endregion
    }
}
