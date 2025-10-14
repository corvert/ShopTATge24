using System.Xml;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergartenServices(
            ShopContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new Kindergarten();
            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, kindergarten);
            }

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;

        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergartens.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergartens.FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.KGFileToApis
                .Where(x => x.KindergartenId == id)
                .Select(y => new KGFileToApiDto
                {
                    ImageId = y.Id,
                    KindergartenId = y.KindergartenId,
                    

                }
                ).ToArrayAsync();
            await _fileServices.RemoveImagesFromApi(images);

            if (kindergarten != null)

            {
                
                _context.Kindergartens.Remove(kindergarten);
                await _context.SaveChangesAsync();
            }
            return kindergarten;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        { 
            Kindergarten kindergarten = new Kindergarten();
            kindergarten.Id = dto.Id;
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.UpdatedAt = DateTime.Now;

            _context.Kindergartens.Update(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Details(Guid id)
        {
            var kindergarten = await _context.Kindergartens.FirstOrDefaultAsync(x => x.Id == id);
            return kindergarten;
        }
    }
}
