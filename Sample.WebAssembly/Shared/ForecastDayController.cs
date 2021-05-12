using System;
using Palermo.BlazorMvc;
using Sample.WebAssembly.Pages;

namespace Sample.WebAssembly.Shared
{
    public class ForecastDayController : ControllerComponentBase<ForecastDayView>, IListener<ApplicationHeartbeat>
    {
        public Func<WeatherForecast> ForecastDay { get; set; }

        protected override void OnViewParametersSet()
        {
            var viewForecastSummary = ForecastDay.Invoke().Summary;
            View.ForecastSummary = viewForecastSummary + Guid.NewGuid();
        }

        public void Handle(ApplicationHeartbeat theEvent)
        {
            View.TimeStamp = theEvent.Time.ToLongTimeString();
            StateHasChanged();
        }
    }
}