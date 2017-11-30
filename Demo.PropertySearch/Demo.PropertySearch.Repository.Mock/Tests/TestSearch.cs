using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Demo.PropertySearch.Domain;
using NUnit.Framework;

namespace Demo.PropertySearch.Repository.Mock.Tests
{
    [TestFixture]
    class TestSearch
    {
        private MockStockRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockStockRepository();
        }

        [TestCase("Bate Bay Road", "AUS0000004306")]
        [TestCase("Barambah Avenue", "AUS0000011666")]
        public void FindSingleStockFromKeyword(string keyword, string propertyId)
        {
            var args = new SearchParams
            {
                Keyword = keyword
            };

            var results = _repository.Search(args).ToArray();

            Assert.That(results.Count(), Is.EqualTo(1));

            var stock = results?.SingleOrDefault();

            Assert.That(stock?.PropertyID, Is.EqualTo(propertyId));
        }
        
        [TestCase("Roseville", 12)]
        [TestCase("Killara", 20)]
        [TestCase("Road", 10)]
        public void FindStockFromKeyword(string keyword, int expectedCount)
        {
            var args = new SearchParams
            {
                Keyword = keyword
            };

            var results = _repository.Search(args).ToArray();

            Assert.That(results.Count(), Is.EqualTo(expectedCount));
        }

        [TestCase(null, null, 240)]
        [TestCase(0, Double.MaxValue, 240)]
        [TestCase(650000, 650000, 2)]
        [TestCase(null, 650000, 44)]
        public void FindStockFromPriceRange(double? min, double? max, int expectedCount)
        {
            var args = new SearchParams
            {
                MinPrice = min, MaxPrice = max
            };

            var results = _repository.Search(args).ToArray();

            Assert.That(results.Count(), Is.EqualTo(expectedCount));
        }
    }
}