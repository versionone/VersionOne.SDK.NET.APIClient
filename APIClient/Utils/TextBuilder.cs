using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VersionOne.SDK.APIClient
{
    public class TextBuilder
    {
        public delegate string Stringizer(object value);

        public delegate string Stringizer<T>(T value);

        private static string DefaultStringize(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public static string Join(ICollection list, string separator, Stringizer stringize)
        {
            var needsep = false;
            var s = new StringBuilder(list.Count * 64);

            foreach (var value in list)
            {
                if (needsep)
                {
                    s.Append(separator);
                }
                else
                {
                    needsep = true;
                }

                s.Append(stringize(value));
            }

            return s.ToString();
        }

        public static string Join<T>(ICollection<T> list, string separator, Stringizer<T> stringize)
        {
            var needsep = false;
            var s = new StringBuilder(list.Count * 64);

            foreach (var value in list)
            {
                if (needsep)
                {
                    s.Append(separator);
                }
                else
                {
                    needsep = true;
                }

                s.Append(stringize(value));
            }

            return s.ToString();
        }

        public static string Join(ICollection list, string separator)
        {
            return Join(list, separator, DefaultStringize);
        }

        public static string Join(string separator, params string[] list)
        {
            return string.Join(separator, list);
        }

        public static void SplitPrefix(string s, char separator, out string prefix, out string suffix)
        {
            var parts = s.Split(new[] { separator }, 2);

            if (parts.Length == 1)
            {
                prefix = string.Empty;
                suffix = parts[0];
            }
            else
            {
                prefix = parts[0];
                suffix = parts[1];
            }
        }

        public static void SplitSuffix(string s, char separator, out string prefix, out string suffix)
        {
            var parts = s.Split(new[] { separator }, 2);
            prefix = parts[0];
            suffix = (parts.Length > 1) ? parts[1] : string.Empty;
        }
    }
}