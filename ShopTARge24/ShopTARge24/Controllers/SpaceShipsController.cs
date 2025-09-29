using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using ShopTARge24.Models.SpaceShips;
using Shop.Core;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace ShopTARge24.Controllers
{
   

    public class SpaceShipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;
        private readonly IFileServices _fileService;

        public SpaceShipsController(ShopContext context,
            ISpaceshipServices spaceshipServices,
            IFileServices fileService)
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
            _fileService = fileService;
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

        [HttpGet]
        public IActionResult Create()
        {
            SpaceShipCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceShipCreateUpdateViewModel vm)
        {
            var dto = new SpaceShipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Classification = vm.Classification,
                BuildDate = vm.BuildDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.Image.Select(x => new FileToApiDto
                {
                    ImageId = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    SpaceShipId = x.SpaceShipId,
                    
                }).ToArray()

            };

            var result = await _spaceshipServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
              .Where(x => x.SpaceShipId == id)
              .Select(y => new ImageViewModel
              {
                  FilePath = y.ExistingFilePath,
                  ImageId = y.Id,
                  SpaceShipId = y.SpaceShipId
              }).ToArrayAsync();

            var vm = new SpaceShipDeleteViewModel();
            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuildDate = spaceship.BuildDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)

        {
            var spaceship = await _spaceshipServices.Delete(id);
            if (spaceship == null) 
                {
                return RedirectToAction(nameof(Index));
                }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var images = await _context.FileToApis
              .Where(x => x.SpaceShipId == id)
              .Select(y => new ImageViewModel
              {
                  FilePath = y.ExistingFilePath,
                  ImageId = y.Id,
                  SpaceShipId = y.SpaceShipId
              }).ToArrayAsync();
            var vm = new SpaceShipCreateUpdateViewModel();
            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuildDate = spaceship.BuildDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Image.AddRange(images);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceShipCreateUpdateViewModel vm)
        {
            var dto = new SpaceShipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Classification = vm.Classification,
                BuildDate = vm.BuildDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.Image.Select(x => new FileToApiDto
                {
                    ImageId = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    SpaceShipId = x.SpaceShipId,

                }).ToArray()
            };
            var result = await _spaceshipServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.SpaceShipId == id)
                .Select(y => new ImageViewModel
                { 
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                    SpaceShipId = y.SpaceShipId
                }).ToArrayAsync();

            var vm = new SpaceShipDetailsViewModel();
            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuildDate = spaceship.BuildDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Images.AddRange(images);
            return View(vm);
        }

        public async Task<IActionResult> RemoveImage(ImageViewModel vm)
            {
            //tuleb ühendada dto ja vm
            //id peab saama edastatud andmebaasi   
            var dto = new FileToApiDto()
            {
                ImageId = vm.ImageId,
           
            };
            //kutsu välja vastav serviceklassi meetod
            var image = await _fileService.RemoveImageFromApi(dto);
            //kui on null, siis vii tagasi index vaatesse
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
