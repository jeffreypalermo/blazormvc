using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAssemblyNet31.Models;
using Sample.WebAssemblyNet31.Shared;

namespace Sample.WebAssemblyNet31.Pages
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