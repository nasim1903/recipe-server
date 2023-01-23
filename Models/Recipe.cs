using System.ComponentModel.DataAnnotations.Schema;

namespace recipe_server.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Avocado Toast";
        public string Ingredients { get; set; } = "Spaghetti Squash: 1, Tomato Sauce: 1 cup, Ground turkey: 1/2 lb";
        public string Instructions { get; set; } = "Slice the avocado in half and remove the pit."; 
        public string NutritionalInformation { get; set; } = "Serving Size: 1 cup (246g)";
        public string Dietary { get; set; } = "string";

    }

}