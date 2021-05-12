using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Palermo.BlazorMvc
{
    public abstract class MvcLayoutComponentBase : LayoutComponentBase, IDisposable, IListener
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
    }
}