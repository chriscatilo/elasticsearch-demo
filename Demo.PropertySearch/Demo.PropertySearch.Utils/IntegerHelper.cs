using System.Collections.Generic;

namespace Demo.PropertySearch.Utils
{
    public static class IntegerHelper
    {
        public static int? ToNullableInt(this object value)
        {
            int @try;
            var @int = string.IsNullOrEmpty((string) value) || !int.TryParse(value.ToString(), out @try)
                ? default(int?)
                : @try;

            return @int;
        }

        public static IEnumerable<int> Integers(int from, int to)
        {
            for (; to >= from; from++)
            {
                yield return from;
            }
        }
    }
}
