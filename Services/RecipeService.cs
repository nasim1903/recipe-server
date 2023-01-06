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

        public async Task<ServiceResponse<List<Recipe>>> CreateRecipe(List<Recipe> recipes)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();

            try
            {
                await _context.AddRangeAsync(recipes);
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