using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //var chatRoom1 = new ChatRoom()
            //{
            //    Id = 1,
            //    Theme = "Light",
            //    Accounts = new List<Account>
            //    {
            //        new Account { Id = 1, Avatar = "avatar1.png", Email = "abc@gmail.com", Password = "password1", Phone = "01298371232", RoleId = 1, UpdatedAt = DateTime.Now, VerifyToken = "asdasdw33r2" },
            //        new Account { Id = 2, Avatar = "avatar2.png", Email = "xyz@gmail.com", Password = "password2", Phone = "01298371232", RoleId = 1, UpdatedAt = DateTime.Now, VerifyToken = "asdasdasdas" }
            //    }
            //};


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
