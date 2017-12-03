using System;
using System.Linq;

// ReSharper disable InvokeAsExtensionMethod

namespace Demo.PropertySearch.Utils
{
    public static class EnumHelper
    {
        public static bool IsEnumType(this object model, string propertyName)
        {
            var property = TypeHelper.GetPropertyByName(model.GetType(), propertyName);

            return property.PropertyType.IsEnum;
        }

        public static Type GetEnumType(this object model, string propertyName)
        {
            var property = TypeHelper.GetPropertyByName(model.GetType(), propertyName);

            var enumType = property.PropertyType;

            return enumType;
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
                    .SingleOrDefault(@enum => Enum.GetName(enumType, @enum).EqualsCaseInsensitive(literalValue));

            return value;
        }

        public static bool IsNullableEnumType(this object model, string propertyName)
        {
            var property = TypeHelper.GetPropertyByName(model.GetType(), propertyName);

            var u = Nullable.GetUnderlyingType(property.PropertyType);

            return (u != null) && u.IsEnum;
        }
    }
}
