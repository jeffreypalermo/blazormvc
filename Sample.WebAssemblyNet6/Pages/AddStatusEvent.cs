using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;

namespace Sample.WebAssemblyNet6.Pages
{
    public class AddStatusEvent : IUiBusEvent
    {
        public Status Status { get; }

        public AddStatusEvent(Status status)
        {
            Status = status;
        }
    }
}
