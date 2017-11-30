using System;
using Demo.PropertySearch.Domain;
using NUnit.Framework;

namespace Demo.PropertySearch.Repository.Mock.Tests
{
    [TestFixture]
    class TestGetByPropertyID
    {
        private IStock _stockUnderTest;

        [SetUp]
        public void SetUp()
        {
            var repository = new MockStockRepository();

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

        [Test(Description = "Price should be correct")]
        public void PriceIsCorrect()
        {
            Assert.That(_stockUnderTest.Price, Is.EqualTo(2500000));
        }

        [Test(Description = "Create Date should be correct")]
        public void CreateDateIsCorrect()
        {
            var expected = DateTime.Parse("2015-12-29T17:00:03.660");
            Assert.That(_stockUnderTest.PropertyCreateDate, Is.EqualTo(expected));
        }

        [Test(Description = "Bathrooms should be correct")]
        public void BathroomsIsCorrect()
        {
            Assert.That(_stockUnderTest.Bathrooms, Is.EqualTo(3));
        }
    }
}