using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
    public interface IValueProvider
    {
        ICollection<object> Values { get; }
        string Stringize();
        void Merge(IValueProvider valueProvider);
        bool CanMerge { get; }
    }
}