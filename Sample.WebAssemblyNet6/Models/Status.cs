using Palermo.BlazorMvc;

namespace Sample.WebAssemblyNet6.Models
{
    public class Status
        : IUiBusEvent
    {
        public string CurrentStatus { get; }
        public int Id { get; }

        public Status(string currentStatus)
        {
            CurrentStatus = currentStatus;
        }

        public Status(string currentStatus, int id)
        {
            CurrentStatus = currentStatus;
            Id = id;
        }
    }
}