using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using ShopTARge24.Models.RealEstates;

namespace ShopTARge24.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopContext _context;
        public RealEstateController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.RealEstates.Select(x => new RealEstateIndexViewModel
            {
                Id = x.Id,
                Area = x.Area,
                Location = x.Location,
                RoomNumber = x.RoomNumber,
                BuildingType = x.BuildingType
            });
            return View();
        }
    }
}
