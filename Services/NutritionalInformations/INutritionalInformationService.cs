using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipe_server.Dtos.NutritionalInformation;

namespace recipe_server.Services.NutritionalInformations
{
    public interface INutritionalInformationService
    {
        Task<ServiceResponse<Recipe>> AddNutrition(AddNutritionDto Nutrition);
    }
}