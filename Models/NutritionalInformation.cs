using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipe_server.Models
{
    public class NutritionalInformation
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public string ServingSize { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string Fat { get; set; } = string.Empty;
        public string Sodium { get; set; } = string.Empty;
        public string Carbohydrates { get; set; } = string.Empty;
        public string Fiber { get; set; } = string.Empty;
        public string Sugar { get; set; } = string.Empty;
        public string Protein { get; set; } = string.Empty;
    }
}