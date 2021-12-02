using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;

namespace Sample.WebAssemblyNet6
{
    public class AppController : ControllerComponentBase<AppView>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            //AppendRenderFragment<HeartbeatController>(builder);
        }
    }
}
