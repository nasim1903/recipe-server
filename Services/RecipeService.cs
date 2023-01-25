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

        public static GetRecipeDto MapToDto(Recipe recipe)
        {

            var recipeDto = new GetRecipeDto();
            recipeDto.Id = recipe.Id;
            recipeDto.Name = recipe.Name;
            recipeDto.Ingredients = recipe.Ingredients.Split(",").Select(x => x.Trim()).ToList();
            recipeDto.Instructions = recipe.Instructions.Split(".").Select(x => x.Trim()).ToList();
            recipeDto.NutritionalInformation = recipe.NutritionalInformation.Split(",").Select(x => x.Trim()).ToList();
            recipeDto.Dietary = recipe.Dietary.Split(",").Select(x => x.Trim()).ToList();
            recipeDto.ImgUrl = recipe.ImgUrl;
            return recipeDto;
        }

        public List<GetRecipeDto> MapToDtoList(List<Recipe> recipes)
        {
            var recipeDtos = new List<GetRecipeDto>();
            foreach (var recipe in recipes)
            {
                recipeDtos.Add(MapToDto(recipe));
            }
            return recipeDtos;
        }

        public async Task<ServiceResponse<List<GetRecipeDto>>> CreateRecipe(List<Recipe> recipes)
        {
            var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();
            var recipe = await _context.Recipes.ToListAsync();

            try
            {
                _context.Recipes.AddRange(recipes);
                await _context.SaveChangesAsync();
                serviceResponse.Data = MapToDtoList(recipe);

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
            if (recipes == null)
            {
                serviceResponse.success = false;
                serviceResponse.Message = "Recipe not found";
                return serviceResponse;
            }
            try
            {
                if (updateRecipe.Name != string.Empty)
                {
                    recipes.Name = updateRecipe.Name;
                }

                if (updateRecipe.Ingredients != string.Empty)
                {
                    recipes.Ingredients = updateRecipe.Ingredients;
                }
                if (updateRecipe.Instructions != string.Empty)
                {
                    recipes.Instructions = updateRecipe.Instructions;
                }
                if (updateRecipe.NutritionalInformation != string.Empty)
                {
                    recipes.NutritionalInformation = updateRecipe.NutritionalInformation;
                }
                if (updateRecipe.Dietary != string.Empty)
                {
                    recipes.Dietary = updateRecipe.Dietary;
                }
                if (updateRecipe.ImgUrl != string.Empty)
                {
                    recipes.ImgUrl = updateRecipe.ImgUrl;
                }
                await _context.SaveChangesAsync();

                serviceResponse.Data = MapToDto(recipes);
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRecipeDto>>> DeleteRecipe(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();
            var recipes = await _context.Recipes.ToListAsync();
            try
            {
                var DbRecipe = await _context.Recipes.FirstAsync(c => c.Id == id);
                _context.Remove(DbRecipe);
                await _context.SaveChangesAsync();

                serviceResponse.Data = MapToDtoList(recipes);
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
            try
            {

                serviceResponse.Data = MapToDtoList(recipes);
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

            try
            {
                serviceResponse.Data = MapToDtoList(recipes);

            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        // public async Task<ServiceResponse<GetRecipeDto>> GetRecipeByIngredient(List<string> ingredients){
        //     var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();
        //     var recipes = await _context.Recipes.Where(c => c.Ingredients.ToLower().Contains(ingredients)).ToListAsync();
        // }
    }

}