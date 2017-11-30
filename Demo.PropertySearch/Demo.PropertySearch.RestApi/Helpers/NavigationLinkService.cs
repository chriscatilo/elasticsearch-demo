using System.Web.Http;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public class NavigationLinkService
    {
        private readonly ApiController _controller;

        public NavigationLinkService(ApiController controller)
        {
            _controller = controller;
        }

        public NavigationLink CreateLink<TRoute>(string relationship)
        {
            var type = typeof(TRoute);

            var routeName = type.GetConstantLiterals()["Name"];

            var href = _controller.Url.Link(routeName, null);

            return CreateLink(relationship, href);
        }

        public NavigationLink CreateLink(string relationship, string href)
        {

            return NavigationLink.Create(relationship, href);
        }

        public NavigationLink CreateLink<TRoute>(string relationship, TRoute route)
        {
            var routeName = route.GetType().GetConstantLiterals()["Name"];
            
            var href = _controller.Url.Link(routeName, route);

            return CreateLink(relationship, href);
        }
    }
}