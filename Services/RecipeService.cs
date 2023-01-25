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

        public async Task<ServiceResponse<List<Recipe>>> CreateRecipe(List<Recipe> recipes)
        {
            var serviceResponse = new ServiceResponse<List<Recipe>>();

            try
            {
                _context.Recipes.AddRange(recipes);
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

        public async Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(Recipe updateRecipe, int id)
        {
            var serviceResponse = new ServiceResponse<GetRecipeDto>();
            var recipes = await _context.Recipes.FirstOrDefaultAsync(c => c.Id == id);
            var recipeDto = new GetRecipeDto();

            try
            {
                _mapper.Map(updateRecipe, recipes);
                await _context.SaveChangesAsync();
                
                recipeDto.Id = recipes.Id;
                recipeDto.Name = recipes.Name;
                recipeDto.Ingredients = recipes.Ingredients.Split(".").Select(x => x.Trim()).ToList();
                recipeDto.Instructions = recipes.NutritionalInformation.Split(",").Select(x => x.Trim()).ToList();
                recipeDto.NutritionalInformation = recipes.NutritionalInformation.Split(",").Select(x => x.Trim()).ToList();
                recipeDto.Dietary = recipes.Dietary.Split(",").Select(x => x.Trim()).ToList();


                serviceResponse.Data = recipeDto;
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
                _context.Remove(DbRecipe);
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
                    recipeDto.Instructions = recipe.Instructions.Split(".").Select(x => x.Trim()).ToList();
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

        public async Task<ServiceResponse<List<GetRecipeDto>>> GetRecipesByName(string name)
        {
            var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();
            var recipes = await _context.Recipes.Where(c => c.Name.ToLower().Contains(name)).ToListAsync();
            var recipeDtos = new List<GetRecipeDto>();

            try
            {

                foreach (var recipe in recipes)
                {
                    var recipeDto = new GetRecipeDto();
                    recipeDto.Id = recipe.Id;
                    recipeDto.Name = recipe.Name;
                    recipeDto.Ingredients = recipe.Ingredients.Split(".").Select(x => x.Trim()).ToList();
                    recipeDto.Instructions = recipe.NutritionalInformation.Split(",").Select(x => x.Trim()).ToList();
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
    }

}