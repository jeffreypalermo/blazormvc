using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;

namespace Palermo.BlazorMvc
{
    public abstract class MvcComponentBase : ComponentBase, IDisposable, IListener
    {
        [Inject] protected ILogger<MvcComponentBase> Logger { get; set; }

        [Inject] protected IUiBus Bus { get; set; }

        public virtual void Dispose()
        {
            Bus.UnRegister(this);
        }

        protected void Log(object message)
        {
            Logger.Log(LogLevel.Information, message.ToString());
        }

        protected override Task OnInitializedAsync()
        {
            Logger.LogDebug($"{ToString()} OnInitializedAsync");
            return base.OnInitializedAsync();
        }

        protected override void OnInitialized()
        {
            Bus.Register(this);
            base.OnInitialized();
            Logger.LogDebug($"{ToString()} OnInitialized");
        }

        protected override Task OnParametersSetAsync()
        {
            Logger.LogDebug($"{ToString()} OnParametersSetAsync");
            return base.OnParametersSetAsync();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Logger.LogDebug($"{ToString()} OnParametersSet");
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            Logger.LogDebug($"{ToString()} OnAfterRenderAsync(firstRender:{firstRender})");
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            Logger.LogDebug($"{ToString()} OnAfterRender(firstRender:{firstRender})");
        }

        public RenderFragment GetRenderFragment<TComponent>()
        {
            return FragmentBuilder.GetRenderFragment<TComponent>();
        }

        public void AppendRenderFragment<TComponent>(RenderTreeBuilder builder)
        {
            GetRenderFragment<TComponent>()(builder);
        }

        public RenderFragment GetRenderFragment<TComponent>(Action<TComponent> OnInitializedAction) where TComponent : ControllerComponentBase
        {
            return FragmentBuilder.GetRenderFragment<TComponent>(OnInitializedAction);
        }
    }
}