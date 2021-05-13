using System;
using Microsoft.AspNetCore.Components;

namespace Palermo.BlazorMvc
{
    public static class FragmentBuilder 
    {
        public static RenderFragment GetRenderFragment<TComponent>()
        {
            var fragment = (RenderFragment)(__builder =>
            {
                __builder.OpenComponent(0, typeof(TComponent));
                __builder.CloseComponent();
            });

            return fragment;
        }

        public static RenderFragment GetRenderFragment<TComponent>(Action<TComponent> OnInitializedAction) where TComponent : ControllerComponentBase
        {
            var fragment = (RenderFragment) (__builder =>
            {
                __builder.OpenComponent<TComponent>(0);
                __builder.AddAttribute(1, nameof(ControllerComponentBase.OnInitialize),
                    new Action<ControllerComponentBase>(controller => OnInitializedAction((TComponent) controller)));
                __builder.CloseComponent();
            });

            return fragment;
        }
    }
}