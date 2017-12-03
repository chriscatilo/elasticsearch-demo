using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo.PropertySearch.Utils
{
    public static class StringHelper
    {
        public static bool EqualsCaseInsensitive(this string value1, string value2)
        {
            return (value1 ?? string.Empty).Equals(value2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return format == null ? null : string.Format(format, args);
        }

        public static string ToCamelCase(this string value)
        {
            if (value == null)
            {
                return null;
            }

            if (value.Length == 1)
            {
                return value.ToLowerInvariant();
            }

            var regex = new Regex(@"^([A-Z]*)(.*)$");

            var match = regex.Match(value);

            if (!match.Success)
            {
                return value.ToLowerInvariant();
            }

            var prefix = match.Groups[1].Value;

            if (prefix.Length == 1)
            {
                prefix = prefix.ToLowerInvariant();
            }
            else
            {
                prefix = prefix.Substring(0, prefix.Length - 1).ToLowerInvariant() + prefix.Substring(prefix.Length - 1);
            }

            var suffix = match.Groups[2];

            return prefix + suffix;
        }

        public static string ToFileNameSafe(this string value)
        {
            var sb = new StringBuilder(value);

            var charactersNotAllowed = new[]
            {
                @"\", @"/", @":", @"*", @"?", "\"", @"<", @">", @"|", @",", @";"
            }.ToList();

            charactersNotAllowed.ForEach(@char => sb.Replace(@char, string.Empty));

            return sb.ToString();
        }

        public static byte[] ToByteArray(this string str)
        {
            if (str == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(str))
            {
                return new byte[0];
            }

            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static IEnumerable<string> ToStringArray(this string value, char separator = ',')
        {
            if (string.IsNullOrEmpty(value))
            {
                return new string[0];
            }

            var result = value.Split(separator)
                .Where(tag => !string.IsNullOrEmpty(tag))
                .Select(tag => tag.Trim());

            return result;
        }

        public static string ToSeparatedString(this IEnumerable<string> values, Func<string, string> format = null, char separator = ',')
        {
            var result = values.Aggregate(new StringBuilder(),
                (sb, next) =>
                {
                    var value = format?.Invoke(next) ?? next;
                    return sb.Append(sb.Length == 0 ? value : $"{separator}{value}");
                });

            return result.ToString();
        }


        public static string ToSeparatedString<TValue>(this IEnumerable<TValue> values, Func<TValue, string> format, char separator = ',')
        {
            var result = values.Aggregate(new StringBuilder(),
                (sb, next) =>
                {
                    var value = format.Invoke(next);
                    return sb.Append(sb.Length == 0 ? value : $"{separator}{value}");
                });

            return result.ToString();
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        private static readonly Regex HtmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        public static string RemoveHtmlTags(this string value)
        {
            return HtmlRegex.Replace(value, string.Empty);
        }

        public static bool IsLike(this string source, string toCheck, StringComparison comp = StringComparison.InvariantCultureIgnoreCase)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
