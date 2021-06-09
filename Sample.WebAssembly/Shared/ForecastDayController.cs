using System;
using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssembly.Models;
using Sample.WebAssembly.Pages;

namespace Sample.WebAssembly.Shared
{
    public class ForecastDayController : ControllerComponentBase<ForecastDayView>, IListener<ApplicationHeartbeat>
    {
        public Func<WeatherForecast> ForecastDay { get; set; }

        protected override void OnViewParametersSet()
        {
            var viewForecastSummary = ForecastDay.Invoke().Summary;
            View.ForecastSummary = viewForecastSummary + " - this guid changes on render: " + Guid.NewGuid();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            AppendRenderFragment<CounterController>(builder);
            AppendRenderFragment<CounterController>(builder);
            AppendRenderFragment<CounterController>(builder);
        }

        public void Handle(ApplicationHeartbeat theEvent)
        {
            View.TimeStamp = theEvent.Time.ToLongTimeString();
            StateHasChanged();
        }
    }
}