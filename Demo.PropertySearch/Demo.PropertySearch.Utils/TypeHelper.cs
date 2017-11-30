using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Demo.PropertySearch.Utils
{
    public static class TypeHelper
    {
        private static readonly IDictionary<string, IEnumerable<PropertyInfo>> TypePropertiesLookup =
            new ConcurrentDictionary<string, IEnumerable<PropertyInfo>>();

        private static readonly IDictionary<Type, IDictionary<string, string>> TypeConstantLiterals =
            new ConcurrentDictionary<Type, IDictionary<string, string>>();

        public static bool IsPropertyByNameExists<TEntity>(string name)
        {
            var value = GetPropertiesOf(typeof(TEntity)).Any(info => info.Name.EqualsCaseInsensitive(name));

            return value;
        }

        public static PropertyInfo GetPropertyByName<TEntity>(string name)
            where TEntity : class
        {
            var type = typeof(TEntity);

            var propertyInfo = GetPropertyByName(type, name);

            return propertyInfo;
        }

        public static PropertyInfo GetPropertyByName(this Type type, string name)
        {
            var propertyInfo = GetPropertiesOf(type).FirstOrDefault(info => info.Name.EqualsCaseInsensitive(name));

            return propertyInfo;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesOf(this Type type)
        {
            IEnumerable<PropertyInfo> properties;

            if (TypePropertiesLookup.TryGetValue(type.FullName, out properties))
            {
                return properties;
            }

            properties = type.GetProperties();

            TypePropertiesLookup.Add(type.FullName, properties);

            return properties;
        }

        public static PropertyInfo GetPropertyByExpression<TEntity, TProperty>(
            Expression<Func<TEntity, TProperty>> selector)
        {
            Action throwError = () =>
            {
                var msg = $"Unable to get PropertyInfo from Lambda expression {selector}";
                throw new ApplicationException(msg);
            };

            Func<Expression, PropertyInfo> getPropertyInfo
                = expr => (PropertyInfo)((MemberExpression)expr).Member;


            var body = selector.Body;

            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var propertyInfo = getPropertyInfo(body);
                        return propertyInfo;
                    }
                case ExpressionType.Convert:
                    {
                        var operand = ((UnaryExpression)selector.Body).Operand;
                        if (operand is MemberExpression)
                        {
                            var propertyInfo = getPropertyInfo(operand);
                            return propertyInfo;
                        }
                        throwError();
                        break;
                    }
            }

            throwError();

            return null;
        }


        /// <summary>
        /// Get all distinct constant string values from a class
        /// </summary>
        public static IDictionary<string, string> GetConstantLiterals(this Type type)
        {
            if (TypeConstantLiterals.ContainsKey(type))
            {
                return TypeConstantLiterals[type];
            }

            var literals = type
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(f => f.IsLiteral && f.FieldType == typeof(string))
                .ToDictionary(f => f.Name, f => (string)f.GetValue(null));

            TypeConstantLiterals.Add(type, literals);

            return literals;
        }

        /// <summary>
        /// Get all distinct values of "public static readonly string" fields from a class
        /// </summary>
        public static IEnumerable<string> GetReadOnlyLiterals(Type type)
        {
            var literals = type
                .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField)
                .Where(f => f.IsInitOnly && f.FieldType == typeof(string))
                .Select(f => (string)f.GetValue(null))
                .Distinct();

            return literals;
        }

        /// <summary>
        /// Do all object properties have default value?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this T @object) where T : class
        {
            var propertyInfos = GetPropertiesOf(typeof(T));

            var result = propertyInfos.All(prop =>
            {
                var propValue = prop.GetValue(@object);
                var defaultValue = prop.PropertyType.IsValueType ? Activator.CreateInstance(prop.PropertyType) : null;
                return propValue != defaultValue;
            });

            return result;
        }
    }
}
