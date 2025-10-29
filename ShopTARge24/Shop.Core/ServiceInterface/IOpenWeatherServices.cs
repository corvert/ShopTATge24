using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Dto.OpenWeatherDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {

        Task<OpenWeatherRootDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
