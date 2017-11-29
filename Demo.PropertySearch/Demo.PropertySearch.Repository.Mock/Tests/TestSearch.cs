using NUnit.Framework;

namespace Demo.PropertySearch.Repository.Mock.Tests
{
    [TestFixture]
    class TestSearch
    {
        private Repository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Repository();

        }

        [Test]
        public void TestKeyword()
        {
            var args = new SearchParams();
        }
    }
}