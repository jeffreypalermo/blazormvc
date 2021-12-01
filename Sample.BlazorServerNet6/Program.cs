using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Sample.BlazorServerNet6.Data;
using Sample.BlazorServerNet6.Pages;
using Sample.BlazorServerNet6;
using Microsoft.Extensions.Logging.Abstractions;
using Palermo.BlazorMvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUiBus>(provider => new MvcBus(NullLogger<MvcBus>.Instance));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AppController>();
builder.Services.AddScoped<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
