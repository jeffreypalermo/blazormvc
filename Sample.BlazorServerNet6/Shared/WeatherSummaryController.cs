using Palermo.BlazorMvc;
using Sample.BlazorServerNet6.Models;
using Sample.BlazorServerNet6.Pages;
namespace Sample.BlazorServerNet6.Shared
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
