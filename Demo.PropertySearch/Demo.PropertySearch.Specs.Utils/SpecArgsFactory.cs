using System;
using System.Linq;
using Castle.DynamicProxy;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.Specs.Utils
{
    public static class SpecArgsFactory
    {
        public static TArgs CreateScenarioArgs<TArgs>() where TArgs : class
        {
            var args = CreateArgs<TArgs>(new ScenarioArgsInterceptor());

            return args;
        }

        public static TArgs CreateFeatureArgs<TArgs>() where TArgs : class
        {
            var args = CreateArgs<TArgs>(new FeatureArgsInterceptor());

            return args;
        }

        private static TArgs CreateArgs<TArgs>(IInterceptor interceptor) where TArgs : class
        {
            var argsType = typeof(TArgs);

            ValidateArgsType(argsType);

            var generator = new ProxyGenerator();

            var args =
                argsType.IsClass
                    ? generator.CreateClassProxy(argsType, interceptor)
                    : generator.CreateInterfaceProxyWithoutTarget(argsType, interceptor);


            return (TArgs)args;
        }

        private static void ValidateArgsType(Type argsType)
        {
            var msg = $"Can not create proxy for type {argsType.FullName}";

            if (!argsType.IsClass && !argsType.IsInterface)
            {
                throw new ApplicationException($"{msg} because it is neither a class or an interface.");
            }

            var argsTypeProperties = argsType.GetPropertiesOf().ToList();

            if (argsType.IsClass && !argsTypeProperties.All(info => info.GetGetMethod().IsVirtual))
            {
                throw new ApplicationException($"{msg} because not all properties are virtual.");
            }

            if (
                argsTypeProperties.Where(info => info.PropertyType.IsValueType)
                    .Any(info => Nullable.GetUnderlyingType(info.PropertyType) == null))
            {
                throw new ApplicationException($"{msg} because not all properties are nullable.");
            }
        }
    }
}