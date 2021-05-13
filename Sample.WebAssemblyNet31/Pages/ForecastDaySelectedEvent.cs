using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Models;

namespace Sample.WebAssemblyNet31.Pages
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