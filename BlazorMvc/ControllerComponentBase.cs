using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Palermo.BlazorMvc
{
    public abstract class ControllerComponentBase : MvcComponentBase
    {
        protected ViewComponentBase View { get; set; }

        [Parameter] public Action<ControllerComponentBase> OnInitialize { get; set; }

        protected abstract Type GetViewType();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var fragment = (RenderFragment) (__builder =>
            {
                __builder.OpenComponent(0, GetViewType());
                __builder.AddAttribute(1, nameof(ViewComponentBase.InitializedAction),
                    new Action<ViewComponentBase>(view => OnViewInitializedPrivate(view)));
                __builder.AddAttribute(2, nameof(ViewComponentBase.ParametersSetAction),
                    new Action(OnViewParametersSetPrivate));
                __builder.AddAttribute(3, nameof(ViewComponentBase.RenderedAction),
                    new Action<bool>(OnAfterViewRenderPrivate));
                __builder.CloseComponent();
            });
            builder.AddContent(0, fragment);
        }

        protected sealed override void OnInitialized()
        {
            if (OnInitialize != null) OnInitialize(this);
            base.OnInitialized();
        }

        private void OnViewInitializedPrivate(ViewComponentBase view)
        {
            View = view;
            OnViewInitialized();
        }

        protected virtual void OnViewInitialized()
        {
        }

        private void OnViewParametersSetPrivate()
        {
            OnViewParametersSet();
        }

        protected virtual void OnViewParametersSet()
        {
        }

        private void OnAfterViewRenderPrivate(bool firstRender)
        {
            OnAfterViewRender(firstRender);
        }

        protected virtual void OnAfterViewRender(bool firstRender)
        {
        }
    }

    public class ControllerComponentBase<TView> : ControllerComponentBase where TView : ViewComponentBase
    {
        protected new TView View => (TView) base.View;

        protected override Type GetViewType()
        {
            return typeof(TView);
        }
    }
}