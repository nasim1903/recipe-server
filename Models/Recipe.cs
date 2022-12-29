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
}

public class Ingredient
{
    public string? Name { get; set; }
    public string? Amount { get; set; }
}

public class NutritionalInformation
{
    public string? ServingSize { get; set; }
    public int? Calories { get; set; }
    public string? Fat { get; set; }
    public string? Sodium { get; set; }
    public string? Carbohydrates { get; set; }
    public string? Fiber { get; set; }
    public string? Sugar { get; set; }
    public string? Protein { get; set; }
}

}