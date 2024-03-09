using BlazorDynamicComponents.Attributes.Panel;
using BlazorDynamicComponents.Patterns;

namespace BlazorDynamicForm.Shared
{
    public class WeatherForecast : IDynamicModel
    {
        public string Id { get; set; }

        [DynamicPanel("Date", ColumnIndex = 1)]
        public DateTime Date { get; set; }

        [DynamicPanel("Summary", ColumnIndex = 1)]
        public string Summary { get; set; }

        [DynamicPanel("Temp. C", ColumnIndex = 2)]
        public int TemperatureC { get; set; }

        [DynamicPanel("Temp. F", ColumnIndex = 2)]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public Dictionary<int, string> Columns { get; set; } = new()
        {
            { 1, "Info" },
            { 2, "Temp." }
        };
    }
}
