using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Dtos.RecipeDtos
{
    public class GetRecipeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string? NutritionalInformation { get; set; }
        public string? Dietary { get; set; }        
    }
}