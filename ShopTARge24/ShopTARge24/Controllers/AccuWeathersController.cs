using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using ShopTARge24.Models.AccuWeathers;

namespace ShopTARge24.Controllers
{
    public class AccuWeathersController : Controller
    {

        private readonly IWeatherForecastServices _watherForecastServices;
        public AccuWeathersController(IWeatherForecastServices watherForecastServices)
        {
            _watherForecastServices = watherForecastServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeathersSearchViewModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new {city = model.CityName});
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            AccuLocationWeatherResultDto dto = new();
            dto.CityName = city;

            _watherForecastServices.AccuWeatherResult(dto);

            return View(dto);
          
        }


    }
}
