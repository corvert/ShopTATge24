using Microsoft.AspNetCore.Mvc;
using Shop.Core.ServiceInterface;
using ShopTARge24.Models.ChuckJoke;

namespace ShopTARge24.Controllers
{
    public class ChuckJokeController : Controller
    {
        private readonly IChuckNorrisServcies _chuckNorrisServcies;
        public ChuckJokeController(IChuckNorrisServcies chuckNorrisServcies)
        {
            _chuckNorrisServcies = chuckNorrisServcies;
        }
        public async Task<IActionResult> Index()
        {
            var dto = await _chuckNorrisServcies.FetchRandomJoke();

            var vm = new ChuckNorrisJokeViewModel
            {
                Id = dto.Id,
                Value = dto.Value,
                Categories = dto.Categories,
                Created_at = dto.Created_at,
                Icon_url = dto.Icon_url,
                Updated_at = dto.Updated_at,
                Url = dto.Url
            };

            return View(vm);
        }

    }
}
