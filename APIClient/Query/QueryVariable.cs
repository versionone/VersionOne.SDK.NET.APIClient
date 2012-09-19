using System;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient {
    public class QueryVariable : IValueProvider {
        public readonly string Name;

        public ICollection<object> Values { get; private set; }

        public string Token {
            get { return string.Format("${0}", Name); }
        }

        public QueryVariable(string name, params object[] values) {
            Name = name;
            Values = values;
        }

        public string Stringize() {
            return Token;
        }

        public void Merge(IValueProvider valueProvider) {
            throw new NotSupportedException("We do not merge variables with anything else until we're sure we should do.");
        }

        public bool CanMerge {
            get { return false; }
        }

        public override string ToString() {
            return string.Format("{0}={1}", Token, TextBuilder.Join(Values, ",", new ValueStringizer(string.Empty).Stringize));
        }
    }
}