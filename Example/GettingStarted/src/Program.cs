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
            RunExample(ShowAdminMemberToken,
                "Showing the admin member oid value...",
                "Press any key to show admin member oid token");

            RunExample(ShowMultipleAttributes,
                "Showing multiple attributes from the admin member...",
                "Press any key to continue");

            RunExample(ShowMultipleAttributesVNextTypedQuery,
                "*NEW DYNAMIC VNEXT TypedQuery Approach* Showing multiple attributes from the admin member...",
                "Press any key to continue");

            RunExample(ShowMultipleAttributesVNextFreeQuery,
                "*NEW DYNAMIC VNEXT FreeQuery Approach* Showing multiple attributes from the admin member...",
                "Press any key to continue");

            RunExample(ShowMultipleAttributesVNextFluentQuery,
                "*NEW DYNAMIC VNEXT FluentQuery Approach* Showing multiple attributes from the admin member...",
                "Press any key to continue");

            RunExample(ShowInteractiveFluentQuery,
                "*NEW DYNAMIC VNEXT FluentQuery Approach Interactive* Showing multiple attributes from user-specified asset type...",
                "Press any key to continue");

            RunExample(ShowProjectNameWithVNextFreeQuery,
                "*NEW DYNAMIC VNEXT FreeQuery Approach* Showing project name...",
                "Press any key to continue");

            RunExample(UpdateAdminMemberName,
                "Updating the admin member's name...",
                "Press any key to exit...");
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
                .Error(exception => Console.WriteLine("Exception! " + exception.Message))
                .Execute();
        }

        public void ShowInteractiveFluentQuery()
        {
            var assetTypeName = ReadString("What asset type do you want to query?");
            var query = new FluentQuery(assetTypeName);

            var criteria = ReadValues(
                "Enter a where term in the form of Field=value (ex: Email=admin@company.com). Hit enter to continue.",
               ParseFilterTerm);

            query.Where(criteria.ToArray());

            var selectTerms = ReadValues("Enter a field name. Hit enter to continue)");

            query.Select(selectTerms.ToArray());

            query.OnSuccess = (assets) =>
            {
                if (assets.Any())
                {
                    Console.WriteLine("No results found");
                }
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

        public void UpdateAdminMemberName()
        {
            var query = new Query(Oid.FromToken("Member:20", _metaModel));
            var nameAttribute = _metaModel.GetAttributeDefinition("Member.Name");
            query.Selection.Add(nameAttribute);
            var result = _services.Retrieve(query);
            var member = result.Assets[0];
            var nameValue = member.GetAttribute(nameAttribute).Value as string;
            Console.WriteLine("Name is currently: " + nameValue);

            var newName = ReadString("Please enter a new name and hit enter");

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

        private static void RunExample(Action exampleMethod, string exmapleMessage, string nextMessage = null)
        {
            Console.WriteLine(exmapleMessage);
            Console.WriteLine();
            exampleMethod();
            Console.WriteLine();
            Console.WriteLine(nextMessage);
            Console.WriteLine();
            Console.ReadKey();
        }

        private string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        private IEnumerable<string> ReadValues(string lineMessage, string terminationPattern = "")
        {
            var lines = new List<string>();
            string newLine = null;
            while (newLine != terminationPattern)
            {
                newLine = ReadString(lineMessage);
                if (newLine != terminationPattern)
                {
                    lines.Add(newLine);
                }
            }
            return lines;
        }

        private IEnumerable<T> ReadValues<T>(string lineMessage, Func<string, T> converter,
            string terminationPattern = "") where T : class
        {
            var results = new List<T>();
            string newLine = null;
            while (newLine != terminationPattern)
            {
                newLine = ReadString(lineMessage);
                if (newLine != terminationPattern)
                {
                    var item = converter(newLine);
                    if (item != null)
                    {
                        results.Add(item);
                    }
                }
            }
            return results;
        }

        private Tuple<string,object,FilterTerm.Operator> ParseFilterTerm(string line)
        {
            if (!line.Contains("="))
            {
                Console.WriteLine("Must enter terms in the form Field=value (ex: Email=admin@company.com).");
                return null;
            }
            var values = line.Split('=');
            return Op.Get(values[0], values[1]);
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
            _services = servicesFactory.CreateServices(BaseUrl, UserName, Password);
            _metaModel = servicesFactory.GetMetaModel();

            ServicesProvider.Services = _services;
            MetaModelProvider.Meta = _metaModel;
        }

        #endregion
    }
}
