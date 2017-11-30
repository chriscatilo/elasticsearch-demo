using System.Linq;
using System.Web.Http;
using Demo.PropertySearch.Domain;
using Demo.PropertySearch.Repository.Mock;
using Demo.PropertySearch.RestApi.Helpers;
using Demo.PropertySearch.RestApi.Models;

namespace Demo.PropertySearch.RestApi.Controllers
{
    public class StockController : ApiController
    {
        private readonly NavigationLinkService _navLinkService;
        private readonly IStockRepository _stockRepository;
        
        public StockController()
        {
            _stockRepository = new StockRepository();
            _navLinkService = new NavigationLinkServiceFactory().Create(this);
        }

        [Route(ApiRoute.Stock.Route, Name = ApiRoute.Stock.Name)]
        public dynamic Get()
        {
            var vm = _stockRepository
                .GetAll()
                .Select(CreateStockListingViewModel)
                .CreateViewModel()
                .AddLinks(_navLinkService.CreateLink("self", Request.RequestUri.AbsoluteUri)); ;

            return Ok(vm);
        }

        [Route(ApiRoute.StockById.Route, Name = ApiRoute.StockById.Name)]
        public dynamic GetById(int id)
        {
            return Ok();
        }

        private ViewModel<IStock> CreateStockListingViewModel(IStock body)
        {
            var vm = new ViewModel<IStock>(body)
                .AddLinks
                (
                    _navLinkService.CreateLink("self", new ApiRoute.StockById
                    {
                        Id = body.PropertyID
                    })
                );

            return vm;
        }

    }

}
