using BlazorDynamicForm.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDynamicForm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("GetWeather")]
        public async Task<WeatherForecast> GetWeather()
        {
            await Task.Delay(3000);

            return new WeatherForecast
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}
