using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.Queries {
    public interface IValueProvider {
        ICollection<object> Values { get; }
        string Stringize();
        void Merge(IValueProvider valueProvider);
        bool CanMerge { get; }
    }
}