using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAPIClient;
using BlazorAPIClient.DataServices;

namespace BlazorAPIClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("BlazorAPIClient has started...");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            builder.Services.AddHttpClient<ISpaceXDataService, GQLSpaceXDataService> // HTTP Factory
                (sp => sp.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

            await builder.Build().RunAsync();
        }
    }
}
