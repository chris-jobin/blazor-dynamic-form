using BlazorDynamicComponents.Attributes.Panel;

namespace BlazorDynamicForm.Shared
{
    public class WeatherForecast
    {
        [DynamicPanel("Date")]
        public DateTime Date { get; set; }

        [DynamicPanel("Temp. C")]
        public int TemperatureC { get; set; }

        [DynamicPanel("Temp. F")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [DynamicPanel("Summary")]
        public string Summary { get; set; }
    }
}
