using System.ComponentModel.DataAnnotations.Schema;

namespace recipe_server.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string NutritionalInformation { get; set; } = string.Empty;
        public string Dietary { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }

    }

}