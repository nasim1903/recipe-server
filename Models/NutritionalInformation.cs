using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipe_server.Models
{
    public class NutritionalInformation
    {
        public int id { get; set; }
        public int RecipeId { get; set; }
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