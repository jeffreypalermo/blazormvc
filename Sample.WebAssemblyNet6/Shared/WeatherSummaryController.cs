using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;
using Sample.WebAssemblyNet6.Pages;

namespace Sample.WebAssemblyNet6.Shared
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
