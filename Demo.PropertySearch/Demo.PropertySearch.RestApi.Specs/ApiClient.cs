using Demo.PropertySearch.RestApi.Specs.Helpers;
using Demo.PropertySearch.RestApi.Specs.Properties;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.PropertySearch.RestApi.Specs
{
    public class ApiClient
    {

        public GetResponse<T> Get<T>(Uri uri)
        {
            var task = Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var response = new GetResponse<T>
                    {
                        Message = await client.GetAsync(uri)
                    };

                    if (response.Message.IsSuccessStatusCode)
                    {
                        response.Content = await response.Message.Content.ReadAsAsync<T>();
                    }
                    else if (response.Message.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var msg = await response.Message.Content.ReadAsStringAsync();
                        throw new Exception(msg);
                    }

                    return response;
                }
            });

            return task.Result;
        }

        public class GetResponse<T>
        {
            public HttpResponseMessage Message { get; set; }

            public T Content { get; set; }
        }

        public GetResponse<T> Get<T>(string partialLocation)
        {
            var uri = new Uri($"{Settings.Default.OwinHostLocation}/{partialLocation}");

            return Get<T>(uri);
        }

        public GetResponse<T> Get<T>(string partialLocation, object args)
        {
            var queryString = args.ToQueryString();

            var uri = new Uri($"{Settings.Default.OwinHostLocation}/{partialLocation}{queryString}");

            return Get<T>(uri);
        }

        public HttpResponseMessage Post<T>(string partialLocation, T model)
        {
            var task = Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var uri = $"{Settings.Default.OwinHostLocation}/{partialLocation}";

                    var response = await client.PostAsJsonAsync(uri, model);

                    return response;
                }
            });

            return task.Result;
        }
    }
}
