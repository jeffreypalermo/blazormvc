using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet6.Models;
using Sample.WebAssemblyNet6.Shared;


namespace Sample.WebAssemblyNet6.Pages
{
    [Route("/fetchdata")]
    public class FetchDataController : ControllerComponentBase<FetchDataView>
    {
        private WeatherForecast[] _forecasts;
        private WeatherForecast _selectedForecast;

        [Inject] public HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            View.Forecasts = _forecasts;
            View.ForecastDaySelected = ViewForecastDaySelected;
        }

        private void ViewForecastDaySelected(WeatherForecast forecast)
        {
            _selectedForecast = forecast;
            Bus.Notify(new ForecastDaySelectedEvent(forecast));
            View.ForecastDayPane = FragmentBuilder.GetRenderFragment<ForecastDayController>(
                controller => { controller.ForecastDay = () => _selectedForecast; });
        }
    }
}
