using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipe_server.Services
{
    public class RecipeService : iRecipeService
    {
        private readonly DataC _context;
        public RecipeService(DataC context)
        {
            _context = context;

        }

        public async Task<ServiceResponse<List<Recipe>>> CreateRecipe(Recipe recipes)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();

            try
            {

                NutritionalInformation nutritional = new NutritionalInformation
                {
                    ServingSize = recipes.NutritionalInformation.ServingSize,
                    Calories = recipes.NutritionalInformation.Calories,
                    Fat = recipes.NutritionalInformation.Fat,
                    Sodium = recipes.NutritionalInformation.Sodium,
                    Carbohydrates = recipes.NutritionalInformation.Carbohydrates,
                    Fiber = recipes.NutritionalInformation.Fiber,
                    Sugar = recipes.NutritionalInformation.Sugar,
                    Protein = recipes.NutritionalInformation.Protein,
                    Recipe = recipes
                };

                _context.Recipes.Add(recipes);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Recipes.ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recipe>>> DeleteRecipe(int id)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();

            try
            {
                var DbRecipe = await _context.Recipes.FirstAsync(c => c.Id == id);
                // var DbIngredients = await _context.Ingredients.FirstAsync(c => c.RecipeId == id);
                _context.Remove(DbRecipe);
                // _context.Remove(DbIngredients);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Recipes.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recipe>>> GetRecipes()
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();
            serviceResponse.Data = await _context.Recipes.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recipe>>> GetRecipesByName(string name)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();
            var DbRecipe = await _context.Recipes.Where(c => c.Name.ToLower().Contains(name)).ToListAsync();
            serviceResponse.Data = DbRecipe;

            return serviceResponse;
        }
    }

}