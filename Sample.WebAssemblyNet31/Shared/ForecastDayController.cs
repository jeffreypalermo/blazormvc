using System;
using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Models;
using Sample.WebAssemblyNet31.Pages;

namespace Sample.WebAssemblyNet31.Shared
{
    public class ForecastDayController : ControllerComponentBase<ForecastDayView>, IListener<ApplicationHeartbeat>
    {
        public Func<WeatherForecast> ForecastDay { get; set; }

        protected override void OnViewParametersSet()
        {
            var viewForecastSummary = ForecastDay.Invoke().Summary;
            View.ForecastSummary = viewForecastSummary + Guid.NewGuid();
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