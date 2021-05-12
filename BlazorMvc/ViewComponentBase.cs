using System;
using Microsoft.AspNetCore.Components;

namespace Palermo.BlazorMvc
{
    public abstract class ViewComponentBase : MvcComponentBase
    {
        [Parameter] 
        public Action<ViewComponentBase> InitializedAction { get; set; }
    
        [Parameter] 
        public Action ParametersSetAction { get; set; }
    
        [Parameter]
        public Action<bool> RenderedAction { get; set; }
        
        protected sealed override void OnParametersSet()
        {
            ParametersSetAction();
            base.OnParametersSet();
        }

        protected sealed override void OnInitialized()
        {
            InitializedAction(this);
            base.OnInitialized();
        }

        protected sealed override void OnAfterRender(bool firstRender)
        {
            RenderedAction(firstRender);
            base.OnAfterRender(firstRender);
        }
    }
}