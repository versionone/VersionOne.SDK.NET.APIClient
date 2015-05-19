using System;
using System.Data.SqlTypes;
using System.Globalization;

namespace VersionOne.SDK.APIClient
{
    public static class DB
    {
        public static readonly object Null = null;

        private const string UnknownConversionMessage = "Unsupported conversion from {0}";

        private static string CreateUnknownConversionMessage(object o)
        {
            return string.Format(UnknownConversionMessage, o == null ? "null" : o.GetType().FullName);
        }

        public static int? Int(object obj)
        {
            return ConvertValue<int?>(obj, x => int.Parse(x, CultureInfo.InvariantCulture), y => Convert.ToInt32(y));
        }

        public static bool? Bit(object obj)
        {
            return ConvertValue<bool?>(obj,
                                       x =>
                                       {
                                           if (x == "0" || x.ToLower(CultureInfo.InvariantCulture) == "false")
                                           {
                                               return false;
                                           }

                                           if (x == "1" || x.ToLower(CultureInfo.InvariantCulture) == "true")
                                           {
                                               return true;
                                           }

                                           return null;
                                       },
                                       y => Convert.ToBoolean(y));
        }

        public static string Str(object obj)
        {
            return ConvertValue(obj,
                                x =>
                                {
                                    x = x.Trim();
                                    return x.Length == 0 ? null : x;
                                },
                                null,
                                Convert.ToString);
        }

        public static double? Real(object obj)
        {
            return ConvertValue<double?>(obj, x => double.Parse(x, CultureInfo.InvariantCulture), y => Convert.ToDouble(y));
        }

        public static long? BigInt(object obj)
        {
            return ConvertValue<long?>(obj, x => long.Parse(x, CultureInfo.InvariantCulture), y => Convert.ToInt64(y));
        }

        public static DateTime? DateTime(object obj)
        {
            return ConvertValue<DateTime?>(obj, x => System.DateTime.Parse(x), y => Convert.ToDateTime(y));
        }

        private static T ConvertValue<T>(object obj, Func<string, T> stringConverter, Func<IConvertible, T> convertibleConverter, Func<object, T> defaultConverter = null)
        {
            if (IsNull(obj))
            {
                return default(T);
            }

            if (obj is string)
            {
                var s = (string)obj;
                return string.IsNullOrEmpty(s) ? default(T) : stringConverter(s);
            }

            if (obj is IConvertible && convertibleConverter != null)
            {
                var convertible = (IConvertible)obj;
                return convertibleConverter(convertible);
            }

            if (defaultConverter != null)
            {
                return defaultConverter(obj);
            }

            throw new InvalidCastException(CreateUnknownConversionMessage(obj));
        }

        private static bool IsNull(object obj)
        {
            return obj == null || (obj is INullable && ((INullable)obj).IsNull);
        }
    }
}