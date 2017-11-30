using System.Collections.Generic;
using System.Linq;
using Demo.PropertySearch.RestApi.Helpers;

namespace Demo.PropertySearch.RestApi.Models
{
    public class QueryResults<TModel> : ILinkedViewModel
    {
        public IEnumerable<NavigationLink> Links { get; set; }

        public int? ResultCount => Result?.Count();

        public IEnumerable<TModel> Result { get; set; }
    }
}