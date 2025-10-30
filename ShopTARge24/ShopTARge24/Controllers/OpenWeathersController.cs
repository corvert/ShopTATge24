using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.OpenWeatherDtos;
using Shop.Core.ServiceInterface;
using ShopTARge24.Models.OpenWeather;

namespace ShopTARge24.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeathersController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchOpenWeatherCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("OpenWeatherCity", "OpenWeathers", new { cityName = model.CityName });
            }
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> OpenWeatherCity(string cityName)
        {
            OpenWeatherResultDto dto = new();
            dto.name = cityName;

            var result = await _openWeatherServices.OpenWeatherResult(dto);

            OpenWeatherViewModel vm = new();

            // Initialize nested objects before assigning properties
            vm.coord = new ShopTARge24.Models.OpenWeather.Coord();
            vm.main = new Models.OpenWeather.Main();
            vm.wind = new Models.OpenWeather.Wind();
            vm.clouds = new Models.OpenWeather.Clouds();
            vm.sys = new Models.OpenWeather.Sys();
            vm.weather = new List<Models.OpenWeather.Weather>();

            // Map coordinates
            vm.coord.lon = result.coord.lon;
            vm.coord.lat = result.coord.lat;

            // Map weather list
            if (result.weather != null && result.weather.Any())
            {
                vm.weather = result.weather.Select(w => new Models.OpenWeather.Weather
                {
                    id = w.id,
                    main = w.main,
                    description = w.description,
                    icon = w.icon
                }).ToList();
            }

            // Map other properties
            vm.@base = result.@base;

            // Map main properties
            vm.main.temp = result.main.temp;
            vm.main.feels_like = result.main.feels_like;
            vm.main.humidity = result.main.humidity;
            vm.main.pressure = result.main.pressure;
            vm.main.temp_min = result.main.temp_min;
            vm.main.temp_max = result.main.temp_max;

            vm.visibility = result.visibility;

            // Map wind properties
            vm.wind.speed = result.wind.speed;
            vm.wind.deg = result.wind.deg;

            // Map clouds
            vm.clouds.all = result.clouds.all;

            vm.dt = result.dt;

            // Map sys properties
            vm.sys.type = result.sys.type;
            vm.sys.id = result.sys.id;
            vm.sys.country = result.sys.country;
            vm.sys.sunrise = result.sys.sunrise;
            vm.sys.sunset = result.sys.sunset;

            vm.timezone = result.timezone;
            vm.id = result.id;
            vm.name = result.name;
            vm.cod = result.cod;

            return View("ResultWeatherCity", vm);
        }
    }
}
