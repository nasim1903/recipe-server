using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recipe_server.Dtos.NutritionalInformation;
using recipe_server.Services.NutritionalInformations;

namespace recipe_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutritionalController : ControllerBase
    {
        private readonly INutritionalInformationService _nutritionalService;

        public NutritionalController(INutritionalInformationService nutritionalService)
        {
            _nutritionalService = nutritionalService;
        }
        [HttpPost]
        public async Task<ActionResult<List<Recipe>>> Get(AddNutritionDto Nutrition )
        {
            return Ok(await _nutritionalService.AddNutrition(Nutrition));
        }
    }
}