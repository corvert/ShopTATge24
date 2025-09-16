using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using ShopTARge24.Models.Kindergarten;

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
            

            var result = _context.Kindergartens.Select( x => new KindergartenIndexViewModel
            {
                Id = x.Id,
                GroupName = x.GroupName,
                ChildrenCount = x.ChildrenCount,
                KindergartenName = x.KindergartenName,
                TeacherName = x.TeacherName,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt

            });
            return View(result);
        }
    }
}
