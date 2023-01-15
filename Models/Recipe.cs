using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public List<Ingredient> Ingredients { get; set; }
        public string? Instructions { get; set; }
        public NutritionalInformation NutritionalInformation { get; set; }
        public Dietary Dietary { get; set; }

    }

}