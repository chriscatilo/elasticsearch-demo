using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using Demo.PropertySearch.RestApi.Models;

namespace Demo.PropertySearch.RestApi.Controllers
{
    public class StockController : ApiController
    {
        [Route(ApiRoute.Stock.Route, Name = ApiRoute.Stock.Name)]
        public dynamic Get()
        {
            return null;
        }
    }
}
