using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Services
{
    public interface iRecipeService
    {
        public List<Recipe> GetRecipes();
    }
}