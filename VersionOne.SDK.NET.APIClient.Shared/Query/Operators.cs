using System;

namespace VersionOne.SDK.APIClient
{
    public class OperatorTuple : Tuple<string, object, FilterTerm.Operator>
    {
        public OperatorTuple(string field, object value, FilterTerm.Operator op) :
            base(field, value, op)
        {
        }
    }

    public static class Operators
    {
        public static OperatorTuple Get(string field,
            object value, FilterTerm.Operator oper = FilterTerm.Operator.Equal) => new OperatorTuple(field, value, oper);

        public static OperatorTuple None(string field, object value) => Get(field, value, FilterTerm.Operator.None);
        public static OperatorTuple Equal(string field, object value) => Get(field, value, FilterTerm.Operator.Equal);
        public static OperatorTuple NotEqual(string field, object value) => Get(field, value, FilterTerm.Operator.NotEqual);
        public static OperatorTuple GreaterThan(string field, object value) => Get(field, value, FilterTerm.Operator.GreaterThan);
        public static OperatorTuple LessThan(string field, object value) => Get(field, value, FilterTerm.Operator.LessThan);
        public static OperatorTuple GreaterThanOrEqual(string field, object value) => Get(field, value, FilterTerm.Operator.GreaterThanOrEqual);
        public static OperatorTuple LessThanOrEqual(string field, object value) => Get(field, value, FilterTerm.Operator.LessThanOrEqual);
        // TODO: not sure about these ones:
        public static OperatorTuple Exists(string field, object value) => Get(field, value, FilterTerm.Operator.Exists);
        public static OperatorTuple NotExists(string field, object value) => Get(field, value, FilterTerm.Operator.NotExists);
    }
}