using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {
        Task<SpaceShips> Create(SpaceShipDto dto);
        Task<SpaceShips> DetailAsync(Guid id);
        Task<SpaceShips> Delete(Guid id);
    }
}
