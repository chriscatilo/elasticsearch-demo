using Demo.PropertySearch.RestApi.Models;
using Demo.PropertySearch.Specs.Utils;
using Demo.PropertySearch.Specs.Utils.Models;
using Demo.PropertySearch.Utils;
using NUnit.Framework;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.RestApi.Specs
{
    [Binding]
    public class StockSteps : TestRunSteps<IPropertySearchTestContext>
    {
        [When(@"I get all stock (successfully|unsuccessfully)")]
        public void WhenIGetAllStockSuccessfully(SuccessAdverbs successAdverb)
        {
            var apiClient = new ApiClient();

            var response = apiClient.Get<QueryResults<ViewModel<StockModel>>>(ApiRoute.StockSearch.Route);

            TestContext.ApiResponse = response.Message;

            if (successAdverb == SuccessAdverbs.Unsuccessfully)
            {
                return;
            }

            Assert.That(TestContext.ApiResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            TestContext.RetrievedStockSearch = response.Content;

            Assert.That(TestContext.RetrievedStockSearch, Is.Not.Null);
        }
        
        [Then(@"I get (.*) properties")]
        public void ThenIGetProperties(int expectedCount)
        {
            Assert.That(TestContext.HasBeenSet(ctx => ctx.RetrievedStockSearch), Is.True);

            var stock = TestContext.RetrievedStockSearch;

            Assert.That(stock.ResultCount, Is.EqualTo(expectedCount));

            Assert.That(stock.Result, Is.Not.Null);

            Assert.That(stock.Result.Count(), Is.EqualTo(expectedCount));
        }

        [When(@"I get stock with Id (.*) (successfully|unsuccessfully)")]
        public void WhenIGetStockWithId(string propertyId, SuccessAdverbs successAdverb)
        {
            var apiClient = new ApiClient();

            var url = ApiRoute.StockById.Route.Replace("{id}", propertyId);

            var response = apiClient.Get<ViewModel<StockModel>>(url);

            TestContext.ApiResponse = response.Message;

            if (successAdverb == SuccessAdverbs.Unsuccessfully)
            {
                return;
            }

            Assert.That(TestContext.ApiResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            TestContext.RetrievedStockById = response.Content;

            Assert.That(TestContext.RetrievedStockById, Is.Not.Null);
        }

        [Then(@"stock should have the following attributes")]
        public void ThenStockShouldHaveTheFollowingAttributes(Table table)
        {
            var actualModel = TestContext.RetrievedStockById.Body;

            var expectedModel = table.To<StockModel>();

            var properties = actualModel.GetType().GetPropertiesOf().ToDictionary(p => p.Name);

            foreach (var row in table.Rows)
            {
                var propertyName = row[0];

                var property = properties[propertyName];

                var actualValue = property.GetValue(actualModel);

                var expectedValue = property.GetValue(expectedModel);

                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
        }
    }
}
