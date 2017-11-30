using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.Repository.Mock
{
    internal static class XElementHelper
    {
        public static string GetSingleStringValue(this XElement element, string name) =>
            element.Descendants(name).SingleOrDefault(d => d.Name.LocalName == name)?.Value ?? null;

        public static int? GetSingleIntValue(this XElement element, string name)
        {
            var value = element.Elements(name).SingleOrDefault(d => d.Name.LocalName == name)?.Value ?? null;
            int result;
            return int.TryParse(value, out result) ? result : default(int?);
        }

        public static DateTime? GetSingleDateTimeValue(this XElement element, string name)
        {
            var value = element.GetSingleStringValue(name);
            DateTime result;
            return DateTime.TryParse(value, out result) ? result : default(DateTime?);
        }

        public static double? GetSingleDoubleValue(this XElement element, string name)
        {
            var value = element.GetSingleStringValue(name);
            double result;
            return double.TryParse(value, out result) ? result : default(double?);
        }

        public static Enum GetSingleEnumValue<TEnumType>(this XElement element, string name)
        {
            var value = element.GetSingleStringValue(name);

            return value.ToEnum<TEnumType>();
        }


        public static Enum ToEnum<TEnum>(this string literalValue)
        {
            var enumType = typeof(TEnum);

            if (!enumType.IsEnum)
            {
                throw new Exception("Type must be enum");
            }

            var value =
                Enum.GetValues(enumType)
                    .Cast<Enum>()
                    .SingleOrDefault(@enum => Enum.GetName(enumType, @enum)
                    .Equals(literalValue, StringComparison.InvariantCultureIgnoreCase));

            return value;
        }

        public static bool IsDescendantElementEqualTo(this XElement el, string propertyName, string value)
        {
            var result = el.Descendants(propertyName)
                .SingleOrDefault()
                ?.Value
                .Equals(value, StringComparison.InvariantCultureIgnoreCase);

            return result ?? false;
        }

        public static bool IsDescendantElementLike(this XElement el, string propertyName, string value)
        {
            var result = el.Descendants(propertyName)
                .SingleOrDefault()
                ?.Value
                .IsLike(value);

            return result ?? false;
        }
    }
}
