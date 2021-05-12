using System;
using Microsoft.AspNetCore.Components;

namespace Palermo.BlazorMvc
{
    public static class FragmentBuilder<TComponent> where TComponent : ControllerComponentBase
    {
        public static RenderFragment GetRenderFragment()
        {
            var fragment = (RenderFragment) (__builder =>
            {
                __builder.OpenComponent(0, typeof(TComponent));
                __builder.CloseComponent();
            });

            return fragment;
        }

        public static RenderFragment GetRenderFragment(Action<TComponent> OnInitializedAction)
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