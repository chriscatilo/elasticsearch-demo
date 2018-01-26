namespace Demo.PropertySearch.RestApi.Models
{
    public class StockListingModel
    {
        public string PropertyID { get; set; }
        public string OfficeID { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? Receptions { get; set; }
        public string PropertyStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string PropertyType { get; set; }
    }
}