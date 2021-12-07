using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sample.WebAssemblyNet6;
using Palermo.BlazorMvc;
using Microsoft.Extensions.Logging.Abstractions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IUiBus>(provider => new MvcBus(NullLogger<MvcBus>.Instance));
builder.RootComponents.Add<AppController>("#app");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
