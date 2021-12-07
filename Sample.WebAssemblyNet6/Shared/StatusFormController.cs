using Microsoft.AspNetCore.Components.Rendering;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;
using Sample.WebAssemblyNet6.Pages;

namespace Sample.WebAssemblyNet6.Shared
{
    public class StatusFormController : ControllerComponentBase<StatusFormView>
    {
        private void UpdateStatus()
        {
            
            Bus.Notify(new Status(View.NewStatus));

        }

        private void AddStatus()
        {
           
            for (int i = 0; i < View.AddCount; i++)
            {
                Random rnd = new Random();
                Status newStatus = new Status(View.NewStatus + i, rnd.Next((10000000)));
                Bus.Notify(new AddStatusEvent(newStatus));
            }
           
           

        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            AppendRenderFragment<StatusController>(builder);
           
        }
        protected override void OnViewInitialized()
        {
            View.UpdateStatus = UpdateStatus;
            View.AddStatus = AddStatus;
            View.NewStatus = "This is the Current Status";
            View.AddCount = 1;
        }

        
    }
}
