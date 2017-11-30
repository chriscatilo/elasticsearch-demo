using System.Web.Http;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public class NavigationLinkServiceFactory
    {
        public NavigationLinkService Create(ApiController controller)
        {
            return new NavigationLinkService(controller);
        }
    }
}