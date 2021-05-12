using System;
using Microsoft.AspNetCore.Components;

namespace Palermo.BlazorMvc
{
    public abstract class LayoutViewComponentBase : MvcLayoutComponentBase
    {
        [Parameter] 
        public Action<LayoutViewComponentBase> InitializedAction { get; set; }
    
        [Parameter] 
        public Action ParametersSetAction { get; set; }
    
        [Parameter]
        public Action<bool> RenderedAction { get; set; }
        
        protected override void OnParametersSet()
        {
            ParametersSetAction();
        }

        protected override void OnInitialized()
        {
            InitializedAction(this);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            RenderedAction(firstRender);
        }
    }
}