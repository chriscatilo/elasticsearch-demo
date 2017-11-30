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
            _stockRepository = new MockStockRepository();
            _navLinkService = new NavigationLinkServiceFactory().Create(this);
        }
        
        [Route(ApiRoute.StockSearch.Route)]
        public dynamic Get([FromUri]StockSearchParams args)
        {
            var vm = _stockRepository
                .Search(args)
                .Select(CreateStockListingViewModel)
                .CreateViewModel()
                .AddLinks(_navLinkService.CreateLink("self", Request.RequestUri.AbsoluteUri));

            return Ok(vm);
        }

        [Route(ApiRoute.StockById.Route, Name = ApiRoute.StockById.Name)]
        public dynamic GetById(string id)
        {
            var vm = _stockRepository
                .GetByPropertyID(id)
                .CreateBodyViewModel()
                .AddLinks(_navLinkService.CreateLink("self", Request.RequestUri.AbsoluteUri));

            return Ok(vm);
        }

        private ViewModel<IStock> CreateStockListingViewModel(IStock body)
        {
            var vm = body
                .CreateBodyViewModel()
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
