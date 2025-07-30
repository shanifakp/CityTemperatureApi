using Microsoft.AspNetCore.Mvc;
using CityTemperatureApi.Services;

namespace CityTemperatureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ICityTemperatureService _temperatureService;

        public TemperatureController(ICityTemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public IActionResult GetTemperature([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City is required");

            var temperature = _temperatureService.GetTemperature(city);
            return Ok(new { City = city, Temperature = temperature, Unit = "°C" });
        }
    }
}
