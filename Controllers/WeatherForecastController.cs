using Microsoft.AspNetCore.Mvc;

namespace DeploymentExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }


        [HttpGet(Name = "KeyValuesAzure")]
        public object GetKeyValues()
        {
            var value = _config.GetSection("MyConfiguration").Value;
            var nestedValue = _config.GetSection("NestedConfiguration:NestedKey");

            return new { value, nestedValue };
        }
    }
}