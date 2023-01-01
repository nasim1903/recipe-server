using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using recipe_server.Models;
using recipe_server.Services;

namespace recipe_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly iRecipeService _recipeService;

        public RecipeController(iRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public ActionResult<Recipe> Get()
        {
            return Ok(_recipeService.GetRecipes());
        }
        [HttpGet("search/name")]
        public ActionResult<Recipe> GetSearch(string name)
        {
            return Ok(_recipeService.GetRecipesByName(name));
        }
        // [HttpGet("search/ingredient")]
        // public ActionResult<Recipe> GetIngredient(string[] ingredients)
        // {
        //     return Ok(_recipeService.GetIngredient(ingredients));
        // }

        [HttpPost("post")]
        public ActionResult<List<Recipe>> createRecipe(List<Recipe> recipes){
            return Ok(_recipeService.CreateRecipe(recipes));
        }
    }
}