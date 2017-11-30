using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Demo.PropertySearch.RestApi;
using Microsoft.Owin;
using Owin;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ApplicationStartUp), "PreStartUp")]
[assembly: OwinStartup(typeof(ApplicationStartUp), "OwinStartup")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ApplicationStartUp), "PostStartUp")]

namespace Demo.PropertySearch.RestApi
{

    public class ApplicationStartUp
    {
//        public static WindsorContainer IocContainer { get; private set; }

        public static void PreStartUp()
        {
//            IocContainer = new WindsorContainer();
//
//            IocContainer.Install(Configuration.FromAppConfig());
        }

        public void OwinStartup(IAppBuilder owinApp)
        {
//            var castleDependencyResolver = new CastleDependencyResolver(IocContainer);

            var httpConfiguration = new HttpConfiguration
            {
//                DependencyResolver = castleDependencyResolver,
            };

            httpConfiguration.Services.Replace(typeof(IExceptionHandler), new Middleware.ExceptionHandler());

            httpConfiguration.Register();

            owinApp
//                .Use<ProvisionUserWithClaimsAndMembership>(IocContainer)
                .UseWebApi(httpConfiguration);
        }

        public static void PostStartUp()
        {
//            GlobalConfiguration.Configuration.DependencyResolver = new CastleDependencyResolver(IocContainer);
        }
    }
}