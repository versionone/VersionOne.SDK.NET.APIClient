using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.Tests.ServicesTests.Constructor
{
    public abstract class ServicesConstructorSpecs
    {
        protected static IDictionary<string, object> Context = new Dictionary<string, object>();

        public static void Initialize()
        {
            Context = new Dictionary<string, object>();
        }
    }
}
