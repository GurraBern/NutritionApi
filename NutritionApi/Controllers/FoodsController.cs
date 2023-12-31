﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionApi.Models;
using NutritionApi.Services;

namespace NutritionApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly INutritionService nutritionService;
    private readonly ILogger<FoodController> _logger;
    private const int maxFoodPageSize = 50;

    public FoodController(INutritionService nutritionService, ILogger<FoodController> logger)
    {
        this.nutritionService = nutritionService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFood(int pageNumber = 1, int pageSize = 10)
    {
        if (pageSize > maxFoodPageSize)
            pageSize = maxFoodPageSize;

        try
        {
            var foods = await nutritionService.Get(pageNumber, pageSize);

            return Ok(foods);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"An exception occurred while retrieving food items.", ex);
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

    [HttpGet("name/{name}")]
    public async Task<ActionResult<ICollection<Food>>> GetFoodByName(string name, int pageNumber = 1, int pageSize = 10)
    {
        if (pageSize > maxFoodPageSize)
            pageSize = maxFoodPageSize;

        try
        {
            var foods = await nutritionService.SearchFoodsByName(name, pageNumber, pageSize);

            return Ok(foods);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"An exception occurred while retrieving food items with name {name}.", ex);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPost]
    public async Task CreateFood(Food food)
    {
        await nutritionService.Create(food);
    }
}