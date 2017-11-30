using System.Collections.Generic;
using Demo.PropertySearch.RestApi.Helpers;

namespace Demo.PropertySearch.RestApi.Models
{
    public class HomeModel
    {
        public string Name { get; } = "Property Demo Api";

        public string Version { get; set; }

        public IEnumerable<NavigationLink> Links { get; set; }
    }
}