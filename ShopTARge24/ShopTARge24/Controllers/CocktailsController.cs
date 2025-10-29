using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.CocktailDtos;
using Shop.Core.ServiceInterface;
using ShopTARge24.Models.Cocktails;


namespace ShopTARge24.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService _cocktailService;
        public CocktailsController
            (
                ICocktailService cocktailService
            )
        {
            _cocktailService = cocktailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCocktail(CocktailSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Cocktail", "Cocktails", new { cocktail = model.CocktailName });
            }
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Cocktail(string cocktail)
        {
            CocktailResultDto dto = new();
            dto.strDrink = cocktail;
            await _cocktailService.CocktailWebResult(dto);
            CocktailViewModel vm = new();
            vm.idDrink = dto.idDrink;
            vm.strDrink = dto.strDrink;
            vm.strCategory = dto.strCategory;
            vm.strAlcoholic = dto.strAlcoholic;
            vm.strGlass = dto.strGlass;
            vm.strInstructions = dto.strInstructions;
            vm.strDrinkThumb = dto.strDrinkThumb;
            vm.strIngredient1 = dto.strIngredient1;
            vm.strMeasure1 = dto.strMeasure1;
            vm.strIngredient2 = dto.strIngredient2;
            vm.strMeasure2 = dto.strMeasure2;
            vm.strIngredient3 = dto.strIngredient3;
            vm.strMeasure3 = dto.strMeasure3;
            vm.strIngredient4 = dto.strIngredient4;
            vm.strMeasure4 = dto.strMeasure4;
            vm.strIngredient5 = dto.strIngredient5;
            vm.strMeasure5 = dto.strMeasure5;
            vm.strIngredient6 = dto.strIngredient6;
            vm.strMeasure6 = dto.strMeasure6;
            vm.strIngredient7 = dto.strIngredient7;
            vm.strMeasure7 = dto.strMeasure7;
            vm.strIngredient8 = dto.strIngredient8;
            vm.strMeasure8 = dto.strMeasure8;
            vm.strIngredient9 = dto.strIngredient9;
            vm.strMeasure9 = dto.strMeasure9;
            vm.strIngredient10 = dto.strIngredient10;
            vm.strMeasure10 = dto.strMeasure10;
            vm.strIngredient11 = dto.strIngredient11;
            vm.strMeasure11 = dto.strMeasure11;
            vm.strIngredient12 = dto.strIngredient12;
            vm.strMeasure12 = dto.strMeasure12;
            vm.strIngredient13 = dto.strIngredient13;
            vm.strMeasure13 = dto.strMeasure13;
            vm.strIngredient14 = dto.strIngredient14;
            vm.strMeasure14 = dto.strMeasure14;
            vm.strIngredient15 = dto.strIngredient15;
            vm.strMeasure15 = dto.strMeasure15;

            return View(vm);
        }
    }
}
