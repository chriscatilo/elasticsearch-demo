using Demo.PropertySearch.Domain;

namespace Demo.PropertySearch.RestApi.Models
{
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
    }
}