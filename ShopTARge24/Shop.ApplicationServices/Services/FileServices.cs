
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {

        private readonly IHostEnvironment _webHost;
        private readonly ShopContext _context;

        public FileServices(
            IHostEnvironment webHost,
            ShopContext context)
        {
            _webHost = webHost;
            _context = context;
        }

        public void FilesToApi(SpaceShipDto dto, SpaceShips domain)
        {


            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FilesToApi path = new FilesToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceShipId = domain.Id
                        };


                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
        public void FilesToApi(KindergartenDto dto, Kindergarten domain)
        {


            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FilesToApi path = new FilesToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            KindergartenId = domain.Id
                        };


                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }

        public async Task<FilesToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            //kui soovin kustutada pilti, siis pean läbi id leidma pildi
            var imageId = await _context.FileToApis.FirstOrDefaultAsync(x => x.Id == dto.ImageId);
            //kus asuvad pildid, mida hakatakse kustutama
            var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"
                + imageId.ExistingFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FileToApis.Remove(imageId);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<List<FilesToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
                var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"
                    + imageId.ExistingFilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                _context.FileToApis.Remove(imageId);
                await _context.SaveChangesAsync();
            }


            return null;

        }

        //public void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain)
        //{
        //    //toimub kontroll, kas on vähemalt üks fail või mitu
        //    if (dto.Files != null && dto.Files.Count > 0)
        //    {
        //        //tuleb kasutada foreach et mitu faili üles laadida
        //        foreach (var file in dto.Files)
        //        {
        //            //foreach sees tuleb kasutada using
        //            using (var target = new MemoryStream())
        //            {
        //                FileToDatabase files = new FileToDatabase
        //                {
        //                    Id = Guid.NewGuid(),
        //                    ImageTitle = file.FileName,
        //                    RealEstateId = domain.Id
        //                };
        //                //andmed salvestada andmebaasi
        //                file.CopyTo(target);
        //                files.ImageData = target.ToArray();

        //                _context.FileToDatabase.Add(files);

        //            }

        //        }
        //    }
        //}
    }
}
