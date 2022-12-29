using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Services
{
    public class RecipeService : iRecipeService
    {
        List<Recipe> newRecipe = new List<Recipe>{
            new Recipe
            {
                Name = "Oatmeal raisin cookies",
                Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Flour", Amount = "1 cup" },
                new Ingredient { Name = "Sugar", Amount = "1/2 cup" },
                new Ingredient { Name = "Baking soda", Amount = "1 tsp" },
                new Ingredient { Name = "Salt", Amount = "1/2 tsp" },
                new Ingredient { Name = "Butter", Amount = "1/2 cup" },
                new Ingredient { Name = "Eggs", Amount = "1" },
                new Ingredient { Name = "Vanilla extract", Amount = "1 tsp" },
                new Ingredient { Name = "Oats", Amount = "1 cup" },
                new Ingredient { Name = "Raisins", Amount = "1/2 cup" }
            },
                Instructions = "1. Preheat your oven to 375°F (190°C). Line a baking sheet with parchment paper.  2. In a large mixing bowl, whisk together the flour, sugar, baking soda, and salt.  3. In a separate bowl, cream together the butter, eggs, and vanilla extract until well combined.  4. Add the wet ingredients to the dry ingredients and stir until just combined. Fold in the oats and raisins.  5. Drop spoonfuls of the dough onto the prepared baking sheet, leaving about 2 inches of space between each cookie.  6. Bake for 8-10 minutes, or until the edges are lightly golden.  7. Remove the cookies from the oven and let them cool on the baking sheet for a few minutes before transferring them to a wire rack to cool completely.",
                NutritionalInformation = new NutritionalInformation
                {
                    ServingSize = "1 cookie (28g)",
                    Calories = 140,
                    Fat = "6g",
                    Sodium = "90mg",
                    Carbohydrates = "20g",
                    Fiber = "1g",
                    Sugar = "11g",
                    Protein = "2g"
                }
            },
            new Recipe
            {
                Name = "Oatmeal raisin cookies",
                Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Flour", Amount = "1 cup" },
                new Ingredient { Name = "Sugar", Amount = "1/2 cup" },
                new Ingredient { Name = "Baking soda", Amount = "1 tsp" },
                new Ingredient { Name = "Salt", Amount = "1/2 tsp" },
                new Ingredient { Name = "Butter", Amount = "1/2 cup" },
                new Ingredient { Name = "Eggs", Amount = "1" },
                new Ingredient { Name = "Vanilla extract", Amount = "1 tsp" },
                new Ingredient { Name = "Oats", Amount = "1 cup" },
                new Ingredient { Name = "Raisins", Amount = "1/2 cup" }
            },
                Instructions = "1. Preheat your oven to 375°F (190°C). Line a baking sheet with parchment paper.  2. In a large mixing bowl, whisk together the flour, sugar, baking soda, and salt.  3. In a separate bowl, cream together the butter, eggs, and vanilla extract until well combined.  4. Add the wet ingredients to the dry ingredients and stir until just combined. Fold in the oats and raisins.  5. Drop spoonfuls of the dough onto the prepared baking sheet, leaving about 2 inches of space between each cookie.  6. Bake for 8-10 minutes, or until the edges are lightly golden.  7. Remove the cookies from the oven and let them cool on the baking sheet for a few minutes before transferring them to a wire rack to cool completely.",
                NutritionalInformation = new NutritionalInformation
                {
                    ServingSize = "1 cookie (28g)",
                    Calories = 140,
                    Fat = "6g",
                    Sodium = "90mg",
                    Carbohydrates = "20g",
                    Fiber = "1g",
                    Sugar = "11g",
                    Protein = "2g"
                }
            }
            
        };

        public List<Recipe> GetRecipes()
        {
            return (newRecipe);
        }
    }

}