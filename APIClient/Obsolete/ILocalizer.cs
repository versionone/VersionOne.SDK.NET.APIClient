using System;

namespace VersionOne.SDK.APIClient {
    [Obsolete]
    public interface ILocalizer {
        string Resolve(string key);
    }
}