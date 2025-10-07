﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using ShopTARge24.Models.RealEstates;
using ShopTARge24.Models.SpaceShips;

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
                BuildingType = x.BuildingType,
                CreatedAt = x.CreatedAt,


            });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new();
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
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x=> new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    RealEstateId = x.RealEstateId
                }).ToArray()
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

            RealEstateImageViewModel[] images = await NewMethod(id);

            var vm = new RealEstateDeleteDetailsViewModel();

            vm.Id = realEsate.Id;
            vm.Area = realEsate.Area;
            vm.Location = realEsate.Location;
            vm.RoomNumber = realEsate.RoomNumber;
            vm.BuildingType = realEsate.BuildingType;
            vm.CreatedAt = realEsate.CreatedAt;
            vm.ModifiedAt = realEsate.ModifiedAt;
            vm.Images.AddRange(images);
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

            RealEstateImageViewModel[] images = await NewMethod(id);

            var vm = new RealEstateCreateUpdateViewModel();
            vm.Id = realEsate.Id;
            vm.Area = realEsate.Area;
            vm.Location = realEsate.Location;
            vm.RoomNumber = realEsate.RoomNumber;
            vm.BuildingType = realEsate.BuildingType;
            vm.CreatedAt = realEsate.CreatedAt;
            vm.ModifiedAt = realEsate.ModifiedAt;
            vm.Image.AddRange(images);
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

            RealEstateImageViewModel[] images = await NewMethod(id);

            var vm = new RealEstateDeleteDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Area = realEstate.Area;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.Images.AddRange(images);
            vm.ShowDeleteBtn = false;


            return View("DeleteDetails", vm);
        }

        private async Task<RealEstateImageViewModel[]> NewMethod(Guid id)
        {
            return await _context.FileToDatabase
               .Where(x => x.RealEstateId == id)
               .Select(y => new RealEstateImageViewModel
               {
                   Id = y.Id,
                   RealEstateId = y.Id,
                   ImageTitle = y.ImageTitle,
                   ImageData = y.ImageData,
                   Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
               }).ToArrayAsync();
        }
    }
}
