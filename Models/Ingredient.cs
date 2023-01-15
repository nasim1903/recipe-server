using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace recipe_server.Models
{
    public class Ingredient
    {
        public int id { get; set; }
        public int RecipeId { get; set; }
        // public Recipe? Recipe { get; set; }
        public string? Name { get; set; }
        public string? Amount { get; set; }
    }
}