using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;

namespace Sample.WebAssemblyNet6.Pages
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
