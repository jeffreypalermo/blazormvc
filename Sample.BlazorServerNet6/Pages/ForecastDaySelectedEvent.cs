using Palermo.BlazorMvc;
using Sample.BlazorServerNet6.Models;

namespace Sample.BlazorServerNet6.Pages
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
