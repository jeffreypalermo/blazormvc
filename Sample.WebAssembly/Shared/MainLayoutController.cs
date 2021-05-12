using System;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAssembly.Pages;
using Sample.WebAssembly.Shared;

namespace Sample.WebAssembly.Shared
{
    public class MainLayoutController : LayoutControllerComponentBase<MainLayoutView>
    {
        protected override void OnViewInitialized()
        {
            View.SidebarBottom = FragmentBuilder<WeatherSummaryController>.GetRenderFragment();
            View.SidebarCounter = FragmentBuilder<CounterController>.GetRenderFragment();
        }
    }
}