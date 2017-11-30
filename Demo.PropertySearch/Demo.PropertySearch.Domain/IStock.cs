using System;
using System.Collections.Generic;

namespace Demo.PropertySearch.Domain
{
    public interface IStock
    {
        string PropertyID { get; }
        string OfficeID { get; }
        DateTime? PropertyCreateDate { get; }
        DateTime? PropertyModifyDate { get; }
        double? Latitude { get; }
        double? Longitude { get; }
        int? Bathrooms { get; }
        int? Bedrooms { get; }
        int? Receptions { get; }
        string PropertyStatus { get; }
        string AddressLine1 { get; }
        string AddressLine2 { get; }
        string Description { get; }
        string LongDescription { get; }
        double? Price { get; }
        string PropertyType { get; }
        string PropertyFeatures { get; set; }
        IEnumerable<IContentResource> ContentResources { get; set; }
    }
}