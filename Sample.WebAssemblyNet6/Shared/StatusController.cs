using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;

namespace Sample.WebAssemblyNet6.Shared
{
    public class StatusController: ControllerComponentBase<StatusView>
    {

        public Func<Status> GetStatus { get; set; }
        public int Id { get; set; }
        protected override void OnViewParametersSet()
        {
            if (GetStatus != null)
            {
                View.Status = GetStatus.Invoke().CurrentStatus;
                Id = GetStatus.Invoke().Id;
                View.CanDelete = true;
            }

        }

        public void DeleteMe()
        {
            Bus.Notify(new RemoveComponentRequested(this, Id));
        }

        protected override void OnViewInitialized()
        {
            View.DeleteMe = DeleteMe;
            View.Status = "This is the Current Status";
        }

    }
}
