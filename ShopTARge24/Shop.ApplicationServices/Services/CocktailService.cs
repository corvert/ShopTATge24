using System.Net.Http;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;


namespace Shop.ApplicationServices.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly HttpClient _httpClient;

        public CocktailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CocktailResultDto> CocktailWebResult(CocktailResultDto dto)
        {
            string baseUrl = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";
            
            var response = await _httpClient.GetAsync(baseUrl);
            
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var cocktailResponse = JsonConvert.DeserializeObject<CocktailApiResponse>(json);
                
                if (cocktailResponse?.Drinks != null && cocktailResponse.Drinks.Count > 0)
                {
                    var cocktail = cocktailResponse.Drinks[0];
                    
                    dto.idDrink = cocktail.idDrink;
                    dto.strDrink = cocktail.strDrink;
                    dto.strDrinkAlternate = cocktail.strDrinkAlternate;
                    dto.strTags = cocktail.strTags;
                    dto.strVideo = cocktail.strVideo;
                    dto.strCategory = cocktail.strCategory;
                    dto.strIBA = cocktail.strIBA;
                    dto.strAlcoholic = cocktail.strAlcoholic;
                    dto.strGlass = cocktail.strGlass;
                    dto.strInstructions = cocktail.strInstructions;
                    dto.strInstructionsES = cocktail.strInstructionsES;
                    dto.strInstructionsDE = cocktail.strInstructionsDE;
                    dto.strInstructionsFR = cocktail.strInstructionsFR;
                    dto.strInstructionsIT = cocktail.strInstructionsIT;
                    dto.strInstructionsZHHANS = cocktail.strInstructionsZHHANS;
                    dto.strInstructionsZHHANT = cocktail.strInstructionsZHHANT;
                    dto.strDrinkThumb = cocktail.strDrinkThumb;
                    dto.strIngredient1 = cocktail.strIngredient1;
                    dto.strIngredient2 = cocktail.strIngredient2;
                    dto.strIngredient3 = cocktail.strIngredient3;
                    dto.strIngredient4 = cocktail.strIngredient4;
                    dto.strIngredient5 = cocktail.strIngredient5;
                    dto.strIngredient6 = cocktail.strIngredient6;
                    dto.strIngredient7 = cocktail.strIngredient7;
                    dto.strIngredient8 = cocktail.strIngredient8;
                    dto.strIngredient9 = cocktail.strIngredient9;
                    dto.strIngredient10 = cocktail.strIngredient10;
                    dto.strIngredient11 = cocktail.strIngredient11;
                    dto.strIngredient12 = cocktail.strIngredient12;
                    dto.strIngredient13 = cocktail.strIngredient13;
                    dto.strIngredient14 = cocktail.strIngredient14;
                    dto.strIngredient15 = cocktail.strIngredient15;
                    dto.strMeasure1 = cocktail.strMeasure1;
                    dto.strMeasure2 = cocktail.strMeasure2;
                    dto.strMeasure3 = cocktail.strMeasure3;
                    dto.strMeasure4 = cocktail.strMeasure4;
                    dto.strMeasure5 = cocktail.strMeasure5;
                    dto.strMeasure6 = cocktail.strMeasure6;
                    dto.strMeasure7 = cocktail.strMeasure7;
                    dto.strMeasure8 = cocktail.strMeasure8;
                    dto.strMeasure9 = cocktail.strMeasure9;
                    dto.strMeasure10 = cocktail.strMeasure10;
                    dto.strMeasure11 = cocktail.strMeasure11;
                    dto.strMeasure12 = cocktail.strMeasure12;
                    dto.strMeasure13 = cocktail.strMeasure13;
                    dto.strMeasure14 = cocktail.strMeasure14;
                    dto.strMeasure15 = cocktail.strMeasure15;
                    dto.strImageSource = cocktail.strImageSource;
                    dto.strImageAttribution = cocktail.strImageAttribution;
                    dto.strCreativeCommonsConfirmed = cocktail.strCreativeCommonsConfirmed;
                    dto.dateModified = cocktail.dateModified;
                }
            }
            
            return dto;
        }
    }
}
