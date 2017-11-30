using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.PropertySearch.RestApi.Models
{

    public static class ApiRoute
    {
        public class Home
        {
            public const string Route = "";

            public const string Name = nameof(Home);
        }

        public class Stock
        {
            public const string Route = "stock";

            public const string Name = nameof(Stock);
        }

        public class StockById
        {
            public const string Route = "stock/{id}";

            public const string Name = nameof(StockById);
        }
    }
}