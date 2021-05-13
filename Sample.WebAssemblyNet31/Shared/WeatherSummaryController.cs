using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Models;
using Sample.WebAssemblyNet31.Pages;

namespace Sample.WebAssemblyNet31.Shared
{
    public class WeatherSummaryController : ControllerComponentBase<WeatherSummaryView>, IListener<ForecastDaySelectedEvent>, IListener<ApplicationHeartbeat>
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