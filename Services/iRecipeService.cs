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
        Task<ServiceResponse<List<Recipe>>> CreateRecipe(List<Recipe> recipes);
        Task<ServiceResponse<List<Recipe>>> DeleteRecipe(int id);
        
        // public List<Recipe> GetIngredient(string[] name);
    }
}