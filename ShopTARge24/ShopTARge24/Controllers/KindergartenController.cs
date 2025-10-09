using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using ShopTARge24.Models.Kindergarten;

namespace ShopTARge24.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly ShopContext _context;
        private readonly IKindergartenServices _kindergartenServices;
        private readonly IFileServices _fileServices;

        public KindergartenController(ShopContext context, IKindergartenServices kindergartenServices, IFileServices fileServices)
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
            _fileServices = fileServices;
        }
        public IActionResult Index()
        {


            var result = _context.Kindergartens.Select(x => new KindergartenIndexViewModel
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

        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = ToKindergartenDto(vm);

            var result = await _kindergartenServices.Create(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private static KindergartenDto ToKindergartenDto(KindergartenCreateUpdateViewModel vm)
        {
            return new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
                Files = vm.Files,



                KGFileToApiDtos = vm.Image.Select(x => new KGFileToApiDto
                {
                    ImageId = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    KindergartenId = x.KindergartenId
                }).ToList()


            };
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            KindergratenImageViewModel[] images = await GetKGImages(id);
            var vm = new KindergartenDeleteDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            vm.Image.AddRange(images);
            vm.ShowDeleteBtn = true;


            return View("DeleteDetails", vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarten = await _kindergartenServices.Delete(id);
            if (kindergarten == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            KindergratenImageViewModel[] images = await GetKGImages(id);

            var vm = new KindergartenCreateUpdateViewModel();
            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            vm.Image.AddRange(images);
            return View("CreateUpdate", vm);
        }

        private async Task<KindergratenImageViewModel[]> GetKGImages(Guid id)
        {
            return await _context.KGFileToApis
                .Where(x => x.KindergartenId == id)
                .Select(x => new KindergratenImageViewModel

                {
                    FilePath = x.ExistingFilePath,
                    ImageId = x.Id
                }).ToArrayAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                KGFileToApiDtos = vm.Image
                .Select(x => new KGFileToApiDto
                {
                    ImageId = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    KindergartenId = x.KindergartenId
                }).ToArray()
            };
            var result = await _kindergartenServices.Update(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergratenImageViewModel[] images = await GetKGImages(id);

            var vm = new KindergartenDeleteDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            vm.Image.AddRange(images);
            vm.ShowDeleteBtn = false;


            return View("DeleteDetails", vm);
        }

        public async Task<IActionResult> RemoveImage(KindergratenImageViewModel vm)
        {
            //tuleb ühendada dto ja vm
            //Id peab saama edastatud andmebaasi
            var dto = new KGFileToApiDto()
            {
                ImageId = vm.ImageId,
              
            };

            //kutsu välja vastav serviceclassi meetod
            var image = await _fileServices.RemoveImageFromApi(dto);

            //kui on null, siis vii Index vaatesse
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
