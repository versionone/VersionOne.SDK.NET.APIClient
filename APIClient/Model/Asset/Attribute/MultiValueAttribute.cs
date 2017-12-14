using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient
{
    // TODO see if we can stop using old school collections here
    internal class MultiValueAttribute : Attribute
    {
        private class UniqueSet : HashSet<object>
        {
            public UniqueSet()
            {
            }

            public UniqueSet(IEnumerable sourceSet)
            {
                foreach (var item in sourceSet) Add(item);
            }
        }

        private UniqueSet _values = new UniqueSet();
        private UniqueSet _addedValues;
        private UniqueSet _removedValues;
        private UniqueSet _newValues;

        internal MultiValueAttribute(IAttributeDefinition def, Asset asset) : base(def, asset) { }

        public override object OriginalValue
        {
            get
            {
                if (_values.Count == 0) return Definition.Coerce(null);
                if (_values.Count == 1) return _values.First();
                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override object NewValue
        {
            get
            {
                if (_newValues == null) return null;
                if (_newValues.Count == 0) return Definition.Coerce(null);
                if (_newValues.Count == 1) return _newValues.First();
                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override IEnumerable OriginalValues => _values;

        public override IEnumerable NewValues => _newValues;

        public override IEnumerable AddedValues => _addedValues;

        public override IEnumerable RemovedValues => _removedValues;

        public override bool HasChanged => (_newValues != null);

        internal override void SetValue(object value) => throw new ApplicationException("Cannot set value on a multi-value attribute: " + Definition.Token);

        internal override void ForceValue(object value) => throw new ApplicationException("Cannot force value on a multi-value attribute: " + Definition.Token);

        //private bool ContainsValue(object value) => _values.Contains(value) || _addedValues.Contains(value);
        private bool AlreadyAddedValue(object value) => _addedValues.Contains(value);

        internal override void AddValue(object value)
        {
            CheckReadOnly();
            value = Definition.Coerce(value);
            CheckNull(value);
            EnsureNewValues();
            EnsureAddedValues();

            if (AlreadyAddedValue(value)) return;

            _newValues.Add(value);
            _addedValues.Add(value);
            _removedValues?.Remove(value);
        }

        internal override void RemoveValue(object value)
        {
            CheckReadOnly();
            value = Definition.Coerce(value);

            EnsureNewValues();
            _newValues.Remove(value);

            EnsureRemovedValues();

            _removedValues.Add(value);

            _addedValues?.Remove(value);
        }

        private void EnsureNewValues() => _newValues = _newValues ?? new UniqueSet(_values);
        private void EnsureAddedValues() => _addedValues = _addedValues ?? new UniqueSet();
        private void EnsureRemovedValues() => _removedValues = _removedValues ?? new UniqueSet();

        public override void AcceptChanges()
        {
            if (HasChanged)
            {
                _values = _newValues;
                _newValues = _addedValues = _removedValues = null;
            }
        }

        public override void RejectChanges() => _newValues = _addedValues = _removedValues = null;

        internal override void LoadValue(object value) => _values.Add(Definition.Coerce(value));
    }
}