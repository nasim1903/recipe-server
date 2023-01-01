using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Models
{
    public class Recipe
    {
        public string? Name { get; set; } 
        public List<Ingredient>? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public NutritionalInformation? NutritionalInformation { get; set; }
        public Dietary? dietary { get; set; }

    }

}