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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEsate = await _realEstateServices.DetailAsync(id);
            if (realEsate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateDeleteDetailsViewModel();

            vm.Id = realEsate.Id;
            vm.Area = realEsate.Area;
            vm.Location = realEsate.Location;
            vm.RoomNumber = realEsate.RoomNumber;
            vm.BuildingType = realEsate.BuildingType;
            vm.CreatedAt = realEsate.CreatedAt;
            vm.ModifiedAt = realEsate.ModifiedAt;
            vm.ShowDeleteBtn = true;


            return View("DeleteDetails", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarten = await _realEstateServices.Delete(id);
            if (kindergarten == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEsate = await _realEstateServices.DetailAsync(id);
            if (realEsate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateCreateUpdateViewModel();
            vm.Id = realEsate.Id;
            vm.Area = realEsate.Area;
            vm.Location = realEsate.Location;
            vm.RoomNumber = realEsate.RoomNumber;
            vm.BuildingType = realEsate.BuildingType;
            vm.CreatedAt = realEsate.CreatedAt;
            vm.ModifiedAt = realEsate.ModifiedAt;
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Area = vm.Area,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = DateTime.Now
            };
            var result = await _realEstateServices.Update(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.DetailAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateDeleteDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Area = realEstate.Area;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.ShowDeleteBtn = false;


            return View("DeleteDetails", vm);
        }
    }
}
