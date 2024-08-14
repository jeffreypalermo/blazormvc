using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet8.Models;

namespace Sample.WebAssemblyNet8.Pages
{
    [Route("/counter")]
    public class CounterController : ControllerComponentBase<CounterView>,
        IListener<ApplicationHeartbeat>
    {
        private int _currentCount = 0;

        protected override void OnViewInitialized()
        {
            View.OnIncrement = IncrementCount;
            View.Model = _currentCount;
        }

        private void IncrementCount()
        {
            _currentCount++;
            View.Model = _currentCount;
        }

        public void Handle(ApplicationHeartbeat theEvent)
        {
            View.Time = theEvent.Time.ToLongTimeString();
            StateHasChanged();
        }
    }
}
