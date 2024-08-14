using Palermo.BlazorMvc;
using Sample.WebAppNet8.Client.Models;

namespace Sample.WebAppNet8.Client.Shared
{
    public class ForecastDayController : ControllerComponentBase<ForecastDayView>, IListener<ApplicationHeartbeat>
    {
        public Func<WeatherForecast> ForecastDay { get; set; } = null!;

        protected override void OnViewParametersSet()
        {
            var viewForecastSummary = ForecastDay.Invoke().Summary;
            View.ForecastSummary = viewForecastSummary;
        }

        public void Handle(ApplicationHeartbeat theEvent)
        {
            View.TimeStamp = theEvent.Time.ToLongTimeString();
            StateHasChanged();
        }
    }
}
