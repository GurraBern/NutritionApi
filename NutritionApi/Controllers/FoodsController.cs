using Microsoft.AspNetCore.Mvc;
using NutritionApi.Models;
using NutritionApi.Services;

namespace NutritionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly INutritionService nutritionService;
    private readonly ILogger<FoodController> _logger;

    public FoodController(INutritionService nutritionService, ILogger<FoodController> logger)
    {
        this.nutritionService = nutritionService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFood()
    {
        try
        {
            var foods = await nutritionService.Get();

            if (!foods.Any())
                return NotFound(foods.ToList());

            return Ok(foods);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Could not get foods from service", ex);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<Food>> GetFood(string id)
    {
        try
        {
            var food = await nutritionService.Get(id);

            if (food is null)
            {
                _logger.LogInformation($"No food item found with id {id}.");
                return NotFound();
            }

            return Ok(food);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"An exception occurred while retrieving food with id {id}.", ex);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("name/{foodName}")]
    public async Task<ActionResult<ICollection<Food>>> GetFoodByName(string foodName)
    {
        try
        {
            var foods = await nutritionService.SearchFoodsByName(foodName);

            if (foods is null)
                return NotFound();

            return Ok(foods);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"An exception occurred while retrieving food items with name {foodName}.", ex);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPost]
    public async Task CreateFood(Food food)
    {
        await nutritionService.Create(food);
    }
}
