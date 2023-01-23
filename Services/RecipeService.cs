using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recipe_server.Dtos.RecipeDtos;

namespace recipe_server.Services
{
    public class RecipeService : iRecipeService
    {
        private readonly DataC _context;
        private readonly IMapper _mapper;

        public RecipeService(DataC context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Recipe>>> CreateRecipe(Recipe recipes)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();

            try
            {
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

        public async Task<ServiceResponse<List<GetRecipeDto>>> GetRecipes()
        {

            var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();
            var recipes = await _context.Recipes.ToListAsync();
            var recipeDtos = new List<GetRecipeDto>();

            try
            {

                foreach (var recipe in recipes)
                {
                    var recipeDto = new GetRecipeDto();
                    recipeDto.Id = recipe.Id;
                    recipeDto.Name = recipe.Name;
                    recipeDto.Ingredients = recipe.Ingredients.Split(",").Select(x => x.Trim()).ToList();
                    recipeDto.Instructions = recipe.Instructions;
                    recipeDto.NutritionalInformation = recipe.NutritionalInformation.Split(",").Select(x => x.Trim()).ToList();
                    recipeDto.Dietary = recipe.Dietary.Split(",").Select(x => x.Trim()).ToList();

                    recipeDtos.Add(recipeDto);

                    serviceResponse.Data = recipeDtos;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

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