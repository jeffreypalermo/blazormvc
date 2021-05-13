using System;
using System.Threading;
using System.Threading.Tasks;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Models;

namespace Sample.WebAssemblyNet31.Shared
{
    public class HeartbeatController : MvcComponentBase
    {
        private Timer _timer;

        protected override Task OnInitializedAsync()
        {
            _timer = new Timer(_ =>
            {
                InvokeAsync(() =>
                {
                    Bus.Notify(new ApplicationHeartbeat(DateTime.Now));

                });
            }, null, 1000, 1000);

            return base.OnInitializedAsync();
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}