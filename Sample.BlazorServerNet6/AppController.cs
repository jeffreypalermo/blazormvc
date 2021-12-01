using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.BlazorServerNet6.Shared;
using Sample.BlazorServerNet6.Pages;

namespace Sample.BlazorServerNet6
{
    public class AppController : ControllerComponentBase<AppView>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            AppendRenderFragment<HeartbeatController>(builder);
            base.BuildRenderTree(builder);
           
        }
    }
}
