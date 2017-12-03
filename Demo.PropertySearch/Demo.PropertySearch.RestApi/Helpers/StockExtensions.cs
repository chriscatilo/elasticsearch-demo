using Demo.PropertySearch.Domain;
using Demo.PropertySearch.RestApi.Models;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public static class StockExtensions
    {
        public static StockModel ToStockModel(this IStock source)
        {
            return new StockModel()
            {
                PropertyID = source.PropertyID,
                OfficeID = source.OfficeID,
                PropertyCreateDate = source.PropertyCreateDate,
                PropertyModifyDate = source.PropertyModifyDate,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
                Bathrooms = source.Bathrooms,
                Bedrooms = source.Bedrooms,
                Receptions = source.Receptions,
                PropertyStatus = source.PropertyStatus,
                AddressLine1 = source.AddressLine1,
                AddressLine2 = source.AddressLine2,
                Description = source.Description,
                LongDescription = source.LongDescription,
                Price = source.Price,
                PropertyType = source.PropertyType
            };
        }
    }
}