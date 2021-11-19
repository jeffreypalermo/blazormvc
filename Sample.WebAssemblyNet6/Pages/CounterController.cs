using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;

namespace Sample.WebAssemblyNet6.Pages
{
    [Route("/counter")]
    public class CounterController : ControllerComponentBase<CounterView>
    {
        private int _currentCount = 0;

        private void IncrementCount()
        {
            _currentCount++;
            View.Model = _currentCount;
        }
        protected override void OnViewInitialized()
        {
            View.OnIncrement = IncrementCount;
            View.Model = _currentCount;
        }

        protected override void OnViewParametersSet()
        {

        }
    }
}
