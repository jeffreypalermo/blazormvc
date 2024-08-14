using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.WebAppNet8.Client.Models;
using Sample.WebAppNet8.Client.Shared;


namespace Sample.WebAppNet8.Client.Pages
{
    [Route("/fetchdata")]
    public class FetchDataController : ControllerComponentBase<FetchDataView>
    {
        private WeatherForecast[] _forecasts = null!;
        private WeatherForecast _selectedForecast = null!;

        [Inject] public HttpClient Http { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            _forecasts = (await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json"))!;
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
