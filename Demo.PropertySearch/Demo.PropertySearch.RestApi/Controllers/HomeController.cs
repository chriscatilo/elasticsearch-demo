using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Demo.PropertySearch.RestApi.Helpers;
using Demo.PropertySearch.RestApi.Models;

namespace Demo.PropertySearch.RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        private readonly NavigationLinkService _linkLinkService;

        public HomeController()
        {
            _linkLinkService = new NavigationLinkServiceFactory().Create(this);
        }

        [Route(ApiRoute.Home.Route, Name = ApiRoute.Home.Name)]
        public dynamic Get()
        {
            var result = new HomeModel
            {
                Version = this.GetType().Assembly.GetName().Version.ToString(),
                Links = new[]
                    {
                        _linkLinkService.CreateLink<ApiRoute.StockSearch>("stock")
                    }
                    .Where(link => link != null)
                    .ToArray()
            };
            return Ok(result);
        }
    }
}
