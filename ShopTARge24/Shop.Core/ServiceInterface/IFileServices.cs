
using System.Xml;
using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
       
        void KGFilesToApi(KindergartenDto dto, Kindergarten domain);
        Task<KGFilesToApi> RemoveImageFromApi(KGFileToApiDto dto);
        Task<List<KGFilesToApi>> RemoveImagesFromApi(KGFileToApiDto[] images);
        void UploadFilesToDatabase(KindergartenDto dto, Kindergarten domain);
    }
}
