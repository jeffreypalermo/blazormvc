using Palermo.BlazorMvc;
using Sample.WebAssemblyNet8.Models;

namespace Sample.WebAssemblyNet8.Pages
{
    public class ForecastDaySelectedEvent : IUiBusEvent
    {
        public WeatherForecast Forecast { get; }

        public ForecastDaySelectedEvent(WeatherForecast forecast)
        {
            Forecast = forecast;
        }
    }
}
