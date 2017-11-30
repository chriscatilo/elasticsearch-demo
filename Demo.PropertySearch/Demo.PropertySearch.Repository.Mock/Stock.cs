using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Demo.PropertySearch.Domain;

namespace Demo.PropertySearch.Repository.Mock
{
    public class Stock : IStock
    {
        private readonly XElement _e;

        public Stock(XElement e)
        {
            _e = e;
        }

        public static Stock Create(XElement e) => new Stock(e);

        public string PropertyID => _e.GetSingleStringValue(nameof(PropertyID));

        public string OfficeID => _e.GetSingleStringValue(nameof(OfficeID));

        public DateTime? CreateDate => _e.GetSingleDateTimeValue(nameof(CreateDate));

        public DateTime? ModifyDate => _e.GetSingleDateTimeValue(nameof(ModifyDate));

        public double? Latitude => _e.GetSingleDoubleValue(nameof(Latitude));

        public double? Longtitude => _e.GetSingleDoubleValue(nameof(Longtitude));

        public int? Bathrooms => _e.GetSingleIntValue(nameof(Bathrooms));

        public int? Bedrooms => _e.GetSingleIntValue(nameof(Bedrooms));

        public int? Receptions => _e.GetSingleIntValue(nameof(Receptions));

        public string PropertyStatus => _e.GetSingleStringValue(nameof(PropertyStatus));

        public string AddressLine1 => _e.GetSingleStringValue(nameof(AddressLine1));

        public string AddressLine2 => _e.GetSingleStringValue(nameof(AddressLine2));

        public string Description => _e.GetSingleStringValue(nameof(Description));

        public string LongDescription => _e.GetSingleStringValue(nameof(LongDescription));

        public double? Price => _e.GetSingleDoubleValue(nameof(Price));

        public string PropertyType => _e.GetSingleStringValue(nameof(PropertyType));

        public string PropertyFeatures { get; set; }

        public IEnumerable<IContentResource> ContentResources { get; set; }       
    }
}