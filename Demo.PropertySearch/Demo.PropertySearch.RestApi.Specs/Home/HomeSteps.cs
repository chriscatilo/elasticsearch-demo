using Demo.PropertySearch.RestApi.Models;
using Demo.PropertySearch.Specs.Utils;
using Demo.PropertySearch.Specs.Utils.Models;
using NUnit.Framework;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.RestApi.Specs
{
    [Binding]
    public class HomeSteps : TestRunSteps<IPropertySearchTestContext>
    {
        [When(@"I navigate to home")]
        [Given(@"I navigate to home")]
        public void WhenINavigateToHome()
        {
            var apiClient = new ApiClient();

            var response = apiClient.Get<HomeModel>(ApiRoute.Home.Route);

            TestContext.ApiResponse = response.Message;

            TestContext.RetrievedHomeModel = response.Content;

            Assert.That(TestContext.RetrievedHomeModel, Is.Not.Null);

            Assert.That(TestContext.ApiResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Then(@"I know the navigation address for stock")]
        [Given(@"I know the navigation address for stock")]
        public void ThenIKnowTheAddressOfStock()
        {
            Assert.That(TestContext.HasBeenSet(ctx => ctx.RetrievedHomeModel), Is.True);

            var stockLink = TestContext.RetrievedHomeModel.Links.SingleOrDefault(l => l.Rel == "stock");

            Assert.That(stockLink, Is.Not.Null);

            Assert.That(stockLink.Href, Is.Not.Null);
        }
    }
}
