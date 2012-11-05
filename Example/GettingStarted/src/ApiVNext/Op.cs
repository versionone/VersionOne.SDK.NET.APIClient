using System;
using VersionOne.SDK.APIClient;

namespace ApiVNext
{
    public static class Op
    {
        public static Tuple<string, object, FilterTerm.Operator> Get(string field,
                                                                     object value, FilterTerm.Operator oper = FilterTerm.Operator.Equal)
        {
            return new Tuple<string, object, FilterTerm.Operator>(field, value, oper);
        }
    }
}