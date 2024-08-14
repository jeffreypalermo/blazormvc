using Palermo.BlazorMvc;
using Sample.WebAppNet8.Client.Models;

namespace Sample.WebAppNet8.Client.Pages
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
