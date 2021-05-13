using System;
using Palermo.BlazorMvc;

namespace Sample.WebAssemblyNet31.Models
{
    public class ApplicationHeartbeat : IUiBusEvent
    {
        public DateTime Time { get; }

        public ApplicationHeartbeat(DateTime time)
        {
            Time = time;
        }
    }
}