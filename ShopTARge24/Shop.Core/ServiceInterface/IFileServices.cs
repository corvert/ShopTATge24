
using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceShipDto dto, SpaceShips domain);
        Task<FilesToApi> RemoveImageFromApi(FileToApiDto dto);

    }
}
