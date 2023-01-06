using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Models
{
    public class Ingredient
    {
        public int RecipeId { get; set; }
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Amount { get; set; }
    }
}