using System;

namespace VersionOne.SDK.APIClient.Obsolete {
    [Obsolete]
    public interface ILocalizer {
        string Resolve(string key);
    }
}