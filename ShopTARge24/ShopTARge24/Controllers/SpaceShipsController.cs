using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using ShopTARge24.Models.SpaceShips;
using Shop.Core;

namespace ShopTARge24.Controllers
{
   

    public class SpaceShipsController : Controller
    {
        private readonly ShopContext _context;

        public SpaceShipsController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.SpaceShips.Select(x => new SpaceShipsIndexViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Classification = x.Classification,
                BuildDate = x.BuildDate,
                Crew = x.Crew
            }
            );
            return View(result);
        }
    }
}
