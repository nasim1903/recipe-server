using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Dtos.NutritionalInformation
{
    public class AddNutritionDto
    {
        public int RecipeId { get; set; }
        public string ServingSize { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string Fat { get; set; } = string.Empty;
        public string Sodium { get; set; } = string.Empty;
        public string Carbohydrates { get; set; } = string.Empty;
        public string Fiber { get; set; } = string.Empty;
        public string Sugar { get; set; } = string.Empty;
        public string Protein { get; set; } = string.Empty;
    }
}