using System.Collections.Generic;
using System.Text.RegularExpressions;
using Castle.DynamicProxy;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.Specs.Utils
{
    internal abstract class ArgsInterceptor : IInterceptor
    {
        private readonly IDictionary<string, object> _specContext;

        private static readonly Regex PropertyNameFormat = new Regex("(get_|set_)(.*)");

        protected ArgsInterceptor
            (
            IDictionary<string, object> specContext
            )
        {
            _specContext = specContext;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            // ReSharper disable once PossibleNullReferenceException
            var key = invocation.Method.DeclaringType.FullName + PropertyNameFormat.Replace(methodName, @".$2");

            var methodPrefix = PropertyNameFormat.Replace(methodName, @"$1");

            switch (methodPrefix)
            {
                case "set_":
                    _specContext[key] = invocation.Arguments[0];
                    break;

                case "get_":
                    if (_specContext.ContainsKey(key))
                    {
                        invocation.ReturnValue = _specContext[key];
                    }
                    break;
            }
        }
    }

    internal class ScenarioArgsInterceptor : ArgsInterceptor
    {
        public ScenarioArgsInterceptor() : base(ScenarioContext.Current)
        {
        }
    }

    internal class FeatureArgsInterceptor : ArgsInterceptor
    {
        public FeatureArgsInterceptor() : base(FeatureContext.Current)
        {
        }
    }
}