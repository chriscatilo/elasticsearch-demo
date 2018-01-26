using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Demo.PropertySearch.Domain;
namespace Demo.PropertySearch.Repository.Mock
{
    public class MockStockRepository : IStockRepository
    {
        public static IEnumerable<XElement> Data { get; }

        static MockStockRepository()
        {
            var propertyFeedResourceName = "Demo.PropertySearch.Repository.Mock.PropertyFeed2.xml";

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(propertyFeedResourceName);
            
            var tr = new XmlTextReader(stream);

            var xd = XElement.Load(tr);

            Data = xd.Elements("Property")
                .ToArray();
        }

        public IEnumerable<IStock> GetAll() => Data.Select(Stock.Create);


        public IStock GetByPropertyID(string id)
        {
            var value = Data
                .SingleOrDefault(el => el.IsDescendantElementEqualTo(nameof(Stock.PropertyID), id));

            return value == null ? null : new Stock(value);
        }

        public IEnumerable<IStock> Search(SearchParams args)
        {
            var stocks = Data
                .Select(Stock.Create)
                .FilterByKeyword(args.Keyword)
                .FilterByValueRange(minValue: args.MinPrice, maxValue: args.MaxPrice);

            return stocks.ToArray();
        }
    }
}
