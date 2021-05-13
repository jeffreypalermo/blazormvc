using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Pages;

namespace Sample.WebAssemblyNet31.Shared
{
    public class MainLayoutController : LayoutControllerComponentBase<MainLayoutView>
    {
        protected override void OnViewInitialized()
        {
            View.SidebarBottom = FragmentBuilder.GetRenderFragment<WeatherSummaryController>();
            View.SidebarCounter = FragmentBuilder.GetRenderFragment<CounterController>();
        }
    }
}