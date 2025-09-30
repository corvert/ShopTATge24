using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using ShopTARge24.Models.RealEstates;

namespace ShopTARge24.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopContext _context;
        private readonly IRealEstateServices _realEstateServices;
        public RealEstateController(ShopContext context,
            IRealEstateServices realEstateServices)
        {
            _context = context;
            _realEstateServices = realEstateServices;
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
        [HttpGet]
        public IActionResult Create()
        {
            RealEstateIndexViewModel realEstate = new();
            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Area = vm.Area,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var realEsate = await _realEstateServices.Create(dto);
            if(realEsate != null) {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
