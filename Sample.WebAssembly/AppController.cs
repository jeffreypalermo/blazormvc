using System;
using System.Threading;
using System.Threading.Tasks;
using Palermo.BlazorMvc;

namespace Sample.WebAssembly
{
    public class AppController : ControllerComponentBase<App>
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