using System;
using System.Linq.Expressions;
using Demo.PropertySearch.Utils;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.Specs.Utils
{
    public interface ISpecArgs<out TArgs>
        where TArgs : ISpecArgs<TArgs>
    {
    }

    public static class SpecArgsExtentions
    {
        public static bool HasBeenSet<TArgs, TProperty>(this TArgs specArgs, Expression<Func<TArgs, TProperty>> selector)
            where TArgs : ISpecArgs<TArgs>
        {
            var info = TypeHelper.GetPropertyByExpression<TArgs, TProperty>(selector);

            // ReSharper disable once PossibleNullReferenceException
            var name = $"{info.DeclaringType.FullName}.{info.Name}";

            var result = ScenarioContext.Current.ContainsKey(name) || FeatureContext.Current.ContainsKey(name);

            return result;
        }
    }
}