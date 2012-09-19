using System;

namespace VersionOne.SDK.APIClient {
    public class FilterTerm : IFilterTerm {
        public enum Operator {
            None,
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterThanOrEqual,
            LessThanOrEqual,
            Exists,
            NotExists
        }

        private readonly IAttributeDefinition def;
        private Operator @operator = Operator.None;
        private IValueProvider valueProvider = new ValueProvider(new object[0]);

        public string Token {
            get { return MakeToken(true); }
        }

        public string ShortToken {
            get { return MakeToken(false); }
        }

        private string MakeToken(bool full) {
            if (@operator == Operator.Exists) {
                if(valueProvider.Values.Count > 0) {
                    throw new APIException("Exists operator may not take values");
                }

                return "%2B" + def.Token;
            }
            
            if (@operator == Operator.NotExists) {
                if(valueProvider.Values.Count > 0) {
                    throw new APIException("NotExists operator may not take values");
                }

                return "-" + def.Token;
            }

            if(valueProvider.Values.Count == 0) {
                return null;
            }

            var prefix = full ? def.Token : def.Name;
            return prefix + OperatorToken(@operator) + valueProvider.Stringize();
        }

        private static string OperatorToken(Operator op) {
            switch (op) {
                case Operator.Equal:
                    return "=";
                case Operator.NotEqual:
                    return "!=";
                case Operator.GreaterThan:
                    return ">";
                case Operator.GreaterThanOrEqual:
                    return ">=";
                case Operator.LessThan:
                    return "<";
                case Operator.LessThanOrEqual:
                    return "<=";
            }

            return null;
        }

        public FilterTerm(IAttributeDefinition def) {
            this.def = def;
        }

        public void Equal(params object[] value) {
            Operate(Operator.Equal, value);
        }

        public void NotEqual(params object[] value) {
            Operate(Operator.NotEqual, value);
        }

        public void Greater(params object[] value) {
            Operate(Operator.GreaterThan, value);
        }

        public void Less(params object[] value) {
            Operate(Operator.LessThan, value);
        }

        public void LessOrEqual(params object[] value) {
            Operate(Operator.LessThanOrEqual, value);
        }

        public void GreaterOrEqual(params object[] value) {
            Operate(Operator.GreaterThanOrEqual, value);
        }

        public void Exists() {
            Operate(Operator.Exists);
        }

        public void NotExists() {
            Operate(Operator.NotExists);
        }

        public void Operate(Operator newop, IValueProvider provider) {
            if(newop == Operator.GreaterThan || newop == Operator.GreaterThanOrEqual || newop == Operator.LessThan || newop == Operator.LessThanOrEqual) {
                var deftype = def.AttributeType;

                if(deftype != AttributeType.Date && deftype != AttributeType.Numeric && deftype != AttributeType.Opaque) {
                    throw new ApplicationException("Inequality Operation Not Valid For " + deftype + " AttributeType.");
                }
            }

            if(newop != @operator) {
                @operator = newop;
                valueProvider = provider ?? new ValueProvider(new object[0]);
                return;
            }

            if(provider != null && valueProvider.CanMerge && provider.CanMerge) {
                valueProvider.Merge(provider);
            }
        }

        public void Operate(Operator newop, params object[] value) {
            Operate(newop, new ValueProvider(value));
        }
    }
}