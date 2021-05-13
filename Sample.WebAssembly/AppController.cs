using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssembly.Pages;
using Sample.WebAssembly.Shared;

namespace Sample.WebAssembly
{
    public class AppController : ControllerComponentBase<AppView>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            AppendRenderFragment<HeartbeatController>(builder);
        }
    }
}