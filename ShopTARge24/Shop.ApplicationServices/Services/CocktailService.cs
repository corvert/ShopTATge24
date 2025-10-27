
using System.Net;
using Nancy.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;


namespace Shop.ApplicationServices.Services
{
    public class CocktailService : ICocktailService
    {
        public async Task<CocktailResultDto> CocktailWebResult(CocktailResultDto dto)
        {
           string baseUrl = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(baseUrl);
                CocktailWebClientDto cocktailDto =
                   new JavaScriptSerializer()
                    .Deserialize<CocktailWebClientDto>(json);
                dto.strCategory = cocktailDto.strCategory;
             
            }
            return dto;

           
        }
    }
}
