using System.ComponentModel.DataAnnotations.Schema;

namespace recipe_server.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public List<string>? Ingredients { get; set; }
        public List<string>? Instructions { get; set; }
        public string? NutritionalInformation { get; set; }
        public string? Dietary { get; set; }

    }

}