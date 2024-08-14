using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAppNet8.Client.Shared;

namespace Sample.WebAppNet8.Client
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
