
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class SpaceshipServices : ISpaceshipServices
    {
        private readonly ShopContext _context;

        //konstruktor
        public SpaceshipServices(ShopContext context)
        {
            _context = context;
        }

        public async Task<SpaceShips> Create(SpaceShipDto dto)
        {
            SpaceShips spaceShips = new SpaceShips();
            spaceShips.Id = Guid.NewGuid();
            spaceShips.Name = dto.Name;
            spaceShips.Classification = dto.Classification;
            spaceShips.BuildDate = dto.BuildDate;
            spaceShips.Crew = dto.Crew;
            spaceShips.EnginePower = dto.EnginePower;
            spaceShips.CreatedAt = DateTime.Now;
            spaceShips.ModifiedAt = DateTime.Now;
            
            await _context.SpaceShips.AddAsync(spaceShips);
            await _context.SaveChangesAsync();

            return spaceShips;
        }

        public async Task<SpaceShips> Update(SpaceShipDto dto)
        {
            SpaceShips spaceShips = new SpaceShips();
            spaceShips.Id = dto.Id;
            spaceShips.Name = dto.Name;
            spaceShips.Classification = dto.Classification;
            spaceShips.BuildDate = dto.BuildDate;
            spaceShips.Crew = dto.Crew;
            spaceShips.EnginePower = dto.EnginePower;
            spaceShips.CreatedAt = dto.CreatedAt;
            spaceShips.ModifiedAt = DateTime.Now;

            _context.SpaceShips.Update(spaceShips);
            await _context.SaveChangesAsync();

            return spaceShips;
        }

        public async Task<SpaceShips> DetailAsync(Guid id)
        {
            var result = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<SpaceShips> Delete(Guid id)
        {             
            var result = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.SpaceShips.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

    }
}
