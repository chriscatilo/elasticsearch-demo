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
        public static IEnumerable<XElement> Stock { get; }

        static Repository()
        {
            var propertyFeedResourceName = "Demo.PropertySearch.Repository.Mock.PropertyFeed.xml";

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(propertyFeedResourceName);
            
            var tr = new XmlTextReader(stream);

            var xd = XElement.Load(tr);

            Stock = xd.Elements("Property")
                .ToArray();
        }

        public IEnumerable<Stock> GetAll() => Stock.Select(Mock.Stock.Create);


        private bool IsPropertyEqualToValue(string propertyName, string value, XElement e)
        {
            var result = e.Elements(propertyName).SingleOrDefault()?.Value
                .Equals(value, StringComparison.InvariantCultureIgnoreCase);

            return result ?? false;
        }

        public Stock GetByPropertyID(string id)
        {
            var value = Stock
                .SingleOrDefault(p => IsPropertyEqualToValue(nameof(Mock.Stock.PropertyID), id, p));

            return new Stock(value);
        }

        public IEnumerable<Stock> Search(SearchParams args)
        {
            throw new NotImplementedException();
        }
    }
}
