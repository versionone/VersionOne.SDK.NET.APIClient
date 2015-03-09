using System;
using System.Collections;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Model.Asset.Attribute {
    // TODO see if we can stop using old school collections here
    internal class MultiValueAttribute : Attribute {
        private ArrayList values = new ArrayList();
        private ArrayList addedValues;
        private ArrayList removedValues;
        private ArrayList newValues;

        internal MultiValueAttribute(IAttributeDefinition def, Asset asset) : base(def, asset) {}

        public override object OriginalValue {
            get {
                if(values.Count == 0) {
                    return Definition.Coerce(null);
                }

                if(values.Count == 1) {
                    return values[0];
                }

                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override object NewValue {
            get {
                if(newValues == null) {
                    return null;
                }

                if(newValues.Count == 0) {
                    return Definition.Coerce(null);
                }

                if(newValues.Count == 1) {
                    return newValues[0];
                }

                throw new ApplicationException("Attribute contains multiple values: " + Definition.Token);
            }
        }

        public override IEnumerable OriginalValues {
            get { return values; }
        }

        public override IEnumerable NewValues {
            get { return newValues; }
        }

        public override IEnumerable AddedValues {
            get { return addedValues; }
        }

        public override IEnumerable RemovedValues {
            get { return removedValues; }
        }

        public override bool HasChanged {
            get { return (newValues != null); }
        }

        internal override void SetValue(object value) {
            throw new ApplicationException("Cannot set value on a multi-value attribute: " + Definition.Token);
        }

        internal override void ForceValue(object value) {
            throw new ApplicationException("Cannot force value on a multi-value attribute: " + Definition.Token);
        }

        internal override void AddValue(object value) {
            CheckReadOnly();
            value = Definition.Coerce(value);
            CheckNull(value);

            EnsureNewValues();
            newValues.Add(value);

            if(addedValues == null) {
                addedValues = new ArrayList();
            }

            addedValues.Add(value);

            if(removedValues != null) {
                removedValues.Remove(value);
            }
        }

        internal override void RemoveValue(object value) {
            CheckReadOnly();
            value = Definition.Coerce(value);

            EnsureNewValues();
            newValues.Remove(value);

            if(removedValues == null) {
                removedValues = new ArrayList();
            }

            removedValues.Add(value);

            if(addedValues != null) {
                addedValues.Remove(value);
            }
        }

        private void EnsureNewValues() {
            if(newValues == null) {
                newValues = new ArrayList(values);
            }
        }

        public override void AcceptChanges() {
            if(HasChanged) {
                values = newValues;
                newValues = addedValues = removedValues = null;
            }
        }

        public override void RejectChanges() {
            newValues = addedValues = removedValues = null;
        }

        internal override void LoadValue(object value) {
            values.Add(Definition.Coerce(value));
        }
    }
}