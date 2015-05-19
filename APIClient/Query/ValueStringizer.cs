using System;
using System.Web;

namespace VersionOne.SDK.APIClient
{
    internal class ValueStringizer
    {
        private readonly string valueWrapper;

        public ValueStringizer(string valueWrapper = "'")
        {
            this.valueWrapper = valueWrapper;
        }

        public string Stringize(object value)
        {
            string valueString = value == null ? null : HttpUtility.UrlEncode(value.ToString());
            return string.Format("{0}{1}{0}", valueWrapper, valueString);
        }

        private static string Format(object value)
        {
            if (value is DateTime)
            {
                var date = (DateTime)value;
                return date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            }

            return value.ToString();
        }
    }
}