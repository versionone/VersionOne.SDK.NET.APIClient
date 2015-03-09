using System;
using System.Collections;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Model.Asset.Attribute {
    internal class SingleValueAttribute : Attribute {
        /// <summary>
        /// Holds original value (incl. null). Also holds null if value isn't been read.
        /// </summary>
        private object value;

        /// <summary>
        /// Holds new (changed) value (incl. null). Also holds null if value isn't been modified.
        /// </summary>
        private object newValue;

        /// <summary>
        /// True if newValue holds new value. False if this attribute isn't been modified.
        /// This field was introduced to differ these states.  
        /// </summary>
        private bool hasChanged;

        /// <summary>
        /// Create from definition and asset.
        /// </summary>
        /// <param name="def">attribute definition</param>
        /// <param name="asset">asset</param>
        internal SingleValueAttribute(IAttributeDefinition def, Asset asset) : base(def, asset) { }

        /// <summary>
        /// Return the value before any modificaions.
        /// </summary>
        public override object OriginalValue {
            get { return value; }
        }

        /// <summary>
        /// Return the modified value or null if it's not been modified.
        /// </summary>
        public override object NewValue {
            get { return HasChanged ? newValue : null; }
        }

        /// <summary>
        /// Return an array of 1 containing the value before any modification
        /// or null if it's not been set.
        /// </summary>
        public override IEnumerable OriginalValues {
            get { return Wrap(OriginalValue); }
        }

        /// <summary>
        /// Return an array of 1 containing the modified value
        /// or null if it's not been set.
        /// </summary>
        public override IEnumerable NewValues {
            get { return Wrap(NewValue); }
        }

        private static IEnumerable Wrap(object value) {
            return value == null ? null : new[] {value};
        }

        public override IEnumerable AddedValues {
            get { return NewValues; }
        }

        public override IEnumerable RemovedValues {
            get {
                return HasChanged ? OriginalValues : null;
            }
        }

        public override bool HasChanged {
            get { return (hasChanged); }
        }

        internal override void SetValue(object value) {
            CheckReadOnly();
            value = Definition.Coerce(value);
            CheckNull(value);
            newValue = value;
            hasChanged = true;
        }

        internal override void ForceValue(object value) {
            value = Definition.Coerce(value);
            CheckNull(value);
            newValue = value;
            hasChanged = true;
        }

        internal override void AddValue(object value) {
            throw new ApplicationException("Cannot assign multiple values to a single-value attribute: " + Definition.Token);
        }

        internal override void RemoveValue(object value) {
            throw new ApplicationException("Cannot remove values from a single-value attribute: " + Definition.Token);
        }

        public override void AcceptChanges() {
            if (HasChanged) {
                value = newValue;
                newValue = null;
                hasChanged = false;
            }
        }

        public override void RejectChanges() {
            newValue = null;
            hasChanged = false;
        }

        internal override void LoadValue(object value) {
            if(this.value != null) {
                throw new ApplicationException("Cannot load multiple values into a single-value attribute: " + Definition.Token);
            }

            this.value = Definition.Coerce(value);
        }
    }
}