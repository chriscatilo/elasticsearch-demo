using NUnit.Framework;

namespace Demo.PropertySearch.Repository.Mock.Tests
{
    [TestFixture]
    class TestGetByPropertyID
    {
        private Stock _stockUnderTest;

        [SetUp]
        public void SetUp()
        {
            var repository = new Repository();

            _stockUnderTest = repository.GetByPropertyID("AUS0000005298");

            Assert.That(_stockUnderTest, Is.Not.Null);
        }

        [Test(Description = "Property should exist")]
        public void ShouldExist()
        {
            Assert.That(_stockUnderTest, Is.Not.Null);
        }
        
        [Test(Description = "Property ID should be correct")]
        public void PropertyIdIsCorrect()
        {
            Assert.That(_stockUnderTest.PropertyID, Is.EqualTo("AUS0000005298"));
        }
        
        [Test(Description = "Office ID should be correct")]
        public void OfficeIdIsCorrect()
        {
            Assert.That(_stockUnderTest.OfficeID, Is.EqualTo("NSWHO"));
        }
    }
}