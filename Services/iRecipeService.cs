using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Services
{
    public interface iRecipeService
    {
        public Task<ServiceResponse<List<Recipe>>> GetRecipes();
        public Task<ServiceResponse<List<Recipe>>> GetRecipesByName(string name);
        public Task<ServiceResponse<List<Recipe>>> CreateRecipe(List<Recipe> recipes);
        // public List<Recipe> GetIngredient(string[] name);
    }
}