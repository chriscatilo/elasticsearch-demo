using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Demo.PropertySearch.Repository.Mock
{
    public class Repository
    {
        public static IEnumerable<XElement> Data { get; }

        static Repository()
        {
            var propertyFeedResourceName = "Demo.PropertySearch.Repository.Mock.PropertyFeed.xml";

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(propertyFeedResourceName);
            
            var tr = new XmlTextReader(stream);

            var xd = XElement.Load(tr);

            Data = xd.Elements("Property")
                .ToArray();
        }

        public IEnumerable<Stock> GetAll() => Data.Select(Stock.Create);


        public Stock GetByPropertyID(string id)
        {
            var value = Data
                .SingleOrDefault(el => el.IsDescendantElementEqualTo(nameof(Stock.PropertyID), id));

            return new Stock(value);
        }

        public IEnumerable<Stock> Search(SearchParams args)
        {
            var stocks = Data
                .Select(Stock.Create)
                .FilterByKeyword(args.Keyword)
                .FilterByValueRange(minValue: args.MinPrice, maxValue: args.MaxPrice);

            return stocks.ToArray();
        }
    }
}
