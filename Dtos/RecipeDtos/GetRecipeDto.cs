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
        public List<string>? Ingredients { get; set; }
        public List<string>? Instructions { get; set; }
        public List<string>? NutritionalInformation { get; set; }
        public List<string>? Dietary { get; set; }        
        public string? ImgUrl { get; set; }        
    }
}