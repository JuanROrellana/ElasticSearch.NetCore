using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AzurePipelineDotnetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;

        public WeatherForecastController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rng = new Random();

                if (rng.Next(0, 5) < 2)
                    throw new Exception("Ops what happened?");

                return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "New Request Entering {CustomProperty}", 50);
                return new StatusCodeResult(500); ;
            }

        }
    }
}
