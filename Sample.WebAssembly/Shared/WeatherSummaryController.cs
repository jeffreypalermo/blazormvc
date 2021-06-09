using Palermo.BlazorMvc;
using Sample.WebAssembly.Models;
using Sample.WebAssembly.Pages;

namespace Sample.WebAssembly.Shared
{
    public class WeatherSummaryController : ControllerComponentBase<WeatherSummaryView>, 
        IListener<ForecastDaySelectedEvent>, IListener<ApplicationHeartbeat>
    {
        protected override void OnViewInitialized()
        {
            View.WeatherSummary = "sunny";
        }

        public void Handle(ForecastDaySelectedEvent theEvent)
        {
            View.WeatherSummary = theEvent.Forecast.Summary;
            StateHasChanged();
        }

        public void Handle(ApplicationHeartbeat theEvent)
        {
            View.Time = theEvent.Time.ToLongTimeString();
            StateHasChanged();
        }
    }
}