using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.RestApi.Specs.Helpers
{
    public static class ApiRouteHelper
    {
        public static string ToQueryString<TParams>(this TParams args)
        {
            var sb = new StringBuilder("?");

            args.GetType()
                .GetPropertiesOf()
                .Select(p => new { p.Name, Value = (dynamic)p.GetValue(args) })
                .ToList()
                .ForEach(val => sb.AppendFormat($"{val.Name}={val.Value}&"));

            return sb.ToString();
        }
    }
}
