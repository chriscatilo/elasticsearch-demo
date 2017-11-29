using System.Linq;
using NUnit.Framework;

namespace Demo.PropertySearch.Repository.Mock.Tests
{
    [TestFixture]
    class TestAllStock
    {
        private Repository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Repository();
        }

        [Test(Description = "Test get all stock")]
        public void TestGetAll()
        {
            var stock = _repository.GetAll();

            Assert.That(stock.Count(), Is.EqualTo(240));
        }

        [Test(Description = "All properties in stock objects do not throw error")]
        public void TestAllObjectProperties()
        {
            var stock = _repository.GetAll();

            var objProperties = typeof(Stock).GetProperties();

            foreach (var s in stock)
            {
                foreach (var op in objProperties)
                {
                    Assert.DoesNotThrow(() => op.GetMethod.Invoke(s, null));
                }
            }
        }
    }
}
