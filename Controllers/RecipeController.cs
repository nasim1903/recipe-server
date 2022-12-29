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
    }
}