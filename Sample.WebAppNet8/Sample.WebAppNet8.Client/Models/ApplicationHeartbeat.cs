using Palermo.BlazorMvc;

namespace Sample.WebAppNet8.Client.Models
{
    public class ApplicationHeartbeat
   : IUiBusEvent
    {
        public DateTime Time { get; }

        public ApplicationHeartbeat(DateTime time)
        {
            Time = time;
        }
    }
}
