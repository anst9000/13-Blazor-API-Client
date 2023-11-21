using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorAPIClient;
using BlazorAPIClient.DataServices;

namespace BlazorAPIClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["rest_api_base_url"])
                // BaseAddress = new Uri(builder.Configuration["graphql_base_url"])
            });

            builder.Services.AddHttpClient<IJsonPlaceholderDataService, GraphQlJsonPlaceholderDataService>
                // (jsonplaceholderds => jsonplaceholderds.BaseAddress = new Uri(builder.Configuration["rest_api_base_url"]));
                (jsonplaceholderds => jsonplaceholderds.BaseAddress = new Uri(builder.Configuration["graphql_base_url"]));

            await builder.Build().RunAsync();
        }
    }
}
