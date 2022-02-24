# Blazor MVC 
### _Add C# MVC capability to any Blazor application_ 
Blazor MVC is a C# Project that enables the ability to use the MVC framework with Blazor applications. Developers that have experience with this framework in the past can have familiar structure and quickly move into Blazor.  
## Features 

- Compatibility with .NET 3, .NET 5, and .NET 6 
- Compatibility with both Blazor Server applications and Blazor WebAssembly
- Example projects on how to implement Blazor MVC 
- Create Controllers and Models for each of your views by extending prebuilt classes 

## Installation 

This section can be used for either Blazor web server or WebAssembly applications. After this section navigate to your desired project type and see the different implementations. 

> Note: You can find working examples of one for each .NET version and for each type of Blazor project (**Blazor Server** or **Blazor WebAssembly**) 

- The first step to add BlazorMVC to your project is to download the BlazorMvc project from (https://github.com/jeffreypalermo/blazormvc). 

- Next, create a **New Project** or open an **Existing Project** using the Blazor framework 

- Navigate to the root folder of the desired solution within File Explorer and copy the project folder **BlazorMvc** from the downloaded project 

> Note: You can add a new project within the downloaded solution of BlazorMvc. 

- Next, open the project in Visual Studio 

- Right click on the solution, hover over Add, and select Existing Project.... 

    - Navigate to the folder of your current project and select the .csproj file of the BlazorMvc project that you copied over 

- Once BlazorMvc has been added to the solution, next add the project as a build dependencies within your desired project. 

    - Right click on the blazor project, hover over Build Dependencies, and select Project Dependencies 

        - Select BlazorMvc and click Ok 

- Then you need to edit the project file by double clicking your project in Visual Studios.  

- Within the newly opened .csproj copy and paste the below code within the **<Project>** tag. 

```  
<!--Add Reference to the BlavorMvc Project within the Solution--> 
    <ItemGroup> 
        <ProjectReference Include="..\BlazorMvc\BlazorMvc.csproj" /> 
    </ItemGroup>  
``` 
Above are the steps that are required to get started using BlazorMvc within your Blazor application. Below are the corresponding steps that are needed for both different types of applications to get them to run. 

> Note: To use BlazorMvc in components you need to make sure you `using Palermo.BlazorMvc;` 

### Blazor WebAssembly Application 
For the Blazor WebAssembly application you need to edit a couple files in order to allow the BlazorMvc library to be properly implemented 

- `Program.cs` 

``` 
using Microsoft.Extensions.Logging.Abstractions; 
using Palermo.BlazorMvc; 
  
var builder = WebAssemblyHostBuilder.CreateDefault(args); 
builder.Services.AddScoped<IUiBus>(provider => new MvcBus(NullLogger<MvcBus>.Instance)); 

// AppController is the class that we are creating next. You can use any naming convention. You will need to add the using statement to gain access to this class within this file 
builder.RootComponents.Add<AppController>("#app"); 
``` 

- `AppController.cs` - Create a new class  

``` 
using Microsoft.AspNetCore.Components.Rendering; 
using Palermo.BlazorMvc; 

// Change namespace to match yours 
namespace Sample.WebAssemblyNet6 
{ 
    // AppView is the default app view. If you created a new Blazor application this class will be named App. We renamed it to AppView 
    public class AppController : ControllerComponentBase<AppView> 
    { 
        protected override void BuildRenderTree(RenderTreeBuilder builder) 
        { 
            base.BuildRenderTree(builder); 
        } 
    } 
} 
``` 

- `AppView.razor`- This is the App.razor file that was renamed 

``` 
@inherits Palermo.BlazorMvc.ViewComponentBase 

<Router AppAssembly="@typeof(Program).Assembly"> 
    <Found Context="routeData"> 
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayoutController)"> 
        </RouteView> 
    </Found> 
    <NotFound> 
        <LayoutView Layout="@typeof(MainLayoutController)"> 
            <p>Sorry, there's nothing at this address.</p> 
        </LayoutView> 
    </NotFound> 
</Router> 
``` 

### Blazor Server Aplication 

- `Program.cs` 

``` 
using Microsoft.Extensions.Logging.Abstractions; 
using Palermo.BlazorMvc; 

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddScoped<IUiBus>(provider => new MvcBus(NullLogger<MvcBus>.Instance)); 

// Add services to the container. 
builder.Services.AddRazorPages(); 
builder.Services.AddServerSideBlazor(); 
builder.Services.AddScoped<AppController>(); 
builder.Services.AddScoped<WeatherForecastService>(); 
``` 
- `AppController.cs` - Create a new class  

``` 
using Microsoft.AspNetCore.Components.Rendering; 
using Palermo.BlazorMvc; 

// Change namespace to match yours 
namespace Sample.BlazorServerNet6 
{ 
    // AppView is the default app view. If you created a new Blazor application this class will be named App. We renamed it to AppView 
    public class AppController : ControllerComponentBase<AppView> 
    { 
        protected override void BuildRenderTree(RenderTreeBuilder builder) 
        { 
            base.BuildRenderTree(builder); 
        } 
    } 
} 
``` 

- `AppView.razor`- This is the App.razor file that was renamed 

``` 
@inherits Palermo.BlazorMvc.ViewComponentBase 

<Router AppAssembly="@typeof(Program).Assembly"> 
    <Found Context="routeData"> 
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayoutController)"> 
        </RouteView> 
    </Found> 
    <NotFound> 
        <LayoutView Layout="@typeof(MainLayoutController)"> 
            <p>Sorry, there's nothing at this address.</p> 
        </LayoutView> 
    </NotFound> 
</Router> 
``` 

- `_Host.cshtml` 

``` 
<component type="typeof(AppController)" render-mode="ServerPrerendered" /> 
``` 
