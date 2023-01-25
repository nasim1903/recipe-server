using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipe_server.Dtos.RecipeDtos;

namespace recipe_server.Services
{
    public interface iRecipeService
    {
        Task<ServiceResponse<List<GetRecipeDto>>> GetRecipes();
        Task<ServiceResponse<List<GetRecipeDto>>> GetRecipesByName(string name);
        Task<ServiceResponse<List<GetRecipeDto>>> CreateRecipe(List<Recipe> recipes);
        Task<ServiceResponse<List<GetRecipeDto>>> DeleteRecipe(int id);
        Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(Recipe updateRecipe, int id);
        // Task<ServiceResponse<GetRecipeDto>> GetRecipeByIngredient(List<string> ingredients);
        
    }
}