using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Palermo.BlazorMvc;

namespace Sample.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddSingleton<IUiBus>(provider => provider.GetService<MvcBus>());
            builder.Services.AddScoped<IUiBus>(provider => new MvcBus(NullLogger<MvcBus>.Instance));

            builder.RootComponents.Add<AppController>("#app");
            await builder.Build().RunAsync();
        }
    }
}