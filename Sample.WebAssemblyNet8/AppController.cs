using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet8.Shared;

namespace Sample.WebAssemblyNet8
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
