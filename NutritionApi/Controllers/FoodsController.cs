using Microsoft.AspNetCore.Mvc;
using NutritionApi.Models;
using NutritionApi.Services;

namespace NutritionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly INutritionService nutritionService;

    public FoodController(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFood()
    {
        var foods = await nutritionService.Get();
        return foods.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFood(string id)
    {
        var food = await nutritionService.Get(id);

        if (food is null)
            return NotFound();

        return food;
    }
}
