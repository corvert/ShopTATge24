using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.OpenWeatherDtos;
using Shop.Core.ServiceInterface;
using ShopTARge24.Models.OpenWeather;

namespace ShopTARge24.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController(IOpenWeatherServices openWeatherServices)
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
                return RedirectToAction("ResultWeatherCity", "OpenWeaters", new { cityName = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OpenWeaterCity(string cityName)
        {
            OpenWeatherResultDto dto = new();
            dto.name = cityName;

            var result = await _openWeatherServices.OpenWeatherResult(dto);

            OpenWeatherViewModel vm = new();

            

            // Map other properties as needed
           
            vm.@base = result.@base;
            vm.main.temp = result.main.temp;
            vm.main.feels_like = result.main.feels_like;
            vm.main.humidity = result.main.humidity;
            vm.main.pressure = result.main.pressure;
          
            vm.visibility = result.visibility;
            vm.wind.speed = result.wind.speed;
            vm.dt = result.dt;
       
            vm.timezone = result.timezone;
            vm.id = result.id;
            vm.name = result.name;
            vm.cod = result.cod;

            return View(vm);
        }
    }
}
