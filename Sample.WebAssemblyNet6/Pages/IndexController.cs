
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;
using Sample.WebAssemblyNet6.Pages;
using Sample.WebAssemblyNet6.Shared;

namespace Sample.WebAssemblyNet6.Pages
{
    [Route("/")]
    public class IndexController : ControllerComponentBase<Index>, IListener<AddStatusEvent>, IListener<RemoveComponentRequested>
    {

        private Status newStatus;
     

        public void Handle(AddStatusEvent theEvent)
        {
            newStatus = theEvent.Status;
          
            int newid = newStatus.Id;

            View.Statuses.Add(newid, FragmentBuilder.GetRenderFragment<StatusController>(
                controller => { controller.GetStatus = () => newStatus; }));
            StateHasChanged();
        }

        public void Handle(RemoveComponentRequested theEvent)
        {
            foreach (var (key,value) in View.Statuses)
            {
                if (key == theEvent.Id)
                {
                    View.Statuses.Remove(key);
                    StateHasChanged();
                    return;
                }
            }

            if (View.Statuses.Count > 0)
            {
                View.Statuses.Remove(View.Statuses.Keys.First());
                StateHasChanged();
            }
               
        }
    }
}
