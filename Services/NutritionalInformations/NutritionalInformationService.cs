using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using recipe_server.Dtos.NutritionalInformation;
using recipe_server.Models;

namespace recipe_server.Services.NutritionalInformations
{
    public class NutritionalInformationService : INutritionalInformationService
    {
        private readonly DataC _context;

        private readonly IMapper _mapper;

        public NutritionalInformationService(DataC context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Recipe>> AddNutrition(AddNutritionDto Nutrition)
        {
            ServiceResponse<Recipe> response = new ServiceResponse<Recipe>();

            try
            {

                Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(c => c.Id == Nutrition.RecipeId);

                if (recipe == null)
                {
                    response.success = false;
                    response.Message = "Recipe not found";
                    return response;
                }

                NutritionalInformation information = new NutritionalInformation
                {
                    ServingSize = Nutrition.ServingSize,
                    Calories = Nutrition.Calories,
                    Fat = Nutrition.Fat,
                    Sodium = Nutrition.Sodium,
                    Carbohydrates = Nutrition.Carbohydrates,
                    Fiber = Nutrition.Fiber,
                    Sugar = Nutrition.Sugar,
                    Protein = Nutrition.Protein,
                    Recipe = recipe
                };

                _context.Add(information);
                await _context.SaveChangesAsync();
                response.Data = recipe;
            }
            catch (Exception ex)
            {

                response.success = false;
                response.Message = ex.Message;

            }
            return response;
        }
    }
}