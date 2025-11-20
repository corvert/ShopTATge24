
using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceShipDto dto, SpaceShips domain);
        Task<FilesToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FilesToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);

    }
}
