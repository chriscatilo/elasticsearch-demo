using Demo.PropertySearch.RestApi.Models;
using Demo.PropertySearch.Specs.Utils;
using System.Net.Http;

namespace Demo.PropertySearch.RestApi.Specs
{
    public interface IPropertySearchTestContext : ISpecArgs<IPropertySearchTestContext>
    {
        HttpResponseMessage ApiResponse { get; set; }

        HomeModel RetrievedHomeModel { get; set; }

        QueryResults<ViewModel<StockModel>> RetrievedStockSearch { get; set; }

        ViewModel<StockModel> RetrievedStockById { get; set; }
    }
}
