using System;
using System.Collections.Generic;

namespace Demo.PropertySearch.Domain
{
    public interface IStock
    {
        string PropertyID { get; }
        string OfficeID { get; }
        DateTime? CreateDate { get; }
        DateTime? ModifyDate { get; }
        double? Latitude { get; }
        double? Longtitude { get; }
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