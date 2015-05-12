using System;

namespace VersionOne.SDK.APIClient {
    [Obsolete("This interface has been deprecated.")]
    public interface ILocalizer {
        string Resolve(string key);
    }
}