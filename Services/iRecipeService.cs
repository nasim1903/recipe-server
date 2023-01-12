using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Services
{
    public interface iRecipeService
    {
        Task<ServiceResponse<List<Recipe>>> GetRecipes();
        Task<ServiceResponse<List<Recipe>>> GetRecipesByName(string name);
        Task<ServiceResponse<List<Recipe>>> CreateRecipe(List<Recipe> recipes);
        Task<ServiceResponse<List<Recipe>>> DeleteRecipe(int id);
        
        // public List<Recipe> GetIngredient(string[] name);
    }
}