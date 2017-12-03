// ReSharper disable ClassNeverInstantiated.Local

using Demo.PropertySearch.RestApi.Specs.Properties;
using Microsoft.Owin.Hosting;
using System;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.RestApi.Specs
{
    // http://www.asp.net/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana

    [Binding]
    public static class StartUp
    {
        private static IDisposable _apiApp;

        [BeforeTestRun]
        public static void OnStartUp()
        {
            _apiApp = WebApp.Start(Settings.Default.OwinHostLocation, builder =>
            {
                ApplicationStartUp.PreStartUp();

                new ApplicationStartUp().OwinStartup(builder);
            });
        }

        [AfterTestRun]
        public static void OnEnding()
        {
            _apiApp.Dispose();
        }
    }
}
