using System;
using System.Collections;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
    internal class MultiValueAttribute : Attribute
    {
        private List<object> _values = new List<object>();
        private List<object> _addedValues;
        private List<object> _removedValues;
        private List<object> _newValues;

        internal MultiValueAttribute(IAttributeDefinition def, Asset asset) : base(def, asset) { }

        public override object OriginalValue
        {
            get
            {
                if (_values.Count == 0) return Definition.Coerce(null);
                if (_values.Count == 1) return _values[0];
                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override object NewValue
        {
            get
            {
                if (_newValues == null) return null;
                if (_newValues.Count == 0) return Definition.Coerce(null);
                if (_newValues.Count == 1) return _newValues[0];
                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override IEnumerable OriginalValues => _values;

        public override IEnumerable NewValues => _newValues;

        public override IEnumerable AddedValues => _addedValues;

        public override IEnumerable RemovedValues => _removedValues;

        public override bool HasChanged => (_newValues != null);

        internal override void SetValue(object value)
        {
            throw new ApplicationException("Cannot set value on a multi-value attribute: " + Definition.Token);
        }

        internal override void ForceValue(object value)
        {
            throw new ApplicationException("Cannot force value on a multi-value attribute: " + Definition.Token);
        }

        internal override void AddValue(object value)
        {
            CheckReadOnly();
            value = Definition.Coerce(value);
            CheckNull(value);

            EnsureNewValues();
            _newValues.Add(value);

            _addedValues = _addedValues ?? new List<object>();

            _addedValues.Add(value);

            _removedValues?.Remove(value);
        }

        internal override void RemoveValue(object value)
        {
            CheckReadOnly();
            value = Definition.Coerce(value);

            EnsureNewValues();
            _newValues.Remove(value);

            _removedValues = _removedValues ?? new List<object>();

            _removedValues.Add(value);

            _addedValues?.Remove(value);
        }

        private void EnsureNewValues() => _newValues = _newValues ?? new List<object>(_values);

        public override void AcceptChanges()
        {
            if (HasChanged)
            {
                _values = _newValues;
                _newValues = _addedValues = _removedValues = null;
            }
        }

        public override void RejectChanges()
        {
            _newValues = _addedValues = _removedValues = null;
        }

        internal override void LoadValue(object value)
        {
            _values.Add(Definition.Coerce(value));
        }
    }
}