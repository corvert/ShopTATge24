using Microsoft.AspNetCore.Mvc;
using Shop.Data;

namespace ShopTARge24.Controllers
{
    public class KindergartenController : Controller
    {
        public readonly ShopContext _context;
        public KindergartenController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();

            var result = _context.Kindergartens.Select( x => new KindergartenIndexViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Capacity = x.Capacity
            });
            return View(result);
        }
    }
}
