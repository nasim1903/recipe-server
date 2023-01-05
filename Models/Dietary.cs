using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipe_server.Models
{
    [Keyless]
    [NotMapped]
    public class Dietary
    {
        public bool vegan { get; set; }
        public bool vegetarian { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool bulking { get; set; }
        public bool cutting { get; set; }
    }
}