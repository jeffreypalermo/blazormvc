using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Palermo.BlazorMvc;
using Sample.BlazorServerNet6.Models;
using Sample.BlazorServerNet6.Shared;
using Sample.BlazorServerNet6.Data;

namespace Sample.BlazorServerNet6.Pages
{
    [Route("/fetchdata")]

    public class FetchDataController : ControllerComponentBase<FetchDataView>
    {
        private WeatherForecast[]? _forecasts;
        private WeatherForecast? _selectedForecast;

        [Inject] public WeatherForecastService? weatherForecastService { get; set; }

      

        protected override void OnViewInitialized()
        {
            _forecasts = weatherForecastService.GetForecastAsync(DateTime.Now).GetAwaiter().GetResult();
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
