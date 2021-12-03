using Palermo.BlazorMvc;
using Sample.BlazorServerNet6.Pages;

namespace Sample.BlazorServerNet6.Shared
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
