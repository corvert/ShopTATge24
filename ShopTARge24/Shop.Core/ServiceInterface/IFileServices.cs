
using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
       
        void KGFilesToApi(KindergartenDto dto, Kindergarten domain);

    }
}
