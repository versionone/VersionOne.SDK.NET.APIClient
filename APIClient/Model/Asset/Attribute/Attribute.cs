using System;
using System.Collections;

namespace VersionOne.SDK.APIClient
{
    public abstract class Attribute : IAttribute
    {
        private readonly IAttributeDefinition def;
        private readonly Asset asset;

        protected Attribute(IAttributeDefinition def, Asset asset)
        {
            this.def = def;
            this.asset = asset;
        }

        public Asset Asset => asset;

        public IAttributeDefinition Definition => def;

        public abstract object OriginalValue { get; }
        public abstract object NewValue { get; }

        public object Value
        {
            get
            {
                if (HasChanged) return NewValue;
                return OriginalValue;
            }
        }

        public abstract IEnumerable OriginalValues { get; }
        public abstract IEnumerable NewValues { get; }
        public abstract IEnumerable AddedValues { get; }
        public abstract IEnumerable RemovedValues { get; }

        public IEnumerable Values
        {
            get
            {
                if (HasChanged) return NewValues;
                return OriginalValues;
            }
        }

        public IList ValuesList
        {
            get
            {
                ArrayList valuesList = new ArrayList();

                foreach (object item in Values)
                {
                    valuesList.Add(item);
                }

                return valuesList;
            }
        }

        public abstract bool HasChanged { get; }

        public abstract void AcceptChanges();
        public abstract void RejectChanges();

        protected void CheckReadOnly()
        {
            if (def.IsReadOnly)
            {
                throw new ApplicationException("Cannot assign new value to a read-only attribute: " + Definition.Token);
            }
        }

        protected void CheckNull(object value)
        {
            if (def.IsRequired || (def.IsMultiValue && def.AttributeType == AttributeType.Relation))
            {
                if (value == null || (value is Oid && ((Oid)value).IsNull))
                {
                    throw new ApplicationException("Value required: " + Definition.Token);
                }
            }
        }

        internal abstract void LoadValue(object value);
        internal abstract void SetValue(object value);
        internal abstract void ForceValue(object value);
        internal abstract void AddValue(object value);
        internal abstract void RemoveValue(object value);
    }
}