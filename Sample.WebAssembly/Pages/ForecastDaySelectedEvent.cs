using Palermo.BlazorMvc;
using Sample.WebAssembly.Models;

namespace Sample.WebAssembly.Pages
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