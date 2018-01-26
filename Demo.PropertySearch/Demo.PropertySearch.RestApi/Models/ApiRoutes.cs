using Demo.PropertySearch.Domain;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.RestApi.Models
{

    public static class ApiRoute
    {
        public class Home
        {
            public const string Route = "";

            public const string Name = nameof(Home);
        }

        public class StockById
        {
            public const string Route = "stock/{id}";

            public const string Name = nameof(StockById);

            public string Id { get; set; }
        }
        public class StockSearch
        {
            public const string Route = "stock";

            public const string Name = nameof(StockSearch);

            public class StockSearchParams
            {
                public string Keyword { get; set; }

                public double? MinPrice { get; set; }

                public double? MaxPrice { get; set; }

                public SearchParams ToDomainSearchArgs()
                {
                    return new SearchParams
                    {
                        Keyword = this.Keyword,

                        MinPrice = this.MinPrice,

                        MaxPrice = this.MaxPrice
                    };
                }

                public bool IsEmpty()
                {
                    return Keyword.IsNullOrEmpty() && MinPrice == null && MaxPrice == null;
                }
            }
        }
    }
}