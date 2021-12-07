using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;

namespace Sample.WebAssemblyNet6.Shared;

public class RemoveComponentRequested : IUiBusEvent
{
    public ComponentBase Component { get; }
    public int Id { get; }

    public RemoveComponentRequested(ComponentBase component, int id)
    {
        Component = component;
        Id = id;
    }

}