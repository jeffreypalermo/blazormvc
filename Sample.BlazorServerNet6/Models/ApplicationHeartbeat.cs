using Palermo.BlazorMvc;
namespace Sample.BlazorServerNet6.Models
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
