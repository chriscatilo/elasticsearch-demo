using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public class NavigationLink
    {
        protected NavigationLink()
        {
        }

        public string Rel { get; set; }

        public string Href { get; set; }

        public static NavigationLink Create(string rel, string href)
        {
            return new NavigationLink
            {
                Rel = rel,
                Href = href
            };
        }
    }
}