using BlazorDynamicComponents.Attributes.Panel;
using BlazorDynamicComponents.Attributes.Validation;
using BlazorDynamicComponents.Patterns;

namespace BlazorDynamicForm.Shared
{
    public class WeatherForecast : IDynamicModel
    {
        public string Id { get; set; }

        [DynamicPanel("Date", ColumnIndex = 1)]
        [DynamicForm(InputType.Date)]
        public DateTime Date { get; set; }

        [DynamicPanel("Summary", ColumnIndex = 1)]
        [DynamicForm(InputType.TextArea)]
        [DynamicRequired(ErrorMessage = "Summary is required.")]
        public string Summary { get; set; }

        [DynamicPanel("Temp. C", ColumnIndex = 2)]
        [DynamicForm(InputType.Number)]
        public int TemperatureC { get; set; }

        [DynamicPanel("Temp. F", ColumnIndex = 2)]
        [DynamicForm(InputType.Number, Readonly = true)]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public Dictionary<int, string> Columns { get; set; } = new()
        {
            { 1, "Info" },
            { 2, "Temp." }
        };
    }
}
