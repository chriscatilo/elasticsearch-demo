using System;
using System.Collections.Generic;

namespace Demo.PropertySearch.Repository.Mock
{
    public class SearchParams
    {
        public IEnumerable<Location> Locations { get; set; }

        public string Keyword { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public class Location
        {
            public LocationType LocationType { get; set; }

            public string Value { get; set; }
        }

        public class LocationType
        {
            public string Name { get; set; }

            public string Value { get; set; }
        }
    }
}