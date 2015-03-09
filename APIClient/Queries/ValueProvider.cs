using System.Collections.Generic;
using System.Linq;
using VersionOne.SDK.APIClient.Utils;

namespace VersionOne.SDK.APIClient.Queries {
    public class ValueProvider : IValueProvider {
        private readonly List<object> values = new List<object>();

        public ICollection<object> Values { get { return values; } }

        public ValueProvider(IEnumerable<object> values) {
            this.values.AddRange(values);
        }
        
        public string Stringize() {
            return TextBuilder.Join(Values, ",", new ValueStringizer().Stringize);
        }

        public void Merge(IValueProvider valueProvider) {
            if(valueProvider.CanMerge) {
                valueProvider.Values.ToList().ForEach(x => Values.Add(x));
            }
        }

        public bool CanMerge {
            get { return true; }
        }
    }
}