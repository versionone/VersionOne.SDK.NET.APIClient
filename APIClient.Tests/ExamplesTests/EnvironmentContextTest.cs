using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.ExamplesTests
{
    [TestFixture]
    public class EnvironmentContextTest
    {
        /// <summary>
        /// This is the simplest scenario, it works with the configuration from app.config
        /// </summary>
        [Test]
        public void EnvironmentContextUsageTest()
        {
            var context = new EnvironmentContext();

            var memberId = Oid.FromToken("Member:20", context.MetaModel);
            var query = new Query(memberId);
            var nameAttribute = context.MetaModel.GetAttributeDefinition("Member.Name");
            var emailAttribute = context.MetaModel.GetAttributeDefinition("Member.Email");

            query.Selection.Add(nameAttribute);
            query.Selection.Add(emailAttribute);

            var result = context.Services.Retrieve(query);
            var member = result.Assets[0];

            Assert.AreEqual("Administrator", member.GetAttribute(nameAttribute).Value);
            Assert.AreEqual("versionone@mailinator.com", member.GetAttribute(emailAttribute).Value);
        }
    }
}
