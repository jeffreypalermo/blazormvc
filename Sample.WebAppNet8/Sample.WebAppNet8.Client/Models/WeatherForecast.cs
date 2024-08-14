namespace Sample.WebAppNet8.Client.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; } = null!;

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
