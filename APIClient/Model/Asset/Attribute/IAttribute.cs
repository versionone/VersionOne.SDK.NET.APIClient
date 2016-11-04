using System.Collections;

namespace VersionOne.SDK.APIClient
{
    public interface IAttribute
    {
        Asset Asset { get; }
        IAttributeDefinition Definition { get; }
        object OriginalValue { get; }
        object NewValue { get; }
        object Value { get; }
        IEnumerable OriginalValues { get; }
        IEnumerable NewValues { get; }
        IEnumerable AddedValues { get; }
        IEnumerable RemovedValues { get; }
        IEnumerable Values { get; }
        IList ValuesList { get; }
        bool HasChanged { get; }
        void AcceptChanges();
        void RejectChanges();
    }
}