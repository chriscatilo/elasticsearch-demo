using System.Collections.Generic;
using System.Linq;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.Repository.Mock
{
    internal static class SearchParamsHelper
    {
        public static IEnumerable<Stock> FilterByKeyword(this IEnumerable<Stock> data, string keyword)
        {
            if (keyword.IsNullOrEmpty())
                return data;

            var result = data
                .Where(s => s.AddressLine1.IsLike(keyword) || s.AddressLine2.IsLike(keyword));

            return result;
        }

        private static bool IsValueNullOrEqualToOrLessThanPrice(double? value, Stock stock)
            => value == null || (stock.Price ?? 999999999.00) >= value;

        private static bool IsValueNullOrEqualToOrGreaterThanPrice(double? value, Stock stock)
            => value == null || (stock.Price ?? 999999999.00) <= value;

        public static IEnumerable<Stock> FilterByValueRange(this IEnumerable<Stock> data, double? minValue, double? maxValue)
        {
            if (minValue == null && maxValue == null)
                return data;

            var result = data
                .Where(s => IsValueNullOrEqualToOrLessThanPrice(minValue, s))
                .Where(s => IsValueNullOrEqualToOrGreaterThanPrice(maxValue, s));
                
            return result;
        }


    }
}
